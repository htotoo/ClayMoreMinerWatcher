using System.Linq;
using System.Windows.Forms;

namespace Claymore_watcher
{
    public partial class CmApiVisual : UserControl
    {
        public CmApiVisual()
        {
            InitializeComponent();
        }

        public void ShowCMApi(CmApi cm)
        {
            lblName.Text = cm.GetConnectionName();
            lblVersion.Text = "Ver: " + cm.GetVersion() + "  Pool: " + cm.GetPool();
            lblUptime.Text = "Uptime: " + cm.GetUptimeStr() + "  Errors: " + cm.GetErrorToStr(cm.GetLastErrorMask());
            lblErrAll.Text = "Past Errors: " + cm.GetErrorToStr(cm.GetAllErrorMask());
            lblTotal.Text = "Total: " + cm.GetMhsStr(cm.GetTotalMhs());
            lblGpuMhs.Text = cm.GetGpuMhsesStr();
            lblGpuTempFan.Text = cm.GetGpuTempFanStr();
            chartTotal.Series.Clear();
            chartGpu.Series.Clear();
            if (cm.GetTotalMhsHist().Count <= 1)
            {
                return;//no data yet
            }
            //Graphs
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.BorderWidth = 3;
            series1.IsVisibleInLegend = false;
            series1.IsXValueIndexed = false;
            int i = 0;
            foreach (long tmp in cm.GetTotalMhsHist())
            {
                series1.Points.AddXY(i, tmp / 1000.0f);
                ++i;
            }

            chartTotal.Series.Add(series1);

            chartTotal.ChartAreas[0].AxisY.Minimum = cm.GetTotalMhsHist().Min() * 0.95 / 1000.0;
            chartTotal.ChartAreas[0].AxisY.Maximum = cm.GetTotalMhsHist().Max() * 1.05 / 1000.0;
            chartTotal.ChartAreas[0].AxisX.Minimum = 0;
            chartTotal.ChartAreas[0].AxisX.Maximum = CmApi.HIST_MAX_NUM;

            chartTotal.ChartAreas[0].AxisY.LabelStyle.Format = "######.#";

            //Per GPU datas
            int gpuNum = cm.GetGpuNum();
            chartGpu.Series.Clear();
            System.Windows.Forms.DataVisualization.Charting.Series[] series = new System.Windows.Forms.DataVisualization.Charting.Series[gpuNum];
            for(i=0; i< gpuNum; ++i)
            {
                series[i] = new System.Windows.Forms.DataVisualization.Charting.Series();
                series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                series[i].BorderWidth = 2;
                series[i].IsVisibleInLegend = true;
                series[i].IsXValueIndexed = false;
                series[i].Name = "GPU " + i.ToString();
            }
            float minValue = 9999999999;
            float maxValue = 0;
            float mhsToAdd = 0;
            foreach (CmApiGpuDataHolder tmp in cm.GetGpuDatasHistory())
            {
                for (i = 0; i < gpuNum; ++i)
                {
                    mhsToAdd = 0;
                    if (tmp.mhsGpu.Length == gpuNum) //if there is not enough gpu, show there is an error.
                    {
                        mhsToAdd = tmp.mhsGpu[i] / 1000.0f;
                    }
                    series[i].Points.Add(mhsToAdd);
                    if (minValue > mhsToAdd) minValue = mhsToAdd;
                    if (maxValue < mhsToAdd) maxValue = mhsToAdd;
                }
            }
            
            for (i = 0; i < gpuNum; ++i)
            {
                chartGpu.Series.Add(series[i]);
            }
            chartGpu.ChartAreas[0].AxisY.LabelStyle.Format = "######.#";
            chartGpu.ChartAreas[0].AxisY.Minimum = minValue * 0.95;
            chartGpu.ChartAreas[0].AxisY.Maximum = maxValue * 1.05;
            chartGpu.ChartAreas[0].AxisX.Minimum = 0;
            chartGpu.ChartAreas[0].AxisX.Maximum = CmApi.HIST_MAX_NUM;
        }
    }
}
