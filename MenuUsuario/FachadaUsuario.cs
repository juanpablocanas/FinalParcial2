using System;
using System.Collections.Generic;
using System.Linq;
using linq.Torneo;

namespace linq.MenuUsuario
{
    public class FachadaUsuario{
        #region Methods
         public int MenuPrincipal(){
            Console.WriteLine("\n \n Bienvenido al estadio Corona-Futbol");
             Console.WriteLine("1. Jugar con selecciones ya cargadas. \n 2. Cargar selecciones y luego simular. 0 Para salir"  );
            int choice;
            string Opcion;
            Opcion = Console.ReadLine();      
            choice = Convert.ToInt32(Opcion);                   
            return choice;    
         }
         public void Opcion(RepositorioDatos Datos, List<Seleccion> Selecciones,List<string> jugadorDestacado,List<string> jugadorSanciones ){
            FachadaUsuario objUsu= new FachadaUsuario();
            inicializador objIniciar = new inicializador();      
             int choice;
             do{
                 choice = objUsu.MenuPrincipal();
                 switch(choice){
                     case 1:
                        Console.WriteLine("Jugando con selecciones ya cargadas");
                        objIniciar.iniciarPartido(Datos,Selecciones,jugadorDestacado,jugadorSanciones);
                     break;
                     case 2:
                        Console.WriteLine("Cargando seleciones....");
                        objIniciar.cargarSeleccion(Selecciones);
                        break;
                 }
             }while(choice!=0);

             }
              #endregion Methods
         }
    }
    
