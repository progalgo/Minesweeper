namespace Minesweeper
{
    partial class MainForm
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
            this.fieldControl1 = new Minesweeper.FieldControl();
            this.SuspendLayout();
            // 
            // fieldControl1
            // 
            this.fieldControl1.Location = new System.Drawing.Point(52, 52);
            this.fieldControl1.MaximumSize = new System.Drawing.Size(160, 160);
            this.fieldControl1.MinimumSize = new System.Drawing.Size(160, 160);
            this.fieldControl1.Name = "fieldControl1";
            this.fieldControl1.Size = new System.Drawing.Size(160, 160);
            this.fieldControl1.TabIndex = 0;
            this.fieldControl1.Text = "fieldControl1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.fieldControl1);
            this.Name = "MainForm";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);

        }

        #endregion

        private FieldControl fieldControl1;
    }
}

