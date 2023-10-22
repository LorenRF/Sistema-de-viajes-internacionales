using System.IO;
using Newtonsoft.Json;
namespace LarimalTravel
{
    public class CSaveUser
    {
        public static void agregarUsuario(CUser usuario)
        {
            // Cargar la lista existente desde el archivo user.json
            List<CUser> usuarios = JsonConvert.DeserializeObject<List<CUser>>(File.ReadAllText("Json/Usuarios.json"));

            // Agregar el nuevo usuario a la lista
            usuarios.Add(usuario);

            // Guardar la lista actualizada en el archivo user.json
            string json = JsonConvert.SerializeObject(usuarios);
            File.WriteAllText("Json/Usuarios.json", json);
        }
    }
}
