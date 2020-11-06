using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using linq.Observer;
using linq.Torneo;
using linq.MenuUsuario;
using Newtonsoft.Json;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositorioDatos Datos = new RepositorioDatos();
            List<Seleccion> Selecciones = Datos.Selecciones;
            //Selecciones = JsonConvert.DeserializeObject<List<Seleccion>>(File.ReadAllText("./ReportePartido.json"));////
            List<string> jugadorDestacado= new List<string>();
            List<string> jugadorSanciones= new List<string>();
            FachadaUsuario objUsu= new FachadaUsuario();
            objUsu.Opcion(Datos,Selecciones,jugadorDestacado,jugadorSanciones);
            //try{
            //Seleccion BrasilDes=JsonConvert.DeserializeObject<Seleccion>(File.ReadAllText("./crearSeleccion.json"));//
            //Console.WriteLine("Funcionalidad Crear selecciones. Se agrega Seleccion por Json");//
            //Selecciones.Add(BrasilDes);//
            

            //Console.WriteLine("Bienvenido al estadio Viva El Coronavirus. Esta es la funcionalidad ejecutar partido\n Escriba el equipo local");//
            //string equipoLo= Console.ReadLine();//
            //Console.WriteLine("Escriba el equipo Visitante");//
            //string equipoVis= Console.ReadLine();       //    
            //Seleccion s1 = Selecciones.First(s => s.Nombre == equipoLo) as Seleccion;//
           // Seleccion s2 = Selecciones.FirstOrDefault(s => s.Nombre == equipoVis) as Seleccion;//
            
            //Partido partido1 = new Partido(s1, s2);
            //Console.WriteLine("El resutlado del partido es: "+partido1.Resultado());  
            //}
            //catch(System.InvalidOperationException){
                //Console.WriteLine("Asegurese que los nombres de los equipos sean correctos");
           // }
            //var seleccionSerializada = JsonConvert.SerializeObject(s1);
            //File.WriteAllText("./selecciones.json", seleccionSerializada);

             //Seleccion FranciaDeserializada = JsonConvert.DeserializeObject<Seleccion>(File.ReadAllText("./selecciones.json"));
             //var jugadoresFranciaSerializados = JsonConvert.SerializeObject(s1.Jugadores);
             //File.WriteAllText("./jugadoresFrancia.json", jugadoresFranciaSerializados);

             //List<Jugador> jugadoresDeserializados = JsonConvert.DeserializeObject<List<Jugador>>(File.ReadAllText("./jugadoresFrancia.json"));
             

             //Seleccion Argentina = Selecciones.FirstOrDefault(s => s.Nombre == "Argentina") as Seleccion;

     

            // Partido partido1 = new Partido(s1, s2);//
             
             //Console.WriteLine("El resutlado del partido es: "+partido1.Resultado( Datos,  Selecciones,jugadorDestacado,jugadorSanciones));//

             //GestorEstadisticas Gestor= new GestorEstadisticas();
             //FaltaTotales foul1 = new FaltaTotales();
             //FaltaTotales foul2 = new FaltaTotales();
             //FaltaTotales foul3 = new FaltaTotales();
             //GolesTotales gol1 = new GolesTotales();
             //Gestor.Suscribe(foul1);
             //Gestor.Suscribe(foul2);
             //Gestor.Suscribe(gol1);
             //Gestor.Notificar("Se ha cometido una eventualidad");


             
             

             //s1.GolesTotales=58;
             //Console.WriteLine("GOOOOOLES: "+ s1.GolesTotales);
            // var seleccionSerializada = JsonConvert.SerializeObject(s1);
            //File.WriteAllText("./selecciones.json", seleccionSerializada);
            
            // Jugador jugador = new Jugador("Cristiano", 35, 7, 98, 40, 25, 3);
            // var jugadorSerializado = JsonConvert.SerializeObject(jugador);

            // File.WriteAllText("./jugadores.json", jugadorSerializado);

            // using (StreamWriter file = File.CreateText("./jugadores.json"))
            // {
            //     JsonSerializer serializer = new JsonSerializer();
            //     serializer.Serialize(file, jugadorSerializado);
            // }

            // Jugador jugador2 = JsonConvert.DeserializeObject<Jugador>(File.ReadAllText("./jugadores.json"));

            // using (StreamReader file = File.OpenText("./jugadores.json"))
            // {
            //     JsonSerializer serializer = new JsonSerializer();
            //     Jugador jugador2  = (Jugador)serializer.Deserialize(file, typeof(Jugador));
            //     Console.WriteLine(jugador2.Nombre);
            // }

            //ANADIR JUGADORES A FRANCIA

            // List<String> Nombres = new List<string>();

            // foreach (Seleccion seleccion in Selecciones)
            // {
            //     if (seleccion.Nombre == "Francia")
            //     {
            //         foreach(Jugador jugador in seleccion.Jugadores)
            //         {
            //             Nombres.Add(jugador.Nombre);
            //         }
            //     }
            // }

            // Seleccion s = Selecciones.Where(s => s.Nombre == "Francia").ToList<Seleccion>()[0];
            // Seleccion francia = Selecciones.First(s => s.Nombre == "Francia") as Seleccion;
            // List<String> nombres2 = francia.Jugadores.Select(jugador => jugador.Nombre).ToList();

            // List<String> nombres3 = Selecciones.First(s => s.Nombre == "Francia")
            //                                    .Jugadores.Select(jugador => jugador.Nombre).ToList();

            // Jugador últimoJugador = francia.Jugadores.First(j => j.Posicion == 11);

            // Jugador jugador33 = francia.Jugadores.FirstOrDefault(j => j.Edad == 33);
            // Jugador jugador332 = francia.Jugadores.LastOrDefault(j => j.Edad == 33);

            // Seleccion Colombia = Selecciones.FirstOrDefault(s => s.Nombre == "Colombia") as Seleccion;
            // List<Jugador> JugadoresViejos = Colombia.Jugadores.Where(j => (j.Edad >= 26 && j.Edad <= 34)).ToList<Jugador>();

            // List<Jugador> JugadoresViejos2 = Colombia.Jugadores.Where(j => j.Edad >= 26)
            //                                                    .Where(j => j.Edad <= 33).ToList<Jugador>();

            // Seleccion Argentina = Selecciones.FirstOrDefault(s => s.Nombre == "Argentina") as Seleccion;
            // bool HayJugadorPro = Argentina.Jugadores.Any(j => j.Goles > 30);

            // List<Jugador> EspañaOrdenados = Selecciones.FirstOrDefault(s => s.Nombre == "España") 
            //                                            .Jugadores.OrderBy(j => j.Edad).ToList<Jugador>();

            // List<Jugador> EspañaOrdenados2 = Selecciones.FirstOrDefault(s => s.Nombre == "España") 
            //                                            .Jugadores.OrderByDescending(j => j.Edad).ToList<Jugador>();    

            // var jugadorMax = francia.Jugadores.Max(j => j.Goles);
            // var jugadorMin = francia.Jugadores.Min(j => j.Goles);

            // List<Jugador> jugadoresCombinados = francia.Jugadores.Concat(Colombia.Jugadores).OrderBy(j => j.Ataque).ToList<Jugador>();
            // int CantidadJugadores = jugadoresCombinados.Count;

        }
    }
}
