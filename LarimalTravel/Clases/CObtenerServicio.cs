namespace LarimalTravel
{
    public class CObtenerServicio
    {
        public static IServicio getServicio(string servicio)
        {
            if (servicio == "Vuelo")
            {
                return new CVuelo();
            }
            else if (servicio == "Hotel")
            {

                return new CHotel();
            }
            else if (servicio == "Transporte")
            {
                return new CTransporte();
            }
            else { return null; }


        }
    }
}
