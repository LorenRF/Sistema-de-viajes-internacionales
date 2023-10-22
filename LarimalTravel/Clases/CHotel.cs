using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace LarimalTravel
{
    public class CHotel: IServicio
    {
        public string ubicacion { get; set; }
        public string habitacion { get; set; }
        public int estrellas { get; set; }
        public int id { get; set; }
        public static int cuposDisponibles = 1;
        public static bool disponibilidad = true;
        public static List<IObservador> observadores = new List<IObservador>();

        public void AgregarSub(IObservador observador)
        {
            observadores.Add(observador);

        }

        public void QuitarSub(IObservador observador)
        {
            observadores.Remove(observador);

        }

        public void Notificar()
        {

            foreach (var elemento in observadores)
            {
                elemento.actualizar();
            }
        }

        public IServicio[] Get()
        {
            string json = File.ReadAllText("Json/Hoteles.json");
            CHotel[] hoteles = JsonConvert.DeserializeObject<CHotel[]>(json);
            return hoteles;
        }


        public void cambiarDisponibilidad(int cup)
        {
            cuposDisponibles = cup;
            if (cuposDisponibles == 0)
            {
                disponibilidad = false;

                Notificar();
            }
            else
            {
                Console.WriteLine("Aun tenemos cupos");
            }

        }



    }
}
