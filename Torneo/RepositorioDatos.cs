using System.Collections.Generic;
using System.Linq;

namespace linq.Torneo
{
    public class RepositorioDatos
    {
        #region Properties  
        public List<Seleccion> Selecciones { get; set; }
        
        #endregion Properties

        #region Initialize
        public RepositorioDatos()
        {
            Selecciones = CrearSelecciones();
        }
        #endregion Initialize


        #region Methods
        private List<Seleccion> CrearSelecciones()
        {
            List<Seleccion> selecciones = new List<Seleccion>();
            selecciones.Add(new Seleccion()
            {
                Nombre = "Francia",
                PuntosTotales=0,
                GolesTotales=0,
                AsistenciasTotales=0,
                Jugadores = new List<Jugador>()
                {
                    new Jugador("Griezmann", 28,0, 11, 90, 55, 10, 2),
                    new Jugador("Benzema", 32,0, 9, 92, 40, 20, 1),
                    new Jugador("Mbappe", 21,0, 7, 95, 50, 15, 14),
                    new Jugador("Pavard", 23,0, 11, 92, 45, 12, 17),
                    new Jugador("Martial", 23,0, 11, 92, 45, 12, 17),
                    new Jugador("Rabiot", 23,0, 11, 92, 45, 12, 17),
                    new Jugador("Pogba", 23,0, 11, 92, 45, 12, 17),
                    new Jugador("Mendy", 23,0, 11, 92, 45, 12, 17),
                    new Jugador("Presnel", 23,0, 11, 92, 45, 12, 17),
                    new Jugador("Umtiti", 23,0, 11, 92, 45, 12, 17),
                    new Jugador("Mandanda", 23,0, 11, 92, 45, 12, 17),
                }
            });
            selecciones.Add(new Seleccion()
            {
                Nombre = "España",
                PuntosTotales=0,
                GolesTotales=0,
                AsistenciasTotales=0,
                Jugadores = new List<Jugador>()
                {
                    new Jugador("Ramos", 33,0, 6, 60, 85, 8, 0),
                    new Jugador("Fati", 17,0, 9, 95, 40, 10, 12),
                    new Jugador("Aspas", 32,0, 11, 85, 55, 5, 5),
                    new Jugador("Busquets", 0,33, 5, 79, 85, 2, 3),
                    new Jugador("Villa", 33,0, 5, 79, 85, 2, 3),
                    new Jugador("Casillas",33,0, 5, 79, 85, 2, 3),
                    new Jugador("Torres",33,0, 5, 79, 85, 2, 3),
                    new Jugador("Navas",33,0, 5, 79, 85, 2, 3),
                    new Jugador("De Gea",33,0, 5, 79, 85, 2, 3),
                    new Jugador("Isco",33,0, 5, 79, 85, 2, 3),
                    new Jugador("Kepa",33,0, 5, 79, 85, 2, 3),
                }
            });
            selecciones.Add(new Seleccion()
            {
                Nombre = "Colombia",
                PuntosTotales=0,
                GolesTotales=0,
                AsistenciasTotales=0,
                Jugadores = new List<Jugador>()
                {
                    new Jugador("Falcao", 33,0, 9, 89, 50, 9, 2),
                    new Jugador("James", 29,0, 10, 97, 45, 7, 17),
                    new Jugador("Ospina", 31,0, 1, 40, 95, 0, 0),
                    new Jugador("Mina", 24,0, 2, 55, 89, 4, 0),
                    new Jugador("Zapata", 24,0, 2, 55, 89, 4, 0),
                    new Jugador("Cuadrado", 24,0, 2, 55, 89, 4, 0),
                    new Jugador("Muriel", 24,0, 2, 55, 89, 4, 0),
                    new Jugador("Arias", 24,0, 2, 55, 89, 4, 0),
                    new Jugador("Sanchez", 24,0, 2, 55, 89, 4, 0),
                    new Jugador("Lerma", 24,0, 2, 55, 89, 4, 0),
                    new Jugador("Mojica", 24,0, 2, 55, 89, 4, 0),
                }
            });
            selecciones.Add(new Seleccion()
            {
                Nombre = "Argentina",
                PuntosTotales=0,
                GolesTotales=0,
                AsistenciasTotales=0,
                Jugadores = new List<Jugador>()
                {
                    new Jugador("Messi", 33,0, 10, 99, 50, 40, 20),
                    new Jugador("Aguero", 32,0, 9, 90, 50, 10, 5),
                    new Jugador("Acuña", 24,0, 4, 75, 85, 3, 10),
                    new Jugador("Dybala", 25,0, 7, 90, 45, 8, 6),
                    new Jugador("Martinez", 25,0, 7, 90, 45, 8, 6),
                    new Jugador("Armani", 25,0, 7, 90, 45, 8, 6),
                    new Jugador("Otamendi", 25,0, 7, 90, 45, 8, 6),
                    new Jugador("Foyth", 25,0, 7, 90, 45, 8, 6),
                    new Jugador("Moradona", 25,0, 7, 90, 45, 8, 6),
                    new Jugador("Medina", 25,0, 7, 90, 45, 8, 6),
                    new Jugador("Perez", 25,0, 7, 90, 45, 8, 6),
                }
            });
            

            return selecciones;
        }

        #endregion Methods



    }
}