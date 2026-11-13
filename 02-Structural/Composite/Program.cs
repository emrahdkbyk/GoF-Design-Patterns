using System;
using System.Collections.Generic;

namespace CompositePatternExample
{
    // --- 1. ORTAK ARAYÜZ (Component) ---
    // Hem tekil nesnelerin (Dosya) hem de grupların (Klasör) uygulayacağı ortak sözleşme
    public interface IFileSystemItem 
    {
        void ShowDetails(int indent);
    }

    // --- 2. TEKİL NESNE (Leaf) ---
    // Ağacın en uç, alt elemanı olmayan parçası (Örn: Dosya)
    public class FileItem : IFileSystemItem 
    {
        private readonly string _name;
        private readonly int _sizeInKb;

        public FileItem(string name, int sizeInKb) 
        {
            _name = name;
            _sizeInKb = sizeInKb;
        }

        public void ShowDetails(int indent) 
        {
            // Girinti (indent) ile ağaç hiyerarşisi konsolda görselleştirilir
            string spaces = new string(' ', indent);
            Console.WriteLine($"{spaces}- [Dosya] {_name} ({_sizeInKb} KB)");
        }
    }

    // --- 3. BİLEŞİK NESNE (Composite) ---
    // İçinde alt elemanlar (dosyalar veya başka klasörler) barındırabilen yapı (Örn: Klasör)
    public class DirectoryItem : IFileSystemItem 
    {
        private readonly string _name;
        private readonly List<IFileSystemItem> _children = new List<IFileSystemItem>();

        public DirectoryItem(string name) 
        {
            _name = name;
        }

        // Gruba yeni eleman ekleme metodu
        public void Add(IFileSystemItem item) 
        {
            _children.Add(item);
        }

        // Gruptan eleman çıkarma metodu
        public void Remove(IFileSystemItem item) 
        {
            _children.Remove(item);
        }

        public void ShowDetails(int indent) 
        {
            string spaces = new string(' ', indent);
            Console.WriteLine($"{spaces}+ [Klasör] {_name}");

            // Gruptaki her bir eleman için özyinelemeli (recursive) olarak detaylar çağrılır
            foreach (var child in _children) 
            {
                child.ShowDetails(indent + 4); // Alt elemanlar için girinti arttırılır
            }
        }
    }

    // --- 4. UYGULAMANIN GİRİŞ NOKTASI (Main) ---
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("--- Composite Pattern Dosya Sistemi Örneği ---\n");

            // Kök dizin oluşturulur
            DirectoryItem rootFolder = new DirectoryItem("Root_C");

            // Alt dosyalar oluşturulur
            FileItem file1 = new FileItem("readme.txt", 5);
            FileItem file2 = new FileItem("config.json", 12);

            // Alt klasör oluşturulur
            DirectoryItem documentsFolder = new DirectoryItem("Belgeler");
            FileItem doc1 = new FileItem("cv.pdf", 1200);
            FileItem doc2 = new FileItem("sunum.pptx", 4500);

            // Belgeler klasörünün içine dosyalar eklenir
            documentsFolder.Add(doc1);
            documentsFolder.Add(doc2);

            // Her şey kök dizine bağlanır
            rootFolder.Add(file1);
            rootFolder.Add(file2);
            rootFolder.Add(documentsFolder); // Klasör içine klasör eklendi!

            // Ağaç yapısının tamamı tek bir komutla ekrana yazdırılır
            Console.WriteLine(">> Dosya Sistemi Ağacı Yazdırılıyor:");
            rootFolder.ShowDetails(0);

            Console.WriteLine("\n--- İşlem Tamamlandı ---");
        }
    }
}