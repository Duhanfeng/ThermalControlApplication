namespace ThermalControlApplication
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series29 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series30 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series31 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series32 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ControlGroupBox = new System.Windows.Forms.GroupBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.Input0CheckBox = new System.Windows.Forms.CheckBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.Output0CheckBox = new System.Windows.Forms.CheckBox();
            this.Input4CheckBox = new System.Windows.Forms.CheckBox();
            this.Output4CheckBox = new System.Windows.Forms.CheckBox();
            this.Input3CheckBox = new System.Windows.Forms.CheckBox();
            this.Output3CheckBox = new System.Windows.Forms.CheckBox();
            this.Input2CheckBox = new System.Windows.Forms.CheckBox();
            this.Output2CheckBox = new System.Windows.Forms.CheckBox();
            this.Input1CheckBox = new System.Windows.Forms.CheckBox();
            this.Output1CheckBox = new System.Windows.Forms.CheckBox();
            this.PresetTemp2Button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PresetTemp2TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PresetTemp1Button = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.PresetTemp1TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CurrentTemp2TextBox = new System.Windows.Forms.TextBox();
            this.WorkStatusTextBox = new System.Windows.Forms.TextBox();
            this.CurrentTemp1TextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SerialComboBox = new System.Windows.Forms.ComboBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.UpdateSerialButton = new System.Windows.Forms.Button();
            this.PolingTimeTextBox = new System.Windows.Forms.TextBox();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.ControlGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 820);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1422, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(15);
            this.splitContainer1.Panel1MinSize = 350;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ControlGroupBox);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(15);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(1422, 820);
            this.splitContainer1.SplitterDistance = 1005;
            this.splitContainer1.SplitterWidth = 9;
            this.splitContainer1.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Name = "Legend1";
            this.chart1.Legends.Add(legend8);
            this.chart1.Location = new System.Drawing.Point(15, 15);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series29.ChartArea = "ChartArea1";
            series29.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series29.Legend = "Legend1";
            series29.Name = "温度1(预设)";
            series30.ChartArea = "ChartArea1";
            series30.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series30.Legend = "Legend1";
            series30.Name = "通道1(实际)";
            series31.ChartArea = "ChartArea1";
            series31.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series31.Legend = "Legend1";
            series31.Name = "温度2(预设)";
            series32.ChartArea = "ChartArea1";
            series32.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series32.Legend = "Legend1";
            series32.Name = "通道2(实际)";
            this.chart1.Series.Add(series29);
            this.chart1.Series.Add(series30);
            this.chart1.Series.Add(series31);
            this.chart1.Series.Add(series32);
            this.chart1.Size = new System.Drawing.Size(973, 788);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // ControlGroupBox
            // 
            this.ControlGroupBox.Controls.Add(this.StopButton);
            this.ControlGroupBox.Controls.Add(this.Input0CheckBox);
            this.ControlGroupBox.Controls.Add(this.StartButton);
            this.ControlGroupBox.Controls.Add(this.Output0CheckBox);
            this.ControlGroupBox.Controls.Add(this.Input4CheckBox);
            this.ControlGroupBox.Controls.Add(this.Output4CheckBox);
            this.ControlGroupBox.Controls.Add(this.Input3CheckBox);
            this.ControlGroupBox.Controls.Add(this.Output3CheckBox);
            this.ControlGroupBox.Controls.Add(this.Input2CheckBox);
            this.ControlGroupBox.Controls.Add(this.Output2CheckBox);
            this.ControlGroupBox.Controls.Add(this.Input1CheckBox);
            this.ControlGroupBox.Controls.Add(this.Output1CheckBox);
            this.ControlGroupBox.Controls.Add(this.PresetTemp2Button);
            this.ControlGroupBox.Controls.Add(this.label5);
            this.ControlGroupBox.Controls.Add(this.label4);
            this.ControlGroupBox.Controls.Add(this.label10);
            this.ControlGroupBox.Controls.Add(this.PresetTemp2TextBox);
            this.ControlGroupBox.Controls.Add(this.label3);
            this.ControlGroupBox.Controls.Add(this.label9);
            this.ControlGroupBox.Controls.Add(this.PresetTemp1Button);
            this.ControlGroupBox.Controls.Add(this.label7);
            this.ControlGroupBox.Controls.Add(this.PresetTemp1TextBox);
            this.ControlGroupBox.Controls.Add(this.label2);
            this.ControlGroupBox.Controls.Add(this.label8);
            this.ControlGroupBox.Controls.Add(this.CurrentTemp2TextBox);
            this.ControlGroupBox.Controls.Add(this.WorkStatusTextBox);
            this.ControlGroupBox.Controls.Add(this.CurrentTemp1TextBox);
            this.ControlGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlGroupBox.Location = new System.Drawing.Point(15, 186);
            this.ControlGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.ControlGroupBox.Name = "ControlGroupBox";
            this.ControlGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.ControlGroupBox.Size = new System.Drawing.Size(376, 579);
            this.ControlGroupBox.TabIndex = 2;
            this.ControlGroupBox.TabStop = false;
            this.ControlGroupBox.Text = "控制";
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(207, 520);
            this.StopButton.Margin = new System.Windows.Forms.Padding(4);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(112, 34);
            this.StopButton.TabIndex = 0;
            this.StopButton.Text = "停止";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // Input0CheckBox
            // 
            this.Input0CheckBox.AutoCheck = false;
            this.Input0CheckBox.AutoSize = true;
            this.Input0CheckBox.Location = new System.Drawing.Point(218, 332);
            this.Input0CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.Input0CheckBox.Name = "Input0CheckBox";
            this.Input0CheckBox.Size = new System.Drawing.Size(88, 22);
            this.Input0CheckBox.TabIndex = 7;
            this.Input0CheckBox.Tag = "0";
            this.Input0CheckBox.Text = "Input0";
            this.Input0CheckBox.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(63, 520);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(112, 34);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "启动";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // Output0CheckBox
            // 
            this.Output0CheckBox.AutoCheck = false;
            this.Output0CheckBox.AutoSize = true;
            this.Output0CheckBox.Location = new System.Drawing.Point(55, 332);
            this.Output0CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.Output0CheckBox.Name = "Output0CheckBox";
            this.Output0CheckBox.Size = new System.Drawing.Size(97, 22);
            this.Output0CheckBox.TabIndex = 7;
            this.Output0CheckBox.Tag = "0";
            this.Output0CheckBox.Text = "Output0";
            this.Output0CheckBox.UseVisualStyleBackColor = true;
            this.Output0CheckBox.Click += new System.EventHandler(this.OutputCheckBox_Click);
            // 
            // Input4CheckBox
            // 
            this.Input4CheckBox.AutoCheck = false;
            this.Input4CheckBox.AutoSize = true;
            this.Input4CheckBox.Location = new System.Drawing.Point(218, 460);
            this.Input4CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.Input4CheckBox.Name = "Input4CheckBox";
            this.Input4CheckBox.Size = new System.Drawing.Size(88, 22);
            this.Input4CheckBox.TabIndex = 7;
            this.Input4CheckBox.Tag = "4";
            this.Input4CheckBox.Text = "Input4";
            this.Input4CheckBox.UseVisualStyleBackColor = true;
            // 
            // Output4CheckBox
            // 
            this.Output4CheckBox.AutoCheck = false;
            this.Output4CheckBox.AutoSize = true;
            this.Output4CheckBox.Location = new System.Drawing.Point(55, 460);
            this.Output4CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.Output4CheckBox.Name = "Output4CheckBox";
            this.Output4CheckBox.Size = new System.Drawing.Size(97, 22);
            this.Output4CheckBox.TabIndex = 7;
            this.Output4CheckBox.Tag = "4";
            this.Output4CheckBox.Text = "Output4";
            this.Output4CheckBox.UseVisualStyleBackColor = true;
            this.Output4CheckBox.Click += new System.EventHandler(this.OutputCheckBox_Click);
            // 
            // Input3CheckBox
            // 
            this.Input3CheckBox.AutoCheck = false;
            this.Input3CheckBox.AutoSize = true;
            this.Input3CheckBox.Location = new System.Drawing.Point(218, 428);
            this.Input3CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.Input3CheckBox.Name = "Input3CheckBox";
            this.Input3CheckBox.Size = new System.Drawing.Size(88, 22);
            this.Input3CheckBox.TabIndex = 7;
            this.Input3CheckBox.Tag = "3";
            this.Input3CheckBox.Text = "Input3";
            this.Input3CheckBox.UseVisualStyleBackColor = true;
            // 
            // Output3CheckBox
            // 
            this.Output3CheckBox.AutoCheck = false;
            this.Output3CheckBox.AutoSize = true;
            this.Output3CheckBox.Location = new System.Drawing.Point(55, 428);
            this.Output3CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.Output3CheckBox.Name = "Output3CheckBox";
            this.Output3CheckBox.Size = new System.Drawing.Size(97, 22);
            this.Output3CheckBox.TabIndex = 7;
            this.Output3CheckBox.Tag = "3";
            this.Output3CheckBox.Text = "Output3";
            this.Output3CheckBox.UseVisualStyleBackColor = true;
            this.Output3CheckBox.Click += new System.EventHandler(this.OutputCheckBox_Click);
            // 
            // Input2CheckBox
            // 
            this.Input2CheckBox.AutoCheck = false;
            this.Input2CheckBox.AutoSize = true;
            this.Input2CheckBox.Location = new System.Drawing.Point(218, 396);
            this.Input2CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.Input2CheckBox.Name = "Input2CheckBox";
            this.Input2CheckBox.Size = new System.Drawing.Size(88, 22);
            this.Input2CheckBox.TabIndex = 7;
            this.Input2CheckBox.Tag = "2";
            this.Input2CheckBox.Text = "Input2";
            this.Input2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Output2CheckBox
            // 
            this.Output2CheckBox.AutoCheck = false;
            this.Output2CheckBox.AutoSize = true;
            this.Output2CheckBox.Location = new System.Drawing.Point(55, 396);
            this.Output2CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.Output2CheckBox.Name = "Output2CheckBox";
            this.Output2CheckBox.Size = new System.Drawing.Size(97, 22);
            this.Output2CheckBox.TabIndex = 7;
            this.Output2CheckBox.Tag = "2";
            this.Output2CheckBox.Text = "Output2";
            this.Output2CheckBox.UseVisualStyleBackColor = true;
            this.Output2CheckBox.Click += new System.EventHandler(this.OutputCheckBox_Click);
            // 
            // Input1CheckBox
            // 
            this.Input1CheckBox.AutoCheck = false;
            this.Input1CheckBox.AutoSize = true;
            this.Input1CheckBox.Location = new System.Drawing.Point(218, 364);
            this.Input1CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.Input1CheckBox.Name = "Input1CheckBox";
            this.Input1CheckBox.Size = new System.Drawing.Size(88, 22);
            this.Input1CheckBox.TabIndex = 6;
            this.Input1CheckBox.Tag = "1";
            this.Input1CheckBox.Text = "Input1";
            this.Input1CheckBox.UseVisualStyleBackColor = true;
            // 
            // Output1CheckBox
            // 
            this.Output1CheckBox.AutoCheck = false;
            this.Output1CheckBox.AutoSize = true;
            this.Output1CheckBox.Location = new System.Drawing.Point(55, 364);
            this.Output1CheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.Output1CheckBox.Name = "Output1CheckBox";
            this.Output1CheckBox.Size = new System.Drawing.Size(97, 22);
            this.Output1CheckBox.TabIndex = 6;
            this.Output1CheckBox.Tag = "1";
            this.Output1CheckBox.Text = "Output1";
            this.Output1CheckBox.UseVisualStyleBackColor = true;
            this.Output1CheckBox.Click += new System.EventHandler(this.OutputCheckBox_Click);
            // 
            // PresetTemp2Button
            // 
            this.PresetTemp2Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetTemp2Button.Location = new System.Drawing.Point(292, 150);
            this.PresetTemp2Button.Margin = new System.Windows.Forms.Padding(4);
            this.PresetTemp2Button.Name = "PresetTemp2Button";
            this.PresetTemp2Button.Size = new System.Drawing.Size(75, 34);
            this.PresetTemp2Button.TabIndex = 5;
            this.PresetTemp2Button.Text = "设置";
            this.PresetTemp2Button.UseVisualStyleBackColor = true;
            this.PresetTemp2Button.Click += new System.EventHandler(this.PresetTemp2Button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 296);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "输入IO(只读)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 296);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "输出IO(读/写)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 262);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "IO控制:";
            // 
            // PresetTemp2TextBox
            // 
            this.PresetTemp2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetTemp2TextBox.Location = new System.Drawing.Point(132, 152);
            this.PresetTemp2TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PresetTemp2TextBox.Name = "PresetTemp2TextBox";
            this.PresetTemp2TextBox.Size = new System.Drawing.Size(147, 28);
            this.PresetTemp2TextBox.TabIndex = 4;
            this.PresetTemp2TextBox.Text = "65";
            this.PresetTemp2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "温度2(预设)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 198);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "温度2(实际)";
            // 
            // PresetTemp1Button
            // 
            this.PresetTemp1Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetTemp1Button.Location = new System.Drawing.Point(292, 69);
            this.PresetTemp1Button.Margin = new System.Windows.Forms.Padding(4);
            this.PresetTemp1Button.Name = "PresetTemp1Button";
            this.PresetTemp1Button.Size = new System.Drawing.Size(75, 34);
            this.PresetTemp1Button.TabIndex = 2;
            this.PresetTemp1Button.Text = "设置";
            this.PresetTemp1Button.UseVisualStyleBackColor = true;
            this.PresetTemp1Button.Click += new System.EventHandler(this.PresetTemp1Button_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "工作状态";
            // 
            // PresetTemp1TextBox
            // 
            this.PresetTemp1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetTemp1TextBox.Location = new System.Drawing.Point(132, 70);
            this.PresetTemp1TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PresetTemp1TextBox.Name = "PresetTemp1TextBox";
            this.PresetTemp1TextBox.Size = new System.Drawing.Size(147, 28);
            this.PresetTemp1TextBox.TabIndex = 1;
            this.PresetTemp1TextBox.Text = "60";
            this.PresetTemp1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "温度1(预设)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 117);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "温度1(实际)";
            // 
            // CurrentTemp2TextBox
            // 
            this.CurrentTemp2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentTemp2TextBox.Location = new System.Drawing.Point(132, 192);
            this.CurrentTemp2TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CurrentTemp2TextBox.Name = "CurrentTemp2TextBox";
            this.CurrentTemp2TextBox.ReadOnly = true;
            this.CurrentTemp2TextBox.Size = new System.Drawing.Size(147, 28);
            this.CurrentTemp2TextBox.TabIndex = 4;
            this.CurrentTemp2TextBox.Text = "0";
            this.CurrentTemp2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // WorkStatusTextBox
            // 
            this.WorkStatusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkStatusTextBox.Location = new System.Drawing.Point(132, 30);
            this.WorkStatusTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.WorkStatusTextBox.Name = "WorkStatusTextBox";
            this.WorkStatusTextBox.ReadOnly = true;
            this.WorkStatusTextBox.Size = new System.Drawing.Size(147, 28);
            this.WorkStatusTextBox.TabIndex = 4;
            this.WorkStatusTextBox.Text = "就绪";
            this.WorkStatusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CurrentTemp1TextBox
            // 
            this.CurrentTemp1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentTemp1TextBox.Location = new System.Drawing.Point(132, 111);
            this.CurrentTemp1TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CurrentTemp1TextBox.Name = "CurrentTemp1TextBox";
            this.CurrentTemp1TextBox.ReadOnly = true;
            this.CurrentTemp1TextBox.Size = new System.Drawing.Size(147, 28);
            this.CurrentTemp1TextBox.TabIndex = 4;
            this.CurrentTemp1TextBox.Text = "0";
            this.CurrentTemp1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DisconnectButton);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SerialComboBox);
            this.groupBox1.Controls.Add(this.ConnectButton);
            this.groupBox1.Controls.Add(this.UpdateSerialButton);
            this.groupBox1.Controls.Add(this.PolingTimeTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(376, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通信";
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(207, 118);
            this.DisconnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(112, 34);
            this.DisconnectButton.TabIndex = 0;
            this.DisconnectButton.Text = "断开连接";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "轮询间隔(MS)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "通信串口";
            // 
            // SerialComboBox
            // 
            this.SerialComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SerialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialComboBox.FormattingEnabled = true;
            this.SerialComboBox.Location = new System.Drawing.Point(132, 30);
            this.SerialComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.SerialComboBox.Name = "SerialComboBox";
            this.SerialComboBox.Size = new System.Drawing.Size(147, 26);
            this.SerialComboBox.TabIndex = 0;
            this.SerialComboBox.SelectedIndexChanged += new System.EventHandler(this.SerialComboBox_SelectedIndexChanged);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(63, 118);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(112, 34);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "连接";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // UpdateSerialButton
            // 
            this.UpdateSerialButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateSerialButton.Location = new System.Drawing.Point(292, 30);
            this.UpdateSerialButton.Margin = new System.Windows.Forms.Padding(4);
            this.UpdateSerialButton.Name = "UpdateSerialButton";
            this.UpdateSerialButton.Size = new System.Drawing.Size(75, 34);
            this.UpdateSerialButton.TabIndex = 2;
            this.UpdateSerialButton.Text = "刷新";
            this.UpdateSerialButton.UseVisualStyleBackColor = true;
            this.UpdateSerialButton.Click += new System.EventHandler(this.UpdateSerialButton_Click);
            // 
            // PolingTimeTextBox
            // 
            this.PolingTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PolingTimeTextBox.Location = new System.Drawing.Point(132, 71);
            this.PolingTimeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PolingTimeTextBox.Name = "PolingTimeTextBox";
            this.PolingTimeTextBox.Size = new System.Drawing.Size(147, 28);
            this.PolingTimeTextBox.TabIndex = 1;
            this.PolingTimeTextBox.Text = "1000";
            this.PolingTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 1000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 842);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(1339, 722);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ControlGroupBox.ResumeLayout(false);
            this.ControlGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox ControlGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SerialComboBox;
        private System.Windows.Forms.Button PresetTemp2Button;
        private System.Windows.Forms.TextBox PresetTemp2TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button PresetTemp1Button;
        private System.Windows.Forms.TextBox PresetTemp1TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UpdateSerialButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox WorkStatusTextBox;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CurrentTemp2TextBox;
        private System.Windows.Forms.TextBox CurrentTemp1TextBox;
        private System.Windows.Forms.CheckBox Output0CheckBox;
        private System.Windows.Forms.CheckBox Output4CheckBox;
        private System.Windows.Forms.CheckBox Output3CheckBox;
        private System.Windows.Forms.CheckBox Output2CheckBox;
        private System.Windows.Forms.CheckBox Output1CheckBox;
        private System.Windows.Forms.CheckBox Input0CheckBox;
        private System.Windows.Forms.CheckBox Input4CheckBox;
        private System.Windows.Forms.CheckBox Input3CheckBox;
        private System.Windows.Forms.CheckBox Input2CheckBox;
        private System.Windows.Forms.CheckBox Input1CheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PolingTimeTextBox;
    }
}

