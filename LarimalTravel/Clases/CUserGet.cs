using System.IO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LarimalTravel
{
    public class CUserGet
    {
        public IActionResult getUser(string userName, string password)
        {
            // Leer el contenido del archivo JSON
            string json = File.ReadAllText("Json/Usuarios.json");

            // Deserializar el contenido JSON en una lista de objetos CUser
            List<CUser> users = JsonConvert.DeserializeObject<List<CUser>>(json);

            // Buscar el usuario deseado en la lista de usuarios
            foreach (CUser usuario in users)
            {
                if (usuario.userName == userName && usuario.password == password)
                {
                    // Serializar el usuario encontrado en formato JSON
                    string userJson = JsonConvert.SerializeObject(usuario);

                    return new JsonResult(userJson); // Retornar el usuario como respuesta en formato JSON
                }
            }

            return null; // Retornar una respuesta de error si no se encontró el usuario
        }

        public IActionResult getUserById(int id)
        {
            // Leer el contenido del archivo JSON
            string json = File.ReadAllText("Json/Usuarios.json");

            // Deserializar el contenido JSON en una lista de objetos CUser
            List<CUser> users = JsonConvert.DeserializeObject<List<CUser>>(json);

            // Buscar el usuario deseado en la lista de usuarios
            foreach (CUser usuario in users)
            {
                if (usuario.iD == id)
                {
                    // Serializar el usuario encontrado en formato JSON
                    string userJson = JsonConvert.SerializeObject(usuario);

                    return new JsonResult(userJson); // Retornar el usuario como respuesta en formato JSON
                }
            }

            return null; // Retornar una respuesta de error si no se encontró el usuario
        }
    }
}
