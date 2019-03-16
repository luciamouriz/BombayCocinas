using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionCocinas
{
    public partial class Escritorio : Form
    {
        IUClientes clientes;
        Presupuesto.IUPresupuesto presupuesto;
        IUContrato contrato;
        IUAyuda ayuda;

        public Escritorio()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientes != null) clientes.Close();

            clientes = new IUClientes(true);
            clientes.MdiParent = this;
            clientes.Dock = DockStyle.Fill;
            clientes.WindowState = FormWindowState.Maximized;
            clientes.Show();
        }

        private void presupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (presupuesto != null) presupuesto.Close();

            presupuesto = new Presupuesto.IUPresupuesto();
            presupuesto.MdiParent = this;
            presupuesto.Dock = DockStyle.Fill;
            presupuesto.WindowState = FormWindowState.Maximized;
            presupuesto.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contrato != null) contrato.Close();

            contrato = new IUContrato();
            contrato.MdiParent = this;
            contrato.Dock = DockStyle.Fill;
            contrato.WindowState = FormWindowState.Maximized;
            contrato.Show();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ayuda != null) ayuda.Close();

            ayuda = new IUAyuda();
            ayuda.MdiParent = this;
            ayuda.Dock = DockStyle.Fill;
            ayuda.WindowState = FormWindowState.Maximized;
            ayuda.Show();
        }

        private void cOCINASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientes != null) clientes.Close();
            if (presupuesto != null) presupuesto.Close();
            if (contrato != null) contrato.Close();
            if (ayuda != null) ayuda.Close();
        }

    }
}
