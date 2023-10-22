using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LarimalTravel
{
    public interface IGestor
    {
        List<IServicio> buscar(int parametro, string servicio);
        List<IServicio> buscar(string parametro, string servicio);
        List<IReservations> reservar(int idVuelo, int idUser, string servicio, string formato);
    }
}
