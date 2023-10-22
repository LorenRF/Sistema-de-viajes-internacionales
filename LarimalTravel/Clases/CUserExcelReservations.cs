using Newtonsoft.Json;
using OfficeOpenXml;
using System.Reflection;

namespace LarimalTravel
{
    public class CUserExcelReservations : IUserReservations
    {
        public string GetReservations(int userId)
        {
            List<IReservations> reservations = new List<IReservations>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(new FileInfo("EXCEL/FlightReservations.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                if (worksheet != null)
                {
                    int rowCount = worksheet.Dimension.Rows;

                    List<CFlightReservations> flightReservations = new List<CFlightReservations>();

                    for (int row = 2; row <= rowCount; row++)
                    {
                        CFlightReservations reservation = new CFlightReservations();

                        for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                        {
                            string propertyName = worksheet.Cells[1, col].Value.ToString();
                            object propertyValue = worksheet.Cells[row, col].Value;

                            PropertyInfo propInfo = reservation.GetType().GetProperty(propertyName);
                            if (propInfo != null)
                            {
                                if (propertyValue is string jsonValue)
                                {
                                    // Convertir el valor JSON al tipo de la propiedad y asignarlo
                                    object convertedValue = JsonConvert.DeserializeObject(jsonValue, propInfo.PropertyType);
                                    propInfo.SetValue(reservation, convertedValue);
                                }
                                else
                                {
                                    // Convertir el valor al tipo de la propiedad y asignarlo
                                    object convertedValue = Convert.ChangeType(propertyValue, propInfo.PropertyType);
                                    propInfo.SetValue(reservation, convertedValue);
                                }
                            }
                        }

                        flightReservations.Add(reservation);
                    }

                    reservations.AddRange(flightReservations.Where(reservation => reservation.user.iD == userId));
                }
            }

            using (ExcelPackage package = new ExcelPackage(new FileInfo("EXCEL/HostelsReservations.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                if (worksheet != null)
                {
                    int rowCount = worksheet.Dimension.Rows;

                    List<CHostelsReservations> flightReservations = new List<CHostelsReservations>();

                    for (int row = 2; row <= rowCount; row++)
                    {
                        CHostelsReservations reservation = new CHostelsReservations();

                        for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                        {
                            string propertyName = worksheet.Cells[1, col].Value.ToString();
                            object propertyValue = worksheet.Cells[row, col].Value;

                            PropertyInfo propInfo = reservation.GetType().GetProperty(propertyName);
                            if (propInfo != null)
                            {
                                if (propertyValue is string jsonValue)
                                {
                                    // Convertir el valor JSON al tipo de la propiedad y asignarlo
                                    object convertedValue = JsonConvert.DeserializeObject(jsonValue, propInfo.PropertyType);
                                    propInfo.SetValue(reservation, convertedValue);
                                }
                                else
                                {
                                    // Convertir el valor al tipo de la propiedad y asignarlo
                                    object convertedValue = Convert.ChangeType(propertyValue, propInfo.PropertyType);
                                    propInfo.SetValue(reservation, convertedValue);
                                }
                            }
                        }

                        flightReservations.Add(reservation);
                    }

                    reservations.AddRange(flightReservations.Where(reservation => reservation.user.iD == userId));
                }
            }

            using (ExcelPackage package = new ExcelPackage(new FileInfo("EXCEL/TransportationReservations.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                if (worksheet != null)
                {
                    int rowCount = worksheet.Dimension.Rows;

                    List<CTransportationReservations> flightReservations = new List<CTransportationReservations>();

                    for (int row = 2; row <= rowCount; row++)
                    {
                        CTransportationReservations reservation = new CTransportationReservations();

                        for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                        {
                            string propertyName = worksheet.Cells[1, col].Value.ToString();
                            object propertyValue = worksheet.Cells[row, col].Value;

                            PropertyInfo propInfo = reservation.GetType().GetProperty(propertyName);
                            if (propInfo != null)
                            {
                                if (propertyValue is string jsonValue)
                                {
                                    // Convertir el valor JSON al tipo de la propiedad y asignarlo
                                    object convertedValue = JsonConvert.DeserializeObject(jsonValue, propInfo.PropertyType);
                                    propInfo.SetValue(reservation, convertedValue);
                                }
                                else
                                {
                                    // Convertir el valor al tipo de la propiedad y asignarlo
                                    object convertedValue = Convert.ChangeType(propertyValue, propInfo.PropertyType);
                                    propInfo.SetValue(reservation, convertedValue);
                                }
                            }
                        }

                        flightReservations.Add(reservation);
                    }

                    reservations.AddRange(flightReservations.Where(reservation => reservation.user.iD == userId));
                }
            }

            string jsonReservations = JsonConvert.SerializeObject(reservations);

            return jsonReservations;
        }
    }
}
