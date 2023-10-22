namespace LarimalTravel
{
    public class CSuscriptionsManager
    {   CObserverContractor contractor;
        CSuscriptions sus;
        List<CUser> Suscriptions;
        public void suscribirUser(int ID)
        {
            
            sus = new CSuscriptions();
            Suscriptions = sus.GetUsersHotelSuscribed(ID, false);


            foreach (var usuario in Suscriptions)
            {
                if (usuario.iD == ID)
                {
                    contractor = new CObserverContractor();
                    contractor.suscribirAHoteles(usuario);

                }
            }

        }

        public void dessuscribirUser(int ID)
        {
            
             sus = new CSuscriptions();
            Suscriptions = sus.GetUsersHotelSuscribed(ID, true);


            foreach (var usuario in Suscriptions)
            {
                if (usuario.iD == ID)
                {
                    contractor = new CObserverContractor();
                    contractor.dessuscribirAHoteles(usuario);

                }
            }



        }

        public IServicio[] getSuscriptions(int ID, bool estado)
        {
            CHotel hotel;
             sus = new CSuscriptions();
            Suscriptions = sus.GetUsersHotelSuscribed(ID, estado);
            IServicio[] servicio = new IServicio[0];
            foreach (var usuario in Suscriptions)
            {
                if (usuario.iD == ID)
                {
                    hotel = new CHotel();
                    servicio = hotel.Get();
                }
            }
            return servicio;
        }

    }
}
