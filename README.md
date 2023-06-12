# UnictiveTest

## Tentang Project
### Deskripsi
*Adalah RESTAPI yang dibuat untuk memenuhi syarat Reqruitment di PT. Uniktif Media Indonesia*

### Framework, Library dan Database
*RestAPI dibangun dengan ASP.NET Core Web API dengan Framework .NET 6.0 dan menggunakan database Microsoft SQL Server 2012*

Ada 2 Project dalam 1 solution ini :
* RestAPI (Untuk DotNet Task)
* TestLogic (Ketentuan : Untuk angka dengan looping 1-30. Setiap angka hasil pembagian dari 4 adalah 0 , maka angka dirubah menjadi unictive,
jika angka hasil pembagian dari 14 dan 4 hasilnya 0 maka angka dirubah menjadi Unictive Media).

Beberapa library yang digunakan, diantaranya :
* Dapper (2.0.123)
* Microsoft.AspNetCore.Authentication.JwtBearer
* Microsoft.Data.SqlClient
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools
* Newtonsoft.Json
* Swashbuckle.AspNetCore

Versi Database : Microsoft SQL Server 2012

*Table* : **Member**

| Columns      | Type        | Length | Primary                 |
| -----------  | ----------- | ------ | ----------------------- |
| Id           | int         | 11     | YES / Auto Increment    |
| Nama         | varchar     | 200    |                         |
| Email        | varchar     | 50     |                         |
| Phone        | varchar     | 15     |                         |

*Table* : **MemberHobby**

| Columns      | Type        | Length | Primary                 |
| -----------  | ----------- | ------ | ----------------------- |
| Id           | int         | 11     | YES / Auto Increment    |
| JenisHobby   | varchar     | 100    |                         |
| MemberId     | int         | 11     | FK                      |

*Table* : **UserInfo**

| Columns      | Type        | Length | Primary                 |
| -----------  | ----------- | ------ | ----------------------- |
| UserId       | int         | 11     | YES / Auto Increment    |
| DisplayName  | varchar     | 60     |                         |
| UserName     | varchar     | 30     |                         |
| Email        | varchar     | 50     |                         |
| Password     | varchar     | 20     |                         |
| CreatedDate  | datetime    |        |                         |

# Memulai
## Requirement/Kebutuhan
Untuk Requierement/Kebutuhan dalam menjalankan REST API ini, diantaranya :
* Visual Studio 2022.
* Microsoft SQL Server Management Studio 2012.
* Postman Version 10.14.2

## Cara Install
Adapun langkah-langkah dalam menggunakan REST API ini adalah sebagai berikut :
1. Buka Visual Studio anda
2. Pilih menu Tools => NuGet Package Manager => Package Manager Console
3. Kemudian Clone repo dengan mengetik perintah/command `git clone https://github.com/yb6241/UnictiveTest.git` 
4. Restore Database
    * Dengan Cara Manual :
        * Mulai
        * db_unictive.bak bisa anda temukan pada folder Project RestAPI
        * Buka dan Masuk ke SQL editor anda
        * Kemudian buat database baru dengan nama db_unictive
        * Klik kanan kemudian pilih menu Task/Restore/Database
        * Selanjutnya pilih Source dari Device
        * Carilah tempat anda menaruhnya (default ada di folder Project RestAPI dengan nama db_unictive.bak)
        * Kemudian klik OK
        * Selesai
5. Menjalankan Project RestAPI :
    * Untuk merubah koneksi database dengan penyesuaian pada settingan MySQL anda, dapat dikonfigurasi pada file `appsettings.json`
        ```json
        "ConnectionStrings": {
            "DefaultConnection": "Server=YB;Database=db_unictive;User Id=sa;password=P@ssw0rd;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;MultipleActiveResultSets=true;"
        }
        ```
    * Ubah settingan Jwt pada file `appsettings.json`
        ```json
        "Jwt": {
            "Key": "Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx",
            "Issuer": "JWTAuthenticationServer",
            "Audience": "JWTServicePostmanClient",
            "Subject": "JWTServiceAccessToken"
        }
        ```
    * Jalankan aplikasi dengan menekan `F5`
    * Aplikasi akan otomatis membuka Swagger editor
    * Collection Postman terdapat pada folder project folder RestAPI
    * Buka aplikasi Postman
    * Kemudian klik tombol import
    * Pilih file pada folder Postman Collection
    * masing-masing terdapat untuk pengetesan Get, GetbyId, GetToken, Post, Put, Delete
    * Untuk pertama kali, pilih Request GetToken untuk mendapatkan Bearer Token (Bearer Token digunakan untuk semua Request yang ada)
    * pastikan email dan password sudah terdaftar pada table UserInfo
    * Pada default email akan terdaftar `user@example.com` dan password `P@ssw0rd`
    * Jika ingin membuat email dan password yang baru, silahkan register secara manual pada table UserInfo
    * Jika semua sudah selesai klik tombol Send pada Postman
    * Enjoy it !
6. Menjalankan Project TestLogic :
    * Buka Solutions Explorer
    * Klik kanan pada Project TestLogic
    * Pilih Set as Startup Project
    * Hit tombol `F5`
    * Jika berhasil akan muncul Command Prompt

# Cara Berkontribusi
Untuk bisa berkontribusi dalam mengembangkan aplikasi ini, silahkan kontak developer terlebih dahulu.

# Lisensi
Lisensi yang digunakan pada projek ini adalah GNU GENERAL PUBLIC LICENSE Version 3

Anda bisa melihatnya pada file `LICENSE.txt`

# Kontak
- Phone : +62 896 3696 7361
- Email : yanbaktra@gmail.com