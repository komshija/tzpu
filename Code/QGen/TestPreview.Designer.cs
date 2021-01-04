
namespace QGen
{
    partial class TestPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestPreview));
            this.dgv_test = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ok = new System.Windows.Forms.Button();
            this.c_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_tekst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_oblasti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_test)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_test
            // 
            this.dgv_test.AllowUserToAddRows = false;
            this.dgv_test.AllowUserToDeleteRows = false;
            this.dgv_test.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_test.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_test.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_id,
            this.c_tekst,
            this.c_oblasti});
            this.dgv_test.Location = new System.Drawing.Point(3, 2);
            this.dgv_test.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_test.Name = "dgv_test";
            this.dgv_test.ReadOnly = true;
            this.dgv_test.RowHeadersWidth = 51;
            this.dgv_test.RowTemplate.Height = 24;
            this.dgv_test.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_test.Size = new System.Drawing.Size(906, 336);
            this.dgv_test.TabIndex = 0;
            this.dgv_test.SizeChanged += new System.EventHandler(this.dgv_test_SizeChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_test, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_ok, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(912, 378);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.Location = new System.Drawing.Point(3, 342);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(906, 34);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // c_id
            // 
            this.c_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.c_id.HeaderText = "Id";
            this.c_id.MinimumWidth = 6;
            this.c_id.Name = "c_id";
            this.c_id.ReadOnly = true;
            this.c_id.Width = 48;
            // 
            // c_tekst
            // 
            this.c_tekst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.c_tekst.HeaderText = "Tekst";
            this.c_tekst.MinimumWidth = 6;
            this.c_tekst.Name = "c_tekst";
            this.c_tekst.ReadOnly = true;
            this.c_tekst.Width = 72;
            // 
            // c_oblasti
            // 
            this.c_oblasti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_oblasti.HeaderText = "Oblasti";
            this.c_oblasti.MinimumWidth = 6;
            this.c_oblasti.Name = "c_oblasti";
            this.c_oblasti.ReadOnly = true;
            // 
            // TestPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 402);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TestPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Preview";
            this.Load += new System.EventHandler(this.TestPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_test)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_test;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_tekst;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_oblasti;
    }
}