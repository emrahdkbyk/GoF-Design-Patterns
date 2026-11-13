Bridge:
Diyelim ki bir Cihaz (Device) (Örn: Televizyon, Radyo) ve bu cihazları kontrol eden Kumandalar (Remote Control) 
(Örn: Standart Kumanda, Gelişmiş/Akıllı Kumanda) tasarlıyorsunuz.

Eğer kalıtım (inheritance) kullanarak bunu çözmeye kalkarsanız şöyle bir senaryo ortaya çıkar:

TvWithStandardRemote

TvWithAdvancedRemote

RadioWithStandardRemote

RadioWithAdvancedRemote

Yarın sisteme "Klima" eklense ve "Dokunmatik Kumanda" çıksa, kombinasyon sayısı katlanarak artar. 
Bu duruma yazılım mühendisliğinde Sınıf Patlaması (Class Explosion) denir.

Çözüm:
Bridge deseni, soyutlama (Abstraction) ile uygulama/gerçekleme (Implementation) kısımlarını birbirinden 
ayırarak iki bağımsız hiyerarşiye böler. Böylece kumandaları değiştirmek cihazları etkilemez, 
cihazları değiştirmek de kumandaları etkilemez. Aralarında bir "köprü" (bridge) kurulur.

Bridge Deseninin Avantajı Nedir?
Sınıf Patlamasını Önler: Cihazlar ve kumandalar tek bir kalıtım ağacında ezilmek yerine iki ayrı 
bağımsız dünyaya (IDevice ve RemoteControl) ayrılır. İstediğiniz kumandayı dilediğiniz cihaza köprü kurarak bağlayabilirsiniz.

Bağımsız Genişleme: Yeni bir cihaz (Klima) veya yeni bir kumanda (SesliKomutKumandası) eklemek istediğinizde mevcut diğer
 sınıflara hiç dokunmadan sistemi büyütebilirsiniz.