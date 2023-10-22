namespace LarimalTravel
{
    public class CGetBook
    {
        public static IReservations getReservation(string servicio)
        {
            if (servicio == "Vuelo")
            {
                return new CFlightReservations();
            }
            else if (servicio == "Hotel")
            {

                return new CHostelsReservations();
            }
            else if (servicio == "Transporte")
            {
                return new CTransportationReservations();
            }
            else { return null; }


        }
    }
}
