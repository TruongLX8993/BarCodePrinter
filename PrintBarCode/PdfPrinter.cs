using System.Drawing.Printing;
using HiQPdf;

namespace PrintBarCode
{
    public class PdfPrinter
    {
        private readonly HiQPdf.PdfPrinter _pdfPrinter;

        public PdfPrinter(string printerName, PaperSize paperSize)
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
                    PaperSize = paperSize
                }
            };
        }

        public void Print(byte[] pdfFile)
        {
            _pdfPrinter.PrintPdf(pdfFile);
        }
    }
}