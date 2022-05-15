Proje .Net Core 3.1 ile Domain-Driven-Design pattern yaklasımı kullanılarak geliştirilmiştir.
Veritabanı MSSQL olup CodeFirst ile EFCore kullanılarak yapılmıstır.
Veritabanın olusturulması ıcın appsettıngs.json da connection bilgilerini değiştirerek
NugetPackage Manager console update-database komut yazılması gerekmektedir.(Api ile kayıt atılması gereken alanlar CustomersRole,Discount ve Authorize test edilmek istenirse UserRole)
Authorize olarak JWT token kullanarak api güvenliği sağlandı.Sistemi kullanacak kullanıcı kayıt etmek ıcın api ile yetki duzeyı belirtilerek kayıt atılabilir.
Api lerin test edilmesi için attirubute  AllowAnonymous olarak verilmiştir.Yetki kontrolu yapılmak ıstenen api ye Authorize attirubute getirilerek test edilebilir.

Kayıt Atılacak Alanlar
CustomerRole Create Api
{
  "customerRoleName": "Magaza Calisani",
  "statu": 1
}
{
  "customerRoleName": "Magaza Üyesi",
  "statu": 2
}
{
  "customerRoleName": "Magaza Müşteri",
  "statu": 3
}

Discount Create Api
{
  "discountName": "Personel",
  "rate": 30,
  "statu": 1
}
{
  "discountName": "Üye",
  "rate": 10,
  "statu": 2
}
{
  "discountName": "Musteri",
  "rate": 5,
  "statu": 3
}