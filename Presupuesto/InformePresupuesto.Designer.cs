namespace AplicacionCocinas.Presupuesto
{
    partial class InformePresupuesto
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
            this.crvPresupuesto = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvPresupuesto
            // 
            this.crvPresupuesto.ActiveViewIndex = -1;
            this.crvPresupuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPresupuesto.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvPresupuesto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPresupuesto.Location = new System.Drawing.Point(0, 0);
            this.crvPresupuesto.Name = "crvPresupuesto";
            this.crvPresupuesto.Size = new System.Drawing.Size(849, 541);
            this.crvPresupuesto.TabIndex = 0;
            this.crvPresupuesto.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // InformePresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 541);
            this.Controls.Add(this.crvPresupuesto);
            this.Name = "InformePresupuesto";
            this.Text = "InformePresupuesto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPresupuesto;
    }
}