using System.Drawing.Printing;

namespace PrintBarCode
{
    public class Printer
    {
        private readonly HiQPdf.PdfPrinter _pdfPrinter;

        public Printer(string printerName, PaperSize paperSize)
        {
            _pdfPrinter = new HiQPdf.PdfPrinter
            {
                SilentPrinting = true,
                PrinterSettings =
                {
                    PrinterName = printerName,
                },
                SerialNumber = Constance.License,
                PageSettings =
                {
                    PaperSize = paperSize,
                    // Margins = new Margins(0, 0, 0, 0)
                }
            };
        }

        public void Print(byte[] pdfFile)
        {
            _pdfPrinter.PrintPdf(pdfFile,1,1);
        }
    }
}