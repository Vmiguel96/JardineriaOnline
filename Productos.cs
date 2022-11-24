using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace ProyectoFinal
{
   public class Productos
    {
        string codigo_producto;
        string nombre;
        string gama;
        string dimensiones;
        string proveedor;
        string descripcion;
        int cantidad_en_stock;
        decimal precio_venta;
        decimal precio_proveedor;

        public string Codigo_producto { get => codigo_producto; set => codigo_producto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Gama { get => gama; set => gama = value; }
        public string Dimensiones { get => dimensiones; set => dimensiones = value; }
        public string Proveedor { get => proveedor; set => proveedor = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Cantidad_en_stock { get => cantidad_en_stock; set => cantidad_en_stock = value; }
        public decimal Precio_venta { get => precio_venta; set => precio_venta = value; }
        public decimal Precio_proveedor { get => precio_proveedor; set => precio_proveedor = value; }

        public Productos(string codigo_producto, string nombre, string gama, string dimensiones, string proveedor, string descripcion, int cantidad_en_stock, decimal precio_venta, decimal precio_proveedor)
        {
            Codigo_producto = codigo_producto;
            Nombre = nombre;
            Gama = gama;
            Dimensiones = dimensiones;
            Proveedor = proveedor;
            Descripcion = descripcion;
            Cantidad_en_stock = cantidad_en_stock;
            Precio_venta = precio_venta;
            Precio_proveedor = precio_proveedor;
        }

        public Productos() 
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Productos productos &&
                   Codigo_producto == productos.Codigo_producto &&
                   Nombre == productos.Nombre &&
                   Gama == productos.Gama &&
                   Dimensiones == productos.Dimensiones &&
                   Proveedor == productos.Proveedor &&
                   Descripcion == productos.Descripcion &&
                   Cantidad_en_stock == productos.Cantidad_en_stock &&
                   Precio_venta == productos.Precio_venta &&
                   Precio_proveedor == productos.Precio_proveedor;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Codigo_producto);
            hash.Add(Nombre);
            hash.Add(Gama);
            hash.Add(Dimensiones);
            hash.Add(Proveedor);
            hash.Add(Descripcion);
            hash.Add(Cantidad_en_stock);
            hash.Add(Precio_venta);
            hash.Add(Precio_proveedor);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return $"{Codigo_producto,-4}-{Nombre,-10} {Cantidad_en_stock,-6} {Precio_venta,-10}";
        }

        public static List<Productos> ListarProducto(string codigo)
        {
            List<Productos> lista = new List<Productos>();
            BasedeDatos bd = new BasedeDatos();
            MySqlDataReader lector;

            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = $"Select * from producto where codigo_producto=?codigo_producto";
            cmd.Parameters.Add("?codigo_producto", MySqlDbType.VarChar).Value = codigo;
            lector = bd.EjecutarSelect(cmd);
            while (lector.Read())
            {
                lista.Add(new Productos(lector.GetString("codigo_producto"), lector.GetString("nombre"),lector.GetString("gama"),
                    lector.IsDBNull(3) ? "" : lector.GetString("dimensiones"),lector.IsDBNull(4) ? "" : lector.GetString("proveedor"),
                    lector.IsDBNull(5) ? "" : lector.GetString("descripcion"),lector.GetInt32("cantidad_en_stock"),
                    lector.GetDecimal("precio_venta"),lector.IsDBNull(8) ? 0 : lector.GetDecimal("precio_venta")));
            }

            bd.Cerrrar();

            return lista;
        }
    }
}
