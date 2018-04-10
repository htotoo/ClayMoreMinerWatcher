using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;


namespace Claymore_watcher
{
    public class CmApi
    {
        public const int HIST_MAX_NUM = 100; //LastNDatas

        public const int CMAPI_ERR_CONNECTION_ERR = 1;
        public const int CMAPI_ERR_REPLY_ERR = 2;
        public const int CMAPI_ERR_HIGHTEMP = 4;
        public const int CMAPI_ERR_LOWHASH = 8;
        public const int CMAPI_ERR_FLUCTUATINGHASH = 16; //NIY
        public const int CMAPI_ERR_INVALIDSHARES = 32;
        public const int CMAPI_ERR_RUNTIMEDECREASED = 64;


        public CmApi() { }
        public CmApi(string hostAndPort) { SetConnection(hostAndPort); }
        private string host = "";
        private int port = 0;
        public void SetHost( string newHost) { host = newHost; }
        public string GetHost() { return host; }
        public void SetPort(int newPort) { port = newPort; }
        public int GetPort() { return port; }
        public string GetConnectionName()
        {
            return host + ":" + port.ToString();
        }
        public bool SetConnection(string hostandport)
        {
            int o = hostandport.LastIndexOf(":");
            if (o <= 0) return false;
            if (o >= hostandport.Length - 1) return false;
            host = hostandport.Substring(0, o);
            string portStr = hostandport.Substring(o + 1);
            return int.TryParse(portStr, out port);
        }

        private string version = "0.0";
        public string GetVersion() { return version;  }

        private int gpuNum = 0;
        public int GetGpuNum() { return gpuNum;  }

        private long uptime = 0;
        private long lastUptime = 0; //for miner restart watch
        public long GetUptime() { return uptime; }
        public string GetUptimeStr()
        {
            long tmp = uptime;
            int days = (int) (tmp / 60 / 24);
            tmp -= days * 60 * 24;
            int hours = (int) (tmp / 60);
            tmp -= hours * 60;
            //tmp = remaining minutes
            return days.ToString() + "d " + hours.ToString() + ":" + tmp.ToString();
        }

        private long totalMhs = 0;
        public long GetTotalMhs() { return totalMhs; }
        public string GetMhsStr(long mhs)
        {
            return (((int)(mhs / 100)) / 10.0).ToString() +" MHS";
        }

        private long sharesGood = 0;
        private long sharesBad = 0;
        public long GetSharesGood() { return sharesGood; }
        public long GetSharesBad() { return sharesBad; }

        private List<CmApiGpuDataHolder> gpuDatas = new List<CmApiGpuDataHolder>();
        private void InsertGpuHistoryData(CmApiGpuDataHolder data)
        {
            gpuDatas.Add(data);
            while (gpuDatas.Count > HIST_MAX_NUM) gpuDatas.RemoveAt(0);
        }
        public List<CmApiGpuDataHolder> GetGpuDatasHistory() { return gpuDatas; }

        private List<long> totalMhsHistory = new List<long>();
        private void InsertTotalMhsHistoryData(long mhs)
        {
            totalMhsHistory.Add(mhs);
            while (totalMhsHistory.Count > HIST_MAX_NUM) totalMhsHistory.RemoveAt(0);
        }
        public List<long> GetTotalMhsHist() { return totalMhsHistory; }

        public long[] GetMhsGpu() { return gpuDatas.Last().mhsGpu; }
        public int[] GetTempGpu() { return gpuDatas.Last().tempGpu; }
        public int[] GetFanGpu() { return gpuDatas.Last().fanGpu; }


        private string pool = "";
        public string GetPool() { return pool; }


        private int lastErrorMask = 0;
        private int allErrorMask = 0;
        public int GetLastErrorMask() { return lastErrorMask; }
        public int GetAllErrorMask() { return allErrorMask; }
        public void ReserAllErrorMask() { allErrorMask = 0; }

        private TcpClient client = null;

        public bool Update()
        {
            lastErrorMask = 0;
            String retStr = "";
            try
            {
                client = new TcpClient(host, port);
                NetworkStream networkStream = client.GetStream();
                String request = "{\"id\":0,\"jsonrpc\":\"2.0\",\"method\":\"miner_getstat1\"}";
                networkStream.Write(Encoding.ASCII.GetBytes(request), 0, request.Length);
                while (networkStream.CanRead)
                {
                    byte[] retArr = new byte[10000];
                    int len = networkStream.Read(retArr, 0, retArr.Length);
                    retStr += Encoding.UTF8.GetString(retArr, 0, len);
                    if (retStr.Contains("}"))
                    {
                        networkStream.Close();
                        client.Close();
                    }
                }
            }
            catch ( Exception e) { lastErrorMask |= CMAPI_ERR_CONNECTION_ERR; allErrorMask |= lastErrorMask; return false; }
            Console.WriteLine(retStr);
            try
            {
                JObject json = JObject.Parse(retStr);
                if (!json.ContainsKey("result"))
                {
                    lastErrorMask |= CMAPI_ERR_REPLY_ERR;
                    return false;
                }
                JArray jArray = (JArray)json["result"];
                if (jArray.Count < 5) return false;
                version = (string)jArray.ElementAt(0); //version

                string tmp = (string)jArray.ElementAt(1); //runtime in minutes
                long.TryParse(tmp, out uptime);

                tmp = (string)jArray.ElementAt(2);//total ETH hashrate in MH/s, number of ETH shares, number of ETH rejected shares.
                string[] tmpSArr = tmp.Split(';');
                if (tmpSArr.Length >= 3)
                {
                    long.TryParse(tmpSArr[0], out totalMhs);
                    long.TryParse(tmpSArr[1], out sharesGood);
                    long.TryParse(tmpSArr[2], out sharesBad);
                }

                tmp = (string)jArray.ElementAt(3); //detailed ETH hashrate for all GPUs.
                tmpSArr = tmp.Split(';');
                gpuNum = 0;
                long[] mhsGpu = new long[tmpSArr.Length];
                int[] tempGpu = new int[tmpSArr.Length];
                int[] fanGpu = new int[tmpSArr.Length];
                foreach (string t in tmpSArr)
                {
                    long.TryParse(t, out mhsGpu[gpuNum]);
                    gpuNum++;
                }

                tmp = (string)jArray.ElementAt(6); //Temperature and Fan speed(%) pairs for all GPUs.
                tmpSArr = tmp.Split(';');
                for (int i = 0; i < gpuNum; ++i)
                {
                    int.TryParse(tmpSArr[i * 2], out tempGpu[i]);
                    int.TryParse(tmpSArr[i * 2 + 1], out fanGpu[i]);
                }
                //Add the arrays to the history
                CmApiGpuDataHolder cmApiGpuData = new CmApiGpuDataHolder();
                cmApiGpuData.fanGpu = fanGpu;
                cmApiGpuData.mhsGpu = mhsGpu;
                cmApiGpuData.tempGpu = tempGpu;
                InsertGpuHistoryData(cmApiGpuData);
                InsertTotalMhsHistoryData(totalMhs); //insert it here too

                pool = (string)jArray.ElementAt(7); //current mining pool.For dual mode, there will be two pools here.
            }
            catch ( Exception e)
            {
                lastErrorMask |= CMAPI_ERR_REPLY_ERR;
                allErrorMask |= lastErrorMask;
                return false;
            }
            CheckForErrors();
            return true;
        }

        private void CheckForErrors()
        {
            //Check for hihg temperature
            foreach( int temp in gpuDatas.Last().tempGpu)
            {
                if (temp >= 90) lastErrorMask |= CMAPI_ERR_HIGHTEMP;
            }
            //Check for low hashrate <2;eg crashed gpu shows 0.
            foreach (long mhs in gpuDatas.Last().mhsGpu)
            {
                if (mhs <= 2) lastErrorMask |= CMAPI_ERR_LOWHASH;
            }
            //check for invalid shares. >0 -> error
            if (sharesBad > 0) lastErrorMask |= CMAPI_ERR_INVALIDSHARES;
            //Check for miner restarts
            if (lastUptime > uptime) lastErrorMask |= CMAPI_ERR_RUNTIMEDECREASED;
            lastUptime = uptime;
            //check for fluctuation
            if (totalMhsHistory.Count > 10)
            {
                double avg = totalMhsHistory.Skip(totalMhsHistory.Count-10).Average();
                double delta = totalMhs / avg;
                if ( delta < 0.96 || delta> 1.04)
                {
                    lastErrorMask |= CMAPI_ERR_FLUCTUATINGHASH;
                }
            }
            allErrorMask |= lastErrorMask;
        }

        public string GetGpuMhsesStr()
        {
            string ret = "GPU MHS: ";
            for (int i = 0; i < gpuNum; ++i)
            {
                ret += "(" + i.ToString() + "): " + GetMhsStr(gpuDatas.Last().mhsGpu[i]) + "  ";
            }
            return ret;
        }
        public string GetGpuTempFanStr()
        {
            string ret = "GPU T+F:  ";
            for (int i = 0; i < gpuNum; ++i)
            {
                ret += "(" + i.ToString() + "): " + gpuDatas.Last().tempGpu[i].ToString() + "°C, " + gpuDatas.Last().fanGpu[i].ToString() + "%   ";
            }
            return ret;
        }

        public string GetErrorToStr(int mask)
        {
            string ret = "";
            if ((mask & CMAPI_ERR_CONNECTION_ERR) == CMAPI_ERR_CONNECTION_ERR) ret += "Connection error. ";
            if ((mask & CMAPI_ERR_REPLY_ERR) == CMAPI_ERR_REPLY_ERR) ret += "Got unknown reply from miner. ";
            if ((mask & CMAPI_ERR_HIGHTEMP) == CMAPI_ERR_HIGHTEMP) ret += "GPU with high temperature. ";
            if ((mask & CMAPI_ERR_INVALIDSHARES) == CMAPI_ERR_INVALIDSHARES) ret += "Got invalid shares. ";
            if ((mask & CMAPI_ERR_LOWHASH) == CMAPI_ERR_LOWHASH) ret += "Got crashed GPU. ";
            if ((mask & CMAPI_ERR_RUNTIMEDECREASED) == CMAPI_ERR_RUNTIMEDECREASED) ret += "Miner restarted. ";
            if ((mask & CMAPI_ERR_FLUCTUATINGHASH) == CMAPI_ERR_FLUCTUATINGHASH) ret += "Hashrate fluctuating. ";
            if (ret.Length == 0) ret = "-";
            return ret;
        }

        public override string ToString()
        {
            if (gpuNum <= 0) return "Not yet loaded.";
            string ret = GetConnectionName() + Environment.NewLine;
            ret += "Ver: " + version + Environment.NewLine;
            ret += "Uptime: " + GetUptimeStr()+ Environment.NewLine;
            ret += "Errors: " + GetErrorToStr(lastErrorMask) + Environment.NewLine;
            ret += "ALL Errors: " + GetErrorToStr(allErrorMask) +  Environment.NewLine;
            ret += "Pool: " + pool + Environment.NewLine;
            ret += "Total: " + GetMhsStr(totalMhs) + Environment.NewLine;
            ret += "Shares / Invalid: " + sharesGood.ToString() + " / " + sharesBad.ToString() + Environment.NewLine;
            ret += GetGpuMhsesStr() + Environment.NewLine;
            ret += GetGpuTempFanStr() + Environment.NewLine;
            ret += "---------------------" + Environment.NewLine + Environment.NewLine;
            return ret;
        }


    }
}
