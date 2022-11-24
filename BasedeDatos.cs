using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace ProyectoFinal
{
    public class BasedeDatos
    {

       private string cadenaConexion;
       private MySqlConnection conectar;
    //   private MySqlCommand comando;
       private MySqlDataReader lector;


        public BasedeDatos()
        {
            cadenaConexion = "Server=127.0.0.1;Port=3306;Database=JardineriaOnline;Uid=root;password=;";
            conectar = new MySqlConnection(cadenaConexion);
    //        comando = new MySqlCommand();
            
        }


        public BasedeDatos(string connectionString)
        {
            cadenaConexion = connectionString;
            conectar = new MySqlConnection(connectionString);
     //       comando = new MySqlCommand();

        }

        public void Abrir() 
        {
            conectar.Open();
        }

        public void Cerrrar() 
        {
            conectar.Close();
            conectar.Dispose();
        }

        public MySqlDataReader EjecutarSelect(MySqlCommand comando) 
        {
            comando.Connection = conectar;
            comando.CommandTimeout = 60;
            lector = comando.ExecuteReader();
            return lector;
        }

        public int EjecutarIUD(MySqlCommand comando) 
        {

            comando.Connection = conectar;
            comando.CommandTimeout = 60;
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }


    }
}
