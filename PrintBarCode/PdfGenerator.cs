using System.IO;
using System.Xml;
using System.Xml.Xsl;
using HiQPdf;

namespace PrintBarCode
{
    public class PdfPageSize
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public PdfPageSize(float width, float height)
        {
            Width = width;
            Height = height;
        }
    }

    public class PdfGenerator
    {
        private readonly string _template;

        public PdfGenerator(string template)
        {
            _template = template;
        }

        public byte[] GenPdf(string xml, PdfPageSize pdfPageSize = null)
        {
            var htmlToPdf = new HtmlToPdf
            {
                SerialNumber = Constance.License,
                Document =
                {
                    FitPageWidth = true,
                    FitPageHeight = true,
                    PageSize = HiQPdf.PdfPageSize.A5
                    // PageSize = pageSize == null
                    //     ? PdfPageSize.A4
                    //     : new PdfPageSize(pageSize.Width, pageSize.Height)
                },
            };
            return htmlToPdf.ConvertHtmlToMemory(CreatHtml(xml), "");
        }

        private string CreatHtml(string xml)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var strWriter = new StringWriter();
            var xsltDoc = new XmlDocument();
            xsltDoc.LoadXml(_template);
            var xsltReader = new XmlNodeReader(xsltDoc);
            var compiledTransform = new XslCompiledTransform();
            compiledTransform.Load(xsltReader);
            compiledTransform.Transform(xmlDoc, null, strWriter);
            var html = strWriter.ToString()
                .Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
            return html;
        }
    }
}