using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace linq.Observer
{
    public class FaltaTotales: IObserverFinalPartido
    {
        public void update(List<string> Jugadores){
            Console.WriteLine("Falta monetaria!! Se informa en el JSON ");
            List<string> temporal = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText("./sanciones.json"));///
            //Console.WriteLine("Mi JSON: "+String.Join("\n",temporal));
            temporal.AddRange(Jugadores);
            
            var dataSerializada = JsonConvert.SerializeObject(temporal);
            File.WriteAllText("./sanciones.json", dataSerializada);
        }
        
    }
    
}