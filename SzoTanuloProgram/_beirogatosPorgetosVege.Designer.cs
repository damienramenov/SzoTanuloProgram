namespace SzoTanuloProgram
{
    partial class _beirogatosPorgetosVege
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._panelAlapAlso = new System.Windows.Forms.Panel();
            this._panelAlsoNoveled = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this._panelAlapAlso.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.ForestGreen;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(976, 253);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(613, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Teljesített Szavak Az Összes szóhoz képest, ami az adott leckében van";
            // 
            // _panelAlapAlso
            // 
            this._panelAlapAlso.BackColor = System.Drawing.Color.Silver;
            this._panelAlapAlso.Controls.Add(this._panelAlsoNoveled);
            this._panelAlapAlso.Location = new System.Drawing.Point(12, 336);
            this._panelAlapAlso.Name = "_panelAlapAlso";
            this._panelAlapAlso.Size = new System.Drawing.Size(976, 45);
            this._panelAlapAlso.TabIndex = 2;
            // 
            // _panelAlsoNoveled
            // 
            this._panelAlsoNoveled.BackColor = System.Drawing.Color.YellowGreen;
            this._panelAlsoNoveled.Location = new System.Drawing.Point(0, 0);
            this._panelAlsoNoveled.Name = "_panelAlsoNoveled";
            this._panelAlsoNoveled.Size = new System.Drawing.Size(203, 45);
            this._panelAlsoNoveled.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(12, 669);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 69);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _beirogatosPorgetosVege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._panelAlapAlso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1000, 750);
            this.MinimumSize = new System.Drawing.Size(1000, 750);
            this.Name = "_beirogatosPorgetosVege";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teljesítve";
            this._panelAlapAlso.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel _panelAlapAlso;
        private System.Windows.Forms.Panel _panelAlsoNoveled;
        private System.Windows.Forms.Button button1;
    }
}