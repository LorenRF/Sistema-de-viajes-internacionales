namespace LarimalTravel
{
    public class CObserverContractor
    {
        public void suscribirAHoteles(IObservador sub)
        {
            CHotel hotel = new CHotel();
            hotel.AgregarSub(sub);
        }

        public void dessuscribirAHoteles(IObservador sub)
        {
            CHotel hotel = new CHotel();
            hotel.QuitarSub(sub);
        }


    }
}
