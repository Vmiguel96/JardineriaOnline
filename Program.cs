/* Proyecto Final Curso .Net
 * Nombre: Victor Miguel Escalona
 * Fecha: 14/07/2021
 */


using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace ProyectoFinal
{
   public class Program
    {
        public static void MenuPrincipal()
        {
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Menu Principal");

            bool salir = false;
            string opcion = "";

            

            do
            {
            Console.Clear();

            Console.WriteLine(" PROGRAMA PARA LA GESTIÓN DE UNA JARDINERIA ");
            Console.WriteLine("1. CLIENTES");
            Console.WriteLine("2. PEDIDOS");
            Console.WriteLine("3. CONSULTAS");
            Console.WriteLine("0. SALIR DEL PROGRAMA");

                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        MenuClientes();
                        break;
                    case "2":
                        MenuPedidos();
                        break;
                    case "3":
                        MenuConsultas();
                        break;
                    case "0":
                        salir = true;
                        ListaIncidencias.GuardarIncidencias();
                        break;
                    default:
                        break;
                }
            }
            while (!salir);
        }

        public static void MenuClientes() 
        {
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Menu Clientes");
            bool salir = false;
            do
            {
                

                Console.Clear();
                Console.WriteLine("1. MENU DE GESTIÓN DE CLIENTES ");
                Console.WriteLine("1. Pulse 1 para INSERTAR un CLIENTE");
                Console.WriteLine("2. Pulse 2 para MODIFICAR un CLIENTE");
                Console.WriteLine("3. Pulse 3 para BORRAR un CLIENTE");
                Console.WriteLine("4. Pulse 4 para MOSTAR todos los CLIENTES");
                Console.WriteLine("0. Pulse 0 para VOLVER al MENÚ PRINCIPAL");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        InsertarCliente();
                        break;
                    case "2":
                        ModificarCliente();
                        break;
                    case "3":
                        BorrarCliente();
                        break;
                    case "4":
                        MostarCliente();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        break;
                }
            }
            while (!salir);

        
        }

        public static void MenuPedidos() 
        {
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Menu Pedidos");
            bool salir = false;
            do
            {


                Console.Clear();
                Console.WriteLine("2. MENU DE GESTIÓN DE PEDIDOS");
                Console.WriteLine("1. Pulse 1 para INSERTAR un PEDIDOS");
                Console.WriteLine("2. Pulse 2 para MODIFICAR un PEDIDOS");
                Console.WriteLine("3. Pulse 3 para BORRAR un PEDIDOS");
                Console.WriteLine("4. Pulse 4 para MOSTAR uno de los PEDIDOS");
                Console.WriteLine("0. Pulse 0 para VOLVER al MENÚ PRINCIPAL");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        InsertarPedido();
                        break;
                    case "2":
                        ModificarPedido();
                        break;
                    case "3":
                        BorrarPedido();
                        break;
                    case "4":
                        MostarPedido();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        break;
                }
            }
            while (!salir);
        }


        public static void MenuConsultas() 
        {
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Menu Consultas");
            bool salir = false;
            do
            {


                Console.Clear();
                Console.WriteLine("3. MENU DE GESTIÓN DE CONSULTAS");
                Console.WriteLine("1. Pulse 1 para mostar los CLIENTES PAÍS ESPAÑA");
                Console.WriteLine("2. Pulse 2 para mostar los CLIENTES de MADRID");
                Console.WriteLine("3. Pulse 3 para mostar los CLIENTES LIMITE CREDITO MAYOR 10000");
                Console.WriteLine("4. Pulse 4 para mostar el STOCK INFERIOR a 50 UNIDADES");
                Console.WriteLine("5. Pulse 5 para mostar los PRODUCTOS ORDENADOS");
                Console.WriteLine("6. Pulse 6 para mostar los PEDIDOS REALIZADOS EN 2008");
                Console.WriteLine("7. Pulse 7 para mostar los PEDIDOS con FECHA ENTREGA ANTERIOR a la ESPERADA");
                Console.WriteLine("8. Pulse 8 para mostar los REPRESENTANTES OFICINA de MADRID");
                Console.WriteLine("0. Pulse 0 para VOLVER al MENÚ PRINCIPAL");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ClientesSpain();
                        break;
                    case "2":
                        ClientesMadrid();
                        break;
                    case "3":
                        ClientesCredito();
                        break;
                    case "4":
                        StockInferior();
                        break;
                    case "5":
                        ProductosOrdenados();
                        break;
                    case "6":
                        PedidosAño();
                        break;
                    case "7":
                        PedidosFecha();
                        break;
                    case "8":
                        RepresentantesOficinaMadrid();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        break;
                }
            }
            while (!salir);
        }

        //Funciones Clientes

        public static void InsertarCliente()
        {
            
                Cliente cliente = new Cliente();
                Console.WriteLine("Nombre cliente: ");
            while ((cliente.Nombre_cliente = Console.ReadLine()) == "") 
            {
                Console.WriteLine("El nombre del cliente no puede estar vacío");
                Console.WriteLine("Nombre cliente: ");
            }
                Console.WriteLine("Nombre contacto: ");
                cliente.Nombre_contacto = Console.ReadLine();
                Console.WriteLine("Apellido contacto: ");
                cliente.Apellido_contacto = Console.ReadLine();
                Console.WriteLine("Telefono: ");
            while ((cliente.Telefono = Console.ReadLine()) == "")
            {
                Console.WriteLine("El Telefono no puede estar vacío");
                Console.WriteLine("Telefono: ");
            }
                Console.WriteLine("Introduzca Fax");
            while ((cliente.Fax = Console.ReadLine()) == "")
            {
                Console.WriteLine("El Fax no puede estar vacío");
                Console.WriteLine("Fax: ");
            }
                Console.WriteLine("Linea direccion1: ");
            while ((cliente.Linea_direccion1 = Console.ReadLine()) == "")
            {
                Console.WriteLine("La Linea_direccion1 no puede estar vacía");
                Console.WriteLine("Linea direccion1: ");
            }
                Console.WriteLine("Linea direccion2: ");
                cliente.Linea_direccion2 = Console.ReadLine();
                Console.WriteLine("Ciudad: ");
            while ((cliente.Ciudad = Console.ReadLine()) == "")
            {
                Console.WriteLine("La Ciudad no puede estar vacía");
                Console.WriteLine("Ciudad: ");
            }
                Console.WriteLine("Region: ");
                cliente.Region = Console.ReadLine();
                Console.WriteLine("País: ");
                cliente.Pais = Console.ReadLine();
                Console.WriteLine("Codigo postal: ");
                cliente.Codigo_postal = Console.ReadLine();

            int codigoR;
            decimal limite;
                Console.WriteLine("Codigo empleado rep ventas: ");
            if (Int32.TryParse(Console.ReadLine(), out codigoR))
                cliente.Codigo_empleado_rep_ventas = codigoR;
            else
                cliente.Codigo_empleado_rep_ventas = 0;
                Console.WriteLine("Limite credito: ");
            if (Decimal.TryParse(Console.ReadLine(), out limite))
                cliente.Limite_credito = Convert.ToDecimal(Console.ReadLine());
            else
                cliente.Limite_credito = 0;
                Console.WriteLine("Pass: ");
            while ((cliente.Pass = Console.ReadLine()) == "")
            {
                Console.WriteLine("El Pass no puede estar vacía");
                Console.WriteLine("Pass: ");
            }


            try
            {
                int filas = cliente.AñadirCliente();

                if (filas > 0)
                { Console.WriteLine($"La insercion se ha realizado correctamente");
                  ListaIncidencias.AñadirIncidencia(DateTime.Now,$"Insertar cliente: {cliente}");
                }
                
                else
                { Console.WriteLine($"La insercion  no se ha realizado correctamente"); }
            }
            catch (MySqlException m)
            {
                Console.WriteLine($"Error base de datos {m.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error desconocido {e.Message}");
            }
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Añadir Cliente");
            Console.ReadLine();


        }

        public static string RellenaCampoString(string texto, string dato)
        {
            string resultado;
            Console.WriteLine($"{texto}: {dato}");
            Console.WriteLine($"Nuevo {texto}");
            resultado = Console.ReadLine();
            if (resultado != "")
            {
                return resultado;
            }
            return dato;
        }

        public static void ModificarCliente()
        {
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

            Cliente cliente;
            int codigo=0;        
            Console.Write("Codigo Cliente a modificar:");
            Int32.TryParse(Console.ReadLine(),out codigo);
            while(Cliente.ListarCliente(codigo).Count ==0)
            {
                Console.WriteLine("Cliente no existe");
                Console.Write("Codigo Cliente a modificar:");
                Int32.TryParse(Console.ReadLine(), out codigo);
            }

             cliente = Cliente.ListarCliente(codigo)[0];

            Console.WriteLine($"Nombre cliente: ({cliente.Nombre_cliente})");
            Console.WriteLine("Nuevo nombre cliente: ");
            nombre_cliente = Console.ReadLine();
            if (nombre_cliente != "")
                cliente.Nombre_cliente = nombre_cliente;

            Console.WriteLine($"Nombre contacto:  ({cliente.Nombre_contacto})");
            Console.WriteLine("Nuevo nombre contacto: ");
            nombre_contacto = Console.ReadLine();
            if (nombre_contacto != "")
                cliente.Nombre_contacto = nombre_cliente;

            Console.WriteLine($"Apellido contacto: ({cliente.Apellido_contacto})");
            Console.WriteLine("Nuevo apellido cliente: ");
            apellido_contacto = Console.ReadLine();
            if (apellido_contacto != "")
                cliente.Apellido_contacto = apellido_contacto;

            Console.WriteLine($"Telefono: ({cliente.Telefono})");
            Console.WriteLine("Nuevo telefono: ");
            telefono = Console.ReadLine();
            if (telefono != "")
                cliente.Telefono = telefono;

            Console.WriteLine($"Introduzca Fax ({cliente.Fax})");
            Console.WriteLine("Nuevo fax: ");
            fax = Console.ReadLine();
            if (fax != "")
                cliente.Fax = fax;

            Console.WriteLine($"Linea direccion1: ({cliente.Linea_direccion1})");
            Console.WriteLine("Nueva direccion1: ");
            linea_direccion1 = Console.ReadLine();
            if (linea_direccion1 != "")
                cliente.Linea_direccion1 = linea_direccion1;

            Console.WriteLine($"Linea direccion2: ({cliente.Linea_direccion2})");
            Console.WriteLine("Nueva direccion2: ");
            linea_direccion2 = Console.ReadLine();
            if (linea_direccion2 != "")
                cliente.Linea_direccion2 = linea_direccion2;

            Console.WriteLine($"Ciudad: ({cliente.Ciudad})");
            Console.WriteLine("Nueva ciudad: ");
            ciudad = Console.ReadLine();
            if (ciudad != "")
                cliente.Ciudad = ciudad;

            Console.WriteLine($"Region: ({cliente.Region})");
            Console.WriteLine("Nueva region: ");
            region = Console.ReadLine();
            if (region != "")
                cliente.Region = region;

            Console.WriteLine($"País: ({cliente.Pais})");
            Console.WriteLine("Nuevo pais: ");
            pais = Console.ReadLine();
            if (pais != "")
                cliente.Pais = pais;

            Console.WriteLine($"Codigo postal: ({cliente.Codigo_postal})");
            Console.WriteLine("Nuevo codigo postal: ");
            codigo_postal = Console.ReadLine();
            if (codigo_postal != "")
                cliente.Codigo_postal = codigo_postal;



            Console.WriteLine($"Codigo empleado rep ventas: ({cliente.Codigo_empleado_rep_ventas})");
            Console.WriteLine("Nuevo codigo empleados rep ventas: ");
            string codigoR = Console.ReadLine();
            if (codigoR != "")
            {
                Int32.TryParse(codigoR, out codigo_empleado_rep_ventas);
                cliente.Codigo_empleado_rep_ventas = codigo_empleado_rep_ventas;
            }



            Console.WriteLine($"Limite credito: ({cliente.Limite_credito})");
            Console.WriteLine("Nuevo limite credito: ");
            codigoR = Console.ReadLine();
            if (codigoR != "")
            {
                Decimal.TryParse(codigoR, out limite_credito);
                cliente.Limite_credito = limite_credito;
            }

            

            Console.WriteLine("Pass: Conservar contraseña");
            Console.WriteLine("Nueva Contraseña: ");
            pass = Console.ReadLine();
            if (pass != "")
                cliente.Pass = pass;


            try
            {
                int filas = cliente.ActualizarCliente();

                if (filas > 0)
                { Console.WriteLine($"La insercion se ha realizado correctamente"); }
                else
                { Console.WriteLine($"La insercion  no se ha realizado correctamente"); }
            }
            catch (MySqlException m)
            {
                Console.WriteLine($"Error base de datos {m.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error desconocido {e.Message}");
            }
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Modificar Cliente");
            Console.ReadLine();
        }

        public static void BorrarCliente()
        {
            

            int codigo = 0;
            Console.Write("Codigo Cliente a BORRAR: ");
            Int32.TryParse(Console.ReadLine(), out codigo);

            Cliente cliente = Cliente.ListarCliente(codigo)[0];
            if (cliente.Codigo_empleado_rep_ventas == 0)
            {
                ListaIncidencias.AñadirIncidencia(DateTime.Now, "Borrar Cliente");
                try
                {
                    int filas = cliente.BorrarCliente();

                    if (filas > 0)
                    { Console.WriteLine($"El borrado se ha realizado correctamente"); }
                    else
                    { Console.WriteLine($"El borrado  no se ha realizado correctamente"); }
                }
                catch (MySqlException m)
                {
                    Console.WriteLine($"Error base de datos {m.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error desconocido {e.Message}");
                }

                Console.ReadLine();
            }
            else 
            {
                Console.WriteLine("No se puede borrar si tiene representante (Modifica primero el cliente)");
            }
            Console.ReadLine();


        }


        public static void MostarCliente()
        {
            ListaIncidencias.AñadirIncidencia(DateTime.Now,"Mostar Clientes");
            List<Cliente> lc = Cliente.ListaClientes();
            foreach (Cliente c in lc)
            {
                    Console.WriteLine(c);
            }
            Console.ReadLine();
        }

        //Funciones Pedidos

        private static void RecogerDetalle(int numLinea, Pedido p) 
        {
            bool productoCorrecto = false;
            DetallePedido detalle = new DetallePedido();
            int c;
            decimal dec;
            do {

                Console.Write("Codigo producto: ");
                while ((detalle.Codigo_producto = Console.ReadLine()) == "")
                {
                    Console.Write("El codigo de cliente no puede estar vacio");
                    Console.Write("Estado del producto: ");
                }
                if (Productos.ListarProducto(detalle.Codigo_producto).Count > 0)
                {
                    productoCorrecto = true;
                }
            } while (productoCorrecto == false);

            Console.Write("Cantidad: ");
            while (!Int32.TryParse(Console.ReadLine(),out c)) 
            {
                Console.WriteLine("La cantidad no puede estar vacio");
                Console.Write("Cantidad: ");
            }
            detalle.Cantidad = c;

            Console.Write("Precio unidad: ");
            while (!Decimal.TryParse(Console.ReadLine(), out dec))
            {
                Console.WriteLine("El precio de unidad no puede estar vacio");
                Console.Write("Precio unidad: ");
            }
            detalle.Precio_unidad = dec;
            detalle.Numero_linea = numLinea;
            p.Detalles.Add(detalle);

            ListaIncidencias.AñadirIncidencia(DateTime.Now,"Recoger Detalle");
        }

        public static void InsertarPedido()
        {
            Pedido pedido = new Pedido();
            DateTime t;
            int c;
            int resultadoInsert = 0;

            Console.Write("La fecha del pedido:");
            while (!DateTime.TryParse(Console.ReadLine(), out t))
            {
                Console.WriteLine("La fecha del pedido no puede estar vacia");
                Console.Write("La fecha del pedido:");
            }
            pedido.Fecha_pedido = t;

            Console.Write("La fecha esperada:");
            while (!DateTime.TryParse(Console.ReadLine(), out t))
            {
                Console.WriteLine("La fecha del pedido no puede estar vacia");
                Console.Write("La fecha esperada:");
            }
            pedido.Fecha_esperada = t;

            Console.Write("La fecha entrega:");
            while (!DateTime.TryParse(Console.ReadLine(), out t))
            {
                Console.Write("La fecha entrega:");
            }
            pedido.Fecha_esperada = t;

            Console.Write("Estado del pedido: ");
            while ((pedido.Estado = Console.ReadLine()) == "")
            {
                Console.WriteLine("El estado no puede estar vacio");
                Console.Write("Estado del pedido: ");
            }

            Console.Write("Comentarios: ");
            pedido.Comentarios = Console.ReadLine();

            bool clienteCorrecto = false;
            do
            {
                Console.Write("Codigo cliente: ");
                while (!Int32.TryParse(Console.ReadLine(), out c))
                {
                    Console.Write("El codigo de cliente no puede estar vacio");
                    Console.Write("Codigo de cliente: ");
                }
                if (Cliente.ListarCliente(c).Count > 0)
                {
                    pedido.Codigo_cliente = c;
                }
            }
            while (!clienteCorrecto == false);

                Console.WriteLine("DETALLES DEL PEDIDO");
                Console.WriteLine("---------------------------------------");
                string opcion = "n";
                int numLinea = 1;
                do
                {
                    RecogerDetalle(numLinea,pedido);
                    Console.Write($"Quiere añadir otro pedido {"S o N"}: ");
                    opcion = Console.ReadLine();
                    numLinea++;

                } while (opcion == "S" || opcion == "s");

                resultadoInsert = pedido.AñadirPedido();
                if (resultadoInsert > 0)
                {
                    Console.WriteLine("Pedido Insertado con éxito");
                }
                else 
                {
                    Console.WriteLine("Pedido no insertado");
                }
            
            Console.ReadLine();

            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Empleados de madrid y puesto rep.ventas");
        }

        private static void ModificarDetalle(int numLinea, Pedido p)
        {
            DetallePedido detalle = new DetallePedido();

            string codigo_producto;
            int cantidad;
            decimal precio_unidad;


            int codigo = 0;
            Console.Write("Codigo Pedido a modificar:");
            Int32.TryParse(Console.ReadLine(), out codigo);
            while (DetallePedido.ListarProducto(codigo).Count == 0)
            {
                Console.WriteLine("Cliente no existe");
                Console.Write("Codigo pedido a modificar:");
                Int32.TryParse(Console.ReadLine(), out codigo);
            }

            detalle = DetallePedido.ListarProducto(codigo)[0];

            Console.WriteLine($"Codigo Productop: ({detalle.Codigo_producto})");
            Console.WriteLine("Nuevo Codigo Producto: ");
            codigo_producto = Console.ReadLine();
            if (codigo_producto != "")
                detalle.Codigo_producto = codigo_producto;

            Console.WriteLine($"Cantidad: ({detalle.Cantidad})");
            Console.WriteLine("Nueva Cantidad: ");
            string codigoR = Console.ReadLine();
            if (codigoR != "")
            {
                Int32.TryParse(codigoR, out cantidad);
                detalle.Cantidad = cantidad;
            }

            Console.WriteLine($"Precio unidad: ({detalle.Precio_unidad})");
            Console.WriteLine("Nuevo precio unidad: ");
            codigoR = Console.ReadLine();
            if (codigoR != "")
            {
                Decimal.TryParse(codigoR, out precio_unidad);
                detalle.Precio_unidad = precio_unidad;
            }



            detalle.Numero_linea = numLinea;

            detalle.ModificarDetalle(detalle.Codigo_pedido);

            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Recoger Detalle");
        }

        public static void ModificarPedido()
        {
            DateTime fecha_pedido;
            DateTime fecha_esperada;
            DateTime fecha_entrega;
            string estado;
            string comentarios;
            int codigo_cliente;

            int codigo = 0;
            Console.Write("Codigo Pedido a modificar:");
            Int32.TryParse(Console.ReadLine(), out codigo);
            while (Pedido.ListarPedido(codigo).Count == 0)
            {
                Console.WriteLine("Cliente no existe");
                Console.Write("Codigo Pedido a modificar:");
                Int32.TryParse(Console.ReadLine(), out codigo);
            }

            Pedido pedido = new Pedido();
            int resultadoInsert = 0;

            pedido = Pedido.ListarPedido(codigo)[0];

            Console.WriteLine($"Fecha pedido: ({pedido.Fecha_pedido})");
            Console.WriteLine("Nueva fecha pedido: ");
            string codigoR = Console.ReadLine();
            if (codigoR != "")
            {
                DateTime.TryParse(codigoR, out fecha_pedido);
                pedido.Fecha_pedido = fecha_pedido;
            }

            Console.WriteLine($"Fecha esperada: ({pedido.Fecha_esperada})");
            Console.WriteLine("Nueva fecha esperada: ");
            codigoR = Console.ReadLine();
            if (codigoR != "")
            {
                DateTime.TryParse(codigoR, out fecha_esperada);
                pedido.Fecha_esperada = fecha_esperada;
            }

            Console.WriteLine($"Fecha entrega: ({pedido.Fecha_entrega})");
            Console.WriteLine("Nuevo fecha entrega: ");
            codigoR = Console.ReadLine();
            if (codigoR != "")
            {
                DateTime.TryParse(codigoR, out fecha_entrega);
                pedido.Fecha_entrega = fecha_entrega;
            }

            Console.WriteLine($"Estado: ({pedido.Estado})");
            Console.WriteLine("Nuevo estado: ");
            estado = Console.ReadLine();
            if (estado != "")
                pedido.Estado = estado;

            Console.WriteLine($"Comentarios: ({pedido.Comentarios})");
            Console.WriteLine("Nuevos Comentarios: ");
            comentarios = Console.ReadLine();
            if (comentarios != "")
                pedido.Comentarios = comentarios;


            bool clienteCorrecto = false;

            Console.WriteLine($"Codigo Cliente: ({pedido.Codigo_cliente})");
            Console.WriteLine("Nuevo codigo cliente: ");
            codigoR = Console.ReadLine();
            if (codigoR != "")
            {
                Int32.TryParse(codigoR, out codigo_cliente);
                pedido.Codigo_cliente = codigo_cliente;
            }
            while (!clienteCorrecto == false);

            Console.WriteLine("DETALLES DEL PEDIDO");
            Console.WriteLine("---------------------------------------");
            string opcion = "n";
            int numLinea = 1;
            do
            {
                ModificarDetalle(numLinea, pedido);
                Console.Write($"Quiere modificar otro pedido {"S o N"}: ");
                opcion = Console.ReadLine();
                numLinea++;

            } while (opcion == "S" || opcion == "s");

            resultadoInsert = pedido.ModificarPedido();
            if (resultadoInsert > 0)
            {
                Console.WriteLine("Pedido modificado con éxito");
            }
            else
            {
                Console.WriteLine("Pedido no modificado");
            }

            Console.ReadLine();

            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Empleados de madrid y puesto rep.ventas");
        }

        public static void BorrarPedido()
        {
            int c;
            int resultadoDelete = 0;
            Pedido p = new Pedido();
            bool pedidoCorrecto = false;
            do
            {
                Console.Write("Introduzca el código del pedido que desea borrar ");
                while (!Int32.TryParse(Console.ReadLine(), out c))
                {
                    Console.Write("El código de pedido no puede estar vacio \n");
                    Console.Write("Introduzca el código del pedido que desea borrar: ");
                }
                if (Pedido.ListarPedido(c).Count > 0)
                {
                    p.Codigo_pedido = c;
                    pedidoCorrecto = true;
                }
            }
            while (pedidoCorrecto == false);
            p = Pedido.ListarPedido(c)[0];
            p.BorrarPedido();

            if (resultadoDelete > 0)
            {
                Console.WriteLine("Pedido Borrado con éxito");
            }
            else
            {
                Console.WriteLine("Pedido Borrado con éxito");
            }

            Console.ReadLine();

            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Mostrar Pedido");
        }

        public static void MostarPedido()
        {

            Console.Write("Introduzca el código del pedido que desea mostrar:");
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Pedido.ListarPedido(codigo)[0].Mostar();
            Console.WriteLine(Pedido.ListarPedido(codigo)[0]);
            Console.ReadLine();
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Mostrar Pedido");

        }

        //Funciones Consultas

        public static void ClientesSpain()
        {
            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT nombre_cliente,pais,region" +
                " FROM cliente " +
                "WHERE pais='Spain'";

                Console.WriteLine("Clientes de España");
            Console.WriteLine($"{"NOMBRE CLIENTE",-40}{"PAIS",-12}{"REGION",-12}");
                Console.WriteLine("---------------------------------------------------------------------");

            MySqlDataReader lector = bd.EjecutarSelect(cmd);

            while (lector.Read()) 
            {
                Console.WriteLine($"{lector.GetString("nombre_cliente"),-40}{lector.GetString("pais"),-12}{lector.GetString("region"),-12}");
            }
            lector.Close();
            bd.Cerrrar();
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Clientes España");
            Console.ReadLine();
        }

        public static void ClientesMadrid() 
        {
            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT nombre_cliente,pais,region" +
                " FROM cliente " +
                "WHERE pais='Spain' AND region='Madrid' ";

            Console.WriteLine("Clientes de Madrid");
            Console.WriteLine($"{"NOMBRE CLIENTE",-40}{"PAIS",-12}{"REGION",-12}");
            Console.WriteLine("---------------------------------------------------------------------");

            MySqlDataReader lector = bd.EjecutarSelect(cmd);

            while (lector.Read())
            {
                Console.WriteLine($"{lector.GetString("nombre_cliente"),-40}{lector.GetString("pais"),-12}{lector.GetString("region"),-12}");
            }
            lector.Close();
            bd.Cerrrar();
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Clientes Madrid");
            Console.ReadLine();
        }

        public static void ClientesCredito() 
        {
            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT nombre_cliente,limite_credito FROM cliente" +
                " WHERE nombre_cliente LIKE 'A%' AND limite_credito >10000";

            Console.WriteLine("Clientes con un Credito Superior a  10000");
            Console.WriteLine($"{"NOMBRE CLIENTE",-40}{"LIMITE CREDITO",-12}");
            Console.WriteLine("---------------------------------------------------------------------");

            MySqlDataReader lector = bd.EjecutarSelect(cmd);

            while (lector.Read())
            {
                Console.WriteLine($"{lector.GetString("nombre_cliente"),-40}{lector.GetDecimal("limite_credito"),-12:F2}");
            }
            lector.Close();
            bd.Cerrrar();
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Clientes Empiezan por A y limite maor a 10000");
            Console.ReadLine();
        }

        public static void StockInferior() 
        {
            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT codigo_producto,nombre,cantidad_en_stock FROM producto WHERE cantidad_en_stock<50";

            Console.WriteLine("Pedidos Con Stock menor a 50");
            Console.WriteLine($"{"CÓDIGO",-12}{"NOMBRE PRODUCTO",-50}{"STOCK",-12}");
            Console.WriteLine("---------------------------------------------------------------------");

            MySqlDataReader lector = bd.EjecutarSelect(cmd);

            while (lector.Read())
            {
                Console.WriteLine($"{lector.GetString("codigo_producto"),-12}{lector.GetString("nombre"),-50}{lector.GetInt32("cantidad_en_stock"),-12}");
            }
            lector.Close();
            bd.Cerrrar();
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Productos en stock menores de 50");
            Console.ReadLine();
        }

        public static void ProductosOrdenados() 
        {
            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT codigo_producto,nombre,cantidad_en_stock,precio_venta,(cantidad_en_stock*precio_venta)AS valortotal " +
                "FROM producto " +
                "ORDER BY valortotal desc";

            Console.WriteLine("Valor Total del Stock de los Pedidos");
            Console.WriteLine($"{"CÓDIGO",-12}{"NOMBRE PRODUCTO",-70}{"CANTIDAD",-12}{"PRECIO",-12}{"VALOR TOTAL",-12}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            MySqlDataReader lector = bd.EjecutarSelect(cmd);

            while (lector.Read())
            {
                Console.WriteLine($"{lector.GetString("codigo_producto"),-12}{lector.GetString("nombre"),-70}{lector.GetInt32("cantidad_en_stock"),-12}{lector.GetDecimal("precio_venta"),-12:F2}{lector.GetDecimal("valortotal"),-12:F2}");
            }
            lector.Close();
            bd.Cerrrar();
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Valor de los productos ordenados de mayor a menor");
            Console.ReadLine();
        }

        public static void PedidosAño() 
        {
            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT p.codigo_pedido,p.fecha_pedido,p.comentarios, c.nombre_cliente,c.telefono " +
                "FROM pedido p, cliente c " +
                "WHERE p.codigo_pedido =c.codigo_cliente AND fecha_pedido LIKE  '2008%'";

            Console.WriteLine("Pedidos Realizados en 2008");
            Console.WriteLine($"{"CÓDIGO",-10}{"FECHA",-12}{"COMENTARIO",-40}{"NOMBRE",-30}{"TELEFONO",-15}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            MySqlDataReader lector = bd.EjecutarSelect(cmd);

            while (lector.Read())
            {
                string comentario = lector.IsDBNull(2) ? "" : lector.GetString("comentarios");
                comentario = comentario.Length > 40 ? comentario.Substring(0, 36) + "..." : comentario;
                Console.WriteLine($"{lector.GetString("codigo_pedido"),-10}{lector.GetDateTime("fecha_pedido").ToShortDateString(),-12}{comentario,-40}{lector.GetString("nombre_cliente"),-30}{lector.GetString("telefono"),-15}");
            }
            lector.Close();
            bd.Cerrrar();
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Mostar Fecha pedido realizados en 2008");
            Console.ReadLine();
        }

        public static void PedidosFecha() 
        {
            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT codigo_pedido,fecha_entrega,fecha_esperada,nombre_cliente,telefono " +
                "FROM pedido p,cliente c " +
                "WHERE p.codigo_pedido=c.codigo_cliente " +
                "AND fecha_entrega < fecha_esperada";

            Console.WriteLine("Entregas anticipadas de pedidos");
            Console.WriteLine($"{"CÓDIGO",-10}{"FECHA ESPERADA",-15}{"FECHA ENTREGA",-15}{"NOMBRE",-30}{"TELEFONO",-15}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            MySqlDataReader lector = bd.EjecutarSelect(cmd);

            while (lector.Read())
            {

                Console.WriteLine($"{lector.GetString("codigo_pedido"),-10}{lector.GetDateTime("fecha_ESPERADA").ToShortDateString(),-15}{lector.GetDateTime("fecha_entrega").ToShortDateString(),-15}{lector.GetString("nombre_cliente"),-30}{lector.GetString("telefono"),-15}");
            }
            lector.Close();
            bd.Cerrrar();
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Entregas anticipadas de pedidos");
            Console.ReadLine();
        }

        public static void RepresentantesOficinaMadrid() 
        {
            BasedeDatos bd = new BasedeDatos();

            bd.Abrir();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT nombre,apellido1,apellido2,email " +
                "FROM empleado " +
                "WHERE codigo_oficina='MAD-ES' AND puesto='Representante Ventas'";

            Console.WriteLine("Empleados de la oficina de madrid y que su puesto sea Rep.Ventas");
            Console.WriteLine($"{"NOMBRE",-15}{"APELLIDOS", -30}{"EMAIL",-30}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            MySqlDataReader lector = bd.EjecutarSelect(cmd);

            while (lector.Read())
            {
                string apellidos = lector.GetString("apellido1") + " "+ lector.GetString("apellido2");
                Console.WriteLine($"{lector.GetString("nombre"),-15}{apellidos,-30}{lector.GetString("email"),-30}");
            }
            lector.Close();
            bd.Cerrrar();
            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Empleados de madrid y puesto rep.ventas");
            Console.ReadLine();
        }



       public static void Main(string[] args)
        {
            ListaIncidencias incidencias = new ListaIncidencias();

            ListaIncidencias.AñadirIncidencia(DateTime.Now, "Main");

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            MenuPrincipal();
            ListaIncidencias.ListarIncidencias();

        }
    }
}
