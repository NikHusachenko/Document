using Document.Prodocument.Response;
using Newtonsoft.Json;

namespace Document.Prodocument.Management.FileManagement.Import
{
    public sealed class TextImport : ImportStrategy
    {
        public override ResponseService<Document> Import(string path)
        {
            string documentJson = string.Empty;

            using (StreamReader stream = new StreamReader(path))
            {
                documentJson = stream.ReadToEnd();
            }

            try
            {
                Document? result = JsonConvert.DeserializeObject<Document>(documentJson);
                return ResponseService<Document>.Ok(result!);
            }
            catch (Exception ex)
            {
                return ResponseService<Document>.Error(ex.ToString());
            }
        }
    }
}