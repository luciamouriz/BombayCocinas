using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

namespace AplicacionCocinas
{
    class MetodosComunes
    {
        public void estilodgv(DataGridView dgv)
        {
            dgv.ReadOnly = true; // Celdas de sólo lectura
            dgv.AllowUserToAddRows = false; // Para que no se muestre la última fila
            dgv.ColumnHeadersVisible = true; // Para que no se muestre el título de la columna
            dgv.RowHeadersVisible = false; // Para que no se muestre la columna vacía de cada fila

            var _with1 = dgv.ColumnHeadersDefaultCellStyle;
            // formato por defecto de las cabeceras de columna
            _with1.Font = new Font("Tahoma", 8, FontStyle.Bold);
            _with1.ForeColor = Color.Black;
            _with1.BackColor = Color.Beige;
            _with1.SelectionForeColor = Color.Yellow;
            _with1.SelectionBackColor = Color.Blue;

            dgv.RowTemplate.Height = 100;

            //altura de las filas
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //modos de seleccion muy importante FullRowSelect//Cellselect
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // para ajustarse el tamaño de las columnas a las dimensiones del datagridview
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            // para ajustar el tamaño de las filas a las dimensiones del datagridview
            dgv.AllowUserToResizeColumns = true;
            // no permitir redimensionar columnas
            dgv.AllowUserToResizeRows = false;
            // no permitir redimensionar filas

            var _with2 = (dgv);
            //para alternar dos colores entre las filas del datagridview
            _with2.RowsDefaultCellStyle.BackColor = Color.White;
            _with2.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            var _with3 = dgv.DefaultCellStyle;
            // formato por defecto del datagridview
            _with3.Font = new Font("Tahoma", 8);
            _with3.ForeColor = Color.Black;
            _with3.BackColor = Color.Beige;
            _with3.SelectionForeColor = Color.White;
            _with3.SelectionBackColor = Color.Navy;//cambiado

            dgv.MultiSelect = false;
            //Para que solo se pueda seleccionar una fila
            dgv.ScrollBars = ScrollBars.Both;
        }

        public void escribirSoloEnterosLimitado(KeyPressEventArgs evt, String texto, int maximo, TextBox txtTexto, Label lblError)
        {
            lblError.Visible = true;
            if ((txtTexto.Text.Length == maximo) && (Char.IsDigit(evt.KeyChar)))
            {
                evt.Handled = true;
                lblError.Text = (texto + " Longitud Máxima: " + maximo + " caracteres");
            }
            else
            {
                lblError.Text = "";
            }
            if (!Char.IsDigit(evt.KeyChar) && !(Convert.ToInt32(evt.KeyChar) == 13) && !(evt.KeyChar == (char)Keys.Back))
            {
                evt.Handled = true;
                lblError.Text = (texto + " Escribe solo números");
            }
        }

        // Controla que se introduzca un numero de caracteres determinado
        // evt Evento KeyPress
        // texto Texto que queramos introducir
        // maximo Maximo de caracteres que queramos poner
        // txtTexto el textbox a validar
        // lblError la etiqueta que mostrará el error
        public void limitarCaracteres(KeyPressEventArgs evt, String texto, int maximo, TextBox txtTexto, Label lblError)
        {
            lblError.Visible = true;
            if (Convert.ToInt32(evt.KeyChar) == 39)
            {
                evt.Handled = true;
                lblError.Text = "¡Vas a pillar eh!. No puedes introducir la comilla simple";
            }
            else
            {
                if (txtTexto.Text.Length == maximo && !(evt.KeyChar == (char)Keys.Back))
                {
                    evt.Handled = true;
                    lblError.Text = texto + " Longitud Máxima: " + maximo + " caracteres";
                }
                else
                {
                    lblError.Text = "";
                }
            }

        }

        public Boolean ComprobarFormatoEmail(string seMailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(seMailAComprobar, sFormato))
            {
                if (Regex.Replace(seMailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("El email no es correcto");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("El email no es correcto");
                return false;
            }
        }

        public Boolean comprobarDNI(String DNIpasado)
        {

            Boolean correcto = false;
            if (DNIpasado.Length >= 8 && DNIpasado.Length <= 9)
            {
                try
                {

                    const int divisor = 23;
                    int dni = Convert.ToInt32(DNIpasado.Substring(0, DNIpasado.Length - 1));
                    int res = dni - (dni / divisor * divisor);
                    char[] letrasNIF = {'T', 'R', 'W', 'A', 'G', 'M', 'Y',
                        'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z',
                        'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E'};

                    String DNICalculado = Convert.ToString(dni) + letrasNIF[res];
                    if (DNICalculado.Length < DNIpasado.Length)
                    {
                        DNICalculado = "0" + DNICalculado;
                        if (DNICalculado.Equals(DNIpasado))
                        {
                            correcto = true;
                        }

                    }
                    else
                    {
                        if (DNICalculado.Equals(DNIpasado))
                        {
                            correcto = true;
                        }
                    }

                    return correcto;

                }
                catch (Exception e)
                {
                    MessageBox.Show("El Dni es incorrecto. Introduce un Dni valido");
                    return correcto;
                }
            }
            else
            {
                MessageBox.Show("El DNI debe ser de 7 u 8 cifras");
                return correcto;
            }

        }

        public void escribirSoloDoubles(KeyPressEventArgs evt, String texto, TextBox campo, Label lblError, int numeroEnteros, int numeroDecimales)
        {
            lblError.Visible = true;
            String text = campo.Text;
            char caracter = evt.KeyChar;
            Boolean coma;


            coma = campo.Text.IndexOf(',') != -1;
            if (coma && caracter.Equals(','))
            {
                lblError.Text = texto + " No puedes escribir más comas";
                evt.Handled = true;
            }
            else
            {
                if (text.Equals("") && (!Char.IsDigit(caracter)))
                {
                    evt.Handled = true;
                    lblError.Text = texto + " No puedes meter letras solo numeros y coma";

                }
                else
                {


                    if (!Char.IsDigit(caracter) && (text.Contains(",") && caracter != ',' && !(caracter == (char)Keys.Back)))
                    {
                        evt.Handled = true;
                        lblError.Text = (texto + " Solo números y coma");
                    }
                    else
                    {
                        if (text.Length >= numeroEnteros && caracter != 46 && !coma && !(caracter == (char)Keys.Back))
                        {
                            evt.Handled = true;
                            lblError.Text = texto + " No puedes escribir más enteros";
                        }
                        else
                        {
                            if (coma)
                            {
                                if (text.Substring(text.IndexOf(',')).Length > numeroDecimales && !(caracter == (char)Keys.Back))
                                {
                                    evt.Handled = true;
                                    lblError.Text = texto + "No puedes escribir más decimales";
                                }
                            }
                            else
                            {
                                lblError.Text = "";
                                if (!Char.IsDigit(caracter) && !(caracter == (char)Keys.Back) && caracter != ',')
                                {
                                    evt.Handled = true;
                                    lblError.Text = texto + " Solo numeros y coma";
                                }
                            }
                        }
                    }
                }

            }


        }


     }
}
