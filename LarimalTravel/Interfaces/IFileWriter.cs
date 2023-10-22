namespace LarimalTravel
{
    public interface IFileWriter
    {
        List<T> LoadReservations<T>();
        void SaveReservations<T>(List<T> reservations);
    }
}
