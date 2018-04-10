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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            chartArea5.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea5.AxisY.MaximumAutoSize = 7F;
            chartArea5.Name = "ChartArea1";
            chartArea5.Position.Auto = false;
            chartArea5.Position.Height = 100F;
            chartArea5.Position.Width = 100F;
            this.chartTotal.ChartAreas.Add(chartArea5);
            this.chartTotal.Location = new System.Drawing.Point(3, 89);
            this.chartTotal.Name = "chartTotal";
            this.chartTotal.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.CustomProperties = "IsXAxisQuantitative=False";
            series5.IsVisibleInLegend = false;
            series5.Name = "Series1";
            this.chartTotal.Series.Add(series5);
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
            chartArea6.AxisX.MaximumAutoSize = 50F;
            chartArea6.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea6.AxisY.MaximumAutoSize = 7F;
            chartArea6.Name = "ChartArea1";
            chartArea6.Position.Auto = false;
            chartArea6.Position.Height = 100F;
            chartArea6.Position.Width = 100F;
            this.chartGpu.ChartAreas.Add(chartArea6);
            legend3.Alignment = System.Drawing.StringAlignment.Far;
            legend3.DockedToChartArea = "ChartArea1";
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            legend3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.chartGpu.Legends.Add(legend3);
            this.chartGpu.Location = new System.Drawing.Point(3, 288);
            this.chartGpu.Name = "chartGpu";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartGpu.Series.Add(series6);
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
