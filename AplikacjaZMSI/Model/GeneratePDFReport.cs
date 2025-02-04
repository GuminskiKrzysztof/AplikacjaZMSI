using System.IO;
using System.Xml.Linq;
using AplikacjaZMSI.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace AplikacjaZMSI
{
    public class PDFReportGenerator : IGeneratePDFReport
    {
        private TestData data;
        public void raportData(TestData d)
        {
            data = d;
        }
        public void GenerateReport(string path)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("raport.pdf", FileMode.Create));
            doc.Open();
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            doc.Add(new Paragraph("Raport", titleFont));

            Font subTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
            doc.Add(new Paragraph("Algoritm tested: " + data.name, subTitleFont));
            doc.Add(new Paragraph("Function tested: " + data.func, subTitleFont));
            LineSeparator line = new LineSeparator();
            doc.Add(line);


            doc.Close();
        }
    }
}
