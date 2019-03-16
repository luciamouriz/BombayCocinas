using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionCocinas.Presupuesto
{
    public partial class InformePresupuesto : Form
    {
        ConexionSQLServer conexion;
        private int idPresupuesto;

        public InformePresupuesto(int idpresupuesto)
        {
            InitializeComponent();
            conexion = new ConexionSQLServer();
            idPresupuesto = idpresupuesto;
            cargarInforme();
        }


        public void cargarInforme()
        {

            DataSet datasetCliente = new DataSet();
            DataTable tablaCliente = new DataTable();
            tablaCliente.Columns.Add("nombre", Type.GetType("System.String"));
            tablaCliente.Columns.Add("apellidos", Type.GetType("System.String"));
            tablaCliente.Columns.Add("direccion", Type.GetType("System.String"));
            tablaCliente.Columns.Add("telefono", Type.GetType("System.String"));
            tablaCliente.Columns.Add("idpresupuesto", Type.GetType("System.String"));
            tablaCliente.Columns.Add("fechapresupuesto", Type.GetType("System.DateTime"));
            tablaCliente.Columns.Add("poblacion", Type.GetType("System.String"));
            tablaCliente.Columns.Add("modelo", Type.GetType("System.String"));
            tablaCliente.Columns.Add("acabado", Type.GetType("System.String"));
            tablaCliente.Columns.Add("colorinterior", Type.GetType("System.String"));
            tablaCliente.Columns.Add("tirador", Type.GetType("System.String"));
            tablaCliente.Columns.Add("zocalo", Type.GetType("System.String"));
            tablaCliente.Columns.Add("calidades", Type.GetType("System.String"));

            datasetCliente = conexion.SelectDataSet("SELECT dbo.Localidades.descripcion AS poblacion, dbo.Clientes.nombre, dbo.Clientes.apellidos, dbo.Clientes.direccion, "
            + " dbo.Clientes.telmovil, dbo.Presupuesto.modelo, dbo.Presupuesto.acabado, dbo.Presupuesto.colorinterior, dbo.Presu_Calidades.descripcion As calidades, "
            + " dbo.Presupuesto.tirador, dbo.Presupuesto.zocalo, dbo.Presupuesto.fechapresupuesto, dbo.Presupuesto.idpresupuesto "
            + " FROM  dbo.Clientes INNER JOIN dbo.Localidades ON dbo.Clientes.reflocalidad = dbo.Localidades.idlocalidad INNER JOIN "
            + " dbo.Presupuesto ON dbo.Clientes.idcliente = dbo.Presupuesto.refcliente INNER JOIN "
            + " dbo.Presu_Calidades ON dbo.Presupuesto.refcalidad = dbo.Presu_Calidades.idcalidad WHERE dbo.Presupuesto.idpresupuesto=" + idPresupuesto, "tablaCliente");

            DataTable tabla2 = datasetCliente.Tables["tablaCliente"];
            foreach (DataRow row in tabla2.Rows)
            {
                tablaCliente.Rows.Add(new Object[] { row["nombre"], row["apellidos"], row["direccion"]
                    , row["telmovil"], row["idpresupuesto"], row["fechapresupuesto"], row["poblacion"]
                    , row["modelo"], row["acabado"], row["colorinterior"], row["tirador"], row["zocalo"]
                    , row["calidades"]});
            }

            DataSet datasetEncimeras = new DataSet();
            DataTable tablaEncimeras = new DataTable();

            tablaEncimeras.Columns.Add("descencimera", Type.GetType("System.String"));
            tablaEncimeras.Columns.Add("precioencimera", Type.GetType("System.Decimal"));
            tablaEncimeras.Columns.Add("idencimera", Type.GetType("System.String"));

            datasetEncimeras = conexion.SelectDataSet("SELECT dbo.Presu_DetalleEncimera.descripcion AS descripcion, dbo.Presu_DetalleEncimera.precio AS precio,dbo.Presu_Encimeras.idencimera "
                 + "  FROM dbo.Presu_DetalleEncimera INNER JOIN dbo.Presu_Encimeras ON dbo.Presu_DetalleEncimera.refencimera = dbo.Presu_Encimeras.idencimera WHERE dbo.Presu_Encimeras.refpresupuesto=" + idPresupuesto, "tablaEncimeras");

            DataTable tabla3 = datasetEncimeras.Tables["tablaEncimeras"];
            foreach (DataRow row in tabla3.Rows)
            {
                tablaEncimeras.Rows.Add(new Object[] { row["descripcion"], row["precio"], row["idencimera"] });
            }


            DataSet datasetSistemaExtraible= new DataSet();
            DataTable tablaSistemaExtraible = new DataTable();

            tablaSistemaExtraible.Columns.Add("descsisextraible", Type.GetType("System.String"));
            tablaSistemaExtraible.Columns.Add("preciosisextraible", Type.GetType("System.Decimal"));
            tablaSistemaExtraible.Columns.Add("idextraible", Type.GetType("System.String"));

            datasetSistemaExtraible = conexion.SelectDataSet("SELECT descripcion, precio, idextraible "
                + " FROM dbo.Presu_Sisextraible WHERE dbo.Presu_Sisextraible.refpresupuesto=" + idPresupuesto, "tablaSistemaExtraible");

            DataTable tabla4 = datasetSistemaExtraible.Tables["tablaSistemaExtraible"];
            foreach (DataRow row in tabla4.Rows)
            {
                tablaSistemaExtraible.Rows.Add(new Object[] { row["descripcion"], row["precio"], row["idextraible"] });
            }

            DataSet datasetPrecioMobiliario = new DataSet();
            DataTable tablaPrecioMobiliario = new DataTable();

            tablaPrecioMobiliario.Columns.Add("descmobiliario", Type.GetType("System.String"));
            tablaPrecioMobiliario.Columns.Add("preciomobiliario", Type.GetType("System.Decimal"));

            datasetPrecioMobiliario = conexion.SelectDataSet("SELECT descripcion, precio "
                +" FROM dbo.Presu_Precio WHERE refpresupuesto=" + idPresupuesto, "tablaPrecioMobiliario");

            DataTable tabla5 = datasetPrecioMobiliario.Tables["tablaPrecioMobiliario"];
            foreach (DataRow row in tabla5.Rows)
            {
                tablaPrecioMobiliario.Rows.Add(new Object[] { row["descripcion"], row["precio"]});
            }

            crvPresupuesto.ShowGroupTreeButton = false;
            crvPresupuesto.ShowParameterPanelButton = false;
            crPresupuesto mireporte = new crPresupuesto();
            mireporte.Database.Tables["presupuesto"].SetDataSource(tablaCliente);
            mireporte.Database.Tables["encimeras"].SetDataSource(tablaEncimeras);
            mireporte.Database.Tables["sisextraibles"].SetDataSource(tablaSistemaExtraible);
            mireporte.Database.Tables["precio"].SetDataSource(tablaPrecioMobiliario);
            crvPresupuesto.ReportSource = mireporte;

        }
    }
}
