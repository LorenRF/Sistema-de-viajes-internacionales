using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LarimalTravel
{
    public class CTransporte : IServicio, IObservador
    {
        public string marca { get; set; }
        public int año { get; set; }
        public string color { get; set; }
        public string modelo { get; set; }
        public string localidad { get; set; }
        public int id { get; set; }

        public void actualizar()
        {
            Console.WriteLine("SABEMOS LO QUE PASA!");
        }

        public IServicio[] Get()
        {CObserverContractor contractor = new CObserverContractor();
            string json = File.ReadAllText("Json/Transportes.json");
            CTransporte[] transportes = JsonConvert.DeserializeObject<CTransporte[]>(json);
            foreach (var transporte in transportes)
            {
                if (!CHotel.observadores.Contains(transporte))
                {
                    contractor = new CObserverContractor();
                    contractor.suscribirAHoteles(transporte);

                }
            }

            return transportes;

        }

    }
}
