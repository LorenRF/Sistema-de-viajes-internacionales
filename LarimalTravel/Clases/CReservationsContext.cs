namespace LarimalTravel
{
    public class CReservationsContext
    {

        public IReservations reservation { get; set; }

        public CReservationsContext(IReservations reservation)
        {
            this.reservation = reservation;
        }

        public List<IReservations> ejecutar(IServicio servicio, CUser user, string formato)
        {
            return reservation.Booking(servicio, user, formato);
        }
    }
}
