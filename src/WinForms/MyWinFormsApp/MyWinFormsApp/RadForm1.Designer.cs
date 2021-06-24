
namespace MyWinFormsApp
{
    partial class RadForm1
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
            this.radSyntaxEditor1 = new Telerik.WinControls.UI.RadSyntaxEditor();
            ((System.ComponentModel.ISupportInitialize)(this.radSyntaxEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radSyntaxEditor1
            // 
            this.radSyntaxEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSyntaxEditor1.Location = new System.Drawing.Point(0, 0);
            this.radSyntaxEditor1.Name = "radSyntaxEditor1";
            this.radSyntaxEditor1.Size = new System.Drawing.Size(825, 639);
            this.radSyntaxEditor1.TabIndex = 0;
            this.radSyntaxEditor1.Text = "radSyntaxEditor1";
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 639);
            this.Controls.Add(this.radSyntaxEditor1);
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RadForm1";
            ((System.ComponentModel.ISupportInitialize)(this.radSyntaxEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadSyntaxEditor radSyntaxEditor1;
    }
}