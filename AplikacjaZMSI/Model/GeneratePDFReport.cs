using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using AplikacjaZMSI.Model;
using System.Collections.Generic;
using iTextSharp.text.pdf.parser;

namespace AplikacjaZMSI
{
    public class PDFReportGenerator : IGeneratePDFReport
    {
        public TestData data;

        public void raportData(TestData d)
        {
            data = d;
        }

        public void Milti(List<TestData> t)
        {
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream("multiraport.pdf", FileMode.Create));
            doc.Open();

            // Nagłówek
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            doc.Add(new Paragraph("Raport", titleFont));
            doc.Add(new Chunk(new LineSeparator()));
            doc.Add(new Paragraph("\n"));

            foreach (var r in t)
            {
                // Informacje ogólne
                Font subTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                Font textFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                doc.Add(new Paragraph("Algorytm testowany: " + r.name, subTitleFont));
                doc.Add(new Paragraph("Funkcja testowana: " + r.func, subTitleFont));
                doc.Add(new Paragraph("Liczba iteracji: " + r.iter, subTitleFont));
                doc.Add(new Paragraph("Rozmiar populacji: " + r.popSize, subTitleFont));
                doc.Add(new Paragraph("\n"));

                // Parametry
                doc.Add(new Paragraph("Parametry:", subTitleFont));
                doc.Add(new Paragraph($"Param1: {r.param1}\nParam2: {r.param2}\nParam3: {r.param3}", textFont));
                doc.Add(new Paragraph("\n"));

                // Wyniki
                doc.Add(new Paragraph("Wyniki optymalizacji:", subTitleFont));
                doc.Add(new Paragraph($"Najlepsza wartość funkcji: {r.FBest}", textFont));

                if (r.XBest != null && r.XBest.Length > 0)
                {
                    doc.Add(new Paragraph("Najlepsze znalezione współrzędne:", textFont));
                    doc.Add(new Paragraph(string.Join(", ", r.XBest), textFont));
                }
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("Wyniki po X iteracjach:", subTitleFont));
                int p = 0;
                foreach (double u in r.resIn)
                {
                    p++;
                    doc.Add(new Paragraph("Najlepsze rozwiązanie po " + (p * 5).ToString() + " iteracjach: " + u.ToString(), textFont));
                }
                doc.Add(new Chunk(new LineSeparator()));
                doc.Add(new Paragraph("\n"));
            }
            doc.Close();
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
            doc.Add(new Paragraph("Liczba iteracji: " + data.iter, subTitleFont));
            doc.Add(new Paragraph("Rozmiar populacji: " + data.popSize, subTitleFont));
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
                doc.Add(new Paragraph("Najlepsze znalezione wspólrzędne:", textFont));
                doc.Add(new Paragraph(string.Join(", ", data.XBest), textFont));
            }
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("Wyniki po X iteracjach:", subTitleFont));
            int t = 0;
            foreach(double u in data.resIn)
            {
                t++;
                doc.Add(new Paragraph("Najlepsze rozwiązanie po " + (t*5).ToString()+ " iteracjach: " + u.ToString(), textFont));
            }
           

            doc.Close();
        }


    }
}
