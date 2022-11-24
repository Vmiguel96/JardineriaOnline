using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace ProyectoFinal
{
    class Oficina
    {
        string codigo_oficina;
        string ciudad;
        string pais;
        string region;
        string codigo_postal;
        string telefono;
        string linea_direccion1;
        string linea_direccion2;

        public Oficina()
        {
        }

        public Oficina(string codigo_oficina, string ciudad, string pais, string region,string codigo_postal, string telefono, string linea_direccion1, string linea_direccion2)
        {
            Codigo_oficina = codigo_oficina;
            Ciudad = ciudad;
            Pais = pais;
            Region = region;
            Codigo_postal = codigo_postal;
            Telefono = telefono;
            Linea_direccion1 = linea_direccion1;
            Linea_direccion2 = linea_direccion2;
        }


        public string Codigo_oficina { get => codigo_oficina; set => codigo_oficina = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Pais { get => pais; set => pais = value; }
        public string Region { get => region; set => region = value; }
        public string Codigo_postal { get => codigo_postal; set => codigo_postal = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Linea_direccion1 { get => linea_direccion1; set => linea_direccion1 = value; }
        public string Linea_direccion2 { get => linea_direccion2; set => linea_direccion2 = value; }

        public override bool Equals(object obj)
        {
            return obj is Oficina oficina &&
                   Codigo_oficina == oficina.Codigo_oficina &&
                   Ciudad == oficina.Ciudad &&
                   Pais == oficina.Pais &&
                   Region == oficina.Region &&
                   Telefono == oficina.Telefono &&
                   Linea_direccion1 == oficina.Linea_direccion1 &&
                   Linea_direccion2 == oficina.Linea_direccion2;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Codigo_oficina, Ciudad, Pais, Region, Telefono, Linea_direccion1, Linea_direccion2);
        }

        public override string ToString()
        {
            return $"{Codigo_oficina}:{Ciudad}-{Pais}";
        }

        public static List<Oficina> ListarOficinas() 
        {
            List<Oficina> lista = new List<Oficina>();

            BasedeDatos bd = new BasedeDatos();
            MySqlDataReader lector;
            
            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from oficina";
            lector = bd.EjecutarSelect(cmd);
            while (lector.Read()) 
            {
                //Console.WriteLine($"{lector.GetString("codigo_oficina")}{lector.GetString("ciudad")}");
                lista.Add(new Oficina(lector.GetString("codigo_oficina"), lector.GetString("ciudad"),lector.GetString("pais"), lector.IsDBNull(3)? "":lector.GetString("region"), lector.GetString("codigo_postal"), lector.GetString("telefono"), lector.GetString("linea_direccion1"),lector.IsDBNull(7)? "": lector.GetString("linea_direccion2")));
            }

            bd.Cerrrar();

            return lista;

        }

        public static List<Oficina> ListarOficina(string codigo) 
        {
            List<Oficina> lista = new List<Oficina>();
            BasedeDatos bd = new BasedeDatos();
            MySqlDataReader lector;

            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = $"Select * from oficina where codigo_oficina=?codigo_oficina";
            cmd.Parameters.Add("?codigo_oficina", MySqlDbType.VarChar).Value = codigo;
            lector = bd.EjecutarSelect(cmd);
            while (lector.Read())
            {
                lista.Add(new Oficina(lector.GetString("codigo_oficina"), lector.GetString("ciudad"), lector.GetString("pais"), lector.IsDBNull(3) ? "" : lector.GetString("region"), lector.GetString("codigo_postal"), lector.GetString("telefono"), lector.GetString("linea_direccion1"), lector.IsDBNull(7) ? "" : lector.GetString("linea_direccion2")));
            }

            bd.Cerrrar();

            return lista;
        }

        public int AñadirOficina ( )
        {
            int filasAfectadas=0;



                BasedeDatos bd = new BasedeDatos();


                bd.Abrir();
                MySqlCommand ComandoInsertar = new MySqlCommand();
                ComandoInsertar.CommandText = $"Insert into oficina (codigo_oficina,ciudad,pais,region,codigo_postal,telefono,linea_direccion1,linea_direccion2) values (?codigo_oficina,?ciudad,?pais,?region,?codigo_postal,?telefono,?linea_direccion1,?linea_direccion2)";


                ComandoInsertar.Parameters.Add("?codigo_oficina", MySqlDbType.VarChar).Value =this.Codigo_oficina;
                ComandoInsertar.Parameters.Add("?ciudad", MySqlDbType.VarChar).Value = this.Ciudad;
                ComandoInsertar.Parameters.Add("?pais", MySqlDbType.VarChar).Value = this.Pais;
                ComandoInsertar.Parameters.Add("?region", MySqlDbType.VarChar).Value = this.Region;
                ComandoInsertar.Parameters.Add("?codigo_postal", MySqlDbType.VarChar).Value = this.Codigo_postal;
                ComandoInsertar.Parameters.Add("?telefono", MySqlDbType.VarChar).Value = this.Telefono;
                ComandoInsertar.Parameters.Add("?linea_direccion1", MySqlDbType.VarChar).Value = this.Linea_direccion1;
                ComandoInsertar.Parameters.Add("?linea_direccion2", MySqlDbType.VarChar).Value = this.Linea_direccion2;

                filasAfectadas = bd.EjecutarIUD(ComandoInsertar);
                bd.Cerrrar();


           

            return filasAfectadas; 
        }

        public int ActualizarOficina() 
        {
            int filasAfectadas = 0;

                BasedeDatos bd = new BasedeDatos();

                bd.Abrir();
                MySqlCommand ComandoUpdate = new MySqlCommand();
                ComandoUpdate.CommandText = $"Update oficina set ciudad=?ciudad,pais=?pais," +
                $"region=?region,codigo_postal=?codigo_postal,telefono=?telefono," +
                $"linea_direccion1=?linea_direccion1,linea_direccion2=?linea_direccion2" +
                $" where codigo_oficina=?codigo_oficina ";


                ComandoUpdate.Parameters.Add("?codigo_oficina", MySqlDbType.VarChar).Value = this.Codigo_oficina;
                ComandoUpdate.Parameters.Add("?ciudad", MySqlDbType.VarChar).Value = this.Ciudad;
                ComandoUpdate.Parameters.Add("?pais", MySqlDbType.VarChar).Value = this.Pais;
                ComandoUpdate.Parameters.Add("?region", MySqlDbType.VarChar).Value = this.Region;
                ComandoUpdate.Parameters.Add("?codigo_postal", MySqlDbType.VarChar).Value = this.Codigo_postal;
                ComandoUpdate.Parameters.Add("?telefono", MySqlDbType.VarChar).Value = this.Telefono;
                ComandoUpdate.Parameters.Add("?linea_direccion1", MySqlDbType.VarChar).Value = this.Linea_direccion1;
                ComandoUpdate.Parameters.Add("?linea_direccion2", MySqlDbType.VarChar).Value = this.Linea_direccion2;

                filasAfectadas = bd.EjecutarIUD(ComandoUpdate);

                bd.Cerrrar();

            return filasAfectadas;
        }

        public int BorrarOficina()
        {
            int filasAfectadas = 0;

            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();
            MySqlCommand ComandoDelete = new MySqlCommand();
            ComandoDelete.CommandText = $"delete from oficina where codigo_oficina=?codigo_oficina ";

            ComandoDelete.Parameters.Add("?codigo_oficina", MySqlDbType.VarChar).Value = this.Codigo_oficina;

            filasAfectadas = bd.EjecutarIUD(ComandoDelete);

            bd.Cerrrar();



            return filasAfectadas;
        }
    }
}
