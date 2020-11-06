using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Excepciones.CustomExceptions;
using Newtonsoft.Json;
using linq.ObserverReporte;

namespace linq.Torneo
{
    public class Partido
    {
        #region Properties  
        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }

        #endregion Properties

        #region Initialize
        public Partido(Seleccion EquipoLocal, Seleccion EquipoVisitante) 
        {
            this.EquipoLocal = new Equipo(EquipoLocal);
            this.EquipoVisitante = new Equipo(EquipoVisitante);
        }
        #endregion Initialize
        #region Methods

        
      
        private void CalcularExpulsiones()
        {
            Random random = new Random();
            int num= random.Next(0,5);
            
            for(int i=0;i<=num;i++){
                int num2=random.Next(EquipoLocal.Seleccion.Jugadores.Count);
                 
                 EquipoLocal.ExpulsarJugador(EquipoLocal.Seleccion.Jugadores[num2].Nombre);              
                
                EquipoVisitante.ExpulsarJugador(EquipoVisitante.Seleccion.Jugadores[num2].Nombre);

            }
            List<String> restodeEquipoLo= EquipoLocal.Seleccion.Jugadores.Select(j=>j.Nombre).ToList();
            Console.WriteLine("Los jugadores restantes del equipo local son:");
            Console.WriteLine(String.Join("\n",restodeEquipoLo));
            Console.WriteLine("----------------------");

            List<String> restodeEquipoVisi= EquipoVisitante.Seleccion.Jugadores.Select(j=>j.Nombre).ToList();
            Console.WriteLine("Los jugadores restantes del equipo visitante son:"); 
            Console.WriteLine(String.Join("\n",restodeEquipoVisi));
                

        }
        private void simularAmarillas(RepositorioDatos Datos, List<Seleccion> Selecciones,List<string> jugadorSanciones){       
            Random random = new Random();
            
            int num= random.Next(9);
            for(int i=0; i<=num;i++){             
                int num2=random.Next(EquipoLocal.Seleccion.Jugadores.Count);
                int num3=random.Next(EquipoVisitante.Seleccion.Jugadores.Count);                
                EquipoLocal.SacarTarjetaAmarilla(EquipoLocal.Seleccion.Nombre,EquipoLocal.Seleccion.Jugadores[num2].Nombre,Datos,Selecciones,jugadorSanciones);
                EquipoVisitante.SacarTarjetaAmarilla(EquipoVisitante.Seleccion.Nombre,EquipoVisitante.Seleccion.Jugadores[num2].Nombre,Datos,Selecciones,jugadorSanciones);
                
            }
                
        }     

        private void CalcularResultado()
        {
            Random random = new Random();
            EquipoLocal.Goles = random.Next(0,6);
            EquipoVisitante.Goles = random.Next(0,6);
            EquipoLocal.Asistencias = random.Next(0,3);
            EquipoVisitante.Asistencias = random.Next(0,3);
            EquipoLocal.Faltas= EquipoLocal.TarjetasAmarillas+EquipoLocal.TarjetasRojas;
            EquipoVisitante.Faltas= EquipoVisitante.TarjetasRojas+EquipoVisitante.TarjetasRojas;   

        }

        private void simularGoles(RepositorioDatos Datos, List<Seleccion> Selecciones,List<string> jugadoresDestacados){
 
            Random random = new Random();
            int num= random.Next(3);
            for(int i=0; i<=num;i++){             
                int num2=random.Next(EquipoLocal.Seleccion.Jugadores.Count);
                int num3=random.Next(EquipoVisitante.Seleccion.Jugadores.Count);
                EquipoLocal.hacergol(EquipoLocal.Seleccion.Nombre,EquipoLocal.Seleccion.Jugadores[num2].Nombre,Datos,Selecciones,jugadoresDestacados);
                EquipoVisitante.hacergol(EquipoVisitante.Seleccion.Nombre,EquipoVisitante.Seleccion.Jugadores[num2].Nombre,Datos,Selecciones,jugadoresDestacados);
            }

        }
        

        public string Resultado(RepositorioDatos Datos, List<Seleccion> Selecciones,List<string> jugadoresDestacado,List<string> jugadorSanciones)
        {
            string resultado = "0 - 0";
            try
            {
                //crearSeleccion();
                
                CalcularExpulsiones();
                //CalcularResultado();
                simularGoles(Datos,Selecciones,jugadoresDestacado);
                simularAmarillas(Datos,Selecciones,jugadorSanciones);
                var seleccionSerializada = JsonConvert.SerializeObject(EquipoLocal);
                File.WriteAllText("./selecciones.json", seleccionSerializada); //////////////Si lo pongo aqui, funciona las goles pero no los tarjestas
                GestorReporte gestor= new GestorReporte();
                EstadisticasFinal finalPartido = new EstadisticasFinal();
                gestor.Suscribe(finalPartido);
                gestor.Notificar(Selecciones);

                //var seleccionSerializada2 = JsonConvert.SerializeObject(EquipoVisitante);
                //File.WriteAllText("./selecciones.json", seleccionSerializada2); //////////////Si lo pongo aqui, funciona las goles pero no los tarjestas
                
                resultado = EquipoLocal.Goles.ToString() + " - " + EquipoVisitante.Goles.ToString();
            
                
            }
            catch(LoseForWException ex)
            {
                Console.WriteLine(ex.Message);
                EquipoLocal.Goles -= EquipoLocal.Goles;
                EquipoVisitante.Goles -= EquipoVisitante.Goles;
                if (ex.NombreEquipo == EquipoLocal.Seleccion.Nombre)
                {
                    EquipoVisitante.Goles += 3;
                    resultado = "0 - 3";
                }
                else
                {
                    EquipoLocal.Goles += 3;
                    resultado = "3 - 0";
                }
            }
            
            return resultado;
        }
        #endregion Methods

    }
}