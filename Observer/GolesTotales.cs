using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace linq.Observer
{
    public class GolesTotales: IObserverFinalPartido
    {
        public void update(List<string> Jugadores){
            Console.WriteLine("Gol historico!! Se actualiza Json ");
            List<string> temporal = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText("./golesDestacables.json"));///
            //Console.WriteLine("Mi JSON: "+String.Join("\n",temporal));
            temporal.AddRange(Jugadores);
            
            var dataSerializada = JsonConvert.SerializeObject(temporal);
            File.WriteAllText("./golesDestacables.json", dataSerializada);
        }
        
    }
    
}