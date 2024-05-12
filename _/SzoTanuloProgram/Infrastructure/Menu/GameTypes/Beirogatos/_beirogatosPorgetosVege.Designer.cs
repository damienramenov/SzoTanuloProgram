namespace SzoTanuloProgram
{
    partial class BeirogatosPorgetosVege
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
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(9, 11);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(732, 206);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 248);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Teljesített szavak az összes szóhoz képest, ami az adott leckében van";
            // 
            // _panelAlapAlso
            // 
            this._panelAlapAlso.BackColor = System.Drawing.Color.Silver;
            this._panelAlapAlso.Controls.Add(this._panelAlsoNoveled);
            this._panelAlapAlso.Location = new System.Drawing.Point(9, 273);
            this._panelAlapAlso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._panelAlapAlso.Name = "_panelAlapAlso";
            this._panelAlapAlso.Size = new System.Drawing.Size(732, 37);
            this._panelAlapAlso.TabIndex = 2;
            // 
            // _panelAlsoNoveled
            // 
            this._panelAlsoNoveled.BackColor = System.Drawing.Color.YellowGreen;
            this._panelAlsoNoveled.Location = new System.Drawing.Point(0, 0);
            this._panelAlsoNoveled.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._panelAlsoNoveled.Name = "_panelAlsoNoveled";
            this._panelAlsoNoveled.Size = new System.Drawing.Size(152, 37);
            this._panelAlsoNoveled.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(9, 544);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 56);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _beirogatosPorgetosVege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(750, 609);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._panelAlapAlso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(750, 609);
            this.MinimumSize = new System.Drawing.Size(750, 609);
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