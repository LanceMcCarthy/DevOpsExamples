namespace MyWinFormsApp
{
    partial class PdfViewerForm
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
            this.radPdfViewer1 = new Telerik.WinControls.UI.RadPdfViewer();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // radPdfViewer1
            // 
            this.radPdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPdfViewer1.Location = new System.Drawing.Point(0, 0);
            this.radPdfViewer1.Name = "radPdfViewer1";
            this.radPdfViewer1.Size = new System.Drawing.Size(800, 450);
            this.radPdfViewer1.TabIndex = 0;
            this.radPdfViewer1.ThumbnailsScaleFactor = 0.15F;
            // 
            // PdfViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radPdfViewer1);
            this.Name = "PdfViewerForm";
            this.Text = "PdfViewerForm";
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPdfViewer radPdfViewer1;
    }
}