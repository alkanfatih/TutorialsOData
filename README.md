# OData (Open Data Protocol) Nedir?
OData (Open Data Protocol), web tabanlı hizmetler arasında veri paylaşımını kolaylaştırmak için kullanılan bir açık protokoldür. OData, REST (Representational State Transfer) prensiplerine dayanır ve HTTP protokolünü kullanarak kaynaklara (örneğin veritabanları, dosya sistemleri, servisler) erişim sağlar. Bu protokol, verilerin standart bir şekilde tarif edilmesini ve paylaşılmasını destekler.
## Asp.NET Web API ve OData
ASP.NET Web API ve OData, birlikte kullanıldığında, veri hizmetlerini standartlaştırmak, sorgulamak ve tüketmek için güçlü bir çözüm sunar. OData protokolü, kaynaklara (veri tabanları, dosyalar, servisler vb.) standart CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştirmek için HTTP üzerinden sorgular yapma yeteneği sağlar. Ayrıca, sorguları genişletmek ve filtrelemek için bir dizi özellik sunar.

### Kurulum
1. **NuGet Paketleri:** Microsoft.AspNetCore.OData paketini ekleyin.
2. **Veri Modelini Tanımlayın:** OData sorgularını işleyeceğiniz veri modelini tanımlayın. (People.cs) ve (AppDbContext.cs)
3. **OData Hizmetini Yapılandırın:** OData servislerini eklemek ve yapılandırmak için AddOData metodu kullanılır. (Program.cs)
4. **ODataController Kullanımı:** ODataController, ASP.NET Web API controller’larına OData özellikleri eklemek için kullanılır. (ValuesController.cs)

## ODATA Kullanımı
> [!TIP]
> **Veri Çekme:** *GET /api/Values*

> [!TIP]
> **Veri Sorgulama ve Filtreleme:** *GET /api/Values?$filter=Age ge 30*

> [!TIP]
> **Veri Sıralama:** *GET /api/Values?$orderby=Age descs*

> [!TIP]
> **Veri Sayfalama:** *GET /api/Values?$top=10&$skip=20*

> [!TIP]
> **Belirli Alanları Seçme:** *GET /api/Values?$select=Name,Age*

> [!TIP]
> **İlişkili Veri Setlerini Genişletme:** *GET /api/Values?$expand=OwnedItems*


[Daha fazla bilgi için: ***alkanfatih.com***](https://alkanfatih.com/odata-open-data-protocol-nedir/)
