using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProyectoFinal
{
   public class ListaIncidencias
    {
        private static List<Incidencia> incidencias;

        public ListaIncidencias() 
        {
            incidencias = new List<Incidencia>();
        }

        public static void AñadirIncidencia(DateTime d,string informacion) 
        {
            incidencias.Add(new Incidencia(d,informacion));
        }

        public static void ListarIncidencias() 
        {
            foreach (Incidencia i in incidencias) 
            {
                Console.WriteLine(i);
            }
        }

        public static void GuardarIncidencias()
        {
           
            string fichero = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month) + Convert.ToString(DateTime.Now.Day) + ".log";
            try
            {
                StreamWriter writer = new StreamWriter(fichero, true);
                foreach (Incidencia i in incidencias)
                {
                    writer.WriteLine(i);
                }
                writer.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error en el fichero {e.Message}");
            }
        }

    }
}
