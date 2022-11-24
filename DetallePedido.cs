using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace ProyectoFinal
{
  public  class DetallePedido
    {
        int codigo_pedido;
        string codigo_producto;
        int cantidad;
        decimal precio_unidad;
        int numero_linea;

        Productos productoEntero;

        public int Codigo_pedido { get => codigo_pedido; set => codigo_pedido = value; }
        public string Codigo_producto { get => codigo_producto; set => codigo_producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Precio_unidad { get => precio_unidad; set => precio_unidad = value; }
        public int Numero_linea { get => numero_linea; set => numero_linea = value; }
        public Productos ProductoEntero { get => productoEntero; set => productoEntero = value; }

        public DetallePedido(int codigo_pedido, string codigo_producto, int cantidad, decimal precio_unidad, int numero_linea)
        {
            Codigo_pedido = codigo_pedido;
            Codigo_producto = codigo_producto;
            Cantidad = cantidad;
            Precio_unidad = precio_unidad;
            Numero_linea = numero_linea;
            ProductoEntero = Productos.ListarProducto(codigo_producto)[0];
        }

        public DetallePedido() 
        {
            productoEntero = new Productos();
        }

        public override bool Equals(object obj)
        {
            return obj is DetallePedido pedido &&
                   Codigo_pedido == pedido.Codigo_pedido &&
                   Codigo_producto == pedido.Codigo_producto &&
                   Cantidad == pedido.Cantidad &&
                   Precio_unidad == pedido.Precio_unidad &&
                   Numero_linea == pedido.Numero_linea;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Codigo_pedido, Codigo_producto, Cantidad, Precio_unidad, Numero_linea);
        }

        public override string ToString()
        {
            return $"{Numero_linea,-7}{productoEntero.Nombre,-40}{Cantidad,-10}{Precio_unidad,-10}{Cantidad * Precio_unidad,-10}";
        }

        public static List<DetallePedido> ListarProducto(int codigo)
        {
            List<DetallePedido> lista = new List<DetallePedido>();
            BasedeDatos bd = new BasedeDatos();
            MySqlDataReader lector;


            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = $"Select * from detalle_pedido where codigo_pedido=?codigo_pedido order by numero_linea ";
            cmd.Parameters.Add("?codigo_pedido", MySqlDbType.VarChar).Value = codigo;
            lector = bd.EjecutarSelect(cmd);
            while (lector.Read())
            {
                lista.Add(new DetallePedido(lector.GetInt32("codigo_pedido"), lector.GetString("codigo_producto"), lector.GetInt32("cantidad"),
                    lector.GetDecimal("precio_unidad"),lector.GetInt32("numero_linea")));
            }

            bd.Cerrrar();

            return lista;
        }

        public int AñadirDetallePedido(int codigo)
        {
            int filasAfectadas = 0;

            try
            {

                BasedeDatos bd = new BasedeDatos();


                bd.Abrir();
                MySqlCommand comandoInsertar = new MySqlCommand();

                comandoInsertar.CommandText = $"Insert into detalle_pedido (codigo_pedido,codigo_producto,cantidad,precio_unidad,numero_linea)" +
                        $" values (?codigo_pedido,?codigo_producto,?cantidad,?precio_unidad,?numero_linea)";

                comandoInsertar.Parameters.Add("?codigo_pedido", MySqlDbType.Int32).Value = codigo;
                comandoInsertar.Parameters.Add("?codigo_producto", MySqlDbType.VarChar).Value = this.Codigo_producto;
                comandoInsertar.Parameters.Add("?cantidad", MySqlDbType.Int32).Value = this.Cantidad;
                comandoInsertar.Parameters.Add("?precio_unidad", MySqlDbType.Decimal).Value = this.Precio_unidad;
                comandoInsertar.Parameters.Add("?numero_linea", MySqlDbType.Int32).Value = this.Numero_linea;


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

        public int ModificarDetalle(int codigo) 
        {
            int filasAfectadas = 0;

            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();
            MySqlCommand comandoUpdate = new MySqlCommand();
            comandoUpdate.CommandText = $"Update detalle_pedido set codigo_producto=?codigo_producto," +
                $"cantidad=?cantidad,precio_unidad=?precio_unidad,numero_linea=?numero_linea," +
                $"where codigo_pedido=?codigo_pedido ";

            comandoUpdate.Parameters.Add("?codigo_pedido", MySqlDbType.Int32).Value = codigo;
            comandoUpdate.Parameters.Add("?codigo_producto", MySqlDbType.VarChar).Value = this.Codigo_producto;
            comandoUpdate.Parameters.Add("?cantidad", MySqlDbType.Int32).Value = this.Cantidad;
            comandoUpdate.Parameters.Add("?precio_unidad", MySqlDbType.Decimal).Value = this.Precio_unidad;
            comandoUpdate.Parameters.Add("?numero_linea", MySqlDbType.Int32).Value = this.Numero_linea;

            filasAfectadas = bd.EjecutarIUD(comandoUpdate);

            bd.Cerrrar();

            return filasAfectadas;
        }

        public int BorrarDetalle() 
        {
            int filasAfectadas = 0;

            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();
            MySqlCommand ComandoDelete = new MySqlCommand();
            ComandoDelete.CommandText = $"delete from detalle_pedido where codigo_pedido=?codigo_pedido ";

            ComandoDelete.Parameters.Add("?codigo_pedido", MySqlDbType.Int32).Value = this.Codigo_pedido;

            filasAfectadas = bd.EjecutarIUD(ComandoDelete);

            bd.Cerrrar();

            return filasAfectadas;
        }
    }
}
