namespace Claymore_watcher
{
    partial class CmApiVisual
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.chartTotal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblGpuMhs = new System.Windows.Forms.Label();
            this.chartGpu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblGpuTempFan = new System.Windows.Forms.Label();
            this.lblUptime = new System.Windows.Forms.Label();
            this.lblErrAll = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName.Location = new System.Drawing.Point(2, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(112, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Connection name";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(3, 22);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(75, 13);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Ver: 0.0 - ETH";
            // 
            // chartTotal
            // 
            this.chartTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.AxisY.MaximumAutoSize = 7F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chartTotal.ChartAreas.Add(chartArea1);
            this.chartTotal.Location = new System.Drawing.Point(3, 89);
            this.chartTotal.Name = "chartTotal";
            this.chartTotal.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.CustomProperties = "IsXAxisQuantitative=False";
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            this.chartTotal.Series.Add(series1);
            this.chartTotal.Size = new System.Drawing.Size(650, 176);
            this.chartTotal.TabIndex = 2;
            this.chartTotal.Text = "chart1";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(2, 73);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(70, 13);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total: 0 MHS";
            // 
            // lblGpuMhs
            // 
            this.lblGpuMhs.AutoSize = true;
            this.lblGpuMhs.Location = new System.Drawing.Point(3, 269);
            this.lblGpuMhs.Name = "lblGpuMhs";
            this.lblGpuMhs.Size = new System.Drawing.Size(60, 13);
            this.lblGpuMhs.TabIndex = 4;
            this.lblGpuMhs.Text = "GPU MHS:";
            // 
            // chartGpu
            // 
            this.chartGpu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.MaximumAutoSize = 50F;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea2.AxisY.MaximumAutoSize = 7F;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            this.chartGpu.ChartAreas.Add(chartArea2);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartGpu.Legends.Add(legend1);
            this.chartGpu.Location = new System.Drawing.Point(3, 288);
            this.chartGpu.Name = "chartGpu";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartGpu.Series.Add(series2);
            this.chartGpu.Size = new System.Drawing.Size(650, 176);
            this.chartGpu.TabIndex = 5;
            this.chartGpu.Text = "chart1";
            // 
            // lblGpuTempFan
            // 
            this.lblGpuTempFan.AutoSize = true;
            this.lblGpuTempFan.Location = new System.Drawing.Point(6, 472);
            this.lblGpuTempFan.Name = "lblGpuTempFan";
            this.lblGpuTempFan.Size = new System.Drawing.Size(78, 13);
            this.lblGpuTempFan.TabIndex = 6;
            this.lblGpuTempFan.Text = "GPU TempFan";
            // 
            // lblUptime
            // 
            this.lblUptime.AutoSize = true;
            this.lblUptime.Location = new System.Drawing.Point(2, 39);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(73, 13);
            this.lblUptime.TabIndex = 7;
            this.lblUptime.Text = "Uptime: 0. 0:0";
            // 
            // lblErrAll
            // 
            this.lblErrAll.AutoSize = true;
            this.lblErrAll.Location = new System.Drawing.Point(3, 57);
            this.lblErrAll.Name = "lblErrAll";
            this.lblErrAll.Size = new System.Drawing.Size(60, 13);
            this.lblErrAll.TabIndex = 8;
            this.lblErrAll.Text = "Past errors:";
            // 
            // CmApiVisual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrAll);
            this.Controls.Add(this.lblUptime);
            this.Controls.Add(this.lblGpuTempFan);
            this.Controls.Add(this.chartGpu);
            this.Controls.Add(this.lblGpuMhs);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.chartTotal);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblName);
            this.MinimumSize = new System.Drawing.Size(659, 471);
            this.Name = "CmApiVisual";
            this.Size = new System.Drawing.Size(659, 493);
            ((System.ComponentModel.ISupportInitialize)(this.chartTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblGpuMhs;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGpu;
        private System.Windows.Forms.Label lblGpuTempFan;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Label lblErrAll;
    }
}
