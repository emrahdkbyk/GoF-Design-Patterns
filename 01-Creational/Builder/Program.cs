using System;
using System.Collections.Generic;

namespace BuilderPatternExample
{
    // --- 1. KARMAŞIK NESNE (Product) ---
    public class Report 
    {
        public string Title { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public bool HasWatermark { get; set; }
        public int PageCount { get; set; }

        public void DisplayReport() 
        {
            Console.WriteLine("=== RAPOR DETAYLARI ===");
            Console.WriteLine($"Başlık     : {Title}");
            Console.WriteLine($"Üst Bilgi  : {Header}");
            Console.WriteLine($"İçerik     : {Content}");
            Console.WriteLine($"Filigran   : {(HasWatermark ? "Var" : "Yok")}");
            Console.WriteLine($"Sayfa Sayısı: {PageCount}");
            Console.WriteLine("=======================\n");
        }
    }

    // --- 2. BUILDER ARAYÜZÜ (Builder) ---
    public interface IReportBuilder 
    {
        IReportBuilder SetTitle(string title);
        IReportBuilder SetHeader(string header);
        IReportBuilder SetContent(string content);
        IReportBuilder AddWatermark();
        IReportBuilder SetPageCount(int count);
        Report Build(); // Nihai nesneyi üreten metot
    }

    // --- 3. SOMUT BUILDER (Concrete Builder) ---
    public class PdfReportBuilder : IReportBuilder 
    {
        private readonly Report _report = new Report();

        public IReportBuilder SetTitle(string title) 
        {
            _report.Title = title;
            return this; // Akıcı (Fluent) kullanım için kendisini döndürür
        }

        public IReportBuilder SetHeader(string header) 
        {
            _report.Header = header;
            return this;
        }

        public IReportBuilder SetContent(string content) 
        {
            _report.Content = content;
            return this;
        }

        public IReportBuilder AddWatermark() 
        {
            _report.HasWatermark = true;
            return this;
        }

        public IReportBuilder SetPageCount(int count) 
        {
            _report.PageCount = count;
            return this;
        }

        public Report Build() 
        {
            // İsteğe bağlı olarak burada nesnenin geçerlilik kontrolü (validation) yapılabilir
            return _report;
        }
    }

    // --- 4. DIRECTOR (İsteğe bağlı yönetim sınıfı - Sık kullanılan şablonlar için) ---
    public class ReportDirector 
    {
        public Report BuildQuickConfidentialReport(IReportBuilder builder, string title, string content) 
        {
            return builder
                .SetTitle(title)
                .SetHeader("GİZLİ BELGE")
                .SetContent(content)
                .AddWatermark()
                .SetPageCount(1)
                .Build();
        }
    }

    // --- 5. UYGULAMANIN GİRİŞ NOKTASI (Main) ---
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("--- Builder Pattern Rapor Oluşturucu Örneği ---\n");

            // Yöntem A: Fluent Interface (Akıcı Zincirleme) ile adım adım nesne üretimi
            IReportBuilder builder = new PdfReportBuilder();
            
            Report customReport = builder
                .SetTitle("Yıllık Bütçe Raporu")
                .SetHeader("Finans Departmanı - 2026")
                .SetContent("Bu rapor 2026 yılı mali projeksiyonlarını içerir.")
                .SetPageCount(12)
                .Build(); // Üretim tamamlandı

            Console.WriteLine(">> Özel Oluşturulan Rapor:");
            customReport.DisplayReport();

            // Yöntem B: Director kullanarak standart (hazır şablon) rapor üretimi
            ReportDirector director = new ReportDirector();
            PdfReportBuilder standardBuilder = new PdfReportBuilder();

            Report quickReport = director.BuildQuickConfidentialReport(
                standardBuilder, 
                "Personel Maaş Listesi", 
                "Mart ayı bordro dökümüdür."
            );

            Console.WriteLine(">> Director ile Şablon Olarak Üretilen Rapor:");
            quickReport.DisplayReport();

            Console.WriteLine("--- İşlem Tamamlandı ---");
        }
    }
}