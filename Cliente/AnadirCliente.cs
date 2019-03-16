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
    public partial class AnadirCliente : Form
    {

        private ConexionSQLServer consultas;
        private int idCliente;
        private Boolean Modificar;
        private MetodosComunes funciones;

        public AnadirCliente(Boolean modificar, int idcliente)
        {
            InitializeComponent();
            DoubleBuffered = true;
            consultas = new ConexionSQLServer();
            funciones = new MetodosComunes();
            idCliente = idcliente;
            Modificar = modificar;
            consultas.rellenacombobox(cmbLocalidad, "Select idlocalidad, descripcion from localidades order by descripcion", "--Seleccionar Localidad--");
            txtOcampana.Visible = false;
            txtOconge.Visible = false;
            txtOconocido.Visible = false;
            txtOfrega.Visible = false;
            txtOfrigo.Visible = false;
            txtOhornos.Visible = false;
            txtOlavadora.Visible = false;
            txtOlavava.Visible = false;
            txtOmicroondas.Visible = false;
            txtOplaca.Visible = false;
            txtOzocalo.Visible = false;
            dtpFechaentrada.Enabled = false;
            if (modificar == true)
            {
                llenarcamposModificar();
            }

        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (chbxCondiciones.Checked == true)
            {
                if (txtEmail.Text!="")
                {
                    funciones.ComprobarFormatoEmail(txtEmail.Text);
                }
                else
                {
                    if (funciones.comprobarDNI(txtDni.Text.ToUpper()) == false)
                    {
                        MessageBox.Show("Dni incorrecto");
                    }
                    else
                    {
                        if (txtNombre.Text == "" || txtApellidos.Text == "" || cmbLocalidad.SelectedIndex == -1 || txtDni.Text == ""
                            || cmbCentro.SelectedIndex == -1 || txtVendedor.Text == "")
                        {
                            MessageBox.Show("Te has dejado algun campo vacio \n "
                                                + "Nombre \n"
                                                + "Apellidos \n"
                                                + "Localidad \n"
                                                + "Dni \n"
                                                + "Centro \n"
                                                + "Vendedor \n");
                        }
                        else
                        {
                            if (Modificar == true)
                            {
                                String actualizarCliente = "UPDATE [Bombay_Cocinas].[dbo].[Clientes] SET [nombre] = '" + txtNombre.Text
                                + "',[apellidos] = '" + txtApellidos.Text + "',[direccion] = '" + txtDireccion.Text + "',[reflocalidad] = '" + cmbLocalidad.SelectedIndex
                                + "',[dni] = '" + txtDni.Text + "',[telmovil] = " + txtMovil.Text + ",[telfijo] = " + txtFijo.Text
                                + ",[email] = '" + txtEmail.Text + "',[conocido] ='" + textoComboBox(cmbConocido, txtOconocido) + "',[observaciones] = '" + txtObservaciones.Text
                                + "' WHERE idcliente=" + idCliente;

                                Console.WriteLine(actualizarCliente);
                                consultas.ejecutarComando(actualizarCliente);

                                String actualizarCocinas = "UPDATE [Bombay_Cocinas].[dbo].[Entrevista] SET [modcocina] = '" + txtModcocina.Text
                                + "',[colorcocina] = '" + txtColorcocina.Text + "',[modencimera] ='" + txtModencimera.Text + "',[colorencimera] = '" + txtColorencimera.Text
                                + "',[tirador] ='" + txtTirador.Text + "',[zocalo] ='" + textoComboBox(cmbZocalo, txtOzocalo) + "',[cornisa] ='" + txtCornisa.Text
                                + "',[tapaluz] ='" + txtTapaluz.Text + "',[frigorifico] ='" + textoComboBox(cmbFrigo, txtOfrigo) + "',[congelador] = '" + textoComboBox(cmbConge, txtOconge)
                                + "',[horno] ='" + textoComboBox(cmbHorno, txtOhornos) + "',[microondas] ='" + textoComboBox(cmbMicro, txtOmicroondas) + "',[campana] ='" + textoComboBox(cmbCampana, txtOcampana)
                                + "',[placa] ='" + textoComboBox(cmbPlaca, txtOplaca) + "',[lavavajillas] ='" + textoComboBox(cmbLavavajillas, txtOlavava) + "',[fregadero] ='" + textoComboBox(cmbFrega, txtOfrega)
                                + "',[lavadora] ='" + textoComboBox(cmbLavadora, txtOlavadora) + "',[caldera] = '" + txtCaldera.Text + "',[centro] ='" + cmbCentro.SelectedItem
                                + "',[numvendedor] =" + txtVendedor.Text + ",[fechaentrada] ='" + dtpFechaentrada.Value.Date + "',[fechamontaje] ='" + txtFechamontaje.Text
                                + "' WHERE refcliente=" + idCliente;

                                Console.WriteLine(actualizarCocinas);
                                consultas.ejecutarComando(actualizarCocinas);
                                MessageBox.Show("Cliente actualizado correctamente");
                                this.Close();

                            }
                            else
                            {
                                int idcliente = consultas.sacarIdMaxima("select max(idcliente) from clientes") + 1;
                                String insertarCliente = "INSERT INTO [Bombay_Cocinas].[dbo].[Clientes]([idcliente],[nombre],[apellidos],"
                                 + " [direccion],[reflocalidad],[dni],[telmovil],[telfijo],[email],[conocido],[observaciones])"
                                 + " VALUES (" + idcliente + ",'" + txtNombre.Text + "','" + txtApellidos.Text + "','" + txtDireccion.Text + "','" + cmbLocalidad.SelectedIndex
                                 + "','" + txtDni.Text + "','" + txtMovil.Text + "','" + txtFijo.Text + "','" + txtEmail.Text + "','" + textoComboBox(cmbConocido, txtOconocido) + "','" + txtObservaciones.Text + "')";

                                Console.WriteLine(insertarCliente);
                                consultas.ejecutarComando(insertarCliente);

                                int identrevista = consultas.sacarIdMaxima("select max(identrevista) from entrevista") + 1;
                                String insertarCocinas = "INSERT INTO [Bombay_Cocinas].[dbo].[Entrevista]([identrevista],[refcliente],[modcocina] "
                                + ",[colorcocina],[modencimera],[colorencimera],[tirador],[zocalo],[cornisa],[tapaluz],[frigorifico] "
                                + ",[congelador],[horno],[microondas],[campana],[placa],[lavavajillas],[fregadero],[lavadora],[caldera] "
                                + ",[centro],[numvendedor],[fechaentrada] ,[fechamontaje]) VALUES (" + identrevista + "," + idcliente + ",'" + txtModcocina.Text
                                + "','" + txtColorcocina.Text + "','" + txtModencimera.Text + "','" + txtColorencimera.Text + "','" + txtTirador.Text + "','" + textoComboBox(cmbZocalo, txtOzocalo)
                                + "','" + txtCornisa.Text + "','" + txtTapaluz.Text + "','" + textoComboBox(cmbFrigo, txtOfrigo) + "','" + textoComboBox(cmbConge, txtOconge)
                                + "','" + textoComboBox(cmbHorno, txtOhornos) + "','" + textoComboBox(cmbMicro, txtOmicroondas) + "','" + textoComboBox(cmbCampana, txtOcampana)
                                + "','" + textoComboBox(cmbPlaca, txtOplaca) + "','" + textoComboBox(cmbLavavajillas, txtOlavava) + "','" + textoComboBox(cmbFrega, txtOfrega)
                                + "','" + textoComboBox(cmbLavadora, txtOlavadora) + "','" + txtCaldera.Text + "','" + cmbCentro.SelectedItem + "','" + txtVendedor.Text + "','" + dtpFechaentrada.Value.Date
                                + "','" + txtFechamontaje.Text + "')";

                                Console.WriteLine(insertarCocinas);
                                consultas.ejecutarComando(insertarCocinas);
                                MessageBox.Show("Cliente añadido correctamente");
                                this.Close();
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Tienes que aceptar las condiciones");

            }
        }

        public void llenarcamposModificar()
        {
            //Llenar tabla cliente
            txtNombre.Text = consultas.selectstring("select nombre from clientes where idcliente=" + idCliente);
            txtApellidos.Text = consultas.selectstring("select apellidos from clientes where idcliente=" + idCliente);
            txtDireccion.Text = consultas.selectstring("select direccion from clientes where idcliente=" + idCliente);
            cmbLocalidad.SelectedValue = Convert.ToInt32(consultas.selectstring("select reflocalidad from clientes where idcliente=" + idCliente));
            txtDni.Text = consultas.selectstring("select dni from clientes where idcliente=" + idCliente);
            txtMovil.Text = consultas.selectstring("select telmovil from clientes where idcliente=" + idCliente);
            txtFijo.Text = consultas.selectstring("select telfijo from clientes where idcliente=" + idCliente);
            txtEmail.Text = consultas.selectstring("select email from clientes where idcliente=" + idCliente);
            cmbConocido.Text = consultas.selectstring("select conocido from clientes where idcliente=" + idCliente);
            txtObservaciones.Text = consultas.selectstring("select observaciones from clientes where idcliente=" + idCliente);
            txtApellidos.Text = consultas.selectstring("select apellidos from clientes where idcliente=" + idCliente);
         
            //Llenar tabla entrevista
            txtModcocina.Text = consultas.selectstring("select modcocina from entrevista where refcliente=" + idCliente);
            txtColorcocina.Text = consultas.selectstring("select colorcocina from entrevista where refcliente=" + idCliente);
            txtModencimera.Text = consultas.selectstring("select modencimera from entrevista where refcliente=" + idCliente);
            txtColorencimera.Text = consultas.selectstring("select colorencimera from entrevista where refcliente=" + idCliente);
            txtTirador.Text = consultas.selectstring("select tirador from entrevista where refcliente=" + idCliente);
            txtCornisa.Text = consultas.selectstring("select cornisa from entrevista where refcliente=" + idCliente);
            txtTapaluz.Text = consultas.selectstring("select tapaluz from entrevista where refcliente=" + idCliente);
            txtCaldera.Text = consultas.selectstring("select caldera from entrevista where refcliente=" + idCliente);
            cmbCentro.Text = consultas.selectstring("select centro from entrevista where refcliente=" + idCliente);
            txtVendedor.Text = consultas.selectstring("select numvendedor from entrevista where refcliente=" + idCliente);
            txtFechamontaje.Text = consultas.selectstring("select fechamontaje from entrevista where refcliente=" + idCliente);
            dtpFechaentrada.Text = consultas.selectstring("select fechaentrada from entrevista where refcliente=" + idCliente);
            llenarCombobox("zocalo", cmbZocalo, txtOzocalo);
            llenarCombobox("frigorifico", cmbFrigo, txtOfrigo);
            llenarCombobox("congelador", cmbConge, txtOconge);
            llenarCombobox("horno", cmbHorno, txtOhornos);
            llenarCombobox("microondas", cmbMicro, txtOmicroondas);
            llenarCombobox("campana", cmbCampana, txtOcampana);
            llenarCombobox("placa", cmbPlaca, txtOplaca);
            llenarCombobox("lavavajillas", cmbLavavajillas, txtOlavava);
            llenarCombobox("fregadero", cmbFrega, txtOfrega);
            llenarCombobox("lavadora", cmbLavadora, txtOlavadora);
           
        }

        public void llenarCombobox(String campo, ComboBox combo, TextBox textbox){

            String descripcion=consultas.selectstring("select "+campo+" from entrevista where refcliente=" + idCliente);
            Boolean resultado = false;
            for (int i = 0; i < combo.Items.Count; i++ )
            {
                if(descripcion.Equals(combo.Items[i])){
                    combo.Text = descripcion;
                    resultado = true;
                }
                
            }
            if(resultado==false){
                combo.Text = "Otros";
                textbox.Visible = true;
                textbox.Text = descripcion;
            }
           

         }

        public String textoComboBox(ComboBox cmb, TextBox txt)
        {
            String resultado = "";
            if (cmb.SelectedItem == null)
            {
                resultado = "";
            }
            else
            {
                if (cmb.SelectedItem.Equals("Otros"))
                {
                    resultado = txt.Text;
                }
                else
                {
                    resultado = Convert.ToString(cmb.SelectedItem);
                }
            }

            return resultado;
        }

        //PLACEHOLDER Y TEXTBOX OTROS
        private void cmbZocalo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbZocalo.SelectedItem != null)
            {
                if (cmbZocalo.SelectedItem.Equals("Otros"))
                {
                    txtOzocalo.Visible = true;
                    txtOzocalo.Text = "Escribe aqui otro...";
                    txtOzocalo.ForeColor = Color.Gray;
                }
                else
                {
                    txtOzocalo.Visible = false;
                }
            }
        }


        public void placeholderGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Escribe aqui otro...")
                tb.Text = "";
            tb.ForeColor = Color.Black;
        }

        public void placeholderLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
                tb.Text = "Escribe aqui otro...";
            tb.ForeColor = Color.Gray;
        }

        private void AnadirCliente_Load(object sender, EventArgs e)
        {
            txtOconocido.GotFocus += new EventHandler(placeholderGotFocus);
            txtOconocido.LostFocus += new EventHandler(placeholderLostFocus);
            txtOcampana.GotFocus += new EventHandler(placeholderGotFocus);
            txtOcampana.LostFocus += new EventHandler(placeholderLostFocus);
            txtOzocalo.GotFocus += new EventHandler(placeholderGotFocus);
            txtOzocalo.LostFocus += new EventHandler(placeholderLostFocus);
            txtOfrigo.GotFocus += new EventHandler(placeholderGotFocus);
            txtOfrigo.LostFocus += new EventHandler(placeholderLostFocus);
            txtOconge.GotFocus += new EventHandler(placeholderGotFocus);
            txtOconge.LostFocus += new EventHandler(placeholderLostFocus);
            txtOmicroondas.GotFocus += new EventHandler(placeholderGotFocus);
            txtOmicroondas.LostFocus += new EventHandler(placeholderLostFocus);
            txtOlavava.GotFocus += new EventHandler(placeholderGotFocus);
            txtOlavava.LostFocus += new EventHandler(placeholderLostFocus);
            txtOlavadora.GotFocus += new EventHandler(placeholderGotFocus);
            txtOlavadora.LostFocus += new EventHandler(placeholderLostFocus);
            txtOplaca.GotFocus += new EventHandler(placeholderGotFocus);
            txtOplaca.LostFocus += new EventHandler(placeholderLostFocus);
            txtOfrega.GotFocus += new EventHandler(placeholderGotFocus);
            txtOfrega.LostFocus += new EventHandler(placeholderLostFocus);
            txtOhornos.GotFocus += new EventHandler(placeholderGotFocus);
            txtOhornos.LostFocus += new EventHandler(placeholderLostFocus);

        }

        private void cmbFrigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFrigo.SelectedItem != null)
            {
                if (cmbFrigo.SelectedItem.Equals("Otros"))
                {
                    txtOfrigo.Visible = true;
                    txtOfrigo.Text = "Escribe aqui otro...";
                    txtOfrigo.ForeColor = Color.Gray;

                }
                else
                {
                    txtOfrigo.Visible = false;
                }
            }
        }

        private void cmbConge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConge.SelectedItem != null)
            {
                if (cmbConge.SelectedItem.Equals("Otros"))
                {
                    txtOconge.Visible = true;
                    txtOconge.Text = "Escribe aqui otro...";
                    txtOconge.ForeColor = Color.Gray;
                }
                else
                {
                    txtOconge.Visible = false;
                }
            }
        }

        private void cmbHorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHorno.SelectedItem != null)
            {
                if (cmbHorno.SelectedItem.Equals("Otros"))
                {
                    txtOhornos.Visible = true;
                    txtOhornos.Text = "Escribe aqui otro...";
                    txtOhornos.ForeColor = Color.Gray;
                }
                else
                {
                    txtOhornos.Visible = false;
                }
            }
        }

        private void cmbMicro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMicro.SelectedItem != null)
            {
                if (cmbMicro.SelectedItem.Equals("Otros"))
                {
                    txtOmicroondas.Visible = true;
                    txtOmicroondas.Text = "Escribe aqui otro...";
                    txtOmicroondas.ForeColor = Color.Gray;
                }
                else
                {
                    txtOmicroondas.Visible = false;
                }
            }
        }

        private void cmbCampana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCampana.SelectedItem != null)
            {
                if (cmbCampana.SelectedItem.Equals("Otros"))
                {
                    txtOcampana.Visible = true;
                    txtOcampana.Text = "Escribe aqui otro...";
                    txtOcampana.ForeColor = Color.Gray;
                }
                else
                {
                    txtOcampana.Visible = false;
                }
            }
        }

        private void cmbPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlaca.SelectedItem != null)
            {
                if (cmbPlaca.SelectedItem.Equals("Otros"))
                {
                    txtOplaca.Visible = true;
                    txtOplaca.Text = "Escribe aqui otro...";
                    txtOplaca.ForeColor = Color.Gray;
                }
                else
                {
                    txtOplaca.Visible = false;
                }
            }
        }

        private void cmbLavavajillas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLavavajillas.SelectedItem != null)
            {
                if (cmbLavavajillas.SelectedItem.Equals("Otros"))
                {
                    txtOlavava.Visible = true;
                    txtOlavava.Text = "Escribe aqui otro...";
                    txtOlavava.ForeColor = Color.Gray;
                }
                else
                {
                    txtOlavava.Visible = false;
                }
            }
        }

        private void cmbFrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFrega.SelectedItem != null)
            {
                if (cmbFrega.SelectedItem.Equals("Otros"))
                {
                    txtOfrega.Visible = true;
                    txtOfrega.Text = "Escribe aqui otro...";
                    txtOfrega.ForeColor = Color.Gray;
                }
                else
                {
                    txtOfrega.Visible = false;
                }
            }
        }

        private void cmbLavadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLavadora.SelectedItem != null)
            {
                if (cmbLavadora.SelectedItem.Equals("Otros"))
                {
                    txtOlavadora.Visible = true;
                    txtOlavadora.Text = "Escribe aqui otro...";
                    txtOlavadora.ForeColor = Color.Gray;
                }
                else
                {
                    txtOlavadora.Visible = false;
                }
            }
        }

        private void cmbConocido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConocido.SelectedItem != null)
            {
                if (cmbConocido.SelectedItem.Equals("Otros"))
                {
                    txtOconocido.Visible = true;
                    txtOconocido.Text = "Escribe aqui otro...";
                    txtOconocido.ForeColor = Color.Gray;
                }
                else
                {
                    txtOconocido.Visible = false;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCaldera.Text = "";
            txtColorcocina.Text = "";
            txtColorencimera.Text = "";
            txtCornisa.Text = "";
            txtDireccion.Text = "";
            txtDni.Text = "";
            txtEmail.Text = "";
            txtFechamontaje.Text = "";
            txtFijo.Text = "";
            txtModcocina.Text = "";
            txtModencimera.Text = "";
            txtMovil.Text = "";
            txtObservaciones.Text = "";
            txtOcampana.Text = "";
            txtOconge.Text = "";
            txtOconocido.Text = "";
            txtOfrega.Text = "";
            txtOfrigo.Text = "";
            txtOhornos.Text = "";
            txtOlavadora.Text = "";
            txtOlavava.Text = "";
            txtOmicroondas.Text = "";
            txtOplaca.Text = "";
            txtOzocalo.Text = "";
            txtTapaluz.Text = "";
            txtTirador.Text = "";
            txtVendedor.Text = "";
            cmbCampana.SelectedIndex = 0;
            cmbCentro.SelectedIndex = -1;
            cmbHorno.SelectedIndex = 0;
            cmbConocido.SelectedIndex = -1;
            cmbFrega.SelectedIndex = 0;
            cmbConge.SelectedIndex = 0;
            cmbFrigo.SelectedIndex = 0;
            cmbLavadora.SelectedIndex = 0;
            cmbLavavajillas.SelectedIndex = 0;
            cmbLocalidad.SelectedIndex = 0;
            cmbMicro.SelectedIndex = 0;
            cmbPlaca.SelectedIndex = 0;
            cmbZocalo.SelectedIndex = 0;
            txtOcampana.Visible = false;
            txtOconge.Visible = false;
            txtOconocido.Visible = false;
            txtOfrega.Visible = false;
            txtOfrigo.Visible = false;
            txtOhornos.Visible = false;
            txtOlavadora.Visible = false;
            txtOlavava.Visible = false;
            txtOmicroondas.Visible = false;
            txtOplaca.Visible = false;
            txtOzocalo.Visible = false;
            lbError.Text = "";

        }

        private void txtVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.escribirSoloEnterosLimitado(e, "Vendedor:", 2, txtVendedor, lbError);
        }

        private void txtMovil_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.escribirSoloEnterosLimitado(e, "Telefono movil:", 9, txtMovil, lbError);
        }

        private void txtFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.escribirSoloEnterosLimitado(e, "Telefono Fijo:", 9, txtFijo, lbError);
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.limitarCaracteres(e, "Dni:", 9, txtDni, lbError);
        }



    }
}
