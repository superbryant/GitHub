namespace ClassLibrary1
{
    partial class PdfToXml
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfToXml));
            this.axPMAX1 = new AxPMAXLib.AxPMAX();
            ((System.ComponentModel.ISupportInitialize)(this.axPMAX1)).BeginInit();
            this.SuspendLayout();
            // 
            // axPMAX1
            // 
            this.axPMAX1.Enabled = true;
            this.axPMAX1.Location = new System.Drawing.Point(86, 76);
            this.axPMAX1.Name = "axPMAX1";
            this.axPMAX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPMAX1.OcxState")));
            this.axPMAX1.Size = new System.Drawing.Size(116, 98);
            this.axPMAX1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.axPMAX1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axPMAX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxPMAXLib.AxPMAX axPMAX1;
    }
}