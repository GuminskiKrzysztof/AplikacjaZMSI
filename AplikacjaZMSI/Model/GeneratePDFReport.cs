using System.IO;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AplikacjaZMSI
{
    public class PDFReportGenerator : IGeneratePDFReport
    {
        public void GenerateReport(string path)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("data.pdf", FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph("Hello, this is a PDF generated in C#!"));
            doc.Close();
        }
    }
}
