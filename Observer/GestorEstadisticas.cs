using System;
using System.Collections.Generic;

namespace linq.Observer
{
    public class GestorEstadisticas
    {
        #region Properties
        private List<IObserverFinalPartido> suscribers;
        public List<IObserverFinalPartido> Suscribers
        {
            get { return suscribers; }
            set { suscribers = value; }
        }
        #endregion Properties

        #region Initialize
        public GestorEstadisticas(){
            Suscribers= new List<IObserverFinalPartido>();
        }
        #endregion Initialize

        #region Methods
        public void Suscribe(IObserverFinalPartido suscriber){
            Suscribers.Add(suscriber);
        }
        public void UnSuscribe(IObserverFinalPartido suscriber){
            Suscribers.Remove(suscriber);
        }
        public void Notificar(List<string> Jugadores){
            Suscribers.ForEach(s=>{
                s.update(Jugadores);
            });
        }




        #endregion Methods

        
        
        
    }
    
}