Factory Method ile karıştırılmaması gereken en temel fark budur:

Factory Method: Tek bir nesne türü üretmeye odaklanır (Örn: Bildirim fabrikası sadece bildirim üretir).

Abstract Factory: Birbiriyle ilişkili veya bağımlı nesne ailelerini (product families) birbirine bağlamadan, 
tek bir merkezden üretmenizi sağlar.

1. Gerçek Hayat Problemi: Çapraz Platform Arayüz (UI) Temaları
Diyelim ki masaüstü bir uygulama geliştiriyorsunuz ve bu uygulamanın hem Windows hem de macOS işletim 
sistemlerinde çalışması gerekiyor. Uygulamanın bir Butonu (IButton) ve bir Onay Kutusu (ICheckbox) var.

Ancak bir kural var: Windows ortamında çalışan bir uygulama tüm arayüz elemanlarını Windows stilinde 
(WindowsButton + WindowsCheckbox), Mac ortamında çalışan ise Mac stilinde (MacButton + MacCheckbox) oluşturmak zorundadır.
 Yanlışlıkla bir Mac ekranında Windows butonu görünmemelidir.

Desensiz yaklaşımda if (os == "Windows") { new WindowsButton(); } gibi kodlar her yere saçılır ve yeni bir tema 
(örneğin Linux/Dark Theme) eklemek kâbusa döner.

2. Abstract Factory ile Çözüm
Abstract Factory deseni, birbiriyle uyumlu ürün aileleri üretmek için bir soyut fabrika arayüzü tanımlar. 
İstemci kod, hangi işletim sisteminde çalıştığını bilmek zorunda kalmaz; sadece kendisine verilen fabrika nesnesi 
üzerinden tutarlı bileşenler üretir.

