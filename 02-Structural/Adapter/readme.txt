Adapter:
Günlük hayattan düşünün: Yanınızda Amerika'dan aldığınız bir elektronik alet var ve uç kısmı (fişi)
Amerikan standartlarında (110V - yassı uçlu). Ancak Türkiye'deki prizler Avrupa standardında (220V - yuvarlak uçlu). 
Cihazı doğrudan prize takamazsınız. Araya bir Adaptör koyarsınız; adaptör bir tarafı prize uydururken 
diğer tarafı cihaza elektrik sağlar.

Yazılımda da durum aynıdır: Elinizde halihazırda çalışan bir sistem (veya 3. parti bir kütüphane) vardır.
Bu sistemin metot isimleri veya çalışma yapısı, sizin yazdığınız yeni uygulamanın beklediği arayüze (interface) uymaz. 
Sistemi baştan yazmak yerine araya bir Adapter koyarak iki uyumsuz yapıyı konuşturursunuz.

Örnek Senaryo: Kargo Servisi Entegrasyonu
Diyelim ki e-ticaret uygulamanızda standart bir kargo arayüzü (IShippingService) var ve sistemimiz 
ShipOrder(string trackingNumber) metodunu çağırıyor.
Ancak şirketimizin yeni anlaşma yaptığı dış kaynaklı bir kargo firması (FastCargoApi) var. 
Bu firmanın sistemi bizim arayüzümüzü tanımıyor ve onların kendi metodu tamamen farklı: SendPackageWithCargo(string barcodeId).

Adapter Deseninin Avantajı Nedir?
Mevcut Kodu Bozmaz: 3. parti veya eski (legacy) sınıfların koduna dokunmadan (değiştiremediğimiz durumlarda bile) 
onları yeni sistemimize entegre etmemizi sağlar.

Open/Closed Principle (Açık/Kapalı Prensibi): Yeni bir kargo firması geldiğinde mevcut ana kodunuzu değiştirmeden 
sadece yeni bir Adapter yazarak sistemi genişletebilirsiniz.