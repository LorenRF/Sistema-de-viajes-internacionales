

namespace LarimalTravel.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class ClienteController : ControllerBase
    {
        [HttpGet("get-user-Suscriptions/unsuscriptions")]
        public IActionResult GetSuscriptions(int user, bool estado)
        {
            CUserManager fachada = new CUserManager();
            IServicio[] Suscriptions = fachada.getSuscriptions(user, estado);

            return Ok(Suscriptions);
        }

        [HttpGet("get-user-Bookings")]
        public IActionResult GetBookins(int id, string formato)
        {
            CUserManager fachada = new CUserManager();
            string reservaciones = fachada.obtenerReservaciones(id, formato);

            // Punto de control: Imprimir la lista de reservaciones antes de convertirla a JSON
            foreach (var reserva in reservaciones)
            {
                Console.WriteLine(reserva.GetType().FullName);
            }

            return Ok(reservaciones);
        }

        [HttpGet("get-user-by-id")]
        public IActionResult GetUser(int id)
        {
            CUserManager fachada = new CUserManager();
            IActionResult user = fachada.obtenerUser(id);

            return user;
        }

        [HttpPost("user-register")]
        public int UserRegister(string correo, string password, string userName)
        {
            CUserManager fachada = new CUserManager();
            int ID = fachada.registrarUser(userName, correo , password);
            fachada.suscribirUser(ID);

            return ID;
        }

        [HttpPost("suscribe-user")]
        public int Usersuscriber(int ID)
        {
            CUserManager fachada = new CUserManager();
            fachada.suscribirUser(ID);

            return ID;
        }

        [HttpDelete("unuscribe-user")]
        public int Userunsuscriber(int ID)
        {
            CUserManager fachada = new CUserManager();
            fachada.dessuscribirUser(ID);

            return ID;
        }
    }
}
