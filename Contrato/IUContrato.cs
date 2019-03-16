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
    public partial class IUContrato : Form
    {
        ConexionSQLServer conexion;
        MetodosComunes funciones;
        private int idcliente = 0;
        private int idcontrato = 0;

        public IUContrato()
        {
            InitializeComponent();
            DoubleBuffered = true;
            conexion = new ConexionSQLServer();
            funciones = new MetodosComunes();
            actualizarDGV();
            conexion.rellenacombobox(cmbLocalidad, "select idlocalidad, descripcion from localidades order by descripcion", "--Seleccionar Localidad--");
        }

        private void actualizarDGV()
        {
            String consulta = "SELECT dbo.Clientes.idcliente, dbo.Contrato.idcontrato, dbo.Clientes.nombre AS Nombre, "
                     + " dbo.Clientes.apellidos AS Apellidos, dbo.Clientes.dni AS Dni, dbo.Localidades.descripcion AS Localidad, dbo.Clientes.telmovil AS Movil, "
                     + " dbo.Entrevista.centro AS Centro, dbo.Contrato.pvpmueble AS PVPMueble, dbo.Contrato.pvpencimera AS PVPEncimera, dbo.Contrato.fechacontrato AS [Fecha Contrato] "
                     + " FROM  dbo.Clientes INNER JOIN dbo.Contrato ON dbo.Clientes.idcliente = dbo.Contrato.refcliente INNER JOIN "
                     + "dbo.Localidades ON dbo.Clientes.reflocalidad = dbo.Localidades.idlocalidad INNER JOIN dbo.Entrevista ON dbo.Clientes.idcliente = dbo.Entrevista.refcliente "
                     + " WHERE dbo.Clientes.dni != '' ";

            if (txtNombre.Text != "")
            {
                consulta = consulta + " and upper(dbo.Clientes.nombre) like '%" + txtNombre.Text.ToUpper() + "%'";
            }
            if (txtApellidos.Text != "")
            {
                consulta = consulta + " and upper(dbo.Clientes.apellidos) like '%" + txtApellidos.Text.ToUpper() + "%'";
            }
            if (txtDni.Text != "")
            {
                consulta = consulta + " and upper(dbo.Clientes.dni) like '%" + txtDni.Text.ToUpper() + "%'";
            }
            if (cmbLocalidad.SelectedIndex != 0)
            {
                consulta = consulta + " and dbo.Localidades.descripcion like '" + cmbLocalidad.Text + "'";
            }
            if (cmbCentro.SelectedIndex != -1)
            {
                consulta = consulta + " and dbo.Entrevista.centro like '" + cmbCentro.Text + "'";
            }
            if (dtpfechaentradaDesde.Value.Date != dtpfechaentradaHasta.Value.Date)
            {
                consulta = consulta + " and dbo.Contrato.fechacontrato between '" + dtpfechaentradaDesde.Value.Date + "' and '" + dtpfechaentradaHasta.Value.Date + "'";
            }
            consulta = consulta + " ORDER BY Nombre";
            Console.WriteLine(consulta);
            conexion.rellenaDGV(dgvContrato, consulta);
            funciones.estilodgv(dgvContrato);
            dgvContrato.Columns[0].Visible = false;
            dgvContrato.Columns[1].Visible = false;
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            actualizarDGV();
        }

        private void txtApellidos_KeyUp(object sender, KeyEventArgs e)
        {
            actualizarDGV();
        }

        private void txtDni_KeyUp(object sender, KeyEventArgs e)
        {
            actualizarDGV();
        }

        private void cmbLocalidad_SelectedValueChanged(object sender, EventArgs e)
        {
            actualizarDGV();
        }

        private void cmbCentro_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarDGV();
        }

        private void dtpfechaentradaDesde_ValueChanged(object sender, EventArgs e)
        {
            int diaMi = Convert.ToInt16(dtpfechaentradaDesde.Value.Day.ToString());
            int mesMi = Convert.ToInt16(dtpfechaentradaDesde.Value.Month.ToString());
            int añoMi = Convert.ToInt16(dtpfechaentradaDesde.Value.Year.ToString());
            int diaMa = Convert.ToInt16(dtpfechaentradaHasta.Value.Day.ToString());
            int mesMa = Convert.ToInt16(dtpfechaentradaHasta.Value.Month.ToString());
            int añoMa = Convert.ToInt16(dtpfechaentradaHasta.Value.Year.ToString());
            if (diaMi > diaMa && mesMi >= mesMa && añoMi >= añoMa)
            {
                MessageBox.Show("La fecha minima no debe de ser mayor que la máxima");
                dtpfechaentradaHasta.Value = DateTime.Today;
            }
            actualizarDGV();
        }

        private void dtpfechaentradaHasta_ValueChanged(object sender, EventArgs e)
        {
            actualizarDGV();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtDni.Text = "";
            cmbLocalidad.SelectedIndex = 0;
            cmbCentro.SelectedIndex = -1;
            dtpfechaentradaDesde.Value = DateTime.Now;
            dtpfechaentradaHasta.Value = DateTime.Now;
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            if (dgvContrato.SelectedCells.Count > 0)
            {
                idcontrato = Convert.ToInt32(dgvContrato.SelectedCells[1].Value.ToString());
                InformeContrato informe = new InformeContrato(idcontrato);
                informe.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecciona un registro");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvContrato.SelectedCells.Count > 0)
            {
                idcliente = Convert.ToInt32(dgvContrato.SelectedCells[0].Value.ToString());
                idcontrato = Convert.ToInt32(dgvContrato.SelectedCells[1].Value.ToString());
                AnadirContrato anadir = new AnadirContrato(true, idcliente, idcontrato);
                anadir.ShowDialog();
                actualizarDGV();
            }
            else
            {
                MessageBox.Show("Selecciona un registro");
            }
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {

            IUClientes cliente = new IUClientes(true);
            cliente.WindowState = FormWindowState.Normal;
            cliente.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            cliente.btnAnadir.Visible = false;
            cliente.btnInforme.Visible = false;
            cliente.btnModificar.Visible = false;
            cliente.lbInformacion.Visible = true;
            cliente.btnAñadirclientepresu.Visible = true;
            cliente.ShowDialog();
            actualizarDGV();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
