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
    public partial class AnadirContrato : Form
    {
        private ConexionSQLServer consultas;
        private int RefContrato;
        private Boolean Modificar;
        private MetodosComunes funciones;
        private List<String> listaEliminar;
        private int RefCliente;
        private int idcontrato;

        public AnadirContrato(Boolean modificar, int idcliente, int idcontrato)
        {
            InitializeComponent();
            DoubleBuffered = true;
            consultas = new ConexionSQLServer();
            funciones = new MetodosComunes();
            listaEliminar = new List<String>();
            RefContrato = idcontrato;
            RefCliente = idcliente;
            Modificar = modificar;
            rellenarDatosCliente();
            if (Modificar == true)
            {
                rellenarDatosContrato();
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtAccesorios.Text == "")
            {
                MessageBox.Show("Tienes que escribir un nombre accesorio");
            }
            else
            {
                lbxAccesorios.Items.Add(txtAccesorios.Text);
                txtAccesorios.Text = "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Modificar == true)
            {
                if (lbxAccesorios.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecciona antes Nombre Accesorio");
                }
                else
                {
                    String[] arrayId = Convert.ToString(lbxAccesorios.SelectedItem).Split(' ');
                    listaEliminar.Add("DELETE FROM [Bombay_Cocinas].[dbo].[Contra_Accesorios] WHERE"
                    + " idaccesorio=" + arrayId[0] + " and refcontrato=" + RefContrato);
                    lbxAccesorios.Items.Remove(lbxAccesorios.SelectedItem);
                }
            }
            else
            {
                if (lbxAccesorios.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecciona antes Nombre Accesorio");
                }
                else
                {
                    lbxAccesorios.Items.Remove(lbxAccesorios.SelectedItem);
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtModcocina.Text == "" || txtAcabCanto.Text == "" || txtColor.Text == "" || txtZocalo.Text == "" ||
                  txtCanto.Text == "" || txtModtirador.Text == "" || txtColtirador.Text == "" || txtPerfil.Text == "" || txtCristal.Text == "" || txtModencimeras.Text == "" || txtAcabCanto.Text == "" ||
                    txtGrosor.Text == "" || txtAcabcopete.Text == "" || txtColfrega.Text == "" || txtTipo.Text == "" || txtCornisa.Text == "" || txtCubreluz.Text == "" || txtPvpmueble.Text == "" || txtPvpencimera.Text == "")
            {
                MessageBox.Show("Te has dejado algun campo vacio \n ");
            }
            else
            {
                if (Modificar == true)
                {
                    ModificarDescripcionAccesorios();

                    String updateContrato = "UPDATE [Bombay_Cocinas].[dbo].[Contrato] SET  "
                    + " [modcocina] = '" + txtModcocina.Text + "',[color] ='" + txtColor.Text + "',[acab_casco] ='" + txtAcabCocina.Text + "' ,[canto_puerta] = '" + txtCanto.Text
                    + "',[modtirador] ='" + txtModtirador.Text + "' ,[coloc_tirador] ='" + txtColtirador.Text + "',[aper_puerta] ='" + elegirAperturaPuerta() + "',[perfil_vitrina] ='" + txtPerfil.Text
                    + "',[cristal_vitrina] ='" + txtCristal.Text + "' ,[modencimera] ='" + txtModencimeras.Text + "' ,[acab_canto] ='" + txtAcabCanto.Text + "' ,[grosor] = '" + txtGrosor.Text
                    + "',[acab_copete] ='" + txtAcabcopete.Text + "',[coloc_frega] ='" + txtColfrega.Text + "' ,[coloc_grifo] = '" + elegirColocacionGrifo() + " ' ,[disp_jabon] = '" + elegirDispJabon()
                    + "',[escurr_tallado] ='" + elegirEscrurridorTallado() + " ' ,[escurr_tipo] ='" + txtTipo.Text + "',[escurr_pos] = '" + elegirPosicion()
                    + "',[elem_zocalo] ='" + txtZocalo.Text + " ',[elem_cornisa] ='" + txtCornisa.Text + "' ,[elem_cubreluz] = '" + txtCubreluz.Text
                    + "',[observaciones] ='" + txtObservaciones.Text + "',[pvpmueble] ='" + txtPvpmueble.Text.Replace(",", ".") + "',[pvpencimera] ='" + txtPvpencimera.Text.Replace(",", ".") + "',[señal] = '" + txtSeñal.Text
                    + "',[fechamontaje] = '" + txtFechamontaje.Text
                    + "' WHERE idcontrato=" + RefContrato;
                    Console.WriteLine(updateContrato);
                    consultas.ejecutarComando(updateContrato);

                    for (int i = 0; i < listaEliminar.Count; i++)
                    {
                        consultas.ejecutarComando(listaEliminar[i]);
                        Console.WriteLine(listaEliminar[i]);
                    }
                    listaEliminar.Clear();
                    MessageBox.Show("Contrato del Cliente " + txtNombre.Text + " actualizado correctamente");
                    this.Close();

                }
                else
                {
                    idcontrato = consultas.sacarIdMaxima("select max(idcontrato) from Contrato") + 1;

                    String insertarContrato = "INSERT INTO [Bombay_Cocinas].[dbo].[Contrato] ([idcontrato] "
                    + ",[refcliente],[modcocina],[color],[acab_casco],[canto_puerta],[modtirador] ,[coloc_tirador],[aper_puerta] "
                    + ",[perfil_vitrina],[cristal_vitrina] ,[modencimera],[acab_canto],[grosor] ,[acab_copete],[coloc_frega],[coloc_grifo] "
                    + ",[disp_jabon],[escurr_tallado],[escurr_tipo],[escurr_pos],[elem_zocalo],[elem_cornisa],[elem_cubreluz],[observaciones] "
                    + ",[pvpmueble],[pvpencimera],[señal],[fechacontrato],[fechamontaje]) "
                    + " VALUES(" + idcontrato + "," + RefCliente + ",'" + txtModcocina.Text + "','" + txtColor.Text + "','" + txtAcabCanto.Text + "','" + txtCanto.Text + "','" + txtModtirador.Text
                    + "','" + txtColtirador.Text + "','" + elegirAperturaPuerta() + "','" + txtPerfil.Text + "','" + txtCristal.Text + "','" + txtModencimeras.Text + "','" + txtAcabCanto.Text
                    + "','" + txtGrosor.Text + "','" + txtAcabcopete.Text + "','" + txtColfrega.Text + "','" + elegirColocacionGrifo() + "','" + elegirDispJabon() + "','" + elegirEscrurridorTallado()
                    + "','" + txtTipo.Text + "','" + elegirPosicion() + "','" + txtZocalo.Text + "','" + txtCornisa.Text + "','" + txtCubreluz.Text + "','" + txtObservaciones.Text
                    + "','" + txtPvpmueble.Text.Replace(",", ".") + "','" + txtPvpencimera.Text.Replace(",", ".") + "','" + txtSeñal.Text + "','" + DateTime.Now.Date + "','" + txtFechamontaje.Text + "')";
                    Console.WriteLine(insertarContrato);
                    consultas.ejecutarComando(insertarContrato);
                    for (int i = 0; i < lbxAccesorios.Items.Count; i++)
                    {
                        insertarAccesorios(i);
                    }
                    MessageBox.Show("Contrato del Cliente " + txtNombre.Text + " añadido correctamente");
                    this.Close();
                }

            }
        }


        private void insertarAccesorios(int i)
        {

            int idaccesorio = consultas.sacarIdMaxima("select max(idaccesorio) from Contra_Accesorios") + 1;
            if (idaccesorio == 0)
            {
                idaccesorio = 1;
            }
            String itemDescripcion = lbxAccesorios.Items[i].ToString();
            String insertItems = "";
            if (Modificar == true)
            {
                insertItems = "INSERT INTO [Bombay_Cocinas].[dbo].[Contra_Accesorios]([idaccesorio],[refcontrato] "
                 + " ,[descripcion]) VALUES(" + idaccesorio + "," + RefContrato + ",'" + itemDescripcion + "')";
                Console.WriteLine("Modificar: " + insertItems);
                consultas.ejecutarComando(insertItems);
            }
            else
            {
                insertItems = "INSERT INTO [Bombay_Cocinas].[dbo].[Contra_Accesorios]([idaccesorio],[refcontrato] "
                 + " ,[descripcion]) VALUES(" + idaccesorio + "," + idcontrato + ",'" + itemDescripcion + "')";
                Console.WriteLine("Insertar: " + insertItems);
                consultas.ejecutarComando(insertItems);

            }


        }

        //Elegir RadioButtons
        private String elegirAperturaPuerta()
        {
            String res = "";
            if (rbAperturaSI.Checked)
            {
                res = "Si";
            }
            if (rbAperturaNO.Checked)
            {
                res = "No";
            }
            return res;
        }

        private String elegirColocacionGrifo()
        {
            String res = "";
            if (rbColGrifoDere.Checked)
            {
                res = "Derecha";
            }
            if (rbColGrifoCentro.Checked)
            {
                res = "Centro";
            }
            if (rbColGrifoIzq.Checked)
            {
                res = "Izquierda";
            }
            return res;
        }

        private String elegirDispJabon()
        {
            String res = "";
            if (rbDispSI.Checked)
            {
                res = "Si";
            }
            if (rbDispNO.Checked)
            {
                res = "No";
            }
            return res;
        }

        private String elegirEscrurridorTallado()
        {
            String res = "";
            if (rbEscurrSI.Checked)
            {
                res = "Si";
            }
            if (rbEscurrNO.Checked)
            {
                res = "No";
            }
            return res;
        }

        private String elegirPosicion()
        {
            String res = "";
            if (rbPosDere.Checked)
            {
                res = "Derecha";
            }
            if (rbPosIzq.Checked)
            {
                res = "Izquierda";
            }
            return res;
        }

        //RELLENAR DATOS
        private void rellenarDatosCliente()
        {

            txtNombre.Text = consultas.selectstring("select nombre from clientes where idcliente=" + RefCliente);
            txtApellidos.Text = consultas.selectstring("select apellidos from clientes where idcliente=" + RefCliente);
            txtDireccion.Text = consultas.selectstring("select direccion from clientes where idcliente=" + RefCliente);
            txtPoblacion.Text = consultas.selectstring("SELECT dbo.Localidades.descripcion FROM dbo.Clientes INNER JOIN "
                    + " dbo.Localidades ON dbo.Clientes.reflocalidad = dbo.Localidades.idlocalidad where dbo.Clientes.idcliente=" + RefCliente);
            txtTelefono.Text = consultas.selectstring("select telmovil from clientes where idcliente=" + RefCliente);

        }

        private void rellenarDatosContrato()
        {

            //Rellenar Contrato
            txtAcabCanto.Text = consultas.selectstring("select acab_canto from contrato where idcontrato=" + RefContrato);
            txtAcabCocina.Text = consultas.selectstring("select acab_casco from contrato where idcontrato=" + RefContrato);
            txtAcabcopete.Text = consultas.selectstring("select acab_copete from contrato where idcontrato=" + RefContrato);
            txtCanto.Text = consultas.selectstring("select canto_puerta from contrato where idcontrato=" + RefContrato);
            txtColfrega.Text = consultas.selectstring("select coloc_frega from contrato where idcontrato=" + RefContrato);
            txtColor.Text = consultas.selectstring("select color from contrato where idcontrato=" + RefContrato);
            txtColtirador.Text = consultas.selectstring("select coloc_tirador from contrato where idcontrato=" + RefContrato);
            txtCornisa.Text = consultas.selectstring("select elem_cornisa from contrato where idcontrato=" + RefContrato);
            txtCristal.Text = consultas.selectstring("select cristal_vitrina from contrato where idcontrato=" + RefContrato);
            txtCubreluz.Text = consultas.selectstring("select elem_cubreluz from contrato where idcontrato=" + RefContrato);
            txtFechamontaje.Text = consultas.selectstring("select fechamontaje from contrato where idcontrato=" + RefContrato);
            txtGrosor.Text = consultas.selectstring("select grosor from contrato where idcontrato=" + RefContrato);
            txtModcocina.Text = consultas.selectstring("select modcocina from contrato where idcontrato=" + RefContrato);
            txtModencimeras.Text = consultas.selectstring("select modencimera from contrato where idcontrato=" + RefContrato);
            txtModtirador.Text = consultas.selectstring("select modtirador from contrato where idcontrato=" + RefContrato);
            txtObservaciones.Text = consultas.selectstring("select observaciones from contrato where idcontrato=" + RefContrato);
            txtPerfil.Text = consultas.selectstring("select perfil_vitrina from contrato where idcontrato=" + RefContrato);
            txtPvpencimera.Text = consultas.selectstring("select pvpencimera from contrato where idcontrato=" + RefContrato);
            txtPvpmueble.Text = consultas.selectstring("select pvpmueble from contrato where idcontrato=" + RefContrato);
            txtSeñal.Text = consultas.selectstring("select señal from contrato where idcontrato=" + RefContrato);
            txtTipo.Text = consultas.selectstring("select escurr_tipo from contrato where idcontrato=" + RefContrato);
            txtZocalo.Text = consultas.selectstring("select elem_zocalo from contrato where idcontrato=" + RefContrato);

            //RadioButtons
            String aperturaPuerta = consultas.selectstring("select aper_puerta from contrato where idcontrato=" + RefContrato);
            String colocacionGrifo = consultas.selectstring("select coloc_grifo from contrato where idcontrato=" + RefContrato);
            String dispensadorJabon = consultas.selectstring("select disp_jabon from contrato where idcontrato=" + RefContrato);
            String escurrTallado = consultas.selectstring("select escurr_tallado from contrato where idcontrato=" + RefContrato);
            String posicion = consultas.selectstring("select escurr_pos from contrato where idcontrato=" + RefContrato);

            if (aperturaPuerta.Trim().Equals(rbAperturaSI.Text))
            {
                rbAperturaSI.Checked = true;
            }
            if (aperturaPuerta.Trim().Equals(rbAperturaNO.Text))
            {
                rbAperturaNO.Checked = true;
            }
            if (colocacionGrifo.Trim().Equals(rbColGrifoCentro.Text))
            {
                rbColGrifoCentro.Checked = true;
            }
            if (colocacionGrifo.Trim().Equals(rbColGrifoDere.Text))
            {
                rbColGrifoDere.Checked = true;
            }
            if (colocacionGrifo.Trim().Equals(rbColGrifoIzq.Text))
            {
                rbColGrifoIzq.Checked = true;
            }
            if (dispensadorJabon.Trim().Equals(rbDispSI.Text))
            {
                rbDispSI.Checked = true;
            }
            if (dispensadorJabon.Trim().Equals(rbDispNO.Text))
            {
                rbDispNO.Checked = true;
            }
            if (escurrTallado.Trim().Equals(rbEscurrSI.Text))
            {
                rbEscurrSI.Checked = true;
            }
            if (escurrTallado.Trim().Equals(rbEscurrNO.Text))
            {
                rbEscurrNO.Checked = true;
            }
            if (posicion.Trim().Equals(rbPosDere.Text))
            {
                rbPosDere.Checked = true;
            }
            if (posicion.Trim().Equals(rbPosIzq.Text))
            {
                rbPosIzq.Checked = true;
            }

            //Accesorios
            consultas.rellenarLbx(lbxAccesorios, "select idaccesorio, descripcion from Contra_Accesorios where refcontrato=" + RefContrato);

        }

        private void ModificarDescripcionAccesorios()
        {

            for (int i = 0; i < lbxAccesorios.Items.Count; i++)
            {
                String itemDescripcion = lbxAccesorios.Items[i].ToString();
                String[] idaccesorioListBox = itemDescripcion.Split(' ');
                String idAccesorioDisponible = consultas.selectstring("select idaccesorio from Contra_Accesorios where refcontrato=" + RefContrato + " and idaccesorio= " + idaccesorioListBox[0]);
                if (idAccesorioDisponible.Equals(""))
                {
                    insertarAccesorios(i);
                }

            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtModcocina.Text = "";
            txtModencimeras.Text = "";
            txtModtirador.Text = "";
            txtObservaciones.Text = "";
            txtAcabCanto.Text = "";
            txtAcabCocina.Text = "";
            txtAcabcopete.Text = "";
            txtAccesorios.Text = "";
            txtCanto.Text = "";
            txtColfrega.Text = "";
            txtColor.Text = "";
            txtColtirador.Text = "";
            txtCornisa.Text = "";
            txtCristal.Text = "";
            txtCubreluz.Text = "";
            txtFechamontaje.Text = "";
            txtGrosor.Text = "";
            txtPerfil.Text = "";
            txtPvpencimera.Text = "";
            txtPvpmueble.Text = "";
            txtSeñal.Text = "";
            txtTipo.Text = "";
            txtZocalo.Text = "";
            rbAperturaSI.Checked = true;
            rbColGrifoDere.Checked = true;
            rbDispSI.Checked = true;
            rbEscurrSI.Checked = true;
            rbPosDere.Checked = true;
           
        }

        private void txtPvpmueble_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.escribirSoloDoubles(e, "Pvp Mueble:", txtPvpmueble, lbError, 1000, 1000);
        }

        private void txtPvpencimera_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.escribirSoloDoubles(e, "Pvp Encimera:", txtPvpencimera, lbError, 1000, 1000);
        }

        private void txtSeñal_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.escribirSoloDoubles(e, "Señal:", txtSeñal, lbError, 1000, 1000);
        }
    }
}
