using System.IO;
using System.Xml;
using System.Xml.Xsl;
using HiQPdf;

namespace PrintBarCode
{
    public class ContentGenerator
    {
        private readonly string _template;

        public ContentGenerator(string template)
        {
            _template = template;
        }

        public byte[] GenPdf(string xml)
        {
            var htmlToPdf = new HtmlToPdf
            {
                SerialNumber = Constance.License,
                Document =
                {
                    FitPageWidth = true,
                    FitPageHeight = true,
                    PageSize = HiQPdf.PdfPageSize.A4
                }
            };
            var html = CreateHtml(xml);
            return htmlToPdf.ConvertHtmlToMemory(html, "");
        }

        public byte[] GenSvg(string xml, PdfPageSize pdfPageSize = null)
        {
            var html = CreateHtml(xml);
            var htmlToImg = new HtmlToSvg()
            {
                SerialNumber = Constance.License,
            };

            return htmlToImg.ConvertHtmlToMemory(html, string.Empty);
        }


        public byte[] GenImg(string xml, PdfPageSize pdfPageSize = null)
        {
            var html = CreateHtml(xml);
            var htmlToImg = new HtmlToImage()
            {
                SerialNumber = Constance.License,
            };
            return htmlToImg.ConvertHtmlToMemory(html, string.Empty);
        }


        private string CreateHtml(string xml)
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