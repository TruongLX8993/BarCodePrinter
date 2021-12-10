using System;
using System.Drawing.Printing;
using System.IO;

namespace PrintBarCode
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Test();
            return;

            // create pdf file ---------------
            var temContent = File.ReadAllText("Sample.xslt");
            var data = File.ReadAllText("Sample.xml");
            // create pdf files.
            var contentGenerator = new ContentGenerator(temContent);
            var bytes = contentGenerator.GenSvg(data);
            File.WriteAllBytes($"test_{Guid.NewGuid().ToString()}.svg", bytes);

            // printing ---------------------
            // var printerName = Console.ReadLine();
            const string printerName = "TX 80";
            // var printerName = "Microsoft Print to PDF";
            // var paperSize = new PaperSize()
            // {
            //     Width = 72
            // };
            //
            // var pdfPrinter = new PdfPrinter(printerName, paperSize);
            // var printer = new PdfPrinter(printerName, paperSize);
            // printer.Print(bytes);
        }

        public static void Test()
        {
            var paperSize = new PaperSize()
            {
                Width = 58
            };
            // const string printerName = "Microsoft Print to PDF";
            const string printerName = "TX 80";
            var xml =
                "<Sequence><HoTen>Nguyễn Van A</HoTen><Stt>1001</Stt><GioLayMau>12:30 12/09/2021</GioLayMau><HangDoi>Phòng lấy mẫu</HangDoi></Sequence>";
            var temContent = File.ReadAllText("Sequence.xslt");
            var data = xml;
            // create pdf files.
            var contentToPrint = new ContentGenerator(temContent);
            var content = contentToPrint.GenPdf(data);
            File.WriteAllBytes($"PhieuSTT_{Guid.NewGuid().ToString()}.pdf", content);
            var printer = new Printer(printerName, null);
            printer.Print(content);
        }
    }
}