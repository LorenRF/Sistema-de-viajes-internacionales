using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using Newtonsoft.Json;
using System.Reflection;

namespace LarimalTravel
{
    public class CReservationsExcelFileWriter : IFileWriter
    {
        private readonly string filePath;

        public CReservationsExcelFileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public List<T> LoadReservations<T>()
        {
            List<T> reservations = new List<T>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    T reservation = Activator.CreateInstance<T>();

                    for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                    {
                        string propertyName = worksheet.Cells[1, col].Value.ToString();
                        object propertyValue = worksheet.Cells[row, col].Value;

                        PropertyInfo propInfo = reservation.GetType().GetProperty(propertyName);
                        if (propInfo != null)
                        {
                            // Deserializar el valor JSON al tipo de la propiedad y asignarlo
                            string jsonValue = propertyValue.ToString();
                            object deserializedValue = JsonConvert.DeserializeObject(jsonValue, propInfo.PropertyType);
                            propInfo.SetValue(reservation, deserializedValue);
                        }
                    }

                    reservations.Add(reservation);
                }
            }

            return reservations;
        }


        public void SaveReservations<T>(List<T> reservations)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Reservations");

                // Escribir los nombres de las propiedades como encabezados de columna
                Type entityType = typeof(T);
                var properties = entityType.GetProperties();
                int col = 1;
                foreach (var property in properties)
                {
                    worksheet.Cells[1, col].Value = property.Name;
                    col++;
                }

                // Escribir los datos de las reservaciones en las celdas como JSON
                int row = 2;
                foreach (var reservation in reservations)
                {
                    col = 1;
                    foreach (var property in properties)
                    {
                        object propertyValue = property.GetValue(reservation);
                        string jsonValue = JsonConvert.SerializeObject(propertyValue);
                        worksheet.Cells[row, col].Value = jsonValue;
                        col++;
                    }
                    row++;
                }

                // Guardar el archivo de Excel
                FileInfo file = new FileInfo(filePath);
                package.SaveAs(file);
            }
        }
    }
}
