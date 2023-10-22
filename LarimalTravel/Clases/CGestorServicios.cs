using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace LarimalTravel
{
    public class CGestorServicios: IGestor
    {

        public List<IServicio> buscar(int parametro, string servicio)
        {
            CBuscador buscador = new CBuscador();

           return buscador.buscar(parametro, servicio);
        }

        public List<IServicio> buscar(string parametro, string servicio)
        {
            CBuscador buscador = new CBuscador();
            return buscador.buscar(parametro, servicio);
        }

        public List<IReservations> reservar(int idservicio, int idUser, string servicio, string formato)
        {
            CReservacion reservacion = new CReservacion();

            return reservacion.reservar(idservicio, idUser, servicio, formato);
        }


    }
}
