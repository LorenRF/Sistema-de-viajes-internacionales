
namespace LarimalTravel
{
    public class CUserRegister
    {
        public int Registrar(string correo, string username, string password)
        {
            CUser usuario = new CUser(correo, username, password);
            usuario.iD = GenerateRandomID();

            CSaveUser.agregarUsuario(usuario); // Guardar el usuario en el archivo JSON

            return usuario.iD;
        }

        private int GenerateRandomID()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }


    }
}
