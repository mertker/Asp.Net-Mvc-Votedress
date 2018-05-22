# Asp.Net-Mvc-Votedress
E-ticaret sistemi üzerine kurulmuş sosyal medya projesi

Günümüzde bilgi ve iletişim teknolojilerinde yaşanan hızlı gelişmeler; toplumun tüm kesimlerinde, günlük yaşamın her alanında bilgisayar kullanımını çağın bir gereği olduğu bilincini oluşturmuştur. Ülkeler sermayenin üretimini yeniden gerçekleştirebilmek ve daha fazla kişiye ulaşabilmek için bilgi ve iletişim teknolojilerinin içinde bulunduğu yeni ekonomik modeli yani elektronik ticareti hayata geçirmişlerdir. E-ticaretin bu kadar yaygınlaşması kıyafet çeşitliliğini artırmakla insanların kıyafet seçimindeki kararsızlığını da arttırmıştır. Çok sayıda kıyafete ulaşmanın yanında diğer insanlarında anlık olarak yorumlarını alıp, kendisine en uygun kıyafeti bulma ihtiyacı doğmuştur.

Bu problem günümüz sosyal medyalarında(instagram vs.) kullanılmasına rağmen verimli olmamaktadır. Size yaşadığım bir örnekle açıklamak isterim.  Bir gün mağazada 2 kıyafet arasında kararsızlıkta kaldım. İnstagram da hangi kıyafeti seçeceğime karar vermek için denediğim 2 kıyafetin resimlerini attım ve diğer arkadaşlarımın yorumlarına göre birini seçmek istedim. Fakat arkadaş sayım çok olduğundan ve çok fazla yorum olduğundan hangi kıyafetimin en çok beğenildiğinin takibini yapmakta çok zorlandım. Ve o zaman farklı bir sosyal medya gereksinimi olduğunu düşündüm. 

## Projenin tanıtımı

Votedress'i kısaca tanımlamak gerekirse klasik e-ticaret sistemlerindeki gibi sepete, ekle sipariş ver gibi sığ bir yaklaşım kullanarak ürün satmak yerine kullanıcıya ürünlerle etkileşim haline girebileceği bir plartform sunmak yani sistemi kullanan kullanıcı gözünde, amaç kişiye ürün satmak değil ona keyifli bir plartform sunmak. Kullanıcı plartformun tatını çıkarırken arka planda ürün reklamı ve satımı kullanıcının dikkatinden kaçmakta bu özellik diğer e-ticaret sistemlerinden votedressi ayırmaktadır


Sisteme girdiğimizde  bizi ilk olarak giriş sayfası karşılıyor önce burdan hesap oluşturmalı veya sosyal medya hesaplarımızdan birisiyle giriş yapmalıyız. Sistemde iki tip hesap bulunmakta bunlardan birincisi Bireysel hesap diğeri ise kurumsal hesap. Kurumsal hesap bir şirketin votedressdeki hesabıdır. Kurumsal hesap oluşturan kişi sisteme ürünlerini ekleyip bu ürünlerini takip etmekte işte bu noktada votedress'in kurumsal kullanıcay sunduğu en etkili avantajlardan birisi devreye girmekte bu avantaj, kurumsal kullanıcının hiçbir uğraş veya emek harcamaksızın ürünlerinin reklamını yapabilmesidir, bunu nasıl yaptığını ileride anlatağım. 

### Giriş Ekranı

![giris](https://user-images.githubusercontent.com/24223180/40380404-ab7814a6-5e01-11e8-832c-47d626173c60.png)

### Bireysel Kayıt

![bireysel kayit](https://user-images.githubusercontent.com/24223180/40381218-cf5dd246-5e03-11e8-8ae2-ff9819544d78.png)


### Kurumsal Kayıt

![kurumsal kayit](https://user-images.githubusercontent.com/24223180/40381279-f6b6efc6-5e03-11e8-989b-6ddf759164bf.png)

### Bireysel Kullanıcı Hesabı ile giriş

Bireysel kullanıcı ile giriş yaptıkdan sonra bizi ilk olarak anasayfamız karşılamakda burda takip ettigimiz kişilerin paylaştıkları oylamalar, ürünler veya koleksiyonları görebilmekteyiz tüm paylaşımlar kiyafetler üstüne olmaktadır

![anasayfa](https://user-images.githubusercontent.com/24223180/40381380-36f8d770-5e04-11e8-9a6a-1294709231a0.png)

### Oylama Sayfası

Oylama sayfasına sol taraftaki oylamalar linki ile ulaşılmaktadır. Öncelikle oylama nedirden bahsedeyim. Oylama, arasında seçim yapamadığımız kıyafetleri ister sistemdeki tüm kullanıcılara istersekte sadece bizim belirlediğimiz kişilere sunduğumuz bir yapıdır.
Bunun neye benzediğini aşağıdaki resimde görebilirsiniz. Oylama sayfasının devamını oylama başlatmayı anlattıkdan sonra anlatacağım


![oylama](https://user-images.githubusercontent.com/24223180/40381812-62253f96-5e05-11e8-9b48-8cb80a56e70c.png)



Örneğin; Bir mağazaya gittik ve 3 adet kıyafetten birini almak istiyoruz ama karar vermekte zorlandık bu kıyafetleri üzerimizde deneyerek resimlerini çekip sisteme yüklüyoruz sistem bizim için bir oylama başlatıyor.

Öncelikle oylama başlatma sayfasına gidiyoruz

![oylamabaslat_link](https://user-images.githubusercontent.com/24223180/40382140-514c48c6-5e06-11e8-9c68-5252a8f058f2.png)


### Oylama Başlatma Sayfası

![oylamabaslat_giris](https://user-images.githubusercontent.com/24223180/40382193-729b2e20-5e06-11e8-8139-d81d31bd9777.png)


Bu sayfada gördüğünüz siyah kamera resimleri oylamada kullanacağımız ürünleri oylamaya eklememizi sağlıyor. 

Not: Kurumsal kullanıcı(Mağaza) sisteme ürünlerini eklediğinde sistem o ürün için tekrar üretilmesi imkansız bir karekod oluşturuyor mağaza bu karekodu ürün etiketine yapıştırıyor.



Ürün etiketi üzerindeki kare kod telefon kameramızdan okutularak oylamaya ekliyoruz

![oylamabaslat_karekod](https://user-images.githubusercontent.com/24223180/40382478-3a1e9554-5e07-11e8-86df-91658535f7c5.png)

Daha sonra eklediğimiz her ürünü üstümüzde deneyip farklı farklı resimlerini çekip onlarıda ekliyoruz.

![oylamabaslat_resimlereklendi](https://user-images.githubusercontent.com/24223180/40382615-7a2d8114-5e07-11e8-9667-1d7501e8ee29.png)








