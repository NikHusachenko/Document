Document.Desktop.Management.Document document1 = new("My new document");
Document.Desktop.Management.Document document2 = document1.Clone();

Console.WriteLine(document2.IsValid);