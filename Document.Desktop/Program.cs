Document.Desktop.Management.Document document1 = new("My new document");
Document.Desktop.Management.Document document2 = document1.Clone();

document1.Display();
document2.Display();

Thread.Sleep(5000);
Console.WriteLine(new string('*', Console.WindowWidth));

document1.Header.CoverPage.Author.Write("NEW AUTHOR IS BATMAN");

document1.Display();
document2.Display();

Console.WriteLine(document2.IsValid);