Composite:

Diyelim ki bir dosya yöneticisi veya şirket yönetim yazılımı yapıyorsunuz. Sistemde iki tür öğe var:

Dosya (Leaf / Yaprak): Tek başına duran, içinde başka bir şey barındırmayan en küçük birim (Örn: txt dosyası).

Klasör (Composite / Bileşik): İçinde hem başka dosyalar hem de yine alt klasörler barındırabilen yapı.

Eğer sistem tekil nesneler (Dosya) ile grup nesneleri (Klasör) arasında ayrım yapmaya çalışırsa, kodunuz her 
işlemde (BoyutHesapla, Yazdir vb.) if (nesne klasör mü yoksa dosya mı?) kontrolü yapmak zorunda kalır ve 
kod karmaşasından geçilmez hale gelir.

Çözüm:
Composite deseni, tekil nesneler (Leaf) ile grup nesnelerini (Composite) ortak bir arayüz (Component) arkasında toplar. 
Böylece istemci, elindeki nesnenin tek bir dosya mı yoksa içi dolu bir klasör mü olduğunu düşünmeden, her ikisine de 
aynı metotla (ShowDetails) talimat verebilir. Grup nesnesi, kendisine gelen komutu içindeki tüm alt elemanlara otomatik 
olarak yayar (rekürsif / özyinelemeli çalışma).


Composite Deseninin Avantajı Nedir?
Ağaç Yapılarını Basitleştirir: İstemci tarafı (Main), elindeki nesnenin tek bir dosya mı yoksa binlerce öğe içeren
 bir klasör mü olduğunu ayırt etmek zorunda kalmaz. Her ikisine de aynı arayüz (IFileSystemItem) üzerinden yaklaşır.

Yeni Bileşenler Eklemek Kolaydır: Yarın sisteme CompressedFile (Sıkıştırılmış Dosya) veya Shortcut (Kısayol)
 eklemek istediğinizde mevcut yapıyı bozmadan kolayca entegre edebilirsiniz.