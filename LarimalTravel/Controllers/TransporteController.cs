
 using Microsoft.AspNetCore.Mvc;
 using Newtonsoft.Json;
namespace LarimalTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransporteController : ControllerBase
    {

        [HttpGet("get-tansporte-by-ID")]
        public IActionResult GethotelByID(int id)
        {
            string tansporte = "Transporte";
            CGestorServicios gestor = new CGestorServicios();
            List<IServicio> resultado = gestor.buscar(id, tansporte);

            // Serializar el arreglo de objetos a JSON
            string json = JsonConvert.SerializeObject(resultado);

            return Ok(json);
        }

        [HttpGet("get-tansporte-by-location")]
        public IActionResult GetVueloByLocation(string location)
        {
            string tansporte = "Transporte";
            CGestorServicios gestor = new CGestorServicios();
            List<IServicio> resultado = gestor.buscar(location, tansporte);

            // Serializar el arreglo de objetos a JSON
            string json = JsonConvert.SerializeObject(resultado);

            return Ok(json);
        }

        [HttpPost("Booking")]
        public IActionResult Booking(int idtransport, int idUser, string formato)
        {
            CGestorServicios gestor = new CGestorServicios();
            string servicio = "Transporte";
            List<IReservations> datosReservacion = gestor.reservar(idtransport, idUser, servicio, formato);
            // Serializar el arreglo de objetos a JSON
            string json = JsonConvert.SerializeObject(datosReservacion);
            return Ok(json);
        }
    }
}
