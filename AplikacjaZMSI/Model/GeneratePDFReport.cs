using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using AplikacjaZMSI.Model;

namespace AplikacjaZMSI
{
    public class PDFReportGenerator : IGeneratePDFReport
    {
        public TestData data;

        public void raportData(TestData d)
        {
            data = d;
        }

        public void GenerateReport(string path)
        {
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            // Nagłówek
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            doc.Add(new Paragraph("Raport", titleFont));
            doc.Add(new Chunk(new LineSeparator()));
            doc.Add(new Paragraph("\n"));

            // Informacje ogólne
            Font subTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
            Font textFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            doc.Add(new Paragraph("Algorytm testowany: " + data.name, subTitleFont));
            doc.Add(new Paragraph("Funkcja testowana: " + data.func, subTitleFont));
            doc.Add(new Paragraph("Stan: " + data.state, textFont));
            doc.Add(new Paragraph("\n"));

            // Parametry
            doc.Add(new Paragraph("Parametry:", subTitleFont));
            doc.Add(new Paragraph($"Param1: {data.param1}\nParam2: {data.param2}\nParam3: {data.param3}", textFont));
            doc.Add(new Paragraph("\n"));

            // Wyniki
            doc.Add(new Paragraph("Wyniki optymalizacji:", subTitleFont));
            doc.Add(new Paragraph($"Najlepsza wartość funkcji: {data.FBest}", textFont));

            if (data.XBest != null && data.XBest.Length > 0)
            {
                doc.Add(new Paragraph("Najlepsze znalezione współrzędne:", textFont));
                doc.Add(new Paragraph(string.Join(", ", data.XBest), textFont));
            }
            doc.Add(new Paragraph("\n"));

            // Informacje o populacji
            if (data.population != null && data.population.Length > 0)
            {
                PdfPTable table = new PdfPTable(data.population[0].Length);
                table.WidthPercentage = 100;

                foreach (var row in data.population)
                {
                    foreach (var value in row)
                    {
                        table.AddCell(new PdfPCell(new Phrase(value.ToString(), textFont)));
                    }
                }
                doc.Add(table);
            }

            doc.Close();
        }
    }
}
