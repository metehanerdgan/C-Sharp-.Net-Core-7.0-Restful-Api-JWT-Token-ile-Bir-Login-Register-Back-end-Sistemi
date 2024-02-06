# C-Sharp-.Net-Core-7.0-Restful-Api-JWT-Token-ile-Bir-Login-Register-Back-end-Sistemi

Bu .NET Core API projesi, kullanıcı kimlik doğrulama ve yetkilendirme işlemleri için tasarlanmıştır. Aşağıda proje ana hatlarıyla madde madde özetlenmiştir:

Proje, .NET Core kullanılarak geliştirilmiştir.
API, RESTful mimaride tasarlanmıştır.
Program.cs dosyası, uygulamanın giriş noktasını içerir. Bu dosyada servislerin ve middleware'lerin konfigürasyonu gerçekleştirilir.
DBContext klasörü altında AuthenticationDbContext.cs, Entity Framework Core ile veritabanı işlemlerini yönetmek için kullanılan bir DbContext sınıfını içerir.
Controllers klasörü altında AuthenticationController.cs, kullanıcı kimlik doğrulama ve yetkilendirme işlemlerini gerçekleştiren API endpoint'lerini barındırır.
Services klasörü altında UserService.cs, kullanıcı kaydı ve girişi gibi işlemleri yöneten bir servis sınıfını içerir. JWTSecurityToken.cs, JWT (Json Web Token) oluşturma ve doğrulama işlemlerini gerçekleştiren bir servis sınıfını içerir. Interface altındaki ISecurtiyService.cs ve IUserService.cs, ilgili servislerin arayüzlerini tanımlar.
SharedVM klasörü altında, API tarafından kullanılan veri modellerini içerir. Login.cs ve Register.cs, kullanıcı giriş ve kayıt işlemleri için kullanılan veri modellerini içerir. UserManager.cs, API tarafından döndürülen kullanıcı yönetimine ilişkin veri modelini içerir.
Proje, Identity ve JWT Authentication kullanarak kullanıcıların kimlik doğrulamasını ve yetkilendirilmesini sağlar.
Swagger, API dokümantasyonu için kullanılmaktadır.
