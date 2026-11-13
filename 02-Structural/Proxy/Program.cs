using System;

namespace ProxyPatternExample
{
    // --- 1. ORTAK ARAYÜZ (Subject) ---
    // Hem gerçek dosyanın hem de vekilin uygulayacağı ortak sözleşme
    public interface ISecretDocument 
    {
        void ReadContent(string userRole);
    }

    // --- 2. GERÇEK NESNE (Real Subject) ---
    // Gizli verileri barındıran ve oluşturulması/erişilmesi maliyetli olan asıl sınıf
    public class RealSecretDocument : ISecretDocument 
    {
        private readonly string _content;

        public RealSecretDocument() 
        {
            Console.WriteLine("[SİSTEM] Gizli dosya sabit diskten belleğe yükleniyor (Ağır işlem)...");
            _content = "Çok Gizli Proje Detayları: Bütçe 10 Milyon Dolar.";
        }

        public void ReadContent(string userRole) 
        {
            Console.WriteLine($"[Dosya İçeriği]: {_content}");
        }
    }

    // --- 3. VEKİL NESNE (Proxy) ---
    // Güvenlik ve yetki kontrolünü sağlayan sarmalayıcı sınıf
    public class DocumentProxy : ISecretDocument 
    {
        private RealSecretDocument _realDocument; // Gerçek nesneye referans (Lazy Loading için başta null olabilir)
        private readonly string _documentName;

        public DocumentProxy(string documentName) 
        {
            _documentName = documentName;
        }

        public void ReadContent(string userRole) 
        {
            Console.WriteLine($"[PROXY] '{_documentName}' için erişim talebi alındı. Kullanıcı Rolü: {userRole}");

            // Güvenlik / Yetki Kontrolü
            if (userRole != "Admin") 
            {
                Console.WriteLine("[PROXY ERİŞİM REDDEDİLDİ] Bu gizli belgeyi yalnızca 'Admin' rolündekiler okuyabilir!");
                return; // Gerçek nesneye asla ulaştırılmaz
            }

            // Lazy Initialization: Gerçek nesneye sadece yetkili biri geldiğinde ihtiyaç duyulursa oluşturulur
            if (_realDocument == null) 
            {
                _realDocument = new RealSecretDocument();
            }

            // Yetki tamamsa istek gerçek nesneye yönlendirilir
            _realDocument.ReadContent(userRole);
        }
    }

    // --- 4. UYGULAMANIN GİRİŞ NOKTASI (Main) ---
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("--- Proxy Pattern Güvenli Dosya Erişim Örneği ---\n");

            // İstemci doğrudan gerçek dosyayla değil, Proxy ile konuşur
            ISecretDocument secretDoc = new DocumentProxy("TopSecret_2026.pdf");

            // Senaryo 1: Yetkisiz bir kullanıcı (Misafir) belgeyi okumaya çalışıyor
            Console.WriteLine(">> Senaryo 1: Misafir (Guest) Girişi");
            secretDoc.ReadContent("Guest");

            Console.WriteLine("\n----------------------------------------\n");

            // Senaryo 2: Yetkili bir kullanıcı (Admin) belgeyi okumaya çalışıyor
            Console.WriteLine(">> Senaryo 2: Yönetici (Admin) Girişi");
            secretDoc.ReadContent("Admin");

            Console.WriteLine("\n--- İşlem Tamamlandı ---");
        }
    }
}