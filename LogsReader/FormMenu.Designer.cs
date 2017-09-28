namespace LogsReader
{
    partial class FormMenu
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
            this.ButtonExtract = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonExtract
            // 
            this.ButtonExtract.Location = new System.Drawing.Point(12, 12);
            this.ButtonExtract.Name = "ButtonExtract";
            this.ButtonExtract.Size = new System.Drawing.Size(339, 56);
            this.ButtonExtract.TabIndex = 0;
            this.ButtonExtract.Text = "Extract";
            this.ButtonExtract.UseVisualStyleBackColor = true;
            this.ButtonExtract.Click += new System.EventHandler(this.ButtonExtract_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 81);
            this.Controls.Add(this.ButtonExtract);
            this.Name = "FormMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonExtract;
    }
}

