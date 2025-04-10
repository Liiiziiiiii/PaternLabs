namespace PaternLab.Service.ImporterService;

public interface IImporterService
{
    Task ImportCsv(string filePath);
    void FillCsv(string filePath);
}


