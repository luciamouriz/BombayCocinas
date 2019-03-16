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
    public partial class AnadirPresupuesto : Form
    {
        private ConexionSQLServer consultas;
        private int idCliente;
        private Boolean Modificar;
        private MetodosComunes funciones;
        private int idpresupuesto;
        private int Refpresupuesto;
        private int calidad;
        private List<String> listaEliminar;

        public AnadirPresupuesto(Boolean modificar, int idcliente, int presupuesto)
        {
            InitializeComponent();
            DoubleBuffered = true;
            consultas = new ConexionSQLServer();
            funciones = new MetodosComunes();
            listaEliminar = new List<String>();
            idCliente = idcliente;
            Modificar = modificar;
            Refpresupuesto = presupuesto;
            rellenarDatosCliente();
            txtCalidades.Text = consultas.selectstring("select descripcion from Presu_Calidades where idcalidad=" + 1);
            if (Modificar == true)
            {
                rellenarDatosPresupuesto();
            }

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (txtColorMob.Text == "" || txtPrecioMob.Text == "")
            {
                MessageBox.Show("Tienes algun campo vacío: \n"
                                 + "Descripción Mobiliario \n"
                                 + "Precio Mobiliario");
            }
            else
            {
                lbxColorMob.Items.Add(txtColorMob.Text + "-" + txtPrecioMob.Text.Replace(",", "."));
                txtColorMob.Text = "";
                txtPrecioMob.Text = "";
            }

        }

        private void btnEColorMob_Click(object sender, EventArgs e)
        {

            if (Modificar == true)
            {
                if (lbxColorMob.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecciona antes Color-Precio Mobiliario");
                }
                else
                {
                    String[] arrayIdPrecio = Convert.ToString(lbxColorMob.SelectedItem).Split(' ');
                    listaEliminar.Add("DELETE FROM [Bombay_Cocinas].[dbo].[Presu_Precio] WHERE"
                    + " idprecio=" + arrayIdPrecio[0] + " and refpresupuesto=" + Refpresupuesto);
                    lbxColorMob.Items.Remove(lbxColorMob.SelectedItem);
                }

            }
            else
            {
                if (lbxColorMob.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecciona antes Color-Precio Mobiliario");
                }
                else
                {
                    lbxColorMob.Items.Remove(lbxColorMob.SelectedItem);
                }
            }

        }

        private void btnAEncimeras_Click(object sender, EventArgs e)
        {
            if (txtEncimeras.Text == "" || txtPrecioEncimeras.Text == "")
            {
                MessageBox.Show("Tienes algun campo vacío: \n"
                                 + "Descripción Encimera \n"
                                 + "Precio Encimera");

            }
            else
            {
                lbxEncimeras.Items.Add(txtEncimeras.Text + "-" + txtPrecioEncimeras.Text);
                txtEncimeras.Text = "";
                txtPrecioEncimeras.Text = "";
            }

        }

        private void btnEEncimeras_Click(object sender, EventArgs e)
        {
            if (Modificar == true)
            {
                if (lbxEncimeras.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecciona antes Encimera-Precio");
                }
                else
                {
                    String[] arrayId = Convert.ToString(lbxEncimeras.SelectedItem).Split(' ');
                    listaEliminar.Add("DELETE FROM [Bombay_Cocinas].[dbo].[Presu_DetalleEncimera] WHERE"
                   + " refencimera=" + arrayId[0]);
                    listaEliminar.Add("DELETE FROM [Bombay_Cocinas].[dbo].[Presu_Encimeras] WHERE"
                    + " idencimera=" + arrayId[0] + " and refpresupuesto=" + Refpresupuesto);
                    lbxEncimeras.Items.Remove(lbxEncimeras.SelectedItem);
                }
            }
            else
            {
                if (lbxEncimeras.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecciona antes Encimera-Precio");
                }
                else
                {
                    lbxEncimeras.Items.Remove(lbxEncimeras.SelectedItem);
                }
            }

        }

        private void btnASisExtraible_Click(object sender, EventArgs e)
        {
            if (txtNombreSis.Text == "" || txtPrecioSis.Text == "")
            {
                MessageBox.Show("Tienes algun campo vacío: \n"
                                 + "Descripción Sistemas Extraibles \n"
                                 + "Precio Sistemas Extraibles");

            }
            else
            {
                lbxSisextraibles.Items.Add(txtNombreSis.Text + "-" + txtPrecioSis.Text);
                txtNombreSis.Text = "";
                txtPrecioSis.Text = "";
            }


        }

        private void btnESisExtraible_Click(object sender, EventArgs e)
        {
            if (Modificar == true)
            {
                if (lbxSisextraibles.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecciona antes Descripción-Precio Sistemas Extraibles");
                }
                else
                {
                    String[] arrayId = Convert.ToString(lbxSisextraibles.SelectedItem).Split(' ');
                    listaEliminar.Add("DELETE FROM [Bombay_Cocinas].[dbo].[Presu_Sisextraible] WHERE"
                    + " idextraible=" + arrayId[0] + " and refpresupuesto=" + Refpresupuesto);
                    lbxSisextraibles.Items.Remove(lbxSisextraibles.SelectedItem);
                }
            }
            else
            {
                if (lbxSisextraibles.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecciona antes Descripción-Precio Sistemas Extraibles");
                }
                else
                {
                    lbxSisextraibles.Items.Remove(lbxSisextraibles.SelectedItem);
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtModelo.Text == "" || txtAcabado.Text == "" || txtColorInteriores.Text == "" || txtZocalo.Text == "" ||
                    txtTirador.Text == "")
            {
                MessageBox.Show("Te has dejado algun campo vacio \n "
                                    + "Modelo \n"
                                    + "Acabado \n"
                                    + "Color Interiores \n"
                                    + "Zócalo \n"
                                    + "Color Mobiliario \n"
                                    + "Precio Mobiliario \n");
            }
            else
            {
                if (Modificar == true)
                {
                    ModificarDescripcionPrecio();
                    ModificarEncimeras();
                    ModificarSisExtraible();
                    String updatePresupuesto = "UPDATE [Bombay_Cocinas].[dbo].[Presupuesto] "
                           + " SET [refcalidad] = " + calidad
                           + ",[modelo] = '" + txtModelo.Text + "',[acabado] = '" + txtAcabado.Text
                           + "',[colorinterior] = '" + txtColorInteriores.Text + "',[tirador] = '" + txtTirador.Text
                           + "',[zocalo] ='" + txtZocalo.Text
                           + "'  WHERE idpresupuesto=" + Refpresupuesto;
                    Console.WriteLine(updatePresupuesto);
                    consultas.ejecutarComando(updatePresupuesto);
                    for (int i = 0; i < listaEliminar.Count; i++)
                    {
                        consultas.ejecutarComando(listaEliminar[i]);
                        Console.WriteLine(listaEliminar[i]);
                    }
                    listaEliminar.Clear();
                    MessageBox.Show("Presupuesto del Cliente " + txtNombre.Text + " actualizado correctamente");
                    this.Close();

                }
                else
                {
                    idpresupuesto = consultas.sacarIdMaxima("select max(idpresupuesto) from presupuesto") + 1;

                    String insertPresupuesto = "INSERT INTO [Bombay_Cocinas].[dbo].[Presupuesto]([idpresupuesto],[refcliente],[refcalidad] "
                    + ",[modelo],[acabado],[colorinterior],[colorcanto],[tirador],[zocalo],[fechapresupuesto]) "
                    + "VALUES(" + idpresupuesto + ",'" + idCliente + "','" + calidad + "','" + txtModelo.Text + "','" + txtAcabado.Text + "','"
                    + txtColorInteriores.Text + "','','" + txtTirador.Text + "','" + txtZocalo.Text + "','" + dtpFechaActual.Value.Date + "')";

                    Console.WriteLine(insertPresupuesto);
                    consultas.ejecutarComando(insertPresupuesto);

                    for (int i = 0; i < lbxColorMob.Items.Count; i++)
                    {
                        insertarPrecio(i);
                    }

                    for (int i = 0; i < lbxEncimeras.Items.Count; i++)
                    {
                        insertarEncimeras(i);
                    }

                    for (int i = 0; i < lbxSisextraibles.Items.Count; i++)
                    {
                        insertarSistemasExtraibles(i);
                    }
                    MessageBox.Show("Presupuesto del Cliente " + txtNombre.Text + " añadido correctamente");
                    this.Close();
                }

            }
        }

        //Insertar en las tablas los listbox
        private void insertarPrecio(int i)
        {

            int idprecio = consultas.sacarIdMaxima("select max(idprecio) from Presu_Precio") + 1;
            if (idprecio == 0)
            {
                idprecio = 1;
            }
            String itemDescripcion = lbxColorMob.Items[i].ToString();
            String[] precioColor = itemDescripcion.Split('-');
            String insertItems = "";
            if (Modificar == true)
            {
                insertItems = "INSERT INTO [Bombay_Cocinas].[dbo].[Presu_Precio]([idprecio],[refpresupuesto] "
                 + " ,[descripcion],[precio]) VALUES(" + idprecio + "," + Refpresupuesto + ",'" + precioColor[0] + "','" + precioColor[1] + "')";
                Console.WriteLine(insertItems);
                consultas.ejecutarComando(insertItems);
            }
            else
            {
                insertItems = "INSERT INTO [Bombay_Cocinas].[dbo].[Presu_Precio]([idprecio],[refpresupuesto] "
                 + " ,[descripcion],[precio]) VALUES(" + idprecio + "," + idpresupuesto + ",'" + precioColor[0] + "','" + precioColor[1] + "')";
                Console.WriteLine(insertItems);
                consultas.ejecutarComando(insertItems);
            }

        }

        private void insertarEncimeras(int i)
        {

            int idencimera = consultas.sacarIdMaxima("select max(idencimera) from Presu_Encimeras") + 1;
            int iddetalle = consultas.sacarIdMaxima("select max(iddetalle) from Presu_DetalleEncimera") + 1;
            if (idencimera == 0)
            {
                idencimera = 1;
            }
            String insertItems = "";
            String insertItems2 = "";
            String itemDescripcion = lbxEncimeras.Items[i].ToString();
            String[] precioEncimeras = itemDescripcion.Split('-');
            String precio = precioEncimeras[1].Replace(",", ".");

            if (Modificar == true)
            {
                insertItems = "INSERT INTO [Bombay_Cocinas].[dbo].[Presu_Encimeras]([idencimera] "
                + " ,[refpresupuesto]) VALUES (" + idencimera + "," + Refpresupuesto + ")";

                insertItems2 = "INSERT INTO [Bombay_Cocinas].[dbo].[Presu_DetalleEncimera]([iddetalle],[refencimera] "
                    + " ,[descripcion],[precio]) VALUES(" + iddetalle + "," + idencimera + ",'" + precioEncimeras[0] + "','" + precio + "') ";

                Console.WriteLine(insertItems);
                Console.WriteLine(insertItems2);
                consultas.ejecutarComando(insertItems);
                consultas.ejecutarComando(insertItems2);
            }
            else
            {
                insertItems = "INSERT INTO [Bombay_Cocinas].[dbo].[Presu_Encimeras]([idencimera] "
                + " ,[refpresupuesto]) VALUES (" + idencimera + "," + idpresupuesto + ")";

                insertItems2 = "INSERT INTO [Bombay_Cocinas].[dbo].[Presu_DetalleEncimera]([iddetalle],[refencimera] "
                    + " ,[descripcion],[precio]) VALUES(" + iddetalle + "," + idencimera + ",'" + precioEncimeras[0] + "','" + precio + "') ";

                Console.WriteLine(insertItems);
                Console.WriteLine(insertItems2);
                consultas.ejecutarComando(insertItems);
                consultas.ejecutarComando(insertItems2);
            }

        }

        private void insertarSistemasExtraibles(int i)
        {

            int idextraible = consultas.sacarIdMaxima("select max(idextraible) from Presu_Sisextraible") + 1;
            if (idextraible == 0)
            {
                idextraible = 1;
            }
            String itemDescripcion = lbxSisextraibles.Items[i].ToString();
            String[] precioSisExtra = itemDescripcion.Split('-');
            String precio = precioSisExtra[1].Replace(",", ".");
            String insertItems = "";
            if (Modificar == true)
            {
                insertItems = "INSERT INTO [Bombay_Cocinas].[dbo].[Presu_Sisextraible]([idextraible] "
                + ",[refpresupuesto],[descripcion],[precio])VALUES (" + idextraible + "," + Refpresupuesto + ",'" + precioSisExtra[0]
                + "','" + precio + "')";
                Console.WriteLine(insertItems);
                consultas.ejecutarComando(insertItems);
            }
            else
            {
                insertItems = "INSERT INTO [Bombay_Cocinas].[dbo].[Presu_Sisextraible]([idextraible] "
               + ",[refpresupuesto],[descripcion],[precio])VALUES (" + idextraible + "," + idpresupuesto + ",'" + precioSisExtra[0]
               + "','" + precio + "')";
                Console.WriteLine(insertItems);
                consultas.ejecutarComando(insertItems);
            }
            

        }

        //Rellenar Datos al formulario
        private void rellenarDatosCliente()
        {

            txtNombre.Text = consultas.selectstring("select nombre from clientes where idcliente=" + idCliente);
            txtApellidos.Text = consultas.selectstring("select apellidos from clientes where idcliente=" + idCliente);
            txtDireccion.Text = consultas.selectstring("select direccion from clientes where idcliente=" + idCliente);
            txtPoblacion.Text = consultas.selectstring("SELECT dbo.Localidades.descripcion FROM dbo.Clientes INNER JOIN "
                    + " dbo.Localidades ON dbo.Clientes.reflocalidad = dbo.Localidades.idlocalidad where dbo.Clientes.idcliente=" + idCliente);
            txtTelefono.Text = consultas.selectstring("select telmovil from clientes where idcliente=" + idCliente);

        }

        private void rellenarDatosPresupuesto()
        {

            txtModelo.Text = consultas.selectstring("select modelo from presupuesto where idpresupuesto=" + Refpresupuesto);
            txtAcabado.Text = consultas.selectstring("select acabado from presupuesto where idpresupuesto=" + Refpresupuesto);
            txtColorInteriores.Text = consultas.selectstring("select colorinterior from presupuesto where idpresupuesto=" + Refpresupuesto);
            txtTirador.Text = consultas.selectstring("select tirador from presupuesto where idpresupuesto=" + Refpresupuesto);
            txtZocalo.Text = consultas.selectstring("select zocalo from presupuesto where idpresupuesto=" + Refpresupuesto);
            consultas.rellenarLbx(lbxColorMob, "select idprecio, descripcion+ '-' + CAST(precio AS VARCHAR) from Presu_precio where refpresupuesto=" + Refpresupuesto);
            consultas.rellenarLbx(lbxSisextraibles, "select idextraible, descripcion+ '-' + CAST(precio AS VARCHAR) from Presu_Sisextraible where refpresupuesto=" + Refpresupuesto);
            consultas.rellenarLbx(lbxEncimeras, "select iddetalle, descripcion+ '-' + CAST(precio AS VARCHAR) from dbo.Presu_DetalleEncimera INNER JOIN "
                    + " dbo.Presu_Encimeras ON dbo.Presu_DetalleEncimera.refencimera = dbo.Presu_Encimeras.idencimera where refpresupuesto=" + Refpresupuesto);
            int idcalidad = Convert.ToInt32(consultas.selectstring("select refcalidad from Presupuesto where idpresupuesto=" + Refpresupuesto));
            if (idcalidad == 1)
            {
                rbnOpcionA.Checked = true;
                txtCalidades.Text = consultas.selectstring("select descripcion from Presu_Calidades where idcalidad=" + 1);
            }
            if (idcalidad == 2)
            {
                rbnOpcionB.Checked = true;
                txtCalidades.Text = consultas.selectstring("select descripcion from Presu_Calidades where idcalidad=" + 2);
            }
            if (idcalidad == 3)
            {
                rbnOpcionC.Checked = true;
                txtCalidades.Text = consultas.selectstring("select descripcion from Presu_Calidades where idcalidad=" + 3);
            }
        }

        private void ModificarDescripcionPrecio()
        {

            for (int i = 0; i < lbxColorMob.Items.Count; i++)
            {
                String itemDescripcion = lbxColorMob.Items[i].ToString();
                String[] idprecioListBox = itemDescripcion.Split(' ');
                String idprecioDisponible = consultas.selectstring("select idprecio from Presu_precio where refpresupuesto=" + Refpresupuesto + " and idprecio= " + idprecioListBox[0]);
                if (idprecioDisponible.Equals(""))
                {
                    insertarPrecio(i);
                }

            }

        }

        private void ModificarEncimeras()
        {
            for (int i = 0; i < lbxEncimeras.Items.Count; i++)
            {
                String itemDescripcion = lbxEncimeras.Items[i].ToString();
                String[] idprecioListBox = itemDescripcion.Split(' ');
                String idencimeraDisponible = consultas.selectstring("select idencimera from Presu_Encimeras where refpresupuesto=" + Refpresupuesto + " and idencimera= " + idprecioListBox[0]);
                if (idencimeraDisponible.Equals(""))
                {
                    insertarEncimeras(i);
                }
            }
        }

        private void ModificarSisExtraible()
        {
            for (int i = 0; i < lbxSisextraibles.Items.Count; i++)
            {
                String itemDescripcion = lbxSisextraibles.Items[i].ToString();
                String[] idextraibleListBox = itemDescripcion.Split(' ');
                String idextraibleDisponible = consultas.selectstring("select idextraible from Presu_Sisextraible where refpresupuesto=" + Refpresupuesto + " and idextraible= " + idextraibleListBox[0]);
                if (idextraibleDisponible.Equals(""))
                {
                    insertarSistemasExtraibles(i);
                }
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbnOpcionA_CheckedChanged(object sender, EventArgs e)
        {
            txtCalidades.Text = consultas.selectstring("select descripcion from Presu_Calidades where idcalidad=" + 1);
            calidad = 1;
        }

        private void rbnOpcionB_CheckedChanged(object sender, EventArgs e)
        {
            txtCalidades.Text = consultas.selectstring("select descripcion from Presu_Calidades where idcalidad=" + 2);
            calidad = 2;
        }

        private void rbnOpcionC_CheckedChanged(object sender, EventArgs e)
        {
            txtCalidades.Text = consultas.selectstring("select descripcion from Presu_Calidades where idcalidad=" + 3);
            calidad = 3;
        }


        private void txtPrecioMob_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.escribirSoloDoubles(e, "Precio Mobiliario:", txtPrecioMob, lbError, 1000, 1000);
        }

        private void txtPrecioSis_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.escribirSoloDoubles(e, "Precio Sistema Extraible:", txtPrecioSis, lbError2, 1000, 1000);
        }

        private void txtPrecioEncimeras_KeyPress(object sender, KeyPressEventArgs e)
        {
            funciones.escribirSoloDoubles(e, "Precio Encimeras:", txtPrecioEncimeras, lbError3, 1000, 1000);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtModelo.Text = "";
            txtAcabado.Text = "";
            txtApellidos.Text = "";
            rbnOpcionA.Checked = true;
            txtColorInteriores.Text = "";
            txtColorMob.Text = "";
            txtEncimeras.Text = "";
            txtNombreSis.Text = "";
            txtPrecioEncimeras.Text = "";
            txtPrecioMob.Text = "";
            txtTirador.Text = "";
            txtZocalo.Text = "";
        }


    }

}
