Flyweight:
Orman Simülasyonu veya Oyun Ağaçları
Diyelim ki bilgisayar oyununda veya 3D simülasyonda devasa bir orman tasarlıyorsunuz. 
Ormanda 1 milyon adet ağaç var. Her bir ağaç nesnesinin şu özellikleri var:

X, Y Koordinatları (Konum - Her ağaçta farklıdır)

Renk (Yeşil / Kahverengi - Çoğu ağaçta aynıdır)

Doku / Grafik Verisi (MB'larca büyüklüğünde 3D model ve görsel - Binlerce ağaçta birebir aynıdır)

Eğer 1 milyon ağacın her birinin içine bu devasa Doku verisini kopyalarsanız, 
kısa sürede bilgisayarın RAM'i dolar ve program çöker.

Çözüm:
Flyweight deseni der ki: "Nesnenin ortak (değişmeyen) verilerini bir havuzda (Factory) paylaş, 
sadece benzeyen veya değişen verileri dışarıdan parametre olarak al."

Bunu ikiye ayırırız:

Intrinsic (İçsel - Paylaşılan): Değişmeyen, ortak veri (Örn: Ağaç türü, rengi, doku verisi). 
Bellekte sadece 1 kez oluşturulur ve ortak kullanılır.

Extrinsic (Dışsal - Değişen): Her nesneye özel olan veri (Örn: X ve Y koordinatları).

Flyweight Deseninin Avantajı Nedir?
Devasa Bellek Tasarrufu (RAM Optimization): Aynı özelliklere sahip binlerce/milyonlarca 
nesne oluşturmak yerine, ortak veriler bir kez saklanır ve paylaşılır. 
Sistem kaynaklarını aşırı tüketen uygulamalarda (oyun motorları, render araçları, metin editörleri) vazgeçilmezdir.