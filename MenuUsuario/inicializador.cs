using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using linq.Torneo;
using Newtonsoft.Json;

namespace linq.MenuUsuario
{
    public class inicializador{
        #region Methods
        public void iniciarPartido(RepositorioDatos Datos,List<Seleccion> Selecciones,List<string> jugadorDestacado,List<string> jugadorSanciones){
            try{
                Console.WriteLine("Escriba el equipo Local");
                string equipoLo= Console.ReadLine();
                Console.WriteLine("Escriba el equipo Visitante");
                string equipoVis= Console.ReadLine();           
                Seleccion s1 = Selecciones.First(s => s.Nombre == equipoLo) as Seleccion;
                Seleccion s2 = Selecciones.FirstOrDefault(s => s.Nombre == equipoVis) as Seleccion;
                Partido partido1 = new Partido(s1, s2);
                Console.WriteLine("El resutlado del partido es: "+partido1.Resultado( Datos,  Selecciones,jugadorDestacado,jugadorSanciones));
            }catch(InvalidOperationException){
                Console.WriteLine("La seleccion que puso a jugar no esta cargada. Cargela primero");
            }
            catch(System.NullReferenceException){
                Console.WriteLine("La seleccion que puso a jugar no esta cargada. Cargela primero");
            }

        }
        public void cargarSeleccion(List<Seleccion> Selecciones){
            try{
                Console.WriteLine("Cargando selecciones del Json");
                Console.WriteLine("Escriba el nombre de la seleccion que quiere cargar. Mexico Brasil Javeriana ");
                string nombreSel= Console.ReadLine();
                string nombreSelJson= "./"+nombreSel+".json";
                Seleccion selDes=JsonConvert.DeserializeObject<Seleccion>(File.ReadAllText(nombreSelJson)); ///
                Console.WriteLine("Funcionalidad Crear selecciones. Se agrega Seleccion por Json. Pulse 1 para jugar");
                Selecciones.Add(selDes);
            }catch(System.IO.FileNotFoundException){
                Console.WriteLine("Esa seleccion no existe. Escriba bien");
            }
             

        }
    }
}
        #endregion Methods