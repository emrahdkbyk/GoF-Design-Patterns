Decorator:

Diyelim ki bir kahve otomatı veya kafe uygulaması yazıyorsunuz. Standart bir Kahve (Coffee) nesneniz var.
Müşteriler bu kahvenin üzerine istedikleri kadar ekstra malzeme isteyebiliyor: Süt, Şeker, Çikolata, 
Kremşanti vb.

Eğer kalıtım (inheritance) kullanarak bunu çözmeye kalkarsanız:

MilkCoffee

SugarCoffee

MilkAndSugarCoffee

ChocolateMilkAndSugarCoffee

Yine sınıf patlaması (class explosion) yaşarsınız ve olası kombinasyonlar yüzünden yüzlerce alt sınıf yazmak 
zorunda kalırsınız.

Çözüm:
Decorator deseni der ki: "Asıl nesneyi bozma, onu bir sarmalayıcının (decorator) içine koy."
Sarmalayıcı sınıf da aynı arayüzü uygular, böylece dışarıdan bakıldığında orijinal nesne gibi görünür ama çağrıldığında
hem kendi ekstra özelliğini ekler hem de alttaki orijinal nesneyi tetikler. Bir soğanı kat kat sarmak veya hediye
paketini süslemek gibi düşünebilirsiniz.

Decorator Deseninin Avantajı Nedir?
Dinamik Davranış Ekleme: Çalışma zamanında (runtime) nesnelere yeni özellikler ekleyip çıkarabilirsiniz 
(kalıtım ise statiktir, derleme zamanında belirlenir).

Open/Closed Principle (Açık/Kapalı Prensibi): Var olan SimpleCoffee veya diğer sınıfların koduna hiç dokunmadan,
sadece yeni bir süsleyici sınıf (CaramelDecorator vb.) yazarak sistemi sonsuz kez genişletebilirsiniz.