using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace LarimalTravel
{
    public class CBuscador: IBusqueda
    { 
 
        public List<IServicio> buscar(int codigo, string servicio)
        {

            CContexto contexto = new CContexto(CObtenerServicio.getServicio(servicio));
            IServicio[] listaServicio = contexto.ejecutar();
            List<IServicio> serviciosEncontrados = new List<IServicio>();

            if (servicio == "Vuelo")
            {
                foreach (CVuelo vuelo in listaServicio)
                {
                    if (vuelo.codigo == codigo)
                    {
                        serviciosEncontrados.Add(vuelo);
                    }
                }
            }
            else if (servicio == "Hotel")
            {
                foreach (CHotel hotel in listaServicio)
                {
                    if (hotel.id == codigo)
                    {
                        
                        serviciosEncontrados.Add(hotel);
                    }
                }
            }

            else if (servicio == "Transporte")
            {
                foreach (CTransporte vehiculo in listaServicio)
                {
                    if (vehiculo.id == codigo)
                    {
                        serviciosEncontrados.Add(vehiculo);
                    }
                }
            }

            return serviciosEncontrados;
        }

        public List<IServicio> buscar(string destino, string servicio)
        {

            CContexto contexto = new CContexto(CObtenerServicio.getServicio(servicio));
            IServicio[] listaServicio = contexto.ejecutar();
            List<IServicio> serviciosEncontrados = new List<IServicio>();

           if (destino == "all")
                {
                    serviciosEncontrados.AddRange(listaServicio);
                CTransporte trasporte = new CTransporte();
                trasporte.Get();
            }
            else if (servicio == "Vuelo")
            {
                    foreach (CVuelo vuelo in listaServicio)
                    {
                        if (vuelo.destino.Contains(destino))
                        {
                            serviciosEncontrados.Add(vuelo);
                        }
                    }
            }
            else if (servicio == "Hotel")
            {

                foreach (CHotel hotel in listaServicio)
                {
                    if (hotel.ubicacion.Contains(destino))
                    {
                        serviciosEncontrados.Add(hotel);
                    }
                }

            }

            else if (servicio == "Transporte")
            {
                foreach (CTransporte vehiculo in listaServicio)
                {
                    if (vehiculo.localidad.Contains(destino))
                    {
                        serviciosEncontrados.Add(vehiculo);
                    }
                }
                
            }

            return serviciosEncontrados;
        }
    }
    
}
