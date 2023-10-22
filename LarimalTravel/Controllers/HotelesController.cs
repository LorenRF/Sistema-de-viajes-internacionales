
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace LarimalTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelesController : ControllerBase
    {

        [HttpGet("get-hotel-by-ID")]
        public IActionResult GethotelByID(int id)
        {
            string hotel = "Hotel";
            CGestorServicios gestor = new CGestorServicios();
            List<IServicio> resultado = gestor.buscar(id, hotel);

            // Serializar el arreglo de objetos a JSON
            string json = JsonConvert.SerializeObject(resultado);

            return Ok(json);
        }

        [HttpGet("get-hotel-by-location")]
        public IActionResult GetVueloByLocation(string destino)
        {
            string hotel = "Hotel";
            CGestorServicios gestor = new CGestorServicios();
            List<IServicio> resultado = gestor.buscar(destino, hotel);

            // Serializar el arreglo de objetos a JSON
            string json = JsonConvert.SerializeObject(resultado);

            return Ok(json);
        }

        [HttpPost("Booking")]
        public IActionResult Booking(int idHotel, int idUser, string formato)
        {
            CGestorServicios gestor = new CGestorServicios();
            string servicio = "Hotel";
            List<IReservations> datosReservacion = gestor.reservar(idHotel, idUser, servicio, formato);
            // Serializar el arreglo de objetos a JSON
            string json = JsonConvert.SerializeObject(datosReservacion);
            return Ok(json);
        }

    }
}
