using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace ProyectoFinal
{
   public class Cliente
    {
        int codigo_cliente;
        string nombre_cliente;
        string nombre_contacto;
        string apellido_contacto;
        string telefono;
        string fax;
        string linea_direccion1;
        string linea_direccion2;
        string ciudad;
        string region;
        string pais;
        string codigo_postal;
        int codigo_empleado_rep_ventas;
        decimal limite_credito;
        string pass;

        public Cliente(int codigo_cliente, string nombre_cliente, string nombre_contacto, string apellido_contacto, string telefono, string fax, string linea_direccion1, string linea_direccion2, string ciudad, string region, string pais, string codigo_postal, int codigo_empleado_rep_ventas, decimal limite_credito, string pass)
        {
            Codigo_cliente = codigo_cliente;
            Nombre_cliente = nombre_cliente;
            Nombre_contacto = nombre_contacto;
            Apellido_contacto = apellido_contacto;
            Telefono = telefono;
            Fax = fax;
            Linea_direccion1 = linea_direccion1;
            Linea_direccion2 = linea_direccion2;
            Ciudad = ciudad;
            Region = region;
            Pais = pais;
            Codigo_postal = codigo_postal;
            Codigo_empleado_rep_ventas = codigo_empleado_rep_ventas;
            Limite_credito = limite_credito;
            Pass = pass;
        }

        public Cliente() 
        { }

        public int Codigo_cliente { get => codigo_cliente; set => codigo_cliente = value; }
        public string Nombre_cliente { get => nombre_cliente; set => nombre_cliente = value; }
        public string Nombre_contacto { get => nombre_contacto; set => nombre_contacto = value; }
        public string Apellido_contacto { get => apellido_contacto; set => apellido_contacto = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Linea_direccion1 { get => linea_direccion1; set => linea_direccion1 = value; }
        public string Linea_direccion2 { get => linea_direccion2; set => linea_direccion2 = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Region { get => region; set => region = value; }
        public string Pais { get => pais; set => pais = value; }
        public string Codigo_postal { get => codigo_postal; set => codigo_postal = value; }
        public int Codigo_empleado_rep_ventas { get => codigo_empleado_rep_ventas; set => codigo_empleado_rep_ventas = value; }
        public decimal Limite_credito { get => limite_credito; set => limite_credito = value; }
        public string Pass { get => pass; set => pass = value; }

        public override string ToString()
        {
            return $"{Codigo_cliente,-4} {Nombre_cliente,-30} {Apellido_contacto,-12} {Ciudad,-40} ";
        }

        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                   Codigo_cliente == cliente.Codigo_cliente &&
                   Nombre_cliente == cliente.Nombre_cliente &&
                   Nombre_contacto == cliente.Nombre_contacto &&
                   Apellido_contacto == cliente.Apellido_contacto &&
                   Telefono == cliente.Telefono &&
                   Fax == cliente.Fax &&
                   Linea_direccion1 == cliente.Linea_direccion1 &&
                   Linea_direccion2 == cliente.Linea_direccion2 &&
                   Ciudad == cliente.Ciudad &&
                   Region == cliente.Region &&
                   Pais == cliente.Pais &&
                   Codigo_postal == cliente.Codigo_postal &&
                   Codigo_empleado_rep_ventas == cliente.Codigo_empleado_rep_ventas &&
                   Limite_credito == cliente.Limite_credito &&
                   Pass == cliente.Pass;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Codigo_cliente);
            hash.Add(Nombre_cliente);
            hash.Add(Nombre_contacto);
            hash.Add(Apellido_contacto);
            hash.Add(Telefono);
            hash.Add(Fax);
            hash.Add(Linea_direccion1);
            hash.Add(Linea_direccion2);
            hash.Add(Ciudad);
            hash.Add(Region);
            hash.Add(Pais);
            hash.Add(Codigo_postal);
            hash.Add(Codigo_empleado_rep_ventas);
            hash.Add(Limite_credito);
            hash.Add(Pass);
            return hash.ToHashCode();
        }

        public static List<Cliente> ListaClientes() 
        {

                List<Cliente> lista = new List<Cliente>();

                BasedeDatos bd = new BasedeDatos();
                MySqlDataReader lector;

                bd.Abrir();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Select * from cliente";
                lector = bd.EjecutarSelect(cmd);
                while (lector.Read())
                {
                    
                    lista.Add(new Cliente(lector.GetInt32("codigo_cliente"), lector.GetString("nombre_cliente"), lector.IsDBNull(2) ? "" : lector.GetString("nombre_contacto"), lector.IsDBNull(3) ? "" : lector.GetString("apellido_contacto"),
                        lector.GetString("telefono"), lector.GetString("fax"), lector.GetString("linea_direccion1"), lector.IsDBNull(7) ? "" : lector.GetString("linea_direccion2"),
                        lector.GetString("ciudad"), lector.IsDBNull(9) ? "" : lector.GetString("region"), lector.IsDBNull(10) ? "" : lector.GetString("pais"), lector.IsDBNull(11) ? "" : lector.GetString("codigo_postal"),
                        lector.IsDBNull(12) ? 0: lector.GetInt32("codigo_empleado_rep_ventas"), lector.IsDBNull(13) ? 0 : lector.GetDecimal("limite_credito"),lector.GetString("pass")));
                }

                bd.Cerrrar();

                return lista;

            
        }

        public static List<Cliente> ListarCliente(int codigo)
        {
            List<Cliente> lista = new List<Cliente>();
            BasedeDatos bd = new BasedeDatos();
            MySqlDataReader lector;

            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = $"Select * from cliente where codigo_cliente=?codigo_cliente";
            cmd.Parameters.Add("?codigo_cliente", MySqlDbType.VarChar).Value = codigo;
            lector = bd.EjecutarSelect(cmd);
            while (lector.Read())
            {
                lista.Add(new Cliente(lector.GetInt32("codigo_cliente"), lector.GetString("nombre_cliente"), lector.IsDBNull(2) ? "" : lector.GetString("nombre_contacto"),
                    lector.IsDBNull(3) ? "" : lector.GetString("apellido_contacto"),lector.GetString("telefono"), lector.GetString("fax"), lector.GetString("linea_direccion1"), lector.IsDBNull(7) ? "" : lector.GetString("linea_direccion2"),
                    lector.GetString("ciudad"), lector.IsDBNull(9) ? "" : lector.GetString("region"), lector.IsDBNull(10) ? "" : lector.GetString("pais"), lector.IsDBNull(11) ? "" : lector.GetString("codigo_postal"),
                    lector.IsDBNull(12) ? 0 : lector.GetInt32("codigo_empleado_rep_ventas"), lector.IsDBNull(13) ? 0 : lector.GetDecimal("limite_credito"), lector.GetString("pass")));
            }

            bd.Cerrrar();

            return lista;
        }

        public int AñadirCliente()
        {
            int filasAfectadas = 0;

            try
            {

                BasedeDatos bd = new BasedeDatos();


                bd.Abrir();
                MySqlCommand comandoInsertar = new MySqlCommand();
                if(this.Codigo_empleado_rep_ventas!=0)
                comandoInsertar.CommandText = $"Insert into cliente (nombre_cliente,nombre_contacto,apellido_contacto,telefono,fax,linea_direccion1,linea_direccion2,ciudad,region,pais,codigo_postal,codigo_empleado_rep_ventas,limite_credito,pass)" +
                    $" values (?nombre_cliente,?nombre_contacto,?apellido_contacto,?telefono,?fax,?linea_direccion1,?linea_direccion2,?ciudad,?region,?pais,?codigo_postal,?codigo_empleado_rep_ventas,?limite_credito,?pass)";

                else
                    comandoInsertar.CommandText = $"Insert into cliente (nombre_cliente,nombre_contacto,apellido_contacto,telefono,fax,linea_direccion1,linea_direccion2,ciudad,region,pais,codigo_postal,limite_credito,pass)" +
    $" values (?nombre_cliente,?nombre_contacto,?apellido_contacto,?telefono,?fax,?linea_direccion1,?linea_direccion2,?ciudad,?region,?pais,?codigo_postal,?limite_credito,?pass)";

                comandoInsertar.Parameters.Add("?codigo_cliente", MySqlDbType.Int32).Value = this.Codigo_cliente;
                comandoInsertar.Parameters.Add("?nombre_cliente", MySqlDbType.VarChar).Value = this.Nombre_cliente;
                comandoInsertar.Parameters.Add("?nombre_contacto", MySqlDbType.VarChar).Value = this.Nombre_contacto;
                comandoInsertar.Parameters.Add("?apellido_contacto", MySqlDbType.VarChar).Value = this.Apellido_contacto;
                comandoInsertar.Parameters.Add("?telefono", MySqlDbType.VarChar).Value = this.Telefono;
                comandoInsertar.Parameters.Add("?fax", MySqlDbType.VarChar).Value = this.Fax;
                comandoInsertar.Parameters.Add("?linea_direccion1", MySqlDbType.VarChar).Value = this.Linea_direccion1;
                comandoInsertar.Parameters.Add("?linea_direccion2", MySqlDbType.VarChar).Value = this.Linea_direccion2;
                comandoInsertar.Parameters.Add("?ciudad", MySqlDbType.VarChar).Value = this.Ciudad;
                comandoInsertar.Parameters.Add("?region", MySqlDbType.VarChar).Value = this.Region;
                comandoInsertar.Parameters.Add("?pais", MySqlDbType.VarChar).Value = this.Pais;
                comandoInsertar.Parameters.Add("?codigo_postal", MySqlDbType.VarChar).Value = this.Codigo_postal;
                if(this.Codigo_empleado_rep_ventas!=0)
                comandoInsertar.Parameters.Add("?codigo_empleado_rep_ventas", MySqlDbType.Int32).Value = this.Codigo_empleado_rep_ventas;
                comandoInsertar.Parameters.Add("?limite_credito", MySqlDbType.Decimal).Value = this.Limite_credito;
                comandoInsertar.Parameters.Add("?pass", MySqlDbType.VarChar).Value = this.Pass;

                filasAfectadas = bd.EjecutarIUD(comandoInsertar);

                bd.Cerrrar();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine($"Inserción realizada con exito {filasAfectadas}");
                }
                else
                {
                    Console.WriteLine($"No se ha realizado ninguna inserción");
                }

            }
            catch (MySqlException m)
            {
                Console.WriteLine($"Se ha producido un error {m.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Se ha producido un error general {e.Message}");
            }
            return filasAfectadas;
        }

        public int ActualizarCliente()
        {
            int filasAfectadas = 0;

            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();
            MySqlCommand comandoUpdate = new MySqlCommand();
            comandoUpdate.CommandText = $"Update cliente set nombre_cliente=?nombre_cliente," +
                $"nombre_contacto=?nombre_contacto,apellido_contacto=?apellido_contacto,telefono=?telefono," +
                $"fax=?fax,linea_direccion1=?linea_direccion1,linea_direccion2=?linea_direccion2," +
                $"ciudad=?ciudad,region=?region,pais=?pais,codigo_postal=?codigo_postal,codigo_empleado_rep_ventas=?codigo_empleado_rep_ventas," +
                $"limite_credito=?limite_credito,pass=?pass  where codigo_cliente=?codigo_cliente ";


            comandoUpdate.Parameters.Add("?codigo_cliente", MySqlDbType.Int32).Value = this.Codigo_cliente;
            comandoUpdate.Parameters.Add("?nombre_cliente", MySqlDbType.VarChar).Value = this.Nombre_cliente;
            comandoUpdate.Parameters.Add("?nombre_contacto", MySqlDbType.VarChar).Value = this.Nombre_contacto;
            comandoUpdate.Parameters.Add("?apellido_contacto", MySqlDbType.VarChar).Value = this.Apellido_contacto;
            comandoUpdate.Parameters.Add("?telefono", MySqlDbType.VarChar).Value = this.Telefono;
            comandoUpdate.Parameters.Add("?fax", MySqlDbType.VarChar).Value = this.Fax;
            comandoUpdate.Parameters.Add("?linea_direccion1", MySqlDbType.VarChar).Value = this.Linea_direccion1;
            comandoUpdate.Parameters.Add("?linea_direccion2", MySqlDbType.VarChar).Value = this.Linea_direccion2;
            comandoUpdate.Parameters.Add("?ciudad", MySqlDbType.VarChar).Value = this.Ciudad;
            comandoUpdate.Parameters.Add("?region", MySqlDbType.VarChar).Value = this.Region;
            comandoUpdate.Parameters.Add("?pais", MySqlDbType.VarChar).Value = this.Pais;
            comandoUpdate.Parameters.Add("?codigo_postal", MySqlDbType.VarChar).Value = this.Codigo_postal;
            comandoUpdate.Parameters.Add("?codigo_empleado_rep_ventas", MySqlDbType.Int32).Value = this.Codigo_empleado_rep_ventas;
            comandoUpdate.Parameters.Add("?limite_credito", MySqlDbType.Decimal).Value = this.Limite_credito;
            comandoUpdate.Parameters.Add("?pass", MySqlDbType.VarChar).Value = this.Pass;

            filasAfectadas = bd.EjecutarIUD(comandoUpdate);

            bd.Cerrrar();

            return filasAfectadas;
        }

        public int BorrarCliente()
        {
            int filasAfectadas = 0;

            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();
            MySqlCommand ComandoDelete = new MySqlCommand();
            ComandoDelete.CommandText = $"delete from cliente where codigo_cliente=?codigo_cliente ";

            ComandoDelete.Parameters.Add("?codigo_cliente", MySqlDbType.VarChar).Value = this.Codigo_cliente;

            filasAfectadas = bd.EjecutarIUD(ComandoDelete);

            bd.Cerrrar();



            return filasAfectadas;
        }
    }
}
