using System;

namespace BridgePatternExample
{
    // --- 1. UYGULAMA/CİHAZ ARAYÜZÜ (Implementor) ---
    // Cihazların sahip olması gereken temel fiziksel yetenekler
    public interface IDevice 
    {
        bool IsEnabled();
        void Enable();
        void Disable();
        int GetVolume();
        void SetVolume(int percent);
    }

    // --- 2. SOMUT CİHAZLAR (Concrete Implementors) ---
    public class Television : IDevice 
    {
        private bool _on = false;
        private int _volume = 30;

        public bool IsEnabled() => _on;
        public void Enable() => _on = true;
        public void Disable() => _on = false;
        public int GetVolume() => _volume;
        public void SetVolume(int percent) 
        {
            _volume = percent;
            Console.WriteLine($"[Televizyon] Ses seviyesi: {_volume}%");
        }
    }

    public class Radio : IDevice 
    {
        private bool _on = false;
        private int _volume = 15;

        public bool IsEnabled() => _on;
        public void Enable() => _on = true;
        public void Disable() => _on = false;
        public int GetVolume() => _volume;
        public void SetVolume(int percent) 
        {
            _volume = percent;
            Console.WriteLine($"[Radyo] Ses seviyesi: {_volume}%");
        }
    }

    // --- 3. SOYUTLAMA (Abstraction) ---
    // Kumandanın temel yapısı (İçinde bir IDevice köprüsü barındırır)
    public class RemoteControl 
    {
        protected IDevice _device; // Köprü (Bridge) burada kuruluyor!

        public RemoteControl(IDevice device) 
        {
            _device = device;
        }

        public void TogglePower() 
        {
            if (_device.IsEnabled()) 
            {
                _device.Disable();
                Console.WriteLine("[Kumanda] Cihaz kapatıldı.");
            } 
            else 
            {
                _device.Enable();
                Console.WriteLine("[Kumanda] Cihaz açıldı.");
            }
        }

        public void VolumeDown() 
        {
            int current = _device.GetVolume();
            _device.SetVolume(current - 5);
        }

        public void VolumeUp() 
        {
            int current = _device.GetVolume();
            _device.SetVolume(current + 5);
        }
    }

    // --- 4. GELİŞTİRİLMİŞ SOYUTLAMA (Refined Abstraction) ---
    // Standart kumandaya ek olarak "Mute" (Sessize Al) özelliği eklenmiş akıllı kumanda
    public class AdvancedRemoteControl : RemoteControl 
    {
        public AdvancedRemoteControl(IDevice device) : base(device) { }

        public void Mute() 
        {
            Console.WriteLine("[Gelişmiş Kumanda] Cihaz sessize alındı.");
            _device.SetVolume(0);
        }
    }

    // --- 5. UYGULAMANIN GİRİŞ NOKTASI (Main) ---
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("--- Bridge Pattern Cihaz & Kumanda Örneği ---\n");

            // Senaryo 1: Standart Kumanda ile Televizyon kontrolü
            Console.WriteLine(">> Televizyon ve Standart Kumanda Eşleştiriliyor:");
            IDevice tv = new Television();
            RemoteControl standardRemote = new RemoteControl(tv);
            
            standardRemote.TogglePower(); // TV'yi açar
            standardRemote.VolumeUp();    // Ses açar

            Console.WriteLine("\n----------------------------------------\n");

            // Senaryo 2: Gelişmiş Kumanda ile Radyo kontrolü (Bridge esnekliği burada görünür)
            Console.WriteLine(">> Radyo ve Gelişmiş Kumanda Eşleştiriliyor:");
            IDevice radio = new Radio();
            AdvancedRemoteControl advancedRemote = new AdvancedRemoteControl(radio);

            advancedRemote.TogglePower(); // Radyoyu açar
            advancedRemote.Mute();        // Gelişmiş kumandanın özel fonksiyonu

            Console.WriteLine("\n--- İşlem Tamamlandı ---");
        }
    }
}