using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LarimalTravel
{
    public class CUserManager
    {
        public int registrarUser(string userName, string correo, string password)
        {
            CUserRegister userRegister = new CUserRegister();
           int ID = userRegister.Registrar(correo,userName,password);
            return ID;
        }

        public void suscribirUser(int ID)
        {
            CSuscriptionsManager suscriptionsManager = new CSuscriptionsManager();
            suscriptionsManager.suscribirUser(ID);

        }

        public void dessuscribirUser(int ID)
        {
            CSuscriptionsManager suscriptionsManager = new CSuscriptionsManager();
            suscriptionsManager.dessuscribirUser(ID);



        }

        public IServicio[] getSuscriptions (int ID, bool estado)
        {
            CSuscriptionsManager suscriptionsManager = new CSuscriptionsManager();
            IServicio[] servicio =  suscriptionsManager.getSuscriptions(ID, estado);
            return servicio;

        }


            public string obtenerReservaciones(int id, string formato)
        {
          CUserReservations book = new CUserReservations();
            string reservaciones = book.GetUserReservations(id, formato);
            return reservaciones;
        }

        public IActionResult obtenerUser(int id)
        {
            CUserGet userGet = new CUserGet();
            IActionResult usuario = userGet.getUserById(id);

            return usuario;
        }


    }
}
