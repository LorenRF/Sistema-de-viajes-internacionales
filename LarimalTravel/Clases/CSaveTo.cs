namespace LarimalTravel
{
    public class CSaveTo
    {
        public IFileWriter fileWriter { get; set; }
        
        public CSaveTo (IFileWriter fileWriter)
        {
            this.fileWriter = fileWriter;
        }
        public void SetFileWriter(IFileWriter fileWriter)
        {
            this.fileWriter = fileWriter;
        }

        public void SaveReservations<T>(List<T> reservations)
        {
            fileWriter.SaveReservations(reservations);
        }


        public List<T> LoadReservations<T>()
        {
           return fileWriter.LoadReservations<T>();
        }
    }
}
