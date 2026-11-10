using System;

namespace AbstractFactoryExample
{
    // --- 1. SOYUT ÜRÜNLER (Abstract Products) ---
    public interface IButton 
    {
        void Paint();
    }

    public interface ICheckbox 
    {
        void Paint();
    }

    // --- 2. SOMUT ÜRÜNLER - AİLE 1: WINDOWS ---
    public class WindowsButton : IButton 
    {
        public void Paint() => Console.WriteLine("[Windows Stili] Buton oluşturuldu.");
    }

    public class WindowsCheckbox : ICheckbox 
    {
        public void Paint() => Console.WriteLine("[Windows Stili] Checkbox oluşturuldu.");
    }

    // --- 3. SOMUT ÜRÜNLER - AİLE 2: MAC ---
    public class MacButton : IButton 
    {
        public void Paint() => Console.WriteLine("[Mac Stili] Buton oluşturuldu.");
    }

    public class MacCheckbox : ICheckbox 
    {
        public void Paint() => Console.WriteLine("[Mac Stili] Checkbox oluşturuldu.");
    }

    // --- 4. SOYUT FABRİKA (Abstract Factory) ---
    public interface IGuiFactory 
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    // --- 5. SOMUT FABRİKALAR (Concrete Factories) ---
    public class WindowsGuiFactory : IGuiFactory 
    {
        public IButton CreateButton() => new WindowsButton();
        public ICheckbox CreateCheckbox() => new WindowsCheckbox();
    }

    public class MacGuiFactory : IGuiFactory 
    {
        public IButton CreateButton() => new MacButton();
        public ICheckbox CreateCheckbox() => new MacCheckbox();
    }

    // --- 6. İSTEMCİ (Client) ---
    public class Application 
    {
        private readonly IButton _button;
        private readonly ICheckbox _checkbox;

        public Application(IGuiFactory factory) 
        {
            _button = factory.CreateButton();
            _checkbox = factory.CreateCheckbox();
        }

        public void RenderUI() 
        {
            _button.Paint();
            _checkbox.Paint();
        }
    }

    // --- 7. UYGULAMANIN GİRİŞ NOKTASI (Main Metodu) ---
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("--- Abstract Factory UI Tema Örneği ---\n");

            // Senaryo A: Windows ortamı simülasyonu
            Console.WriteLine(">> Sistem Yapılandırması: Windows Algılandı.");
            IGuiFactory windowsFactory = new WindowsGuiFactory();
            Application appWindows = new Application(windowsFactory);
            appWindows.RenderUI();

            Console.WriteLine("\n----------------------------------------\n");

            // Senaryo B: Mac ortamı simülasyonu
            Console.WriteLine(">> Sistem Yapılandırması: Mac Algılandı.");
            IGuiFactory macFactory = new MacGuiFactory();
            Application appMac = new Application(macFactory);
            appMac.RenderUI();

            Console.WriteLine("\n--- İşlem Tamamlandı ---");
        }
    }
}