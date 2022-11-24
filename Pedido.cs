using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace ProyectoFinal
{
   public class Pedido
    {
        int codigo_pedido;
        DateTime fecha_pedido;
        DateTime fecha_esperada;
        DateTime fecha_entrega;
        string estado;
        string comentarios;
        int codigo_cliente;

        Cliente cliente;
        List<DetallePedido> detalles;

        public int Codigo_pedido { get => codigo_pedido; set => codigo_pedido = value; }
        public DateTime Fecha_pedido { get => fecha_pedido; set => fecha_pedido = value; }
        public DateTime Fecha_esperada { get => fecha_esperada; set => fecha_esperada = value; }
        public DateTime Fecha_entrega { get => fecha_entrega; set => fecha_entrega = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public int Codigo_cliente { get => codigo_cliente; set => codigo_cliente = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public List<DetallePedido> Detalles { get => detalles; set => detalles = value; }

        public Pedido(int codigo_pedido, DateTime fecha_pedido, DateTime fecha_esperada, DateTime fecha_entrega, string estado, string comentarios, int codigo_cliente)
        {
            Codigo_pedido = codigo_pedido;
            Fecha_pedido = fecha_pedido;
            Fecha_esperada = fecha_esperada;
            Fecha_entrega = fecha_entrega;
            Estado = estado;
            Comentarios = comentarios;
            Codigo_cliente = codigo_cliente;

            Cliente = Cliente.ListarCliente(codigo_cliente)[0];
            Detalles = DetallePedido.ListarProducto(codigo_pedido);
        }
        public Pedido()
        {
            Cliente = new Cliente();
            Detalles = new List<DetallePedido>();
        }

        public void Mostar() 
        {
            decimal total = 0;
            int IVA = 21;

            Console.WriteLine($"CÓDIGO PEDIDO:  {codigo_pedido}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                        
            Console.WriteLine($"{"NOMBRE: ",-7} {Cliente.Nombre_cliente}                                 {"APELLIDOS: ",-10} {Cliente.Apellido_contacto}");
            Console.WriteLine($"{"FECHA PEDIDO: ",-7} {fecha_pedido.ToShortDateString()}                 {"FECHA ENTREGA: ",-15} {fecha_entrega.ToShortDateString()}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"LÍNEA",-7}{"PRODUCTO",-40}{"CANTIDAD",-10}{"PRECIO",-10}{"TOTAL",-10}");

            

            foreach (DetallePedido linea in Detalles) 
            {
                total += linea.Cantidad * linea.Precio_unidad;
                Console.WriteLine(linea);
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"TOTAL sin IVA: {total} IVA(21%):{total*IVA/100}  Total: {total + (total*IVA/100)}");
            Console.WriteLine("Pulse una tecla para continuar ...");
            Console.ReadLine();
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Codigo_pedido, Fecha_pedido, Fecha_esperada, Fecha_entrega, Estado, Comentarios, Codigo_cliente);
        }

        public override string ToString()
        {
            decimal total=0;
            int IVA = 21;
            string resultado = $"{"PEDIDO CÓDIGO: "}{Codigo_pedido}\n" +
                $"------------------------------------------------------------------------------------------------------------------\n" +
                $"{"NOMBRE: ",-7} {Cliente.Nombre_cliente}                           {"APELLIDOS: ",-10} {Cliente.Apellido_contacto}\n" +
                $"{"FECHA PEDIDO: ",-7} {fecha_pedido.ToShortDateString()}                 {"FECHA ENTREGA: ",-15} {fecha_entrega.ToShortDateString()}\n" +
                $"--------------------------------------------------------------------------------------------------------------------\n" +
                $"{"LÍNEA",-7}{"PRODUCTO",-40}{"CANTIDAD",-10}{"PRECIO",-10}{"TOTAL",-10}\n";

            foreach (DetallePedido linea in Detalles) 
            {
                total += linea.Cantidad * linea.Precio_unidad;
                resultado += $"{linea}\n";
            }
            resultado += $"-------------------------------------------------------------------------------------------------------------\n" +
                $"Total sin IVA: {total} IVA(21%): {(total * IVA) / 100} Total: {total + (total * IVA)}\n";

            return resultado;
        }

        public override bool Equals(object obj)
        {
            return obj is Pedido pedido &&
                   Codigo_pedido == pedido.Codigo_pedido &&
                   Fecha_pedido == pedido.Fecha_pedido &&
                   Fecha_esperada == pedido.Fecha_esperada &&
                   Fecha_entrega == pedido.Fecha_entrega &&
                   Estado == pedido.Estado &&
                   Comentarios == pedido.Comentarios &&
                   Codigo_cliente == pedido.Codigo_cliente;
        }

        public static List<Pedido> ListarPedido(int codigo)
        {
            List<Pedido> lista = new List<Pedido>();
            BasedeDatos bd = new BasedeDatos();
            MySqlDataReader lector;


            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = $"Select * from pedido where codigo_pedido=?codigo_pedido ";
            cmd.Parameters.Add("?codigo_pedido", MySqlDbType.VarChar).Value = codigo;
            lector = bd.EjecutarSelect(cmd);
            while (lector.Read())
            {
                lista.Add(new Pedido(lector.GetInt32("codigo_pedido"), lector.GetDateTime("fecha_pedido"), lector.GetDateTime("fecha_esperada"),
                   lector.IsDBNull(3)? default : lector.GetDateTime("fecha_entrega"), lector.GetString("estado"),
                   lector.IsDBNull(5)? "" : lector.GetString("comentarios"),lector.GetInt32("codigo_cliente")));
            }


            bd.Cerrrar();

            return lista;
        }



        public int AñadirPedido()
        {
            
            BasedeDatos bd = new BasedeDatos();

            int filasAfectadas = 0;
            long codigo_Pedido = 0;

            try
            {

                


                bd.Abrir();
                MySqlCommand comandoInsertar = new MySqlCommand();

                comandoInsertar.CommandText = $"Insert into pedido (fecha_pedido,fecha_esperada,fecha_entrega,estado,comentarios,codigo_cliente)" +
                        $" values (?fecha_pedido,?fecha_esperada,?fecha_entrega,?estado,?comentarios,?codigo_cliente)";

                comandoInsertar.CommandType = System.Data.CommandType.Text;

                comandoInsertar.Parameters.Add("?fecha_pedido", MySqlDbType.DateTime).Value = this.Fecha_pedido;
                comandoInsertar.Parameters.Add("?fecha_esperada", MySqlDbType.DateTime).Value = this.Fecha_esperada;
                comandoInsertar.Parameters.Add("?fecha_entrega", MySqlDbType.DateTime).Value = this.Fecha_entrega;
                comandoInsertar.Parameters.Add("?estado", MySqlDbType.VarChar).Value = this.Estado;
                comandoInsertar.Parameters.Add("?comentarios", MySqlDbType.VarChar).Value = this.Comentarios;
                comandoInsertar.Parameters.Add("?codigo_cliente", MySqlDbType.Int32).Value = this.Codigo_cliente;


                filasAfectadas = bd.EjecutarIUD(comandoInsertar);

                codigo_Pedido = comandoInsertar.LastInsertedId;

                
                foreach (DetallePedido linea in Detalles)
                {
                    linea.Codigo_pedido = (int)codigo_Pedido;
                    linea.AñadirDetallePedido((int)codigo_Pedido);

                }

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
                filasAfectadas = 0;
                Console.WriteLine($"Se ha producido un error general {e.Message}");
                if (codigo_Pedido != 0)
                {
                    this.Codigo_pedido = (int)codigo_Pedido;
                    this.BorrarPedido();
                }
            }
            finally 
            {
                bd.Cerrrar();
            }
            return filasAfectadas;
        }

        public int ModificarPedido() 
        {
            int filasAfectadas = 0;

            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();
            MySqlCommand comandoUpdate = new MySqlCommand();
            comandoUpdate.CommandText = $"Update pedido set fecha_pedido=?fecha_pedido," +
                $"fecha_esperada=?fecha_esperada,fecha_entrega=?fecha_entrega,estado=?estado," +
                $"comentarios=?comentarios,codigo_cliente=?codigo_cliente" +
                $"where codigo_pedido=?codigo_pedido ";

            comandoUpdate.Parameters.Add("?codigo_pedido", MySqlDbType.Int32).Value = this.Codigo_pedido;
            comandoUpdate.Parameters.Add("?fecha_pedido", MySqlDbType.DateTime).Value = this.Fecha_pedido;
            comandoUpdate.Parameters.Add("?fecha_esperada", MySqlDbType.DateTime).Value = this.Fecha_esperada;
            comandoUpdate.Parameters.Add("?fecha_entrega", MySqlDbType.DateTime).Value = this.Fecha_entrega;
            comandoUpdate.Parameters.Add("?estado", MySqlDbType.VarChar).Value = this.Estado;
            comandoUpdate.Parameters.Add("?comentarios", MySqlDbType.VarChar).Value = this.Comentarios;
            comandoUpdate.Parameters.Add("?codigo_cliente", MySqlDbType.Int32).Value = this.Codigo_cliente;

            filasAfectadas = bd.EjecutarIUD(comandoUpdate);

            

            foreach (DetallePedido linea in Detalles) 
            {
                
                linea.ModificarDetalle(codigo_pedido);
            }

            bd.Cerrrar();

            return filasAfectadas;
        }

        public int BorrarPedido() 
        {
            int filasAfectadas = 0;

            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();
            if (this.Detalles.Count >= 0) 
            {
                Detalles[0].BorrarDetalle();
            }
            

            MySqlCommand ComandoDelete = new MySqlCommand();
            ComandoDelete.CommandText = $"delete from pedido where codigo_pedido=?codigo_pedido ";

            ComandoDelete.Parameters.Add("?codigo_pedido", MySqlDbType.Int32).Value = this.codigo_pedido;

            filasAfectadas = bd.EjecutarIUD(ComandoDelete);



            bd.Cerrrar();

            return filasAfectadas;
        }
    }
}
