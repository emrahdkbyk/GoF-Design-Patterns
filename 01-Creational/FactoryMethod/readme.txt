Diyelim ki bir e-ticaret uygulaması geliştiriyorsunuz. Uygulamanızda sipariş verildiğinde 
veya şifre sıfırlandığında kullanıcılara bildirim göndermeniz gerekiyor. Bu bildirimler 
E-posta (Email), SMS veya Push Bildirimi (Mobile Notification) aracılığıyla gönderilebilir.

Desensiz yaklaşımda, bildirim göndereceğiniz yerde sürekli new EmailNotification(), 
new SmsNotification() gibi nesne üretim kodları yazarsınız. İleride sisteme "WhatsApp bildirimi" 
eklemek istediğinizde, uygulamanın her yerindeki if-else bloklarını tek tek değiştirmeniz gerekir. 
Bu durum yazılımın bakımını zorlaştırır (Open/Closed Principle ihlal edilir).

Factory deseni, nesne oluşturma mantığını istemci koddan (Client) ayırarak merkezi bir "Fabrika" sınıfına devreder.
 İstemci hangi nesneye ihtiyacı olduğunu doğrudan new ile üretmek yerine, fabrikaya türü söyler ve fabrika ona uygun 
 nesneyi üretip teslim eder.
