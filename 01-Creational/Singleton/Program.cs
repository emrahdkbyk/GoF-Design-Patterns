using System;
using System.Threading.Tasks;

namespace SingletonLoggerExample
{
    // Logger sınıfı sealed olarak tanımlanır (kalıtım yoluyla Singleton ihlalini önlemek için)
    public sealed class Logger 
    {
        // 1. Sınıfın kendi türünden private static örneği
        private static Logger _instance = null;
        
        // 2. Thread-safe (eş zamanlı erişim) güvenliği için kilit nesnesi
        private static readonly object _lock = new object();

        // Sayaç: Nesnenin gerçekten sadece 1 kez üretildiğini kanıtlamak için
        private static int _instanceCount = 0;

        // 3. Constructor private yapılarak dışarıdan 'new'lenmesi engellenir
        private Logger() 
        {
            _instanceCount++;
            Console.WriteLine($"[SİSTEM]: Logger nesnesi oluşturuldu. (Toplam Üretilme Sayısı: {_instanceCount})");
        }

        // 4. Global erişim noktası (Thread-safe)
        public static Logger Instance 
        {
            get 
            {
                lock (_lock) 
                {
                    if (_instance == null) 
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }

        // Log yazma metodu
        public void LogInfo(string message, string sourceComponent) 
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | [INFO] | [{sourceComponent}] | {message}";
            Console.WriteLine(logEntry);
            // Gerçek senaryoda burada File.AppendAllText(...) ile dosyaya yazılır.
        }

        public void LogError(string message, string sourceComponent) 
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | [ERROR] | [{sourceComponent}] | {message}";
            Console.WriteLine(logEntry);
        }
    }

    // Uygulama bileşenleri simülasyonu
    public class UserService 
    {
        public void RegisterUser(string username) 
        {
            // Her yerden tek satırda Logger'a erişilir
            Logger.Instance.LogInfo($"'{username}' isimli kullanıcı başarıyla kaydedildi.", "UserService");
        }
    }

    public class PaymentService 
    {
        public void ProcessPayment(decimal amount) 
        {
            try 
            {
                // Ödeme işlemi simülasyonu
                if (amount <= 0) throw new ArgumentException("Tutar 0'dan büyük olmalıdır.");
                Logger.Instance.LogInfo($"{amount} TL tutarında ödeme başarıyla alındı.", "PaymentService");
            } 
            catch (Exception ex) 
            {
                Logger.Instance.LogError(ex.Message, "PaymentService");
            }
        }
    }

    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("--- Uygulama Başlatıldı ---");

            // Farklı servislerden Logger çağrıları yapalım
            UserService userService = new UserService();
            PaymentService paymentService = new PaymentService();

            userService.RegisterUser("AhmetYilmaz");
            paymentService.ProcessPayment(250.50m);
            paymentService.ProcessPayment(-10.00m); // Hata senaryosu

            // Referans eşitliği testi
            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;

            Console.WriteLine("\n--- Singleton Doğrulama Testi ---");
            Console.WriteLine($"logger1 ve logger2 aynı nesneyi mi işaret ediyor? -> {object.ReferenceEquals(logger1, logger2)}");

            Console.WriteLine("\n--- Uygulama Sonlandırılıyor ---");
        }
    }
}