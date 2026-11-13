using System;

namespace AdapterPatternExample
{
    // --- 1. HEDEF ARAYÜZ (Target) ---
    // Uygulamamızın standart olarak çalışmasını beklediği arayüz
    public interface IShippingService 
    {
        void ShipOrder(string trackingNumber);
    }

    // --- 2. MEVCUT / STANDART SİSTEM (Concrete Target) ---
    public class StandardShippingService : IShippingService 
    {
        public void ShipOrder(string trackingNumber) 
        {
            Console.WriteLine($"[Standart Kargo] Sipariş gönderildi. Takip No: {trackingNumber}");
        }
    }

    // --- 3. UYUMSUZ / 3. PARTİ SERVİS (Adaptee) ---
    // Başka bir firmadan alınan ve metot adı farklı olan mevcut sınıf
    public class FastCargoApi 
    {
        public void SendPackageWithCargo(string barcodeId) 
        {
            Console.WriteLine($"[FastCargo API] Hızlı kargo ile gönderim sağlandı. Barkod: {barcodeId}");
        }
    }

    // --- 4. ADAPTÖR SINIFI (Adapter) ---
    // FastCargoApi'yi, IShippingService arayüzüne dönüştüren köprü sınıf
    public class FastCargoAdapter : IShippingService 
    {
        private readonly FastCargoApi _fastCargoApi;

        public FastCargoAdapter(FastCargoApi fastCargoApi) 
        {
            _fastCargoApi = fastCargoApi;
        }

        public void ShipOrder(string trackingNumber) 
        {
            // Çağrıyı, 3. parti API'nin anladığı formata çeviriyoruz
            _fastCargoApi.SendPackageWithCargo(trackingNumber);
        }
    }

    // --- 5. UYGULAMANIN GİRİŞ NOKTASI (Main) ---
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("--- Adapter Pattern Kargo Entegrasyon Örneği ---\n");

            // Durum A: Standart Kargo servisi kullanımı
            Console.WriteLine(">> 1. Yöntem: Standart Kargo Servisi Kullanılıyor");
            IShippingService standardShipping = new StandardShippingService();
            standardShipping.ShipOrder("TR123456");

            Console.WriteLine("\n----------------------------------------\n");

            // Durum B: Yeni 3. parti FastCargo servisi (Adaptör ile entegre ediliyor)
            Console.WriteLine(">> 2. Yöntem: Yeni FastCargo Servisi (Adapter Aracılığıyla)");
            
            // 3. parti sınıfımız
            FastCargoApi externalApi = new FastCargoApi();
            
            // Adaptör vasıtasıyla bizim sisteme uyduruluyor
            IShippingService adaptedShipping = new FastCargoAdapter(externalApi);
            
            // Uygulama hiç fark etmeden standart metodu çağırır, arkada adaptör işi çözer
            adaptedShipping.ShipOrder("FAST987654");

            Console.WriteLine("\n--- İşlem Tamamlandı ---");
        }
    }
}