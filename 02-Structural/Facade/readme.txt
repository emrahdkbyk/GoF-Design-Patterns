Facade:
Diyelim ki evinizde harika bir ev sinema sistemi kurdunuz. Film izlemek istediğinizde yapmanız gereken işlemler şunlardır:

Işıkları kapat (Lights.Dim())

Projektörü aç ve girişi ayarla (Projector.On(), Projector.SetInput("DVD"))

Ses sistemini aç ve ses seviyesini ayarla (Amplifier.On(), Amplifier.SetVolume(5))

DVD Oynatıcıyı çalıştır ve filmi oynat (DvdPlayer.On(), DvdPlayer.Play("Matrix"))

Film bittiğinde ise tüm bu cihazları tek tek kapatmanız gerekir. İstemci (siz), arka plandaki bu 4-5 farklı cihazın 
karmaşık detaylarıyla tek tek uğraşmak yerine tek bir düğmeye ("Film İzle") basmak istersiniz.

Çözüm:
Facade deseni, karmaşık bir alt sistem kümesinin (Projector, Amplifier, Lights vb.) önüne basit, ortak bir arayüz 
(bir cephe / facade sınıfı) koyar. İstemci, alt sistemlerin sınıflarıyla doğrudan konuşmak yerine sadece Facade sınıfıyla
(HomeTheaterFacade) konuşur. Böylece kod karmaşası ortadan kalkar ve kullanım son derece kolaylaşır.

Facade Deseninin Avantajı Nedir?
Kullanım Kolaylığı (Simplicity): İstemci kodunu, alt sistemlerin karmaşık yapısından ve bağımlılıklarından izole eder. 
Karmaşık alt sistemleri tek bir metodun arkasına saklar.

Gevşek Bağlılık (Loose Coupling): Alt sistemlerde ileride yapılacak değişiklikler 
(örneğin Projector sınıfını yenisiyle değiştirmek), ana istemci kodunu etkilemez; sadece Facade sınıfını güncellemek yeterlidir.