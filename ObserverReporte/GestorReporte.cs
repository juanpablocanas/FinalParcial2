using System;
using System.Collections.Generic;
using linq.Torneo;

namespace linq.ObserverReporte
{
    public class GestorReporte
    {
        #region Properties
        private List<IObserverReportePartido> suscribers;
        public List<IObserverReportePartido> Suscribers
        {
            get { return suscribers; }
            set { suscribers = value; }
        }
        #endregion Properties

        #region Initialize
        public GestorReporte(){
            Suscribers= new List<IObserverReportePartido>();
        }
        #endregion Initialize

        #region Methods
        public void Suscribe(IObserverReportePartido suscriber){
            Suscribers.Add(suscriber);
        }
        public void UnSuscribe(IObserverReportePartido suscriber){
            Suscribers.Remove(suscriber);
        }
        public void Notificar(List<Seleccion> Selecciones){
            Suscribers.ForEach(s=>{
                s.update(Selecciones);
            });
        }
        #endregion Methods
    }
}