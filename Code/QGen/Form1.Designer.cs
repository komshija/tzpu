
namespace QGen
{
    partial class glavna_forma
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.gBox_oblasti = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.rb_nizovi = new System.Windows.Forms.RadioButton();
            this.rb_matrice = new System.Windows.Forms.RadioButton();
            this.rb_algoritmi = new System.Windows.Forms.RadioButton();
            this.rb_fajlovi = new System.Windows.Forms.RadioButton();
            this.rb_funkcije = new System.Windows.Forms.RadioButton();
            this.chart_zastupljenost = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gBox_selektovana = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_lako = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar_srednje = new System.Windows.Forms.TrackBar();
            this.trackBar_tesko = new System.Windows.Forms.TrackBar();
            this.btn_kreiraj = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.oAplikacijiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBox_oblasti.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_zastupljenost)).BeginInit();
            this.gBox_selektovana.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_lako)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_srednje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_tesko)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBox_oblasti
            // 
            this.gBox_oblasti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBox_oblasti.Controls.Add(this.tableLayoutPanel3);
            this.gBox_oblasti.Location = new System.Drawing.Point(3, 3);
            this.gBox_oblasti.Name = "gBox_oblasti";
            this.gBox_oblasti.Size = new System.Drawing.Size(638, 219);
            this.gBox_oblasti.TabIndex = 0;
            this.gBox_oblasti.TabStop = false;
            this.gBox_oblasti.Text = "Ponudjene oblasti";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.rb_nizovi, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.rb_matrice, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.rb_algoritmi, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.rb_fajlovi, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.rb_funkcije, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(43, 21);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 191);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // rb_nizovi
            // 
            this.rb_nizovi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_nizovi.AutoSize = true;
            this.rb_nizovi.Location = new System.Drawing.Point(3, 3);
            this.rb_nizovi.Name = "rb_nizovi";
            this.rb_nizovi.Size = new System.Drawing.Size(67, 32);
            this.rb_nizovi.TabIndex = 0;
            this.rb_nizovi.TabStop = true;
            this.rb_nizovi.Tag = "0";
            this.rb_nizovi.Text = "Nizovi";
            this.rb_nizovi.UseVisualStyleBackColor = true;
            this.rb_nizovi.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_matrice
            // 
            this.rb_matrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_matrice.AutoSize = true;
            this.rb_matrice.Location = new System.Drawing.Point(3, 155);
            this.rb_matrice.Name = "rb_matrice";
            this.rb_matrice.Size = new System.Drawing.Size(75, 33);
            this.rb_matrice.TabIndex = 4;
            this.rb_matrice.TabStop = true;
            this.rb_matrice.Tag = "4";
            this.rb_matrice.Text = "Matrice";
            this.rb_matrice.UseVisualStyleBackColor = true;
            this.rb_matrice.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_algoritmi
            // 
            this.rb_algoritmi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_algoritmi.AutoSize = true;
            this.rb_algoritmi.Location = new System.Drawing.Point(3, 41);
            this.rb_algoritmi.Name = "rb_algoritmi";
            this.rb_algoritmi.Size = new System.Drawing.Size(83, 32);
            this.rb_algoritmi.TabIndex = 1;
            this.rb_algoritmi.TabStop = true;
            this.rb_algoritmi.Tag = "1";
            this.rb_algoritmi.Text = "Algoritmi";
            this.rb_algoritmi.UseVisualStyleBackColor = true;
            this.rb_algoritmi.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_fajlovi
            // 
            this.rb_fajlovi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_fajlovi.AutoSize = true;
            this.rb_fajlovi.Location = new System.Drawing.Point(3, 117);
            this.rb_fajlovi.Name = "rb_fajlovi";
            this.rb_fajlovi.Size = new System.Drawing.Size(69, 32);
            this.rb_fajlovi.TabIndex = 2;
            this.rb_fajlovi.TabStop = true;
            this.rb_fajlovi.Tag = "3";
            this.rb_fajlovi.Text = "Fajlovi";
            this.rb_fajlovi.UseVisualStyleBackColor = true;
            this.rb_fajlovi.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_funkcije
            // 
            this.rb_funkcije.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_funkcije.AutoSize = true;
            this.rb_funkcije.Location = new System.Drawing.Point(3, 79);
            this.rb_funkcije.Name = "rb_funkcije";
            this.rb_funkcije.Size = new System.Drawing.Size(81, 32);
            this.rb_funkcije.TabIndex = 3;
            this.rb_funkcije.TabStop = true;
            this.rb_funkcije.Tag = "2";
            this.rb_funkcije.Text = "Funkcije";
            this.rb_funkcije.UseVisualStyleBackColor = true;
            this.rb_funkcije.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // chart_zastupljenost
            // 
            this.chart_zastupljenost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "chartArea_zastupljenost";
            this.chart_zastupljenost.ChartAreas.Add(chartArea1);
            legend1.Name = "legend_zastupljenost";
            this.chart_zastupljenost.Legends.Add(legend1);
            this.chart_zastupljenost.Location = new System.Drawing.Point(3, 3);
            this.chart_zastupljenost.Name = "chart_zastupljenost";
            this.chart_zastupljenost.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "chartArea_zastupljenost";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "legend_zastupljenost";
            series1.Name = "series_zastupljenost";
            this.chart_zastupljenost.Series.Add(series1);
            this.chart_zastupljenost.Size = new System.Drawing.Size(643, 500);
            this.chart_zastupljenost.TabIndex = 5;
            this.chart_zastupljenost.Text = "chart";
            // 
            // gBox_selektovana
            // 
            this.gBox_selektovana.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBox_selektovana.Controls.Add(this.tableLayoutPanel4);
            this.gBox_selektovana.Location = new System.Drawing.Point(3, 228);
            this.gBox_selektovana.Name = "gBox_selektovana";
            this.gBox_selektovana.Size = new System.Drawing.Size(638, 219);
            this.gBox_selektovana.TabIndex = 6;
            this.gBox_selektovana.TabStop = false;
            this.gBox_selektovana.Text = "Selektovana oblast";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.trackBar_lako, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.trackBar_srednje, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.trackBar_tesko, 1, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 33);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(626, 180);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 59);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lako";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tesko";
            // 
            // trackBar_lako
            // 
            this.trackBar_lako.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_lako.Location = new System.Drawing.Point(96, 3);
            this.trackBar_lako.Name = "trackBar_lako";
            this.trackBar_lako.Size = new System.Drawing.Size(527, 53);
            this.trackBar_lako.TabIndex = 0;
            this.trackBar_lako.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Srednje";
            // 
            // trackBar_srednje
            // 
            this.trackBar_srednje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_srednje.Location = new System.Drawing.Point(96, 62);
            this.trackBar_srednje.Name = "trackBar_srednje";
            this.trackBar_srednje.Size = new System.Drawing.Size(527, 54);
            this.trackBar_srednje.TabIndex = 1;
            this.trackBar_srednje.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // trackBar_tesko
            // 
            this.trackBar_tesko.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_tesko.Location = new System.Drawing.Point(96, 122);
            this.trackBar_tesko.Name = "trackBar_tesko";
            this.trackBar_tesko.Size = new System.Drawing.Size(527, 55);
            this.trackBar_tesko.TabIndex = 2;
            this.trackBar_tesko.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // btn_kreiraj
            // 
            this.btn_kreiraj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_kreiraj.Location = new System.Drawing.Point(3, 453);
            this.btn_kreiraj.Name = "btn_kreiraj";
            this.btn_kreiraj.Size = new System.Drawing.Size(638, 44);
            this.btn_kreiraj.TabIndex = 7;
            this.btn_kreiraj.Text = "Kreiraj test";
            this.btn_kreiraj.UseVisualStyleBackColor = true;
            this.btn_kreiraj.Click += new System.EventHandler(this.btn_kreiraj_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart_zastupljenost, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 506F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1299, 506);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.gBox_oblasti, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_kreiraj, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.gBox_selektovana, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(652, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(644, 500);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oAplikacijiToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1318, 33);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip";
            // 
            // oAplikacijiToolStripMenuItem
            // 
            this.oAplikacijiToolStripMenuItem.Name = "oAplikacijiToolStripMenuItem";
            this.oAplikacijiToolStripMenuItem.Size = new System.Drawing.Size(119, 29);
            this.oAplikacijiToolStripMenuItem.Text = "O aplikaciji";
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // glavna_forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1330, 463);
            this.Name = "glavna_forma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QGen";
            this.gBox_oblasti.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_zastupljenost)).EndInit();
            this.gBox_selektovana.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_lako)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_srednje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_tesko)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBox_oblasti;
        private System.Windows.Forms.RadioButton rb_matrice;
        private System.Windows.Forms.RadioButton rb_funkcije;
        private System.Windows.Forms.RadioButton rb_fajlovi;
        private System.Windows.Forms.RadioButton rb_algoritmi;
        private System.Windows.Forms.RadioButton rb_nizovi;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_zastupljenost;
        private System.Windows.Forms.GroupBox gBox_selektovana;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar_tesko;
        private System.Windows.Forms.TrackBar trackBar_srednje;
        private System.Windows.Forms.TrackBar trackBar_lako;
        private System.Windows.Forms.Button btn_kreiraj;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem oAplikacijiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
    }
}

