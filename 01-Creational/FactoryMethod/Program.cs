using System;

namespace FactoryMethodExample
{
    // 1. Ortak Arayüz (Product)
    // Tüm bildirim türlerinin sahip olacağı standart sözleşme
    public interface INotification 
    {
        void Send(string message);
    }

    // 2. Somut Ürünler (Concrete Products)
    public class EmailNotification : INotification 
    {
        public void Send(string message) 
        {
            Console.WriteLine($"[E-POSTA Gönderiliyor]: {message}");
            // Burada SMTP işlemleri yapılırdı
        }
    }

    public class SmsNotification : INotification 
    {
        public void Send(string message) 
        {
            Console.WriteLine($"[SMS Gönderiliyor]: {message}");
            // Burada SMS API entegrasyonu yapılırdı
        }
    }

    public class PushNotification : INotification 
    {
        public void Send(string message) 
        {
            Console.WriteLine($"[Push Bildirimi Gönderiliyor]: {message}");
            // Burada Mobil Push servisi entegrasyonu yapılırdı
        }
    }

    // 3. Bildirim Türleri Enum'ı
    public enum NotificationType 
    {
        Email,
        Sms,
        Push
    }

    // 4. Fabrika Sınıfı (Creator / Factory)
    // Nesne oluşturma kararının verildiği merkez
    public static class NotificationFactory 
    {
        public static INotification CreateNotification(NotificationType type) 
        {
            return type switch 
            {
                NotificationType.Email => new EmailNotification(),
                NotificationType.Sms => new SmsNotification(),
                NotificationType.Push => new PushNotification(),
                _ => throw new ArgumentException("Geçersiz bildirim türü!")
            };
        }
    }

    // 5. İstemci (Client) Kullanımı
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("--- Factory Pattern Bildirim Sistemi Örneği ---\n");

            // Kullanıcı tercihine veya senaryoya göre bildirim türü seçilir
            // Kodun geri kalanı hangi nesnenin üretildiğiyle ilgilenmez, sadece INotification arayüzünü kullanır.

            INotification notification1 = NotificationFactory.CreateNotification(NotificationType.Email);
            notification1.Send("Hesabınız başarıyla oluşturuldu.");

            INotification notification2 = NotificationFactory.CreateNotification(NotificationType.Sms);
            notification2.Send("Doğrulama kodunuz: 4829");

            INotification notification3 = NotificationFactory.CreateNotification(NotificationType.Push);
            notification3.Send("Sepetinizdeki ürünler sizi bekliyor!");

            Console.WriteLine("\n--- İşlem Tamamlandı ---");
        }
    }
}