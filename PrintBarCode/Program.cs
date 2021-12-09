using System;
using System.Drawing.Printing;
using System.IO;

namespace PrintBarCode
{
    internal class Program
    {
        public static void Main(string[] args)
        {
       
            // create pdf file ---------------
            var temContent = File.ReadAllText("Sample.xslt");
            var data = File.ReadAllText("Sample.xml");
            // create pdf files.
            var pdfGenerator = new PdfGenerator(temContent);
            var bytes = pdfGenerator.GenPdf(data);
            File.WriteAllBytes($"test_{Guid.NewGuid().ToString()}.pdf", bytes);

            // printing ---------------------
            // var printerName = Console.ReadLine();
            const string printerName = "TX 80";
            // var printerName = "Microsoft Print to PDF";
            var paperSize = new PaperSize()
            {
                Width = 72
            };

            var pdfPrinter = new PdfPrinter(printerName, paperSize);
            var printer = new PdfPrinter(printerName, paperSize);
            printer.Print(bytes);
        }
    }
}