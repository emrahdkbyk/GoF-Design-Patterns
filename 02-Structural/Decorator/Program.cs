using System;

namespace DecoratorPatternExample
{
    // --- 1. ORTAK ARAYÜZ (Component) ---
    // Kahvenin temel sözleşmesi (Fiyat ve Açıklama)
    public interface ICoffee 
    {
        string GetDescription();
        double GetCost();
    }

    // --- 2. SOMUT BİLEŞEN (Concrete Component) ---
    // Özelliksiz, sade temel kahve
    public class SimpleCoffee : ICoffee 
    {
        public string GetDescription() 
        {
            return "Sade Kahve";
        }

        public double GetCost() 
        {
            return 50.0; // Temel fiyat
        }
    }

    // --- 3. SOYUT SÜSLEYİCİ (Base Decorator) ---
    // Diğer tüm süsleyicilerin türeyeceği ortak taban sınıf
    public abstract class CoffeeDecorator : ICoffee 
    {
        protected readonly ICoffee _coffee; // Sarmalanan kahve nesnesi

        public CoffeeDecorator(ICoffee coffee) 
        {
            _coffee = coffee;
        }

        public virtual string GetDescription() 
        {
            return _coffee.GetDescription();
        }

        public virtual double GetCost() 
        {
            return _coffee.GetCost();
        }
    }

    // --- 4. SOMUT SÜSLEYİCİLER (Concrete Decorators) ---
    
    // Süt Ekleme Süsleyicisi
    public class MilkDecorator : CoffeeDecorator 
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() 
        {
            return _coffee.GetDescription() + ", Süt";
        }

        public override double GetCost() 
        {
            return _coffee.GetCost() + 10.0; // Süt fiyatı eklenir
        }
    }

    // Çikolata Ekleme Süsleyicisi
    public class ChocolateDecorator : CoffeeDecorator 
    {
        public ChocolateDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() 
        {
            return _coffee.GetDescription() + ", Çikolata";
        }

        public override double GetCost() 
        {
            return _coffee.GetCost() + 15.0; // Çikolata fiyatı eklenir
        }
    }

    // --- 5. UYGULAMANIN GİRİŞ NOKTASI (Main) ---
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("--- Decorator Pattern Kahve Sipariş Örneği ---\n");

            // 1. Adım: Sade bir kahve sipariş edilir
            ICoffee myCoffee = new SimpleCoffee();
            Console.WriteLine($"Sipariş 1: {myCoffee.GetDescription()} | Tutar: {myCoffee.GetCost()} TL");

            // 2. Adım: Kahveye Süt eklenir (Sarmalanır - Decorate edilir)
            myCoffee = new MilkDecorator(myCoffee);
            Console.WriteLine($"Sipariş 2: {myCoffee.GetDescription()} | Tutar: {myCoffee.GetCost()} TL");

            // 3. Adım: Aynı kahveye bir de Çikolata eklenir (İç içe sarmalama)
            myCoffee = new ChocolateDecorator(myCoffee);
            Console.WriteLine($"Sipariş 3: {myCoffee.GetDescription()} | Tutar: {myCoffee.GetCost()} TL");

            Console.WriteLine("\n----------------------------------------\n");

            // Farklı bir kombinasyon: Doğrudan Sütlü ve Çikolatalı Kahve
            ICoffee customCoffee = new ChocolateDecorator(new MilkDecorator(new SimpleCoffee()));
            Console.WriteLine($"Özel Kombinasyon: {customCoffee.GetDescription()} | Tutar: {customCoffee.GetCost()} TL");

            Console.WriteLine("\n--- İşlem Tamamlandı ---");
        }
    }
}