using Waitless.BLL.Models;
using Waitless.Dto;
using Microsoft.Extensions.Options;

namespace Waitless.BLL.Helpers;

public class FileHelper
{
    private readonly FileSettings _fileSettings;
    private readonly string _rootPath;
    private readonly string _documentPath;

    public FileHelper(IOptions<FileSettings> fileSettings)
    {
        _fileSettings = fileSettings.Value;
        _rootPath = _fileSettings.FilePath;
        _documentPath = _fileSettings.DocumentPath;
    }

    public async Task<List<string>> UploadFiles(List<FileDto> fileDtos, string path, string id = null)
    {
        var uploadedFiles = new List<string>();
        foreach (var file in fileDtos)
        {
            uploadedFiles.Add(await UploadFile(file, path, id));
        }

        return uploadedFiles;
    }

    public async Task<string> UploadFile(FileDto file, string path, string id = null)
    {
        if (file.Data?.Length == 0 || file.Data?.Length == 0)
        {
            throw new ArgumentException();
        }

        path = Path.Combine(_rootPath, path);

        if (!string.IsNullOrEmpty(id))
        {
            path = Path.Combine(path, id);
        }

        var extension = "." + file.Type;

        CheckDirectiryExists(path);

        string filePath;

        filePath = Path.Combine(path, Guid.NewGuid().ToString("N") + extension);

        await File.WriteAllBytesAsync(filePath, Convert.FromBase64String(file.Data));
        return await ConvertToUrl(filePath);
    }

    public bool DeleteFile(string path)
    {
        path = path.StartsWith("/") ? path.Substring(1) : path;
        string filePath = Path.Combine(_rootPath, path);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            return true;
        }

        return false;
    }

    private async Task<string> ConvertToUrl(string filePath)
    {
        return filePath.Replace(_rootPath, "").Replace("\\", "/");
    }

    private static void CheckDirectiryExists(string path)
    {
        var exists = Directory.Exists(path);

        if (!exists)
        {
            Directory.CreateDirectory(path);
        }
    }
}