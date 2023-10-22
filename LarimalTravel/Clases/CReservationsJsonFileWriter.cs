using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LarimalTravel
{
    public class CReservationsJsonFileWriter : IFileWriter
    {
        private readonly string filePath;

        public CReservationsJsonFileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public List<T> LoadReservations<T>()
        {

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            else
            {
                return new List<T>();
            }
        }

        void IFileWriter.SaveReservations<T>(List<T> reservations)
        {
            string json = JsonConvert.SerializeObject(reservations);
            File.WriteAllText(filePath, json);
        }


    }
}
