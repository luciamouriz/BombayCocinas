namespace AplicacionCocinas
{
    partial class InformeCliente
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
            this.crvCliente = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCliente
            // 
            this.crvCliente.ActiveViewIndex = -1;
            this.crvCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCliente.Location = new System.Drawing.Point(0, 0);
            this.crvCliente.Name = "crvCliente";
            this.crvCliente.Size = new System.Drawing.Size(755, 435);
            this.crvCliente.TabIndex = 0;
            this.crvCliente.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // InformeCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 435);
            this.Controls.Add(this.crvCliente);
            this.Name = "InformeCliente";
            this.Text = "InformeCliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCliente;
    }
}