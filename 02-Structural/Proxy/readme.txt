Proxy:
Günlük hayattan düşünün: Çok önemli bir şirketin CEO'su ile görüşmek istiyorsunuz. Doğrudan CEO'nun odasına dalamazsınız. 
Kapıda bir Resepsiyonist (Proxy) vardır. Resepsiyonist size randevunuzun olup olmadığını sorar, kimliğinizi kontrol eder:

Eğer yetkiniz yoksa sizi içeri almaz.

Eğer yetkiniz varsa veya randevunuz tamamsa, sizi gerçek CEO'ya yönlendirir.

Yazılımda da durum aynıdır: Ağır bir nesneyi (örneğin veritabanından devasa bir dosya çekmek) 
her an yüklemek istemeyebiliriz ya da hassas bir kaynağa erişmeden önce güvenlik (yetki kontrolü) yapmak isteyebiliriz.

Çözüm
Proxy deseni, asıl işi yapan nesneyle (Real Subject) istemci (Client) arasına aynı arayüzü uygulayan bir vekil sınıf (Proxy) koyar.
İstemci, karşısındakinin asıl nesne mi yoksa vekil mi olduğunu bilmez. Vekil, gelen isteği kontrol eder (örneğin kullanıcı admin mi?); 
uygunsa asıl nesneye iletir, değilse işlemi engeller veya geciktirir.


Proxy Deseninin Avantajı Nedir?
Güvenlik ve Yetkilendirme (Protection Proxy): Hassas kaynaklara erişilmeden önce kimlik ve rol denetimi yapılmasını sağlar.

Performans / Kaynak Tasarrufu (Virtual Proxy): Ağır nesneler gereksiz yere hemen oluşturulmaz; gerçekten ihtiyaç 
duyulduğunda (Admin geldiğinde) belleğe yüklenir.