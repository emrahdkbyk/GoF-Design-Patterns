using System;
using System.Collections.Generic;

namespace PrototypePatternExample
{
    // --- 1. PROTOTİP ARAYÜZÜ (Prototype) ---
    public interface IReportPrototype 
    {
        IReportPrototype Clone();
        void DisplayInfo();
    }

    // --- 2. SOMUT PROTOTİP (Concrete Prototype) ---
    public class FinancialReport : IReportPrototype 
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public List<string> DataRows { get; set; } // Karmaşık bir veri yapısı

        public FinancialReport(string title, string author) 
        {
            Title = title;
            Author = author;
            DataRows = new List<string>();
        }

        // Klonlama (Prototype) Metodu - Derin Kopya (Deep Copy) mantığıyla
        public IReportPrototype Clone() 
        {
            // Yeni bir nesne oluşturulur ve mevcut değerler aktarılır
            FinancialReport clonedReport = new FinancialReport(this.Title, this.Author);
            
            // Liste referans tip olduğu için klonlanırken yeni bir listeye kopyalanır (Deep Copy)
            clonedReport.DataRows = new List<string>(this.DataRows);
            
            return clonedReport;
        }

        public void DisplayInfo() 
        {
            Console.WriteLine($"[Rapor] Başlık: {Title} | Yazar: {Author} | Satır Sayısı: {DataRows.Count}");
            Console.WriteLine($"  İçerik Verileri: {string.Join(", ", DataRows)}");
        }
    }

    // --- 3. UYGULAMANIN GİRİŞ NOKTASI (Main) ---
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("--- Prototype Pattern Rapor Şablonu Örneği ---\n");

            // Adım 1: Pahalı ve zaman alıcı işlemlerle ana (prototip) rapor nesnesi oluşturulur
            FinancialReport masterTemplate = new FinancialReport("2026 Yıllık Finansal Raporu", "Merkez Bankası");
            masterTemplate.DataRows.Add("Ocak Ayı Verisi");
            masterTemplate.DataRows.Add("Şubat Ayı Verisi");
            masterTemplate.DataRows.Add("Mart Ayı Verisi");

            Console.WriteLine(">> Orijinal Şablon (Prototip) Hazır:");
            masterTemplate.DisplayInfo();

            Console.WriteLine("\n----------------------------------------\n");

            // Adım 2: Yeni bir rapor oluşturmak için 'new'lemek yerine PROTOTİP KLONLANIR!
            Console.WriteLine(">> Prototip klonlanarak 1. Şube Raporu üretiliyor...");
            FinancialReport branchReport1 = (FinancialReport)masterTemplate.Clone();
            branchReport1.Title = "2026 Yıllık Finansal Raporu - İstanbul Şubesi"; // Sadece değişen kısım güncellenir
            branchReport1.DataRows.Add("İstanbul Ek Verisi"); // Klon üzerinde esneme yapılabilir
            branchReport1.DisplayInfo();

            Console.WriteLine("\n>> Prototip klonlanarak 2. Şube Raporu üretiliyor...");
            FinancialReport branchReport2 = (FinancialReport)masterTemplate.Clone();
            branchReport2.Title = "2026 Yıllık Finansal Raporu - Ankara Şubesi";
            branchReport2.DisplayInfo();

            Console.WriteLine("\n----------------------------------------\n");
            Console.WriteLine(">> Orijinal Şablonun Son Durumu (Değişmediğini görmek için):");
            masterTemplate.DisplayInfo();

            Console.WriteLine("\n--- İşlem Tamamlandı ---");
        }
    }
}