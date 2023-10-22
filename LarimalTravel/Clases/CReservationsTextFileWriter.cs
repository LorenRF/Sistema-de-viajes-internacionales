using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LarimalTravel
{
    public class CReservationsTextFileWriter : IFileWriter
    {
        private readonly string filePath;

        public CReservationsTextFileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public List<T> LoadReservations<T>()
        {
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<T>>(text);
            }
            else
            {
                return new List<T>();
            }
        }

        public void SaveReservations<T>(List<T> reservations)
        {
            string text = JsonConvert.SerializeObject(reservations);
            File.WriteAllText(filePath, text);
        }
    }
}
