namespace PaternLab.Csv
{
    public class CsvReaderService
    {
        public string ReadFromCsv(string path)
        {
            var lines = File.ReadAllLines(path).ToList();
            return string.Join("\n", lines);
        }

    }

}
