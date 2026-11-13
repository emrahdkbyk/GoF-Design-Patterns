using System;

namespace FacadePatternExample
{
    // --- 1. KARMAŞIK ALT SİSTEM BİLEŞENLERİ (Subsystems) ---
    
    public class DvdPlayer 
    {
        public void On() => Console.WriteLine("[DVD] Oynatıcı açılıyor...");
        public void Play(string movie) => Console.WriteLine($"[DVD] '{movie}' oynatılıyor.");
        public void Off() => Console.WriteLine("[DVD] Oynatıcı kapatılıyor.");
    }

    public class Projector 
    {
        public void On() => Console.WriteLine("[Projektör] Açılıyor...");
        public void SetInput(string source) => Console.WriteLine($"[Projektör] Kaynak ayarlandı: {source}");
        public void Off() => Console.WriteLine("[Projektör] Kapatılıyor.");
    }

    public class SoundSystem 
    {
        public void On() => Console.WriteLine("[Ses Sistemi] Açılıyor...");
        public void SetVolume(int level) => Console.WriteLine($"[Ses Sistemi] Ses seviyesi: {level}");
        public void Off() => Console.WriteLine("[Ses Sistemi] Kapatılıyor.");
    }

    public class TheaterLights 
    {
        public void Dim(int level) => Console.WriteLine($"[Işıklar] Karartılıyor: %{level} parlaklık.");
        public void On() => Console.WriteLine("[Işıklar] Tamamen açıldı.");
    }

    // --- 2. FACADE SINIFI (Cephe) ---
    // Tüm karmaşık alt sistemleri tek bir çatı altında toplayan arayüz
    public class HomeTheaterFacade 
    {
        private readonly DvdPlayer _dvd;
        private readonly Projector _projector;
        private readonly SoundSystem _sound;
        private readonly TheaterLights _lights;

        public HomeTheaterFacade(DvdPlayer dvd, Projector projector, SoundSystem sound, TheaterLights lights) 
        {
            _dvd = dvd;
            _projector = projector;
            _sound = sound;
            _lights = lights;
        }

        // Karmaşık adımları tek bir metoda indirgiyoruz
        public void WatchMovie(string movieTitle) 
        {
            Console.WriteLine(">> Film izleme modu hazırlanıyor...\n");
            _lights.Dim(10);
            _projector.On();
            _projector.SetInput("DVD");
            _sound.On();
            _sound.SetVolume(8);
            _dvd.On();
            _dvd.Play(movieTitle);
            Console.WriteLine("\n>> İyi seyirler!\n");
        }

        // Kapatma işlemlerini de tek tuşa bağlıyoruz
        public void EndMovie() 
        {
            Console.WriteLine(">> Sistem kapatılıyor...\n");
            _dvd.Off();
            _sound.Off();
            _projector.Off();
            _lights.On();
            Console.WriteLine("\n>> Sistem başarıyla kapatıldı.");
        }
    }

    // --- 3. UYGULAMANIN GİRİŞ NOKTASI (Main) ---
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("--- Facade Pattern Ev Sinema Sistemi Örneği ---\n");

            // Alt sistem nesneleri oluşturulur
            DvdPlayer dvd = new DvdPlayer();
            Projector projector = new Projector();
            SoundSystem sound = new SoundSystem();
            TheaterLights lights = new TheaterLights();

            // Facade nesnesi, alt sistemleri içine alır
            HomeTheaterFacade homeTheater = new HomeTheaterFacade(dvd, projector, sound, lights);

            // İstemci (Main), karmaşık metotlarla uğraşmaz; tek komutla filmi başlatır!
            homeTheater.WatchMovie("Yüzüklerin Efendisi");

            Console.WriteLine("----------------------------------------\n");

            // Film bittiğinde tek komutla her şey kapatılır
            homeTheater.EndMovie();

            Console.WriteLine("\n--- İşlem Tamamlandı ---");
        }
    }
}