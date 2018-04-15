using Claymore_miner_watcher.Properties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Claymore_watcher
{
    public partial class Form1 : Form
    {
        CmApi[] cmApis;
        bool isInited = false;
        List<string> urlList = new List<string>();
        bool chkReenable = false;


        public Form1()
        {
            InitializeComponent();
            isInited = false;
            LoadUrls();
            tbUpdateIntervall.Value = Settings.Default.updateIntSec;
        }


        private void LoadUrls()
        {
            string tmp = Settings.Default.urls;
            string[] tmparr = tmp.Split('|');
            urlList.Clear();
            isInited = false;
            cmApis = null;
            foreach (string t in tmparr)
            {
                if (t.LastIndexOf(":") > 0)
                {
                    urlList.Add(t);
                }
            }
            DrawListBox();
        }

        private void SaveUrls() { SaveUrls(""); }
        private void SaveUrls(string except)
        {
            string ret = "";
            foreach (string t in urlList)
            {
                if (t.Equals(except)) continue;
                ret += t + "|";
            }
            Settings.Default.urls = ret;
            Settings.Default.Save();
        }

        private void Init()
        {
            LoadUrls();
            int urlListNum = (urlList == null) ? 0 : urlList.Count;
            if (urlListNum == 0) return; //not yet set up
            cmApis = new CmApi[urlListNum];
            for(int i = 0; i<cmApis.Length; ++i)
            {
                cmApis[i] = new CmApi(urlList[i]);
            }
            isInited = true;
        }


        private async Task Query()
        {
            if (isInited == false) Init();
            if (isInited == false) return; //can't init yet.
            for (int i = 0; i < cmApis.Length; ++i)
            {
                cmApis[i].Update();
            }
            Draw();
        }

        private void Draw()
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke((MethodInvoker)(() => { Draw(); }));
                return;
            }
            if (cmApis == null) return;
            
            int i = listBox1.SelectedIndex;
            if (i == -1) i = 0;
            if (cmApis[i] == null) return;
            txtSumm.Text = cmApis[i].ToString();
            cmApiVisual1.ShowCMApi(cmApis[i]);
        }

        private void DrawListBox()
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke((MethodInvoker)(() => { DrawListBox(); }));
                return;
            }
            listBox1.Items.Clear();
            foreach (string t in urlList) { listBox1.Items.Add(t); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReenable && chkAuto.Checked)
            {
                chkAuto.Checked = false;
                timer1.Enabled = false;
                return; //already running, don't enable it, to start twice
            }
            if (chkAuto.Checked)
            {
                //was not checked, just checked it. fire an update, and after the update process the timer will be enabled, so i don't have to enable it right here.
                Timer1_TickAsync(null, null); 
                return;
            }
            timer1.Enabled = chkAuto.Checked;
            
        }

        private async void Timer1_TickAsync(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            chkReenable = true;
            await Task.Run(() => Query());
            timer1.Enabled = chkAuto.Checked; //if during it it was disabled, let it be disabled
            chkReenable = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDialog dlg = new AddDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                urlList.Add(dlg.result);
                SaveUrls(); //to save
                Init(); //to redraw + reapply
            }
        }

        private void btnClearErr_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i == -1) i = 0;
            if (cmApis == null || cmApis.Length < i) return;
            cmApis[i].ReserAllErrorMask();
            Draw();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i == -1) return;
            string wtd = (string)listBox1.SelectedItem;
            wtd = wtd.Replace("!", "").Trim(); //remove the alert sign.
            SaveUrls(wtd);
            Init();
        }

        private void tbUpdateIntervall_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = tbUpdateIntervall.Value * 1000;
            lblUpdateInterval.Text = tbUpdateIntervall.Value.ToString() + " sec / update";
            Settings.Default.updateIntSec = tbUpdateIntervall.Value;
            Settings.Default.Save();
        }

    }
}
