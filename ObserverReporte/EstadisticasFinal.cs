using System;
using System.Collections.Generic;
using System.IO;
using linq.Torneo;
using Newtonsoft.Json;

namespace linq.ObserverReporte
{
    public class EstadisticasFinal: IObserverReportePartido
    {
        public void update(List<Seleccion> Selecciones){
            Console.WriteLine("Observer: Final del Partido. Se actualiza el json ");
            List<Seleccion> temporal = JsonConvert.DeserializeObject<List<Seleccion>>(File.ReadAllText("./ReportePartido.json"));///
            temporal.AddRange(Selecciones);
            
            var dataSerializada = JsonConvert.SerializeObject(Selecciones);
            File.WriteAllText("./ReportePartido.json", dataSerializada);

        }
        
    }
    
}