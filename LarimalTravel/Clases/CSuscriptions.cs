using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace LarimalTravel
{
    public class CSuscriptions
    {
        // Lista de usuarios suscritos a la lista de observadores
        public List<CUser> SubscribedUsers { get; set; }

        // Lista de usuarios que no están suscritos a la lista de observadores
        public List<CUser> UnsubscribedUsers { get; set; }

        public CSuscriptions()
        {
            // Inicializar las listas en el constructor
            SubscribedUsers = new List<CUser>();
            UnsubscribedUsers = new List<CUser>();
        }

        // Método para obtener los usuarios suscritos y no suscritos
        public List<CUser> GetUsersHotelSuscribed(int ID, bool estado)
        {
            CHotel hotel = new CHotel();

            // Buscar al usuario por ID en la lista de observadores
            CUser user = CHotel.observadores.Find(observador => observador is CUser cUser && cUser.iD == ID) as CUser;

            if (user != null)
            {
                // El usuario está suscrito, agregarlo a la lista de suscritos
                SubscribedUsers.Add(user);
                
            }
            else
            {
                // El usuario no está suscrito, agregarlo a la lista de no suscritos
                // Leer el contenido del archivo JSON
                string json = File.ReadAllText("Json/Usuarios.json");

                // Deserializar el contenido JSON en una lista de objetos CUser
                List<CUser> users = JsonConvert.DeserializeObject<List<CUser>>(json);

                // Buscar el usuario deseado en la lista de usuarios
                foreach (CUser usuario in users)
                {
                    if (usuario.iD == ID)
                    {
                        user = usuario;
                        UnsubscribedUsers.Add(user);
                    }

                }
                
                
            }

            if (estado == true) 
            {
                return SubscribedUsers;
            }
            else
            {
                return UnsubscribedUsers;
            }

        }

        public IServicio[] GetHotelSuscriptions(int ID)
        {

            CHotel hotel = new CHotel();

            CUser user = CHotel.observadores.Find(observador => observador is CUser cUser && cUser.iD == ID) as CUser;

            if (user != null)
            {

                return hotel.Get();
            }
            else
            {

                return new IServicio[0];
            }
        }
    }
}
