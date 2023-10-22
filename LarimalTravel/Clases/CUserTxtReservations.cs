using Newtonsoft.Json;
namespace LarimalTravel
{
    public class CUsertxtReservations : IUserReservations
    {
        public string GetReservations(int userId)
        {

            List<IReservations> reservations = new List<IReservations>();

            // Obtener las reservaciones de vuelos del archivo txt
            List<CFlightReservations> vueloReservaciones = JsonConvert.DeserializeObject<List<CFlightReservations>>(File.ReadAllText("txt/FlightReservations.txt")) ?? new List<CFlightReservations>();
            reservations.AddRange(vueloReservaciones.Where(CFlightReservations => CFlightReservations.user.iD == userId));

            // Obtener las reservaciones de hoteles del archivo txt
            List<CHostelsReservations> hotelReservaciones = JsonConvert.DeserializeObject<List<CHostelsReservations>>(File.ReadAllText("txt/HostelsReservations.txt")) ?? new List<CHostelsReservations>();
            reservations.AddRange(hotelReservaciones.Where(CHostelsReservations => CHostelsReservations.user.iD == userId));

            // Obtener las reservaciones de transporte del archivo txt
            List<CTransportationReservations> transporteReservaciones = JsonConvert.DeserializeObject<List<CTransportationReservations>>(File.ReadAllText("txt/TransportationReservations.txt")) ?? new List<CTransportationReservations>();
            reservations.AddRange(transporteReservaciones.Where(CTransportationReservations => CTransportationReservations.user.iD == userId));

            string jsonReservations = JsonConvert.SerializeObject(reservations);

            return jsonReservations;

        }
    }
}
