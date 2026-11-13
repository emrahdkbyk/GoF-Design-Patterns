using System;
using System.Collections.Generic;

namespace FlyweightPatternExample
{
    // --- 1. FLYWEIGHT NESNESİ (Paylaşılan Ortak Veri) ---
    // Ağacın ortak özellikleri (Değişmeyen, hafızada tek bir kopya olarak tutulacak kısım)
    public class TreeType 
    {
        public string Name { get; }
        public string Color { get; }
        public string Texture { get; } // Devasa veri varsayalım

        public TreeType(string name, string color, string texture) 
        {
            Name = name;
            Color = color;
            Texture = texture;
        }

        // Çizim işlemi yapılırken dışarıdan gelen konum (extrinsic) bilgileri kullanılır
        public void Draw(int x, int y) 
        {
            Console.WriteLine($"[Ağaç Çizildi] Tür: {Name} | Renk: {Color} | Konum: ({x}, {y})");
        }
    }

    // --- 2. FLYWEIGHT FABRİKASI (Havuz / Cache Yöneticisi) ---
    // Aynı türde ağaç nesnelerinin tekrar tekrar üretilmesini engeller, havuzdan verir
    public class TreeFactory 
    {
        private static readonly Dictionary<string, TreeType> _treeTypes = new Dictionary<string, TreeType>();

        public static TreeType GetTreeType(string name, string color, string texture) 
        {
            string key = $"{name}_{color}_{texture}";

            if (!_treeTypes.ContainsKey(key)) 
            {
                _treeTypes[key] = new TreeType(name, color, texture);
                Console.WriteLine($"[FACTORY] Yeni TreeType belleğe oluşturuldu: {name}");
            }

            return _treeTypes[key]; // Havuzda varsa direkt var olanı döndürür (RAM tasarrufu)
        }

        public static int GetTotalTypesCount() 
        {
            return _treeTypes.Count;
        }
    }

    // --- 3. CONTEXT NESNESİ (Ağacın Kendisi) ---
    // Her ağaca özel olan benzersiz verileri (X, Y koordinatları) ve ortak türe referansı tutar
    public class Tree 
    {
        private int _x;
        private int _y;
        private TreeType _treeType; // Paylaşılan ortak veriye köprü

        public Tree(int x, int y, TreeType treeType) 
        {
            _x = x;
            _y = y;
            _treeType = treeType;
        }

        public void Draw() 
        {
            _treeType.Draw(_x, _y);
        }
    }

    // --- 4. UYGULAMANIN GİRİŞ NOKTASI (Main) ---
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("--- Flyweight Pattern Orman Simülasyonu Örneği ---\n");

            List<Tree> forest = new List<Tree>();

            // Senaryo: Milyonlarca ağaç eklediğimizi düşünelim. 
            // Sadece 2-3 farklı TreeType (Meşe, Çam) kullanılıyor ama binlerce koordinat var.

            // 50 tane Meşe ağacı dikelim
            for (int i = 0; i < 50; i++) 
            {
                TreeType type = TreeFactory.GetTreeType("Meşe", "Yeşil", "mese_dokusu.png");
                forest.Add(new Tree(i * 10, i * 5, type));
            }

            // 50 tane Çam ağacı dikelim
            for (int i = 0; i < 50; i++) 
            {
                TreeType type = TreeFactory.GetTreeType("Çam", "Koyu Yeşil", "cam_dokusu.png");
                forest.Add(new Tree(i * 5, i * 15, type));
            }

            Console.WriteLine($"\n>> Toplam Ağaç Nesnesi Sayısı: {forest.Count}");
            Console.WriteLine($">> Bellekte Tutulan Gerçek Ağaç Türü (Flyweight) Sayısı: {TreeFactory.GetTotalTypesCount()}");
            
            Console.WriteLine("\n>> İlk 3 ağaç çiziliyor:");
            forest[0].Draw();
            forest[1].Draw();
            forest[50].Draw();

            Console.WriteLine("\n--- İşlem Tamamlandı ---");
        }
    }
}