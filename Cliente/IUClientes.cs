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
    public partial class IUClientes : Form
    {
        ConexionSQLServer conexion;
        MetodosComunes funciones;
        private int idcliente = 0;
        private Boolean Ventana;

        public IUClientes(Boolean ventana)
        {
            InitializeComponent();
            DoubleBuffered = true;
            Ventana = ventana;
            conexion = new ConexionSQLServer();
            funciones = new MetodosComunes();
            actualizarDGV();
            conexion.rellenacombobox(cmbLocalidad, "select idlocalidad, descripcion from localidades order by descripcion", "--Seleccionar Localidad--");
        }

        private void actualizarDGV()
        {
            String consulta = "SELECT dbo.Clientes.idcliente, dbo.Clientes.nombre AS Nombre, dbo.Clientes.apellidos AS Apellidos, dbo.Clientes.dni AS Dni, "
            + "dbo.Clientes.direccion AS Dirección, dbo.Localidades.descripcion AS Localidad, dbo.Clientes.telmovil AS Movil, dbo.Entrevista.fechaentrada AS [Fecha Entrada], "
            + "dbo.Entrevista.centro AS Centro "
            + "FROM dbo.Clientes INNER JOIN dbo.Entrevista ON dbo.Clientes.idcliente = dbo.Entrevista.refcliente INNER JOIN "
            + "dbo.Localidades ON dbo.Clientes.reflocalidad = dbo.Localidades.idlocalidad WHERE dbo.Clientes.dni!='' ";

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
                consulta = consulta + " and dbo.Entrevista.fechaentrada between '" + dtpfechaentradaDesde.Value.Date + "' and '" + dtpfechaentradaHasta.Value.Date + "'";
            }
            consulta = consulta + " ORDER BY Nombre";
            Console.WriteLine(consulta);
            conexion.rellenaDGV(dgvClientes, consulta);
            funciones.estilodgv(dgvClientes);
            dgvClientes.Columns[0].Visible = false;
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            AnadirCliente anadir = new AnadirCliente(false, idcliente);
            anadir.ShowDialog();
            actualizarDGV();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedCells.Count > 0)
            {
                idcliente = Convert.ToInt32(dgvClientes.SelectedCells[0].Value.ToString());
                AnadirCliente anadir = new AnadirCliente(true, idcliente);
                anadir.ShowDialog();
                actualizarDGV();
            }
            else
            {
                MessageBox.Show("Selecciona un registro");
            }
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedCells.Count > 0)
            {
                idcliente = Convert.ToInt32(dgvClientes.SelectedCells[0].Value.ToString());
                InformeCliente informe = new InformeCliente(idcliente);
                informe.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecciona un registro");
            }
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cmbCentro_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedCells.Count > 0)
            {
                idcliente = Convert.ToInt32(dgvClientes.SelectedCells[0].Value.ToString());
                Presupuesto.AnadirPresupuesto presupuesto = new Presupuesto.AnadirPresupuesto(false, idcliente, 0);
                presupuesto.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecciona un Cliente");
            }

        }

        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idcliente = Convert.ToInt32(dgvClientes.SelectedCells[0].Value.ToString());
            if(Ventana==true){
                AnadirContrato contrato = new AnadirContrato(false,idcliente,0);
                contrato.ShowDialog();
                this.Close();
            }
            else
            {
                Presupuesto.AnadirPresupuesto presupuesto = new Presupuesto.AnadirPresupuesto(false, idcliente, 0);
                presupuesto.ShowDialog();
                this.Close();
            }
            
        }

        private void btnAñadirclientepresu_Click(object sender, EventArgs e)
        {
            idcliente = Convert.ToInt32(dgvClientes.SelectedCells[0].Value.ToString());
            if (Ventana == true)
            {
                AnadirContrato contrato = new AnadirContrato(false, idcliente,0);
                contrato.ShowDialog();
                this.Close();
            }
            else
            {
                Presupuesto.AnadirPresupuesto presupuesto = new Presupuesto.AnadirPresupuesto(false, idcliente, 0);
                presupuesto.ShowDialog();
                this.Close();
            }
            
        }

    }
}
