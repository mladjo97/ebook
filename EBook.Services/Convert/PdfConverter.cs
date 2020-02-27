namespace EBook.Services.Convert
{
    using EBook.Domain;
    using EBook.Services.Contracts.Convert;
    using iText.Kernel.Pdf;
    using iText.Kernel.Pdf.Canvas.Parser;
    using iText.Kernel.Pdf.Canvas.Parser.Listener;
    using System.Text;
    using System.Threading.Tasks;

    public class PdfConverter : IFilePdfConverter
    {
        public Task<File> Convert(string path)
        {
            return Task.Run(() =>
            {
                var file = new File
                {
                    Path = path,
                    Mime = "application/json"
                };

                using (var document = new PdfDocument(new PdfReader(path)))
                {
                    int numOfPages = document.GetNumberOfPages();

                    var listener = new FilteredEventListener();
                    var extractionStrategy = listener
                        .AttachEventListener(new LocationTextExtractionStrategy());

                    var processor = new PdfCanvasProcessor(listener);
                    var content = new StringBuilder();

                    for (int i = 1; i <= numOfPages; i++)
                    {
                        processor.ProcessPageContent(document.GetPage(i));
                        content.Append(extractionStrategy.GetResultantText());

                        processor.Reset();
                    }

                    file.Content = content.ToString();
                }

                return file;
            });
        }
    }
}
