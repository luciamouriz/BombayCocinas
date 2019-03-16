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
    public partial class InformeContrato : Form
    {
        ConexionSQLServer conexion;
        private int idContrato;

        public InformeContrato(int idcontrato)
        {
            InitializeComponent();
            conexion = new ConexionSQLServer();
            idContrato = idcontrato;
            cargarInforme();
        }

        public void cargarInforme()
        {
            DataSet datasetContrato = new DataSet();
            DataTable tablaContrato = new DataTable();
            tablaContrato.Columns.Add("nombrecliente", Type.GetType("System.String"));
            tablaContrato.Columns.Add("apellidoscliente", Type.GetType("System.String"));
            tablaContrato.Columns.Add("direccion", Type.GetType("System.String"));
            tablaContrato.Columns.Add("telefono", Type.GetType("System.String"));
            tablaContrato.Columns.Add("dni", Type.GetType("System.String"));
            tablaContrato.Columns.Add("fechacontrato", Type.GetType("System.DateTime"));
            tablaContrato.Columns.Add("poblacion", Type.GetType("System.String"));
            tablaContrato.Columns.Add("modcocina", Type.GetType("System.String"));
            tablaContrato.Columns.Add("color", Type.GetType("System.String"));
            tablaContrato.Columns.Add("acab_casco", Type.GetType("System.String"));
            tablaContrato.Columns.Add("canto_puerta", Type.GetType("System.String"));
            tablaContrato.Columns.Add("modtirador", Type.GetType("System.String"));
            tablaContrato.Columns.Add("coloc_tirador", Type.GetType("System.String"));
            tablaContrato.Columns.Add("aper_puerta", Type.GetType("System.String"));
            tablaContrato.Columns.Add("perfil_vitrina", Type.GetType("System.String"));
            tablaContrato.Columns.Add("cristal_vitrina", Type.GetType("System.String"));
            tablaContrato.Columns.Add("modencimera", Type.GetType("System.String"));
            tablaContrato.Columns.Add("acab_canto", Type.GetType("System.String"));
            tablaContrato.Columns.Add("grosor", Type.GetType("System.String"));
            tablaContrato.Columns.Add("acab_copete", Type.GetType("System.String"));
            tablaContrato.Columns.Add("coloc_frega", Type.GetType("System.String"));
            tablaContrato.Columns.Add("coloc_grifo", Type.GetType("System.String"));
            tablaContrato.Columns.Add("disp_jabon", Type.GetType("System.String"));
            tablaContrato.Columns.Add("escurr_tallado", Type.GetType("System.String"));
            tablaContrato.Columns.Add("escurr_tipo", Type.GetType("System.String"));
            tablaContrato.Columns.Add("escurr_pos", Type.GetType("System.String"));
            tablaContrato.Columns.Add("elem_zocalo", Type.GetType("System.String"));
            tablaContrato.Columns.Add("elem_cornisa", Type.GetType("System.String"));
            tablaContrato.Columns.Add("elem_cubreluz", Type.GetType("System.String"));
            tablaContrato.Columns.Add("observaciones", Type.GetType("System.String"));
            tablaContrato.Columns.Add("pvpmueble", Type.GetType("System.Decimal"));
            tablaContrato.Columns.Add("pvpencimera", Type.GetType("System.Decimal"));
            tablaContrato.Columns.Add("señal", Type.GetType("System.Decimal"));
            tablaContrato.Columns.Add("fechamontaje", Type.GetType("System.String"));


            datasetContrato = conexion.SelectDataSet("SELECT dbo.Contrato.modcocina, dbo.Contrato.color, dbo.Contrato.acab_casco, dbo.Contrato.canto_puerta, dbo.Contrato.modtirador, dbo.Contrato.coloc_tirador, "
                     +" dbo.Contrato.aper_puerta, dbo.Contrato.cristal_vitrina, dbo.Contrato.perfil_vitrina, dbo.Contrato.escurr_tipo, dbo.Contrato.escurr_tallado, dbo.Contrato.disp_jabon, "
                     +" dbo.Contrato.coloc_grifo, dbo.Contrato.coloc_frega, dbo.Contrato.acab_copete, dbo.Contrato.grosor, dbo.Contrato.acab_canto, dbo.Contrato.modencimera, "
                     +" dbo.Contrato.observaciones, dbo.Contrato.elem_cubreluz, dbo.Contrato.elem_cornisa, dbo.Contrato.elem_zocalo, dbo.Contrato.escurr_pos, "
                     +" dbo.Contrato.fechacontrato, dbo.Contrato.señal, dbo.Contrato.pvpencimera, dbo.Contrato.pvpmueble, dbo.Contrato.fechamontaje, dbo.Contrato.refcliente, "
                     +" dbo.Contrato.idcontrato, dbo.Clientes.nombre, dbo.Clientes.apellidos, dbo.Clientes.direccion, dbo.Localidades.descripcion, dbo.Clientes.dni, "
                     +" dbo.Clientes.telmovil FROM dbo.Clientes INNER JOIN dbo.Contrato ON dbo.Clientes.idcliente = dbo.Contrato.refcliente INNER JOIN "
                     + " dbo.Localidades ON dbo.Clientes.reflocalidad = dbo.Localidades.idlocalidad WHERE dbo.Contrato.idcontrato="+idContrato,"tablacontrato");

            DataTable tabla2 = datasetContrato.Tables["tablaContrato"];
            foreach (DataRow row in tabla2.Rows)
            {
                tablaContrato.Rows.Add(new Object[] { row["nombre"], row["apellidos"], row["direccion"]
                    , row["telmovil"], row["dni"], row["fechacontrato"], row["descripcion"]
                    , row["modcocina"], row["color"], row["acab_casco"], row["canto_puerta"], row["modtirador"]
                    , row["coloc_tirador"], row["aper_puerta"], row["perfil_vitrina"], row["cristal_vitrina"], row["modencimera"]
                    , row["acab_canto"], row["grosor"], row["acab_copete"], row["coloc_frega"], row["coloc_grifo"]
                    , row["disp_jabon"] , row["escurr_tallado"], row["escurr_tipo"], row["escurr_pos"], row["elem_zocalo"]
                    , row["elem_cornisa"], row["elem_cubreluz"], row["observaciones"], row["pvpmueble"], row["pvpencimera"]
                    , row["señal"], row["fechamontaje"]});
            }

            DataSet datasetAccesorios = new DataSet();
            DataTable tablaAccesorios = new DataTable();

            tablaAccesorios.Columns.Add("accesorio", Type.GetType("System.String"));
            datasetAccesorios = conexion.SelectDataSet("SELECT descripcion, refcontrato FROM dbo.Contra_Accesorios WHERE refcontrato="+idContrato, "tablaAccesorios");
            DataTable tabla3 = datasetAccesorios.Tables["tablaAccesorios"];
            foreach (DataRow row in tabla3.Rows)
            {
                tablaAccesorios.Rows.Add(new Object[] { row["descripcion"] });
            }

            crvContrato.ShowGroupTreeButton = false;
            crvContrato.ShowParameterPanelButton = false;
            Contrato.crContrato mireporte = new Contrato.crContrato();
            mireporte.Database.Tables["contratos"].SetDataSource(tablaContrato);
            mireporte.Database.Tables["accesorios"].SetDataSource(tablaAccesorios);
            crvContrato.ReportSource = mireporte;


        }
    }
}
