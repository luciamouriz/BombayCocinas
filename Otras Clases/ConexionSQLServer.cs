using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace AplicacionCocinas
{
   class ConexionSQLServer
    {
       private string connection = "server=LUCY-PC\\SQLEXPRESS ; database=base1 ; integrated security = true";

        private SqlConnection connect;
        private SqlCommand command;
        private SqlDataAdapter da;
        private DataTable dt;
        private DataSet ds;

        public ConexionSQLServer()
        {
            connect = new SqlConnection();
           
        }
        public SqlConnection conexionBD()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.ConnectionString = connection;
                    connect.Open();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return connect;
        }

        private void closeconnection()
        {
            if (connect.State != ConnectionState.Closed)
                connect.Close();
        }

        public string selectstring(string query)
        {
            string cadena = string.Empty;
            try
            {
                conexionBD();
                command = new SqlCommand(query, connect);
                cadena = command.ExecuteScalar().ToString();
            }
            catch
            {
                cadena = string.Empty;
            }
            finally
            {
                closeconnection();
            }
            return cadena;
        }

        public bool ejecutarComando(string query)
        {
            bool exito;
            try
            {
                conexionBD();
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
                closeconnection();
            }
            return exito;
        }

        public bool ExecuteStoreProcedure(string namestoreprocedure)
        {
            try
            {
                conexionBD();
                command = new SqlCommand(namestoreprocedure, connect);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                closeconnection();
            }
        }

        public DataTable SelectDataTableFromStoreProcedure(string namestoreprocedure)
        {
            dt = new DataTable();
            try
            {
                conexionBD();
                command = new SqlCommand(namestoreprocedure, connect);
                command.CommandType = CommandType.StoredProcedure;
                dt = new DataTable();
                da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeconnection();
            }
            return dt;
        }
        public DataTable SelectDataTable(string query)
        {
            dt = new DataTable();
            try
            {
                conexionBD();
                da = new SqlDataAdapter(query, connect);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexionBD();
            }
            return dt;
        }

        public DataSet SelectDataSet(string query, string table)
        {
            ds = new DataSet();
            try
            {
                conexionBD();
                da = new SqlDataAdapter(query, connect);
                da.Fill(ds, table);
            }
            catch //(Exception ex)
            {
                // ds = null;
            }
            finally
            {
                closeconnection();
            }
            return ds;
        }

        public void rellenaDGV(DataGridView tabla, String consulta)
        {
            try
            {
                DataTable datos = new DataTable();
                SqlCommand cmd = new SqlCommand(consulta, conexionBD());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(datos);
                tabla.DataSource = datos;
            }
            catch //(Exception ex)
            {
                // ds = null;
            }
            finally
            {
                closeconnection();
            }

        }
        //Metodo para rellenar combobox con una consulta de dos valores, el primero oculto y el segundo visible
        //
        //combo -> Combobox a rellenar
        //consulta -> Consulta SQL para obtener los valores
        //inicio -> Primer elemento del combo (Seleccione ...). Si no se desea inicio introducir ""
        //
        //
        //Metodos para extraer los elementos del combobox
        //
        //Elem oculto = cboCombo.SelectedValue()
        //Nombre de la columna visible = cboCombo.DisplayMember() 
        //Posicion del seleccionado = cboCombo.SelectedIndex)
        //
        public void rellenacombobox(ComboBox combo, String consulta, String inicio)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand(consulta, conexionBD());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            if (!inicio.Equals(""))
            {
                DataRow newrow2 = tabla.NewRow();
                newrow2[0] = -1;
                newrow2[1] = inicio;
                tabla.Rows.InsertAt(newrow2, 0);
            }
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ToString();
            combo.ValueMember = tabla.Columns[0].ToString();
        }


        public int sacarIdMaxima(String consultaMax)
        {
            int idMax = 0;
            try
            {
                String idmax = selectstring(consultaMax);
                if(idmax==null){

                    idMax=0;

                }else{

                    idMax = Convert.ToInt32(idmax);

                 }
             
            }
            catch //(Exception ex)
            {
                // ds = null;
            }
            finally
            {
                closeconnection();
            }
            return idMax;
        }

        public void rellenalistbox(DataTable tabla,ListBox combo, String consulta, String inicio)
        {
            
            SqlCommand cmd = new SqlCommand(consulta, conexionBD());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            if (!inicio.Equals(""))
            {
                DataRow newrow2 = tabla.NewRow();
                newrow2[0] = -1;
                newrow2[1] = inicio;
                tabla.Rows.InsertAt(newrow2, 0);
            }
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ToString();
            combo.ValueMember = tabla.Columns[0].ToString();
        }


        public void rellenarLbx(ListBox list, String consulta)
        {
            SqlCommand cmd = new SqlCommand(consulta, conexionBD());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
               
               while (reader.Read())
               {
                   list.Items.Add(reader[0].ToString()+" "+reader[1].ToString());
                   
               }
               
           }
            closeconnection();

       }
       
    }
}