using System.IO;
using LarimalTravel.Controllers;
using Newtonsoft.Json;
namespace LarimalTravel
{
    public class CReservacion
    {
        IServicio Servicio;
        CUser Usuario;
        public List<IReservations> reservar(int id, int idUser, string servicio, string formato)
        {
            string jsonUsuarios = File.ReadAllText("Json/Usuarios.json");
            IReservations setBook = CGetBook.getReservation(servicio);
            CContexto contexto = new CContexto(CObtenerServicio.getServicio(servicio));
            IServicio[] listaServicio = contexto.ejecutar();
            List<CUser> listaUsuario = JsonConvert.DeserializeObject<List<CUser>>(jsonUsuarios);
            CReservationsContext CRC = new CReservationsContext(setBook);

            if (servicio == "Vuelo")
            {
                foreach (CVuelo vuelo in listaServicio)
                {
                    if (vuelo.codigo == id)
                    {
                        Servicio = vuelo;
                    }
                }
            }
            else if (servicio == "Hotel")
            {
                foreach (CHotel hotel in listaServicio)
                {
                    if (hotel.id == id && CHotel.disponibilidad == true)
                    {
                        Servicio = hotel;
                    }
                    else
                    {
                        List<IReservations> noHayCupos = new List<IReservations>();
                        return null;
                    }
                }
            }
            else if (servicio == "Transporte")
            {
                foreach (CTransporte transporte in listaServicio)
                {
                    if (transporte.id == id)
                    {
                        Servicio = transporte;
                    }
                }
            }

            else
            {
                setBook = null;
            }

            foreach (CUser usuario in listaUsuario)
            {
                if (usuario.iD == idUser)
                {
                    Usuario = usuario;
                }
            }


            List<IReservations> datosReservacion = CRC.ejecutar(Servicio, Usuario, formato);

            return datosReservacion;
        }

    }
    
}
