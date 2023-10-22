namespace LarimalTravel
{
    public class CUser: IObservador
    {
        public string correo { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int iD { get; set; }

        public CUser(string correo, string username, string password)
        {
            this.correo = correo;
            this.userName = username;
            this.password = password;
        }

        public void actualizar()
        {
            CEnvioDeEmailPorGmail email;

            if (CHotel.cuposDisponibles < 100)
            {
                email = new CEnvioDeEmailPorGmail("lorenr.feliz@gmail.com", "deajylplewunlktu");
                email.EnviarCorreo(correo, "LA DISPONIBILIDAD DEL HOTEL SE HA AGOTADO!!!", " Querid@ " + userName + " Queremos informarle que actualmente quedan " + CHotel.cuposDisponibles + " cupos disponibles en el hotel de Santo Domingo RD, esperamos que alla podido reservar y de no ser asi ¡no se preocupe! pronto tendremos nuevas habitaciones y ofertas.");
            }
        }
    }
}
