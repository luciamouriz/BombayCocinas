using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

namespace AplicacionCocinas
{
    public partial class InformeCliente : Form
    {
        ConexionSQLServer conexion;
        private int idCliente;

        public InformeCliente(int idcliente)
        {
            InitializeComponent();
            conexion = new ConexionSQLServer();
            idCliente = idcliente;
            cargarInforme();
            
        }

        public void cargarInforme()
        {
            DataSet datasetCliente = new DataSet();
            DataTable tablaCliente = new DataTable();
            tablaCliente.Columns.Add("nombre", Type.GetType("System.String"));
            tablaCliente.Columns.Add("apellido", Type.GetType("System.String"));
            tablaCliente.Columns.Add("direccion", Type.GetType("System.String"));
            tablaCliente.Columns.Add("dni", Type.GetType("System.String"));
            tablaCliente.Columns.Add("poblacion", Type.GetType("System.String"));
            tablaCliente.Columns.Add("telmovil", Type.GetType("System.String"));
            tablaCliente.Columns.Add("telfijo", Type.GetType("System.String"));
            tablaCliente.Columns.Add("email", Type.GetType("System.String"));
            tablaCliente.Columns.Add("vendedor", Type.GetType("System.String"));
            tablaCliente.Columns.Add("centro", Type.GetType("System.String"));
            tablaCliente.Columns.Add("fechaentrada", Type.GetType("System.DateTime"));
            tablaCliente.Columns.Add("fechamontaje", Type.GetType("System.String"));
            tablaCliente.Columns.Add("conocido", Type.GetType("System.String"));
            tablaCliente.Columns.Add("modcocina", Type.GetType("System.String"));
            tablaCliente.Columns.Add("modencimera", Type.GetType("System.String"));
            tablaCliente.Columns.Add("colorcocina", Type.GetType("System.String"));
            tablaCliente.Columns.Add("colorencimera", Type.GetType("System.String"));
            tablaCliente.Columns.Add("tirador", Type.GetType("System.String"));
            tablaCliente.Columns.Add("zocalo", Type.GetType("System.String"));
            tablaCliente.Columns.Add("cornisa", Type.GetType("System.String"));
            tablaCliente.Columns.Add("tapaluz", Type.GetType("System.String"));
            tablaCliente.Columns.Add("placa", Type.GetType("System.String"));
            tablaCliente.Columns.Add("horno", Type.GetType("System.String"));
            tablaCliente.Columns.Add("lavavajillas", Type.GetType("System.String"));
            tablaCliente.Columns.Add("lavadora", Type.GetType("System.String"));
            tablaCliente.Columns.Add("microondas", Type.GetType("System.String"));
            tablaCliente.Columns.Add("frigorifico", Type.GetType("System.String"));
            tablaCliente.Columns.Add("fregadero", Type.GetType("System.String"));
            tablaCliente.Columns.Add("campana", Type.GetType("System.String"));
            tablaCliente.Columns.Add("congelador", Type.GetType("System.String"));
            tablaCliente.Columns.Add("caldera", Type.GetType("System.String"));
            tablaCliente.Columns.Add("observaciones", Type.GetType("System.String"));


            datasetCliente = conexion.SelectDataSet("SELECT dbo.Clientes.nombre, dbo.Clientes.apellidos, dbo.Clientes.direccion, dbo.Clientes.dni, dbo.Clientes.telmovil, dbo.Clientes.telfijo, dbo.Clientes.email, "
                     +" dbo.Clientes.conocido, dbo.Clientes.observaciones, dbo.Entrevista.tapaluz, dbo.Entrevista.cornisa, dbo.Entrevista.zocalo, dbo.Entrevista.tirador, "
                     +" dbo.Entrevista.colorencimera, dbo.Entrevista.modencimera, dbo.Entrevista.colorcocina, dbo.Entrevista.modcocina, dbo.Entrevista.frigorifico, "
                     +" dbo.Entrevista.congelador, dbo.Entrevista.horno, dbo.Entrevista.placa, dbo.Entrevista.campana, dbo.Entrevista.microondas, dbo.Entrevista.caldera, "
                     +" dbo.Entrevista.lavadora, dbo.Entrevista.fregadero, dbo.Entrevista.lavavajillas, dbo.Entrevista.centro, dbo.Entrevista.fechamontaje, dbo.Entrevista.fechaentrada, "
                     +" dbo.Entrevista.numvendedor, dbo.Localidades.descripcion "
                     +"FROM  dbo.Clientes INNER JOIN dbo.Entrevista ON dbo.Clientes.idcliente = dbo.Entrevista.refcliente INNER JOIN "
                     + " dbo.Localidades ON dbo.Clientes.reflocalidad = dbo.Localidades.idlocalidad WHERE dbo.Clientes.idcliente="+idCliente, "tablaCliente");

            DataTable tabla2 = datasetCliente.Tables["tablaCliente"];
            foreach (DataRow row in tabla2.Rows)
            {
                tablaCliente.Rows.Add(new Object[] { row["nombre"], row["apellidos"], row["direccion"]
                    , row["dni"], row["descripcion"], row["telmovil"], row["telfijo"]
                    , row["email"], row["numvendedor"], row["centro"], row["fechaentrada"], row["fechamontaje"]
                    , row["conocido"], row["modcocina"], row["modencimera"], row["colorcocina"], row["colorencimera"]
                    , row["tirador"], row["zocalo"], row["cornisa"], row["tapaluz"], row["placa"]
                    , row["horno"] , row["lavavajillas"], row["lavadora"], row["microondas"], row["frigorifico"]
                    , row["fregadero"], row["campana"], row["congelador"], row["caldera"], row["observaciones"]});
            }


            crvCliente.ShowGroupTreeButton = false;
            crvCliente.ShowParameterPanelButton = false;
            Cliente.crClientes mireporte = new Cliente.crClientes();
            mireporte.Database.Tables["clientes"].SetDataSource(tablaCliente);
            crvCliente.ReportSource = mireporte;

            //OTRO METODO PARA RELLENAR DESDE UN PROCEDIMIENTO.
            //LO MALO QUE TIENES QUE PONER LA CONTRASEÑA SIEMPRE QUE QUIERAS IMPRIMIR
            //ParameterDiscreteValue crtParamDiscreteValue;
            //ParameterValues dato1;
            //crClientes reporte;

            //dato1 = new ParameterValues();
            //reporte = new crClientes();
            //crtParamDiscreteValue = new ParameterDiscreteValue();

            //crtParamDiscreteValue.Value = idCliente;
            //dato1.Add(crtParamDiscreteValue);
            //reporte.DataDefinition.ParameterFields["@IDCLIENTE"].ApplyCurrentValues(dato1);
            //crvCliente.ShowGroupTreeButton= false;
            //crvCliente.ShowParameterPanelButton = false;
            
            //crvCliente.ReportSource = reporte;
            //crvCliente.Refresh();


        }
    }
}
