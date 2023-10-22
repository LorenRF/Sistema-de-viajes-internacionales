using Newtonsoft.Json;
namespace LarimalTravel
{
    public class CUserjsonreservations : IUserReservations
    {
        public string GetReservations(int userId) {

            List<IReservations> reservations = new List<IReservations>();

            // Obtener las reservaciones de vuelos del archivo JSON
            List<CFlightReservations> vueloReservaciones = JsonConvert.DeserializeObject<List<CFlightReservations>>(File.ReadAllText("Json/FlightReservations.json")) ?? new List<CFlightReservations>();
        reservations.AddRange(vueloReservaciones.Where(CFlightReservations => CFlightReservations.user.iD == userId));

            // Obtener las reservaciones de hoteles del archivo JSON
            List<CHostelsReservations> hotelReservaciones = JsonConvert.DeserializeObject<List<CHostelsReservations>>(File.ReadAllText("Json/HostelsReservations.json")) ?? new List<CHostelsReservations>();
        reservations.AddRange(hotelReservaciones.Where(CHostelsReservations => CHostelsReservations.user.iD == userId));

            // Obtener las reservaciones de transporte del archivo JSON
            List<CTransportationReservations> transporteReservaciones = JsonConvert.DeserializeObject<List<CTransportationReservations>>(File.ReadAllText("Json/TransportationReservations.json")) ?? new List<CTransportationReservations>();
        reservations.AddRange(transporteReservaciones.Where(CTransportationReservations => CTransportationReservations.user.iD == userId));

            string jsonReservations = JsonConvert.SerializeObject(reservations);

            return jsonReservations;
                
                }
    }
}
