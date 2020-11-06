using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Excepciones.CustomExceptions;
using linq.Observer;
using Newtonsoft.Json;

namespace linq.Torneo
{
    public class Equipo
    {
        #region Properties  
        public int Goles { get; set; }
        public int Asistencias { get; set; }
        public int Faltas { get; set; }
        public int TarjetasAmarillas { get; set; }
        public int TarjetasRojas { get; set; }
        public Seleccion Seleccion { get; set; }
        public bool EsLocal { get; set; }

        #endregion Properties

        #region Initialize
        public Equipo(Seleccion seleccion)
        {
            this.Seleccion = seleccion;
        }
        #endregion Initialize

        #region Methods

        public void golHistorico(string seleccionDeseada,string jugadorDeseado,RepositorioDatos Datos, List<Seleccion> Selecciones,List<string> jugadorGol){
            GestorEstadisticas Gestor= new GestorEstadisticas();
            GolesTotales valioso = new GolesTotales();
            Seleccion s = Selecciones.First(s=> s.Nombre== seleccionDeseada);
            Jugador jogger=s.Jugadores.First(j=> j.Nombre == jugadorDeseado);
            jugadorGol.Add(jogger.Nombre);
            Gestor.Suscribe(valioso);
            Gestor.Notificar(jugadorGol);
            jogger.Goles+=1;     
            Goles++;
            s.GolesTotales++;
        }

        public void sancionMonetaria(string seleccionDeseada,string jugadorDeseado,RepositorioDatos Datos, List<Seleccion> Selecciones,List<string> jugadorSanciones){
            GestorEstadisticas Gestor= new GestorEstadisticas();
            FaltaTotales valioso = new FaltaTotales();
            Seleccion s = Selecciones.First(s=> s.Nombre== seleccionDeseada);
            Jugador jogger=s.Jugadores.First(j=> j.Nombre == jugadorDeseado);
            jugadorSanciones.Add(jogger.Nombre);
            Gestor.Suscribe(valioso);
            Gestor.Notificar(jugadorSanciones);
            Faltas++;

        }


        public void hacergol(string seleccionDeseada,string jugadorDeseado,RepositorioDatos Datos, List<Seleccion> Selecciones,List<string> jugadoresDestacados){
            try{
            Random random=new Random();    
            
            Seleccion s = Selecciones.First(s=> s.Nombre== seleccionDeseada);
            Jugador jogger=s.Jugadores.First(j=> j.Nombre == jugadorDeseado);
            jogger.Goles+=1;     
            Goles++;
            //var seleccionSerializada2 = JsonConvert.SerializeObject(s);
            //File.WriteAllText("./colombia.json", seleccionSerializada2); 
            Console.WriteLine(jogger.Nombre+"  ha marcado GOOL!");
            s.GolesTotales++;
            Asistencias=Goles*2;
            s.PuntosTotales=Goles+2;

            int num=random.Next(5);
           
            if(num==1){
                golHistorico(s.Nombre,jogger.Nombre,Datos,Selecciones,jugadoresDestacados);
            }
            else{
                Console.WriteLine("No es gol destacable");
            }
            

            
            

            //Seleccion ColombiaEstadisticas=JsonConvert.DeserializeObject<Seleccion>(File.ReadAllText("./colombia.json"));
            //Console.WriteLine("Stats Colombia: "+ColombiaEstadisticas.GolesTotales);

            // var seleccionSerializada = JsonConvert.SerializeObject(s);
             //File.WriteAllText("./selecciones.json", seleccionSerializada);

             using (StreamReader file = File.OpenText("./selecciones.json"))
             {
                 JsonSerializer serializer = new JsonSerializer();
                  s  = (Seleccion)serializer.Deserialize(file, typeof(Seleccion));
                  //s.GolesTotales=s.GolesTotales+Goles;
                 //Console.WriteLine("TEEEEEEST TOTALLEEEESSSSS: "+s.GolesTotales);
             }




            //var seleccionSerializada = JsonConvert.SerializeObject(s);
            //File.WriteAllText("./selecciones.json", seleccionSerializada);
            }
            catch(InvalidOperationException){
                Console.WriteLine("Ese Jugador no puede hacer gol");
            }
      
        }

        public void SacarTarjetaAmarilla(string seleccionDeseada,string jugadorDeseado,RepositorioDatos Datos, List<Seleccion> Selecciones,List<string> jugadorSanciones)
        {
            try{
                Seleccion s = Selecciones.First(s=> s.Nombre== seleccionDeseada);
                Jugador jogger=s.Jugadores.First(j=> j.Nombre == jugadorDeseado);                
                jogger.amarillas+=1;
                TarjetasAmarillas++;
                Faltas++;
                Console.WriteLine("Se le ha sacado amarilla a: "+ jogger.Nombre);     
                int cant = jogger.amarillas;
                Console.WriteLine("La cantidad de amarillas de "+jogger.Nombre+" es: "+cant);
                if(cant>=2){
                    Console.WriteLine("Esta ya es la segunda tarjeta amarilla. Se procede a expulsar al jugador");
                    ExpulsarJugador(jogger.Nombre);
                }
                else{
                    //Console.WriteLine("Primera Amarilla. Otra y se le expulsara");
                }
                Random random = new Random();
                int num=random.Next(5);
           
            if(num==1){
                sancionMonetaria(s.Nombre,jogger.Nombre,Datos,Selecciones,jugadorSanciones);
            }
            else{
                Console.WriteLine("No falta amonestable monetaria");
            }
                //var seleccionSerializada = JsonConvert.SerializeObject(s);
                 //File.WriteAllText("./selecciones.json", seleccionSerializada); //////////////Si lo pongo aqui, funciona las tarjetas pero no los goles

            }
            catch(InvalidOperationException){
                Console.WriteLine();
            }
        }
          
        public void ExpulsarJugador(string name)
        {
            try
            {
 
                Jugador jugadorExpulsado = Seleccion.Jugadores.First(j => j.Nombre == name);
                TarjetasRojas++;
                Faltas++;
                if (Seleccion.Jugadores.Count < 2)   
                {
                    LoseForWException ex = new LoseForWException(Seleccion.Nombre);
                    ex.NombreEquipo = Seleccion.Nombre;
                    throw ex;
                }
                Seleccion.Jugadores.Remove(jugadorExpulsado);
                Console.WriteLine("Se ha expulsado al jugador: "+ jugadorExpulsado.Nombre);
                
                
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("No existe ese jugador para expulsarlo del equipo " + Seleccion.Nombre);
            }
            
        }
       

          }
        }

        
        #endregion Methods
    
