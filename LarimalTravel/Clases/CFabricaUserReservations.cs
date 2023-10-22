namespace LarimalTravel
{
    public class CFabricaUserReservations
    {
        public static IUserReservations fabricar (string formato)
        {
            IUserReservations userReservations;

            if (formato == "json")
            {
                userReservations = new CUserjsonreservations();
            }
            else if(formato == "txt")
            {
                userReservations = new CUsertxtReservations();
            }
            else if (formato == "excel")
            {
                userReservations = new CUserExcelReservations();
            }
            else
            {
                userReservations=null;
            }

            return userReservations;
        }
    }
}
