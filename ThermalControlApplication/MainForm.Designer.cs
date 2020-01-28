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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ControlGroupBox = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Input0CheckBox = new System.Windows.Forms.CheckBox();
            this.Output0CheckBox = new System.Windows.Forms.CheckBox();
            this.Input4CheckBox = new System.Windows.Forms.CheckBox();
            this.Output4CheckBox = new System.Windows.Forms.CheckBox();
            this.Input3CheckBox = new System.Windows.Forms.CheckBox();
            this.Output3CheckBox = new System.Windows.Forms.CheckBox();
            this.Input2CheckBox = new System.Windows.Forms.CheckBox();
            this.Output2CheckBox = new System.Windows.Forms.CheckBox();
            this.Input1CheckBox = new System.Windows.Forms.CheckBox();
            this.Output1CheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.OneStepPanel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.PresetTemp1TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PresetTemp1Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PresetTemp2TextBox = new System.Windows.Forms.TextBox();
            this.PresetTemp2Button = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SerialComboBox = new System.Windows.Forms.ComboBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.UpdateSerialButton = new System.Windows.Forms.Button();
            this.PolingTimeTextBox = new System.Windows.Forms.TextBox();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.UpdateDateTimer = new System.Windows.Forms.Timer(this.components);
            this.MultiStepSettingButton = new System.Windows.Forms.Button();
            this.WorkStatusTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.OneStepRadioButton = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.MultiStepRadioButton = new System.Windows.Forms.RadioButton();
            this.CurrentTemp1TextBox = new System.Windows.Forms.TextBox();
            this.CurrentTemp2TextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.ControlGroupBox.SuspendLayout();
            this.panel3.SuspendLayout();
            this.OneStepPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimeLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 619);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TimeLabel
            // 
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(29, 17);
            this.TimeLabel.Text = "123";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Panel1MinSize = 350;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ControlGroupBox);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Panel2MinSize = 260;
            this.splitContainer1.Size = new System.Drawing.Size(984, 619);
            this.splitContainer1.SplitterDistance = 715;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(10, 10);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "温度1(预设)";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "通道1(实际)";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "温度2(预设)";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "通道2(实际)";
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(693, 597);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // ControlGroupBox
            // 
            this.ControlGroupBox.Controls.Add(this.panel3);
            this.ControlGroupBox.Controls.Add(this.panel2);
            this.ControlGroupBox.Controls.Add(this.OneStepPanel);
            this.ControlGroupBox.Controls.Add(this.StopButton);
            this.ControlGroupBox.Controls.Add(this.StartButton);
            this.ControlGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlGroupBox.Location = new System.Drawing.Point(10, 124);
            this.ControlGroupBox.Name = "ControlGroupBox";
            this.ControlGroupBox.Size = new System.Drawing.Size(241, 483);
            this.ControlGroupBox.TabIndex = 2;
            this.ControlGroupBox.TabStop = false;
            this.ControlGroupBox.Text = "控制";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.Input0CheckBox);
            this.panel3.Controls.Add(this.Output0CheckBox);
            this.panel3.Controls.Add(this.Input4CheckBox);
            this.panel3.Controls.Add(this.Output4CheckBox);
            this.panel3.Controls.Add(this.Input3CheckBox);
            this.panel3.Controls.Add(this.Output3CheckBox);
            this.panel3.Controls.Add(this.Input2CheckBox);
            this.panel3.Controls.Add(this.Output2CheckBox);
            this.panel3.Controls.Add(this.Input1CheckBox);
            this.panel3.Controls.Add(this.Output1CheckBox);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(3, 276);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 171);
            this.panel3.TabIndex = 10;
            // 
            // Input0CheckBox
            // 
            this.Input0CheckBox.AutoCheck = false;
            this.Input0CheckBox.AutoSize = true;
            this.Input0CheckBox.Location = new System.Drawing.Point(139, 57);
            this.Input0CheckBox.Name = "Input0CheckBox";
            this.Input0CheckBox.Size = new System.Drawing.Size(60, 16);
            this.Input0CheckBox.TabIndex = 13;
            this.Input0CheckBox.Tag = "0";
            this.Input0CheckBox.Text = "Input0";
            this.Input0CheckBox.UseVisualStyleBackColor = true;
            // 
            // Output0CheckBox
            // 
            this.Output0CheckBox.AutoCheck = false;
            this.Output0CheckBox.AutoSize = true;
            this.Output0CheckBox.Location = new System.Drawing.Point(31, 57);
            this.Output0CheckBox.Name = "Output0CheckBox";
            this.Output0CheckBox.Size = new System.Drawing.Size(66, 16);
            this.Output0CheckBox.TabIndex = 14;
            this.Output0CheckBox.Tag = "0";
            this.Output0CheckBox.Text = "Output0";
            this.Output0CheckBox.UseVisualStyleBackColor = true;
            // 
            // Input4CheckBox
            // 
            this.Input4CheckBox.AutoCheck = false;
            this.Input4CheckBox.AutoSize = true;
            this.Input4CheckBox.Location = new System.Drawing.Point(139, 143);
            this.Input4CheckBox.Name = "Input4CheckBox";
            this.Input4CheckBox.Size = new System.Drawing.Size(60, 16);
            this.Input4CheckBox.TabIndex = 15;
            this.Input4CheckBox.Tag = "4";
            this.Input4CheckBox.Text = "Input4";
            this.Input4CheckBox.UseVisualStyleBackColor = true;
            // 
            // Output4CheckBox
            // 
            this.Output4CheckBox.AutoCheck = false;
            this.Output4CheckBox.AutoSize = true;
            this.Output4CheckBox.Location = new System.Drawing.Point(31, 143);
            this.Output4CheckBox.Name = "Output4CheckBox";
            this.Output4CheckBox.Size = new System.Drawing.Size(66, 16);
            this.Output4CheckBox.TabIndex = 16;
            this.Output4CheckBox.Tag = "4";
            this.Output4CheckBox.Text = "Output4";
            this.Output4CheckBox.UseVisualStyleBackColor = true;
            // 
            // Input3CheckBox
            // 
            this.Input3CheckBox.AutoCheck = false;
            this.Input3CheckBox.AutoSize = true;
            this.Input3CheckBox.Location = new System.Drawing.Point(139, 121);
            this.Input3CheckBox.Name = "Input3CheckBox";
            this.Input3CheckBox.Size = new System.Drawing.Size(60, 16);
            this.Input3CheckBox.TabIndex = 17;
            this.Input3CheckBox.Tag = "3";
            this.Input3CheckBox.Text = "Input3";
            this.Input3CheckBox.UseVisualStyleBackColor = true;
            // 
            // Output3CheckBox
            // 
            this.Output3CheckBox.AutoCheck = false;
            this.Output3CheckBox.AutoSize = true;
            this.Output3CheckBox.Location = new System.Drawing.Point(31, 121);
            this.Output3CheckBox.Name = "Output3CheckBox";
            this.Output3CheckBox.Size = new System.Drawing.Size(66, 16);
            this.Output3CheckBox.TabIndex = 18;
            this.Output3CheckBox.Tag = "3";
            this.Output3CheckBox.Text = "Output3";
            this.Output3CheckBox.UseVisualStyleBackColor = true;
            // 
            // Input2CheckBox
            // 
            this.Input2CheckBox.AutoCheck = false;
            this.Input2CheckBox.AutoSize = true;
            this.Input2CheckBox.Location = new System.Drawing.Point(139, 100);
            this.Input2CheckBox.Name = "Input2CheckBox";
            this.Input2CheckBox.Size = new System.Drawing.Size(60, 16);
            this.Input2CheckBox.TabIndex = 19;
            this.Input2CheckBox.Tag = "2";
            this.Input2CheckBox.Text = "Input2";
            this.Input2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Output2CheckBox
            // 
            this.Output2CheckBox.AutoCheck = false;
            this.Output2CheckBox.AutoSize = true;
            this.Output2CheckBox.Location = new System.Drawing.Point(31, 100);
            this.Output2CheckBox.Name = "Output2CheckBox";
            this.Output2CheckBox.Size = new System.Drawing.Size(66, 16);
            this.Output2CheckBox.TabIndex = 20;
            this.Output2CheckBox.Tag = "2";
            this.Output2CheckBox.Text = "Output2";
            this.Output2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Input1CheckBox
            // 
            this.Input1CheckBox.AutoCheck = false;
            this.Input1CheckBox.AutoSize = true;
            this.Input1CheckBox.Location = new System.Drawing.Point(139, 79);
            this.Input1CheckBox.Name = "Input1CheckBox";
            this.Input1CheckBox.Size = new System.Drawing.Size(60, 16);
            this.Input1CheckBox.TabIndex = 11;
            this.Input1CheckBox.Tag = "1";
            this.Input1CheckBox.Text = "Input1";
            this.Input1CheckBox.UseVisualStyleBackColor = true;
            // 
            // Output1CheckBox
            // 
            this.Output1CheckBox.AutoCheck = false;
            this.Output1CheckBox.AutoSize = true;
            this.Output1CheckBox.Location = new System.Drawing.Point(31, 79);
            this.Output1CheckBox.Name = "Output1CheckBox";
            this.Output1CheckBox.Size = new System.Drawing.Size(66, 16);
            this.Output1CheckBox.TabIndex = 12;
            this.Output1CheckBox.Tag = "1";
            this.Output1CheckBox.Text = "Output1";
            this.Output1CheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "输入IO(只读)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "输出IO(读/写)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "IO控制:";
            // 
            // OneStepPanel
            // 
            this.OneStepPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OneStepPanel.Controls.Add(this.label12);
            this.OneStepPanel.Controls.Add(this.PresetTemp1TextBox);
            this.OneStepPanel.Controls.Add(this.label2);
            this.OneStepPanel.Controls.Add(this.PresetTemp1Button);
            this.OneStepPanel.Controls.Add(this.label3);
            this.OneStepPanel.Controls.Add(this.PresetTemp2TextBox);
            this.OneStepPanel.Controls.Add(this.PresetTemp2Button);
            this.OneStepPanel.Location = new System.Drawing.Point(3, 172);
            this.OneStepPanel.Name = "OneStepPanel";
            this.OneStepPanel.Size = new System.Drawing.Size(232, 98);
            this.OneStepPanel.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(0, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "单段模式设置:";
            // 
            // PresetTemp1TextBox
            // 
            this.PresetTemp1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetTemp1TextBox.Location = new System.Drawing.Point(88, 36);
            this.PresetTemp1TextBox.Name = "PresetTemp1TextBox";
            this.PresetTemp1TextBox.Size = new System.Drawing.Size(86, 21);
            this.PresetTemp1TextBox.TabIndex = 1;
            this.PresetTemp1TextBox.Text = "60";
            this.PresetTemp1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "温度1(预设)";
            // 
            // PresetTemp1Button
            // 
            this.PresetTemp1Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetTemp1Button.Location = new System.Drawing.Point(179, 35);
            this.PresetTemp1Button.Name = "PresetTemp1Button";
            this.PresetTemp1Button.Size = new System.Drawing.Size(50, 23);
            this.PresetTemp1Button.TabIndex = 2;
            this.PresetTemp1Button.Text = "设置";
            this.PresetTemp1Button.UseVisualStyleBackColor = true;
            this.PresetTemp1Button.Click += new System.EventHandler(this.PresetTemp1Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "温度2(预设)";
            // 
            // PresetTemp2TextBox
            // 
            this.PresetTemp2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetTemp2TextBox.Location = new System.Drawing.Point(88, 65);
            this.PresetTemp2TextBox.Name = "PresetTemp2TextBox";
            this.PresetTemp2TextBox.Size = new System.Drawing.Size(86, 21);
            this.PresetTemp2TextBox.TabIndex = 4;
            this.PresetTemp2TextBox.Text = "65";
            this.PresetTemp2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PresetTemp2Button
            // 
            this.PresetTemp2Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetTemp2Button.Location = new System.Drawing.Point(179, 64);
            this.PresetTemp2Button.Name = "PresetTemp2Button";
            this.PresetTemp2Button.Size = new System.Drawing.Size(50, 23);
            this.PresetTemp2Button.TabIndex = 5;
            this.PresetTemp2Button.Text = "设置";
            this.PresetTemp2Button.UseVisualStyleBackColor = true;
            this.PresetTemp2Button.Click += new System.EventHandler(this.PresetTemp2Button_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(138, 453);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 0;
            this.StopButton.Text = "停止";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(42, 453);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "启动";
            this.StartButton.UseVisualStyleBackColor = true;
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
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通信";
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(138, 79);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButton.TabIndex = 0;
            this.DisconnectButton.Text = "断开连接";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "轮询间隔(MS)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "通信串口";
            // 
            // SerialComboBox
            // 
            this.SerialComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SerialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialComboBox.FormattingEnabled = true;
            this.SerialComboBox.Location = new System.Drawing.Point(88, 20);
            this.SerialComboBox.Name = "SerialComboBox";
            this.SerialComboBox.Size = new System.Drawing.Size(89, 20);
            this.SerialComboBox.TabIndex = 0;
            this.SerialComboBox.SelectedIndexChanged += new System.EventHandler(this.SerialComboBox_SelectedIndexChanged);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(42, 79);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "连接";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // UpdateSerialButton
            // 
            this.UpdateSerialButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateSerialButton.Location = new System.Drawing.Point(353, 20);
            this.UpdateSerialButton.Name = "UpdateSerialButton";
            this.UpdateSerialButton.Size = new System.Drawing.Size(50, 23);
            this.UpdateSerialButton.TabIndex = 2;
            this.UpdateSerialButton.Text = "刷新";
            this.UpdateSerialButton.UseVisualStyleBackColor = true;
            this.UpdateSerialButton.Click += new System.EventHandler(this.UpdateSerialButton_Click);
            // 
            // PolingTimeTextBox
            // 
            this.PolingTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PolingTimeTextBox.Location = new System.Drawing.Point(88, 47);
            this.PolingTimeTextBox.Name = "PolingTimeTextBox";
            this.PolingTimeTextBox.Size = new System.Drawing.Size(89, 21);
            this.PolingTimeTextBox.TabIndex = 1;
            this.PolingTimeTextBox.Text = "1000";
            this.PolingTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 1000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // UpdateDateTimer
            // 
            this.UpdateDateTimer.Tick += new System.EventHandler(this.UpdateDateTimer_Tick);
            // 
            // MultiStepSettingButton
            // 
            this.MultiStepSettingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MultiStepSettingButton.Location = new System.Drawing.Point(179, 116);
            this.MultiStepSettingButton.Name = "MultiStepSettingButton";
            this.MultiStepSettingButton.Size = new System.Drawing.Size(50, 23);
            this.MultiStepSettingButton.TabIndex = 2;
            this.MultiStepSettingButton.Text = "设置";
            this.MultiStepSettingButton.UseVisualStyleBackColor = true;
            this.MultiStepSettingButton.Click += new System.EventHandler(this.MultiStepSettingButton_Click);
            // 
            // WorkStatusTextBox
            // 
            this.WorkStatusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkStatusTextBox.Location = new System.Drawing.Point(88, 7);
            this.WorkStatusTextBox.Name = "WorkStatusTextBox";
            this.WorkStatusTextBox.ReadOnly = true;
            this.WorkStatusTextBox.Size = new System.Drawing.Size(86, 21);
            this.WorkStatusTextBox.TabIndex = 4;
            this.WorkStatusTextBox.Text = "就绪";
            this.WorkStatusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "工作状态";
            // 
            // OneStepRadioButton
            // 
            this.OneStepRadioButton.AutoSize = true;
            this.OneStepRadioButton.Checked = true;
            this.OneStepRadioButton.Location = new System.Drawing.Point(88, 97);
            this.OneStepRadioButton.Name = "OneStepRadioButton";
            this.OneStepRadioButton.Size = new System.Drawing.Size(71, 16);
            this.OneStepRadioButton.TabIndex = 5;
            this.OneStepRadioButton.TabStop = true;
            this.OneStepRadioButton.Text = "单段模式";
            this.OneStepRadioButton.UseVisualStyleBackColor = true;
            this.OneStepRadioButton.CheckedChanged += new System.EventHandler(this.OneStepRadioButton_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "温度1(实际)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "温度2(实际)";
            // 
            // MultiStepRadioButton
            // 
            this.MultiStepRadioButton.AutoSize = true;
            this.MultiStepRadioButton.Location = new System.Drawing.Point(88, 119);
            this.MultiStepRadioButton.Name = "MultiStepRadioButton";
            this.MultiStepRadioButton.Size = new System.Drawing.Size(71, 16);
            this.MultiStepRadioButton.TabIndex = 6;
            this.MultiStepRadioButton.Text = "多段模式";
            this.MultiStepRadioButton.UseVisualStyleBackColor = true;
            this.MultiStepRadioButton.CheckedChanged += new System.EventHandler(this.MultiStepRadioButton_CheckedChanged);
            // 
            // CurrentTemp1TextBox
            // 
            this.CurrentTemp1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentTemp1TextBox.Location = new System.Drawing.Point(88, 34);
            this.CurrentTemp1TextBox.Name = "CurrentTemp1TextBox";
            this.CurrentTemp1TextBox.ReadOnly = true;
            this.CurrentTemp1TextBox.Size = new System.Drawing.Size(86, 21);
            this.CurrentTemp1TextBox.TabIndex = 4;
            this.CurrentTemp1TextBox.Text = "0";
            this.CurrentTemp1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CurrentTemp2TextBox
            // 
            this.CurrentTemp2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentTemp2TextBox.Location = new System.Drawing.Point(88, 61);
            this.CurrentTemp2TextBox.Name = "CurrentTemp2TextBox";
            this.CurrentTemp2TextBox.ReadOnly = true;
            this.CurrentTemp2TextBox.Size = new System.Drawing.Size(86, 21);
            this.CurrentTemp2TextBox.TabIndex = 4;
            this.CurrentTemp2TextBox.Text = "0";
            this.CurrentTemp2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "温度模式";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.CurrentTemp2TextBox);
            this.panel2.Controls.Add(this.CurrentTemp1TextBox);
            this.panel2.Controls.Add(this.MultiStepRadioButton);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.OneStepRadioButton);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.WorkStatusTextBox);
            this.panel2.Controls.Add(this.MultiStepSettingButton);
            this.panel2.Location = new System.Drawing.Point(3, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 150);
            this.panel2.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 641);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1000, 680);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ControlGroupBox.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.OneStepPanel.ResumeLayout(false);
            this.OneStepPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PolingTimeTextBox;
        private System.Windows.Forms.Panel OneStepPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox Input0CheckBox;
        private System.Windows.Forms.CheckBox Output0CheckBox;
        private System.Windows.Forms.CheckBox Input4CheckBox;
        private System.Windows.Forms.CheckBox Output4CheckBox;
        private System.Windows.Forms.CheckBox Input3CheckBox;
        private System.Windows.Forms.CheckBox Output3CheckBox;
        private System.Windows.Forms.CheckBox Input2CheckBox;
        private System.Windows.Forms.CheckBox Output2CheckBox;
        private System.Windows.Forms.CheckBox Input1CheckBox;
        private System.Windows.Forms.CheckBox Output1CheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripStatusLabel TimeLabel;
        private System.Windows.Forms.Timer UpdateDateTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox CurrentTemp2TextBox;
        private System.Windows.Forms.TextBox CurrentTemp1TextBox;
        private System.Windows.Forms.RadioButton MultiStepRadioButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton OneStepRadioButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox WorkStatusTextBox;
        private System.Windows.Forms.Button MultiStepSettingButton;
    }
}

