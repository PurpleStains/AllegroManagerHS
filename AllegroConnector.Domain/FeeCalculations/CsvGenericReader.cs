using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace AllegroConnector.Domain
{
    public static class CsvGenericReader<T>
    {
        public static List<T> Read(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";",
            };

            List<T> result = new();
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                result.AddRange(csv.GetRecords<T>());
            }

            return result;
        }
    }
}
