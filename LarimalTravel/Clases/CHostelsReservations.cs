using System.IO;
using Newtonsoft.Json;

namespace LarimalTravel
{
    public class CHostelsReservations : IReservations
    {
        public CHotel hotel { get; set; }
        public CUser user { get; set; }

        private string filePath; 


        public List<IReservations> Booking(IServicio servicio, CUser user, string formato)
        {
            if(formato == "json")
            {
                filePath = "Json/HostelsReservations.json";
            }
            else if(formato == "txt")
            {
                filePath = "txt/HostelsReservations.txt";
            }
            else { filePath = "EXCEL/HostelsReservations.xlsx"; }

            CSaveTo contexto = new CSaveTo(CObtenerFormato.getFormato(formato, filePath));
           

            // Cargar la lista de reservaciones existente desde el archivo JSON
            List<CHostelsReservations> reservacionesHoteles = contexto.LoadReservations<CHostelsReservations>();

            hotel = servicio as CHotel;

            // Agregar la nueva reservación a la lista
            reservacionesHoteles.Add(new CHostelsReservations
            {
                hotel = hotel, 
                user = user
            });

            hotel.cambiarDisponibilidad(CHotel.cuposDisponibles - 1);

            // Guardar la lista actualizada en el archivo JSON
            contexto.SaveReservations(reservacionesHoteles);

            List<IReservations> reservacionesIReservations = reservacionesHoteles.Cast<IReservations>().ToList();

            return reservacionesIReservations;
        }
    }
}
