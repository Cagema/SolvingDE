
namespace SolvingDE
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.mTextBox = new System.Windows.Forms.TextBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.hTextBox = new System.Windows.Forms.TextBox();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aLabel = new System.Windows.Forms.Label();
            this.aTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.lTextBox = new System.Windows.Forms.TextBox();
            this.massTextBox = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.massLabel = new System.Windows.Forms.Label();
            this.angle1TextBox = new System.Windows.Forms.TextBox();
            this.angle2TextBox = new System.Windows.Forms.TextBox();
            this.angle1Label = new System.Windows.Forms.Label();
            this.angle2Label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ODU1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ODU2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ODU3MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ODU4MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MethodsListBox = new System.Windows.Forms.CheckedListBox();
            this.timeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DecTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.globalChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.efficiencyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ArrayHTextBox = new System.Windows.Forms.TextBox();
            this.ErrorsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efficiencyChart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea5.AxisX.IsLabelAutoFit = false;
            chartArea5.AxisX.LabelStyle.Format = "0.0";
            chartArea5.AxisY.IsLabelAutoFit = false;
            chartArea5.AxisY.LabelStyle.Format = "0.0";
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Location = new System.Drawing.Point(12, 27);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(244, 244);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // mTextBox
            // 
            this.mTextBox.Location = new System.Drawing.Point(675, 141);
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.Size = new System.Drawing.Size(100, 29);
            this.mTextBox.TabIndex = 2;
            this.mTextBox.Text = "0";
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Location = new System.Drawing.Point(781, 144);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(157, 24);
            this.mLabel.TabIndex = 3;
            this.mLabel.Text = "Коэффициент m";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 555);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 44);
            this.button1.TabIndex = 4;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hTextBox
            // 
            this.hTextBox.Location = new System.Drawing.Point(676, 31);
            this.hTextBox.Name = "hTextBox";
            this.hTextBox.Size = new System.Drawing.Size(100, 29);
            this.hTextBox.TabIndex = 5;
            this.hTextBox.Text = "0,01";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(676, 67);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(100, 29);
            this.timeTextBox.TabIndex = 6;
            this.timeTextBox.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(782, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Шаг";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(781, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Время";
            // 
            // aLabel
            // 
            this.aLabel.AutoSize = true;
            this.aLabel.Location = new System.Drawing.Point(782, 144);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(151, 24);
            this.aLabel.TabIndex = 9;
            this.aLabel.Text = "Коэффициент a";
            this.aLabel.Visible = false;
            // 
            // aTextBox
            // 
            this.aTextBox.Location = new System.Drawing.Point(675, 141);
            this.aTextBox.Name = "aTextBox";
            this.aTextBox.Size = new System.Drawing.Size(100, 29);
            this.aTextBox.TabIndex = 10;
            this.aTextBox.Text = "0";
            this.aTextBox.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(781, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Начальные условия";
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(676, 103);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(40, 29);
            this.xTextBox.TabIndex = 13;
            this.xTextBox.Text = "1";
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(735, 103);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(40, 29);
            this.yTextBox.TabIndex = 14;
            this.yTextBox.Text = "0";
            // 
            // lTextBox
            // 
            this.lTextBox.Location = new System.Drawing.Point(675, 141);
            this.lTextBox.Name = "lTextBox";
            this.lTextBox.Size = new System.Drawing.Size(100, 29);
            this.lTextBox.TabIndex = 15;
            this.lTextBox.Text = "10";
            this.lTextBox.Visible = false;
            // 
            // massTextBox
            // 
            this.massTextBox.Location = new System.Drawing.Point(675, 176);
            this.massTextBox.Name = "massTextBox";
            this.massTextBox.Size = new System.Drawing.Size(100, 29);
            this.massTextBox.TabIndex = 16;
            this.massTextBox.Text = "1";
            this.massTextBox.Visible = false;
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(781, 144);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(160, 24);
            this.lengthLabel.TabIndex = 17;
            this.lengthLabel.Text = "Длина стержней";
            this.lengthLabel.Visible = false;
            // 
            // massLabel
            // 
            this.massLabel.AutoSize = true;
            this.massLabel.Location = new System.Drawing.Point(781, 179);
            this.massLabel.Name = "massLabel";
            this.massLabel.Size = new System.Drawing.Size(160, 24);
            this.massLabel.TabIndex = 18;
            this.massLabel.Text = "Масса стержней";
            this.massLabel.Visible = false;
            // 
            // angle1TextBox
            // 
            this.angle1TextBox.Location = new System.Drawing.Point(675, 211);
            this.angle1TextBox.Name = "angle1TextBox";
            this.angle1TextBox.Size = new System.Drawing.Size(100, 29);
            this.angle1TextBox.TabIndex = 19;
            this.angle1TextBox.Text = "37";
            this.angle1TextBox.Visible = false;
            // 
            // angle2TextBox
            // 
            this.angle2TextBox.Location = new System.Drawing.Point(675, 246);
            this.angle2TextBox.Name = "angle2TextBox";
            this.angle2TextBox.Size = new System.Drawing.Size(100, 29);
            this.angle2TextBox.TabIndex = 20;
            this.angle2TextBox.Text = "72";
            this.angle2TextBox.Visible = false;
            // 
            // angle1Label
            // 
            this.angle1Label.AutoSize = true;
            this.angle1Label.Location = new System.Drawing.Point(781, 214);
            this.angle1Label.Name = "angle1Label";
            this.angle1Label.Size = new System.Drawing.Size(250, 24);
            this.angle1Label.TabIndex = 21;
            this.angle1Label.Text = "Начальный угол стержня 1";
            this.angle1Label.Visible = false;
            // 
            // angle2Label
            // 
            this.angle2Label.AutoSize = true;
            this.angle2Label.Location = new System.Drawing.Point(781, 249);
            this.angle2Label.Name = "angle2Label";
            this.angle2Label.Size = new System.Drawing.Size(260, 24);
            this.angle2Label.TabIndex = 22;
            this.angle2Label.Text = "Начальный угол стержняя 2";
            this.angle2Label.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ODU1MenuItem,
            this.ODU2MenuItem,
            this.ODU3MenuItem,
            this.ODU4MenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1046, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ODU1MenuItem
            // 
            this.ODU1MenuItem.Name = "ODU1MenuItem";
            this.ODU1MenuItem.Size = new System.Drawing.Size(93, 20);
            this.ODU1MenuItem.Text = "Ван дер Поля";
            this.ODU1MenuItem.Click += new System.EventHandler(this.ODU1MenuItem_Click);
            // 
            // ODU2MenuItem
            // 
            this.ODU2MenuItem.Name = "ODU2MenuItem";
            this.ODU2MenuItem.Size = new System.Drawing.Size(146, 20);
            this.ODU2MenuItem.Text = "Гамильтонова система";
            this.ODU2MenuItem.Click += new System.EventHandler(this.ODU2MenuItem_Click);
            // 
            // ODU3MenuItem
            // 
            this.ODU3MenuItem.Name = "ODU3MenuItem";
            this.ODU3MenuItem.Size = new System.Drawing.Size(158, 20);
            this.ODU3MenuItem.Text = "Маятник с возмущением";
            this.ODU3MenuItem.Click += new System.EventHandler(this.ODU3MenuItem_Click);
            // 
            // ODU4MenuItem
            // 
            this.ODU4MenuItem.Name = "ODU4MenuItem";
            this.ODU4MenuItem.Size = new System.Drawing.Size(117, 20);
            this.ODU4MenuItem.Text = "Двойной маятник";
            this.ODU4MenuItem.Click += new System.EventHandler(this.ODU4MenuItem_Click);
            // 
            // MethodsListBox
            // 
            this.MethodsListBox.FormattingEnabled = true;
            this.MethodsListBox.Items.AddRange(new object[] {
            "Рунге-Кутты явный 2 ",
            "Рунге-Кутты явный 4 ",
            "Рунге-Кутты явный 6",
            "Рунге-Кутты явный 8",
            "Рунге-Кутты неявный 2 (трапеция, неявная средняя точка)",
            "Рунге-Кутты неявный 4 порядка",
            "Экстраполяционный метод на основе явной средней точки (Грегга-Булирша-Штера)",
            "Экстраполяционный метод на основе неявной средней точки",
            "Экстраполяционный метод на основе метода КД (произвольный порядок)",
            "Композиционный метод на основе метода неявной средней точки",
            "Композиционный метод на основе метода КД 4 порядка",
            "Композиционный метод на основе метода КД 6 порядка",
            "Композиционный метод на основе метода КД 8 порядка",
            "Многошаговый метод Адамса-Башфорта 2 порядка",
            "Многошаговый метод Адамса-Башфорта 4 порядка",
            "Многошаговый метод Адамса-Башфорта 6 порядка",
            "Адамса-Мультона 2 порядка",
            "Адамся-Мультона 4 порядка",
            "Адамса-Мультона 6 порядка",
            "Многошаговый метод Томинга 3 порядка",
            "Многошаговый метод Томинга 4 порядка",
            "Многошаговый метод Томинга 6 порядка"});
            this.MethodsListBox.Location = new System.Drawing.Point(676, 427);
            this.MethodsListBox.Name = "MethodsListBox";
            this.MethodsListBox.Size = new System.Drawing.Size(309, 172);
            this.MethodsListBox.TabIndex = 25;
            // 
            // timeChart
            // 
            chartArea6.AxisX.IsLabelAutoFit = false;
            chartArea6.AxisY.IsLabelAutoFit = false;
            chartArea6.Name = "ChartArea1";
            this.timeChart.ChartAreas.Add(chartArea6);
            this.timeChart.Location = new System.Drawing.Point(262, 27);
            this.timeChart.Name = "timeChart";
            this.timeChart.Size = new System.Drawing.Size(407, 244);
            this.timeChart.TabIndex = 26;
            this.timeChart.Text = "chart2";
            // 
            // DecTextBox
            // 
            this.DecTextBox.Location = new System.Drawing.Point(841, 31);
            this.DecTextBox.Name = "DecTextBox";
            this.DecTextBox.Size = new System.Drawing.Size(100, 29);
            this.DecTextBox.TabIndex = 27;
            this.DecTextBox.Text = "20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(947, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 24);
            this.label1.TabIndex = 28;
            this.label1.Text = "Dec";
            // 
            // globalChart
            // 
            chartArea7.AxisX.IsLabelAutoFit = false;
            chartArea7.AxisY.IsLabelAutoFit = false;
            chartArea7.Name = "ChartArea1";
            this.globalChart.ChartAreas.Add(chartArea7);
            this.globalChart.Location = new System.Drawing.Point(12, 277);
            this.globalChart.Name = "globalChart";
            this.globalChart.Size = new System.Drawing.Size(407, 244);
            this.globalChart.TabIndex = 29;
            this.globalChart.Text = "chart2";
            // 
            // efficiencyChart
            // 
            chartArea8.AxisX.LabelStyle.Format = "0.0";
            chartArea8.AxisX.Title = "Затраченное время";
            chartArea8.AxisY.IsLabelAutoFit = false;
            chartArea8.AxisY.LabelStyle.Format = "0.0";
            chartArea8.AxisY.Title = "Ошибка";
            chartArea8.Name = "ChartArea1";
            this.efficiencyChart.ChartAreas.Add(chartArea8);
            this.efficiencyChart.Location = new System.Drawing.Point(12, 27);
            this.efficiencyChart.Name = "efficiencyChart";
            this.efficiencyChart.Size = new System.Drawing.Size(658, 494);
            this.efficiencyChart.TabIndex = 30;
            this.efficiencyChart.Text = "chart3";
            this.efficiencyChart.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(676, 393);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(157, 28);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "Массив шагов";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ArrayHTextBox
            // 
            this.ArrayHTextBox.Location = new System.Drawing.Point(833, 391);
            this.ArrayHTextBox.Name = "ArrayHTextBox";
            this.ArrayHTextBox.Size = new System.Drawing.Size(198, 29);
            this.ArrayHTextBox.TabIndex = 32;
            this.ArrayHTextBox.Text = "0,01 0,02 0,04 0,06 0,08 0,1 0,12 0,14 0,16 0,18 0,2";
            this.ArrayHTextBox.Visible = false;
            // 
            // ErrorsTextBox
            // 
            this.ErrorsTextBox.AllowDrop = true;
            this.ErrorsTextBox.Location = new System.Drawing.Point(675, 281);
            this.ErrorsTextBox.Multiline = true;
            this.ErrorsTextBox.Name = "ErrorsTextBox";
            this.ErrorsTextBox.ReadOnly = true;
            this.ErrorsTextBox.Size = new System.Drawing.Size(356, 106);
            this.ErrorsTextBox.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 628);
            this.Controls.Add(this.ErrorsTextBox);
            this.Controls.Add(this.efficiencyChart);
            this.Controls.Add(this.ArrayHTextBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.globalChart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DecTextBox);
            this.Controls.Add(this.timeChart);
            this.Controls.Add(this.MethodsListBox);
            this.Controls.Add(this.angle2Label);
            this.Controls.Add(this.angle1Label);
            this.Controls.Add(this.angle2TextBox);
            this.Controls.Add(this.angle1TextBox);
            this.Controls.Add(this.massLabel);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.massTextBox);
            this.Controls.Add(this.lTextBox);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.aTextBox);
            this.Controls.Add(this.aLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.hTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mLabel);
            this.Controls.Add(this.mTextBox);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Осциллятор Ван дер Поля";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efficiencyChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox mTextBox;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox hTextBox;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label aLabel;
        private System.Windows.Forms.TextBox aTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox lTextBox;
        private System.Windows.Forms.TextBox massTextBox;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label massLabel;
        private System.Windows.Forms.TextBox angle1TextBox;
        private System.Windows.Forms.TextBox angle2TextBox;
        private System.Windows.Forms.Label angle1Label;
        private System.Windows.Forms.Label angle2Label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ODU1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ODU2MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ODU3MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ODU4MenuItem;
        private System.Windows.Forms.CheckedListBox MethodsListBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart timeChart;
        private System.Windows.Forms.TextBox DecTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart globalChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart efficiencyChart;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox ArrayHTextBox;
        private System.Windows.Forms.TextBox ErrorsTextBox;
    }
}

