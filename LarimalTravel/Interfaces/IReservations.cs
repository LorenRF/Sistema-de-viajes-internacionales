namespace LarimalTravel
{
    public interface IReservations
    {
        public List<IReservations> Booking(IServicio servicio, CUser user, string formato);
    }
}
