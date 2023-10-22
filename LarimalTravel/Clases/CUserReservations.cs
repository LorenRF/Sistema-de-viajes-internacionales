using Newtonsoft.Json;
namespace LarimalTravel
{
    public class CUserReservations
    {
        public string GetUserReservations(int userId, string formato)
        {
            CUserReservationsContext context = new CUserReservationsContext(CFabricaUserReservations.fabricar(formato));
            return context.GetUserReservations(userId);
        }
    }
}
