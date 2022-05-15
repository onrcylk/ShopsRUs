# ShopsRUs
-TR-
Proje .Net Core 3.1 ile Domain-Driven-Design pattern yaklasımı kullanılarak geliştirilmiştir.
Veritabanı MSSQL olup CodeFirst ile EFCore kullanılarak yapılmıstır.
Veritabanın olusturulması ıcın appsettıngs.json da connection bilgilerini değiştirerek
NugetPackage Manager console update-database komut yazılması gerekmektedir.(Api ile kayıt atılması gereken alanlar CustomersRole,Discount ve Authorize test edilmek istenirse UserRole)
Authorize olarak JWT token kullanarak api güvenliği sağlandı.Sistemi kullanacak kullanıcı kayıt etmek ıcın api ile yetki duzeyı belirtilerek kayıt atılabilir.
Api lerin test edilmesi için attirubute  AllowAnonymous olarak verilmiştir.Yetki kontrolu yapılmak ıstenen api ye Authorize attirubute getirilerek test edilebilir.
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
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


--------------------------------------------------------------------------------------------------------------------------------------------------------------------
-ENG-
The project was developed with .Net Core 3.1 using the Domain-Driven-Design pattern approach.
The database is MSSQL and built using CodeFirst and EFCore.
To create the database, changing the connection information in appsettings.json
NugetPackage Manager console update-database command should be written.
If you want to test the fields CustomersRole, Discount and Authorize that need to be registered with API, UserRole
API security is provided by using JWT token as Authorize. In order to register the user who will use the system, registration can be done by specifying the authorization level with the API.
Attirubute is given as AllowAnonymous for testing APIs. It can be tested by bringing Authorize Attirubute to the API for which authorization control is desired.
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
Areas to be registered
CustomerRole Create Api
{
  "customerRoleName": "Store Staff",
  "statu": 1
}
{
  "customerRoleName": "Store Member",
  "statu": 2
}
{
  "customerRoleName": "Store Customer",
  "statu": 3
}

Discount Create API
{
  "discountName": "Personnel",
  "rate": 30,
  "statu": 1
}
{
  "discountName": "Member",
  "rate": 10,
  "statu": 2
}
{
  "discountName": "Customer",
  "rate": 5,
  "statu": 3
}


--------------------------------------------------------------------------------------------------------------------------------------------------------------------
