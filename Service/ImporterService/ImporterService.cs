using PaternLab.Context;
using PaternLab.Csv;
using PaternLab.Models;
using System.Text;

namespace PaternLab.Service.ImporterService
{
    public class ImporterService : IImporterService
    {
        private readonly CsvReaderService _csvReader;
        private readonly AppDbContext _context;

        public ImporterService(CsvReaderService csvReader, AppDbContext context)
        {
            _csvReader = csvReader;
            _context = context;
        }

        public void FillCsv(string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id,Name,Age");
            int rowCount = 1000;

            for (int i = 1; i <= rowCount; i++)
            {
                sb.AppendLine($"{i},Name_{i},{20 + (i % 10)}");
            }

            File.WriteAllText(filePath, sb.ToString());
            Console.WriteLine($"CSV файл створено: {filePath}");
        }
        public async Task ImportCsv(string filePath)
        {
            var csvContent = _csvReader.ReadFromCsv(filePath);
            var csvData = new CsvData { Data = csvContent };

            await _context.AddAsync(csvData);
            await _context.SaveChangesAsync();
        }
    }

}
