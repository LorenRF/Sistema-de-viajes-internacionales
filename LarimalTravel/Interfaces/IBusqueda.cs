

namespace LarimalTravel
{
    public interface IBusqueda
    {
        List<IServicio> buscar(int codigo, string servicio);
        List<IServicio> buscar(string destino, string servicio);
    }
}
