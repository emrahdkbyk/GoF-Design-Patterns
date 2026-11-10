1. Gerçek Hayat Problemi: Belge / Rapor Şablonları
Diyelim ki bir doküman yönetim veya raporlama yazılımı geliştiriyorsunuz. 
Sisteminizde çok karmaşık, içinde onlarca alt bileşeni (grafikler, tablolar, sayfa yapısı, 
kurumsal stiller) barındıran devasa bir Rapor Şablonu (Report) nesnesi var.

Her kullanıcı yeni bir rapor oluşturmak istediğinde, sıfırdan bir rapor nesnesi oluşturup 
tüm bu karmaşık alt bileşenleri tek tek veritabanından çekmek veya yeniden yüklemek hem büyük bir 
performans kaybına (CPU ve I/O maliyeti) yol açar hem de kod karmaşası yaratır.

2. Prototype Pattern ile Çözüm
Prototype deseninin temel fikri şudur: Var olan bir nesneyi (prototipi) kopyalayarak 
(klonlayarak) yeni bir nesne üretmek.

Yani sıfırdan yeni bir nesne new'lemek yerine, elimizdeki hazır nesnenin hafızadaki bir kopyasını
 (clone) alırız ve üzerinde ufak değişiklikler yaparak hızla kullanıma sunarız. 
 C# dilinde bu işi built-in olarak sağlayan ICloneable arayüzü veya derin kopya (deep copy) mekanizmaları kullanılır.

 Prototype Deseninin Kritik Noktası: Sığ (Shallow) vs Derin (Deep) Kopya
Sığ Kopya (Shallow Copy): Nesnenin içindeki referans tipli özellikler 
(örneğin yukarıdaki DataRows listesi) klonlandığında bellekte yeni bir liste oluşturulmaz;
 iki nesne de aynı listeyi işaret eder. İstanbul şubesine veri eklediğinizde orijinal rapor da bozulur (istenmeyen durum).

Derin Kopya (Deep Copy): Kodumuzda yaptığımız gibi, alt nesneler/listeler de tamamen 
bağımsız yeni kopyalar olarak yeniden oluşturulur. Böylece klonlanan nesne üzerinde yapılan 
değişiklikler orijinal prototipi etkilemez.