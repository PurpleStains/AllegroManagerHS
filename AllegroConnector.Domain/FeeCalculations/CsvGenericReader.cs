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

            var file = new DirectoryInfo(path)
                .GetFiles()
                .OrderByDescending(x => x.CreationTime)
                .First();

            List<T> result = new();
            using (var reader = new StreamReader(file.FullName))
            using (var csv = new CsvReader(reader, config))
            {
                result.AddRange(csv.GetRecords<T>());
            }

            return result;
        }
    }
}
