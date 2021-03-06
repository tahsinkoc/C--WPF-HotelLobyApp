# C# WPF-HotelLobyApp

## Bu Uygulamayı C# WPF kullanarak geliştirdim.

## Bu Uygulama ile

> Oteldeki odaların müsaitlik durumunu kontrol edebilir ve değiştirebilir
> 
> Gelen müşteriye müsait olan odalardan birini gün sayısı belirterek kiralayabilir
> 
> Dolu olan odayı boşaltabilir ve müşterinin çıkış işlemlerini yapabilirsiniz.

# Projeyi Kendi Bilgisayarınızda Geliştirme

Proje dosyalarını indirdikten sonra projeyi VisualStudio ile açabilirsiniz.
Ancak projeyi geliştirirken SQLite kullanabilmek amacıyla <code> System Data SQLite Core </code> Eklentisini kurdum
Eğer projeyi bilgisayarınızda geliştirme yapmak üzere açtığınızda hatalar ile karşılaşıyorsanız sizler de eklentiyi kurabilirsiniz.

# Uygulamanın Çalıştırılması ve Kullanımı

Proje Dosyasını bilgisayarınıza indirdikten sonra bin klasörü içersindeki debug klasörü içerisine girip ve oradaki <code>hotel-loby.exe</code>
dosyasını çalıştırdığınızda sorunsuz bir şekilde uygulamayı çalıştırmış olacaksınızdır.
> **ÖNEMLİN NOT: <code>hotel-loby.exe</code> dosyasını klasöründen çıkarmayınız aksi takdirde uygulama çalışmayacaktır. Bunun nedeni ise 
> klasör hiyerarşisinde SQLite için gerekli bazı dosyaların bulunmasıdır.**

## Uygulamanın Kullanımı

Uygulama iki panelden oluşur sol taraftaki panel ile işlemerli yapabilir sağ taraftaki panel ile de odaları görüntüleyebilirsiniz.

Sol taraftaki Oda Filtreleri Bölümünden oda kapasitesine göre görüntüleme yapabilirsiniz.

![Oda Filtresi](/Assets/roomFilter.png)

Biz 2 kişilik odaları görüntülemek üzere <code>2 KİŞİLİK ODALAR</code> butonuna basıyoruz.

![Oda Filtresi](/Assets/filtered.png)

Oda işlemleri bölümünde ise odaları seçmek için sağ taraftaki seçmek istediğimiz odanın satırındaki herhangi bir sütuna tıkladığımızda o odayı seçmiş olur ve dilersek odayı boşaltabilir ya da odayı yine soldaki menüden müşteri bilgilerini girerek kiralayabiliriz

![Oda](/Assets/roomSelect.png)

Örneğin burada 4 numaralı odayı seçtiğimzde oda detaylarının açıldığını ve  sol paneldeki odayı kirala butonunun <code>4 NUMARALI ODAYI KİRALA</code> şeklinde değiştiğini görebiliriz

![Oda](/Assets/renting.png)
 
Sonrasında ise müşteri bilgilerini girip butona tıkladığımızda kolaylıkla odanın kiralandığını görebilirsiniz.
 
![Oda](/Assets/rented.png)



