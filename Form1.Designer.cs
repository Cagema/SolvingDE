
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.mTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.hTextBox = new System.Windows.Forms.TextBox();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.aTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.lTextBox = new System.Windows.Forms.TextBox();
            this.massTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.angle1TextBox = new System.Windows.Forms.TextBox();
            this.angle2TextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.EulerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RK2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RK4MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RK8MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtraMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImplicitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Format = "0.00";
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Format = "0.00";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 27);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.CustomProperties = "IsXAxisQuantitative=False";
            series1.Name = "Series0";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(665, 394);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.BorderColor = System.Drawing.Color.Black;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            title1.Name = "Title1";
            title1.Text = "Фазовый портрет";
            this.chart1.Titles.Add(title1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Осциллятор Ван дер Поля",
            "Гамильтонова система с неразделяемым гамильтонианом",
            "Маятник с возмущением",
            "Двойной маятник"});
            this.comboBox1.Location = new System.Drawing.Point(683, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(332, 32);
            this.comboBox1.TabIndex = 1;
            // 
            // mTextBox
            // 
            this.mTextBox.Location = new System.Drawing.Point(683, 427);
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.Size = new System.Drawing.Size(100, 29);
            this.mTextBox.TabIndex = 2;
            this.mTextBox.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(789, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Коэффициент m";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 44);
            this.button1.TabIndex = 4;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hTextBox
            // 
            this.hTextBox.Location = new System.Drawing.Point(684, 66);
            this.hTextBox.Name = "hTextBox";
            this.hTextBox.Size = new System.Drawing.Size(100, 29);
            this.hTextBox.TabIndex = 5;
            this.hTextBox.Text = "0,01";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(684, 102);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(100, 29);
            this.timeTextBox.TabIndex = 6;
            this.timeTextBox.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(790, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Шаг";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(789, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Время";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(790, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Коэффициент a";
            // 
            // aTextBox
            // 
            this.aTextBox.Location = new System.Drawing.Point(683, 392);
            this.aTextBox.Name = "aTextBox";
            this.aTextBox.Size = new System.Drawing.Size(100, 29);
            this.aTextBox.TabIndex = 10;
            this.aTextBox.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(789, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(790, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "Y";
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(684, 138);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(100, 29);
            this.xTextBox.TabIndex = 13;
            this.xTextBox.Text = "0";
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(684, 173);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(100, 29);
            this.yTextBox.TabIndex = 14;
            this.yTextBox.Text = "1";
            // 
            // lTextBox
            // 
            this.lTextBox.Location = new System.Drawing.Point(684, 208);
            this.lTextBox.Name = "lTextBox";
            this.lTextBox.Size = new System.Drawing.Size(100, 29);
            this.lTextBox.TabIndex = 15;
            this.lTextBox.Text = "10";
            // 
            // massTextBox
            // 
            this.massTextBox.Location = new System.Drawing.Point(684, 243);
            this.massTextBox.Name = "massTextBox";
            this.massTextBox.Size = new System.Drawing.Size(100, 29);
            this.massTextBox.TabIndex = 16;
            this.massTextBox.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(790, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 24);
            this.label7.TabIndex = 17;
            this.label7.Text = "Длина стержней";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(790, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 24);
            this.label8.TabIndex = 18;
            this.label8.Text = "Масса стержней";
            // 
            // angle1TextBox
            // 
            this.angle1TextBox.Location = new System.Drawing.Point(684, 278);
            this.angle1TextBox.Name = "angle1TextBox";
            this.angle1TextBox.Size = new System.Drawing.Size(100, 29);
            this.angle1TextBox.TabIndex = 19;
            this.angle1TextBox.Text = "37";
            // 
            // angle2TextBox
            // 
            this.angle2TextBox.Location = new System.Drawing.Point(684, 313);
            this.angle2TextBox.Name = "angle2TextBox";
            this.angle2TextBox.Size = new System.Drawing.Size(100, 29);
            this.angle2TextBox.TabIndex = 20;
            this.angle2TextBox.Text = "72";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(790, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(250, 24);
            this.label9.TabIndex = 21;
            this.label9.Text = "Начальный угол стержня 1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(790, 316);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(260, 24);
            this.label10.TabIndex = 22;
            this.label10.Text = "Начальный угол стержняя 2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EulerMenuItem,
            this.RK2MenuItem,
            this.RK4MenuItem,
            this.RK8MenuItem,
            this.ExtraMenuItem,
            this.CompMenuItem,
            this.ImplicitMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1046, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // EulerMenuItem
            // 
            this.EulerMenuItem.Name = "EulerMenuItem";
            this.EulerMenuItem.Size = new System.Drawing.Size(50, 20);
            this.EulerMenuItem.Text = "Эйлер";
            this.EulerMenuItem.Click += new System.EventHandler(this.EulerMenuItem_Click);
            // 
            // RK2MenuItem
            // 
            this.RK2MenuItem.Name = "RK2MenuItem";
            this.RK2MenuItem.Size = new System.Drawing.Size(38, 20);
            this.RK2MenuItem.Text = "РК2";
            this.RK2MenuItem.Click += new System.EventHandler(this.RK2MenuItem_Click);
            // 
            // RK4MenuItem
            // 
            this.RK4MenuItem.Name = "RK4MenuItem";
            this.RK4MenuItem.Size = new System.Drawing.Size(38, 20);
            this.RK4MenuItem.Text = "РК4";
            this.RK4MenuItem.Click += new System.EventHandler(this.RK4MenuItem_Click);
            // 
            // RK8MenuItem
            // 
            this.RK8MenuItem.Name = "RK8MenuItem";
            this.RK8MenuItem.Size = new System.Drawing.Size(38, 20);
            this.RK8MenuItem.Text = "РК8";
            this.RK8MenuItem.Click += new System.EventHandler(this.RK8MenuItem_Click);
            // 
            // ExtraMenuItem
            // 
            this.ExtraMenuItem.Name = "ExtraMenuItem";
            this.ExtraMenuItem.Size = new System.Drawing.Size(97, 20);
            this.ExtraMenuItem.Text = "Экстраполятор";
            this.ExtraMenuItem.Click += new System.EventHandler(this.ExtraMenuItem_Click);
            // 
            // CompMenuItem
            // 
            this.CompMenuItem.Name = "CompMenuItem";
            this.CompMenuItem.Size = new System.Drawing.Size(105, 20);
            this.CompMenuItem.Text = "Композиционный";
            this.CompMenuItem.Click += new System.EventHandler(this.CompMenuItem_Click);
            // 
            // ImplicitMenuItem
            // 
            this.ImplicitMenuItem.Name = "ImplicitMenuItem";
            this.ImplicitMenuItem.Size = new System.Drawing.Size(64, 20);
            this.ImplicitMenuItem.Text = "Неявный";
            this.ImplicitMenuItem.Click += new System.EventHandler(this.ImplicitMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 618);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.angle2TextBox);
            this.Controls.Add(this.angle1TextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.massTextBox);
            this.Controls.Add(this.lTextBox);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.aTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.hTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mTextBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Решение некоторых ДУ";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox mTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox hTextBox;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox aTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox lTextBox;
        private System.Windows.Forms.TextBox massTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox angle1TextBox;
        private System.Windows.Forms.TextBox angle2TextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem EulerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RK2MenuItem;
        private System.Windows.Forms.ToolStripMenuItem RK4MenuItem;
        private System.Windows.Forms.ToolStripMenuItem RK8MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExtraMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CompMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImplicitMenuItem;
    }
}

