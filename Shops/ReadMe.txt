Proje .Net Core 3.1 ile Domain-Driven-Design pattern yaklasımı kullanılarak geliştirilmiştir.
Veritabanı MSSQL olup CodeFirst ile EFCore kullanılarak yapılmıstır.
Veritabanın olusturulması ıcın appsettıngs.json da connection bilgilerini değiştirerek NugetPackage Manager console update-database komut yazılması gerekmektedir.(Kayıt atılması gereken alanlar CustomersRole ve Authorize test edilmek istenirse UserRole)
Authorize olarak JWT token kullanarak api güvenliği sağlandı.Sistemi kullanacak kullanıcı kayıt etmek ıcın api ile yetki duzeyı belirtilerek kayıt atılabilir.
Api lerin test edilmesi için attirubute  AllowAnonymous olarak verilmiştir.Yetki kontrolu yapılmak ıstenen api ye Authorize attirubute getilerek test edilebilir.

