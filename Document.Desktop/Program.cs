using Document.Desktop.Management;
using Document.Desktop.Management.FileManagement.Export;
using Document.Desktop.Management.FileManagement.Import;

Document.Desktop.Management.Document document1 = new("My new document");

DocumentFileManager fileManager = new DocumentFileManager(document1);
fileManager.ExportProvider = new TextExport();
fileManager.ImportProvider = new TextImport();

string path = fileManager.Export(string.Empty).Value;

Document.Desktop.Management.Document document2 = fileManager.Import(path).Value;

Console.WriteLine(document2.IsValid);