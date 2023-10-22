namespace LarimalTravel
{
    public class CObtenerFormato
    {
        public static IFileWriter getFormato(string formato, string path)
        {
            if (formato == "json")
            {
                return new CReservationsJsonFileWriter(path);
            }
            else if (formato == "txt")
            {

                return new CReservationsTextFileWriter(path);
            }
            else if (formato == "excel")
            {
                return new CReservationsExcelFileWriter(path);
            }
            else { return null; }


        }
    }
}
