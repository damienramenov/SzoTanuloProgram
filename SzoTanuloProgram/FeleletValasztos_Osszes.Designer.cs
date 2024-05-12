namespace SzoTanuloProgram
{
    partial class FeleletValasztos_Osszes
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.mennyiKerdes = new System.Windows.Forms.NumericUpDown();
            this._ButtonBEtolto = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mennyiKerdes)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(62)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this._ButtonBEtolto, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mennyiKerdes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(12, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 99);
            this.label1.TabIndex = 36;
            this.label1.Text = "Add meg a betöltendő kérdések számát";
            // 
            // mennyiKerdes
            // 
            this.mennyiKerdes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mennyiKerdes.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.mennyiKerdes.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mennyiKerdes.Location = new System.Drawing.Point(299, 183);
            this.mennyiKerdes.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mennyiKerdes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mennyiKerdes.Name = "mennyiKerdes";
            this.mennyiKerdes.Size = new System.Drawing.Size(200, 83);
            this.mennyiKerdes.TabIndex = 37;
            this.mennyiKerdes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _ButtonBEtolto
            // 
            this._ButtonBEtolto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._ButtonBEtolto.BackColor = System.Drawing.Color.Firebrick;
            this._ButtonBEtolto.Cursor = System.Windows.Forms.Cursors.Hand;
            this._ButtonBEtolto.FlatAppearance.BorderSize = 5;
            this._ButtonBEtolto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._ButtonBEtolto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ButtonBEtolto.Location = new System.Drawing.Point(558, 156);
            this._ButtonBEtolto.Name = "_ButtonBEtolto";
            this._ButtonBEtolto.Size = new System.Drawing.Size(216, 138);
            this._ButtonBEtolto.TabIndex = 39;
            this._ButtonBEtolto.Text = "BETÖLTÖM";
            this._ButtonBEtolto.UseVisualStyleBackColor = false;
            this._ButtonBEtolto.Click += new System.EventHandler(this._ButtonBEtolto_Click);
            // 
            // FeleletValasztos_Osszes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FeleletValasztos_Osszes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FeleletValasztos_Osszes";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mennyiKerdes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown mennyiKerdes;
        private System.Windows.Forms.Button _ButtonBEtolto;
    }
}