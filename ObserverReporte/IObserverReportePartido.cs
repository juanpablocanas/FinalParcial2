using System.Collections.Generic;
using linq.Torneo;

namespace linq.ObserverReporte
{
    public interface IObserverReportePartido
    {
        void update(List<Seleccion> Selecciones);
        
    }
    
}