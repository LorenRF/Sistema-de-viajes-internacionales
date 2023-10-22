using System.IO;
using Newtonsoft.Json;

namespace LarimalTravel
{
    public class CTransportationReservations : IReservations
    {
        public CTransporte transporte { get; set; }
        public CUser user { get; set; }

        private string filePath;

        public List<IReservations> Booking(IServicio servicio, CUser user, string formato)
        {
            if (formato == "json")
            {
                filePath = "Json/TransportationReservations.json";
            }
            else if (formato == "txt")
            {
                filePath = "txt/TransportationReservations.txt";
            }
            else { filePath = "EXCEL/TransportationReservations.xlsx"; }

            CSaveTo contexto = new CSaveTo(CObtenerFormato.getFormato(formato, filePath));


            // Cargar la lista de reservaciones existente desde el archivo JSON
            List<CTransportationReservations> reservacionesTransportes = contexto.LoadReservations<CTransportationReservations>();

            transporte = servicio as CTransporte;

            // Agregar la nueva reservación a la lista
            reservacionesTransportes.Add(new CTransportationReservations
            {
                transporte = transporte,
                user = user
            });

            // Guardar la lista actualizada en el archivo JSON
            contexto.SaveReservations(reservacionesTransportes);

            List<IReservations> reservacionesIReservations = reservacionesTransportes.Cast<IReservations>().ToList();

            return reservacionesIReservations;
        }
    }
}
