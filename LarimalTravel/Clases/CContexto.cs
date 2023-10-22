using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace LarimalTravel
{
    public class CContexto
    {
        public IServicio servicio { get; set; }

        public CContexto(IServicio servicio)
        {
            this.servicio = servicio;
        }

        public IServicio[] ejecutar()
        {
           return servicio.Get();
        }
    }

}
