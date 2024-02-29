using Document.Desktop.Response;
using Newtonsoft.Json;

namespace Document.Desktop.Management.FileManagement.Export
{
    public sealed class TextExport : ExportStrategy
    {
        public override ResponseService<string> Export(Document document, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                path = document.Metadata.SavedAt;
            }

            string fileName = document.Metadata.DocumentName;
            string fileExtension = document.Metadata.Extension;
            string fullFileName = $"{fileName}.{fileExtension}";
            string fileWithPathAndExtension = Path.Combine(path, fullFileName);

            string documentJson = JsonConvert.SerializeObject(document, Formatting.Indented);

            try
            {
                using (StreamWriter stream = new StreamWriter(fileWithPathAndExtension))
                {
                    stream.WriteLine(documentJson);
                }
            }
            catch (Exception ex)
            {
                return ResponseService<string>.Error(ex.ToString());
            }
            return ResponseService<string>.Ok(fileWithPathAndExtension);
        }
    }
}