using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LarimalTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        [HttpGet("get-vuelos-by-ID")]
        public IActionResult GetVueloByID(int id)
        {
            string vuelo = "Vuelo";
            CGestorServicios gestor = new CGestorServicios();
            List<IServicio> resultado = gestor.buscar(id, vuelo);
            // Serializar el arreglo de objetos a JSON
            string json = JsonConvert.SerializeObject(resultado);
            return Ok(json);
        }

        [HttpGet("get-vuelos-by-destiny")]
        public IActionResult GetVueloByDestiny(string destino)
        {
            string vuelo = "Vuelo";
            CGestorServicios gestor = new CGestorServicios();
            List<IServicio> resultado = gestor.buscar(destino, vuelo);

            // Serializar el arreglo de objetos a JSON
            string json = JsonConvert.SerializeObject(resultado);

            return Ok(json);
        }

        [HttpPost("Booking")]
        public IActionResult Booking(int idVuelo, int idUser, string formato)
        {
            CGestorServicios gestor = new CGestorServicios();
            string servicio = "Vuelo";
            List<IReservations> datosReservacion = gestor.reservar(idVuelo, idUser, servicio, formato);
            // Serializar el arreglo de objetos a JSON
            string json = JsonConvert.SerializeObject(datosReservacion);
            return Ok(json);
        }
    }
}
