using System.IO;
using Newtonsoft.Json;

namespace LarimalTravel
{
    public class CFlightReservations : IReservations
    {
        [JsonProperty("vuelo")]
        public CVuelo vuelo { get; set; }

        [JsonProperty("user")]
        public CUser user { get; set; }

        private string filePath;

        public List<IReservations> Booking(IServicio servicio, CUser user, string formato)
        {
            if (formato == "json")
            {
                filePath = "Json/FlightReservations.json";
            }
            else if (formato == "txt")
            {
                filePath = "txt/FlightReservations.txt";
            }
            else { filePath = "EXCEL/FlightReservations.xlsx"; }

            CSaveTo contexto = new CSaveTo(CObtenerFormato.getFormato(formato, filePath));


            // Cargar la lista de reservaciones existente desde el archivo JSON
            List<CFlightReservations> reservacionesVuelos = contexto.LoadReservations<CFlightReservations>();

            vuelo = servicio as CVuelo;

            // Agregar la nueva reservación a la lista
            reservacionesVuelos.Add(new CFlightReservations
            {
                vuelo = vuelo,
                user = user
            });

            // Guardar la lista actualizada en el archivo JSON
            contexto.SaveReservations(reservacionesVuelos);

            List<IReservations> reservacionesIReservations = reservacionesVuelos.Cast<IReservations>().ToList();

            return reservacionesIReservations;
        }
    }
}
