namespace AplicacionCocinas
{
    partial class InformeContrato
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
            this.crvContrato = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvContrato
            // 
            this.crvContrato.ActiveViewIndex = -1;
            this.crvContrato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvContrato.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvContrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvContrato.Location = new System.Drawing.Point(0, 0);
            this.crvContrato.Name = "crvContrato";
            this.crvContrato.Size = new System.Drawing.Size(931, 546);
            this.crvContrato.TabIndex = 0;
            this.crvContrato.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // InformeContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 546);
            this.Controls.Add(this.crvContrato);
            this.Name = "InformeContrato";
            this.Text = "InformeContrato";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvContrato;
    }
}