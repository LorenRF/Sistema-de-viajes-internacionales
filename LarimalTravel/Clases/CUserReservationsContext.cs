namespace LarimalTravel
{
    public class CUserReservationsContext
    {
        public IUserReservations userReservations { get; set; }

        public CUserReservationsContext(IUserReservations userReservations)
        {
            this.userReservations = userReservations;
        }
        public string GetUserReservations(int userId)
        {
            string lista = userReservations.GetReservations(userId);
            return lista;
        }
    }
}
