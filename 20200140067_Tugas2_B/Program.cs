using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _20200140067_Tugas2_B
{
    class Program
    {
        public void BuatTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=LAPTOP-O4QM7APE;database=Apotek_Tiara067;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand("create table Supplier (Kode_Supplier char(6) not null primary key, Nama_Supplier varchar(30) not null, No_Telpon char(12) not null, Alamat varchar (50))" +
                    "create table Pembeli (Kode_Pembeli char(6) not null primary key, Nama_Pembeli varchar(30) not null, Jenis_Kelamin char(1) CHECK (Jenis_Kelamin in ('L','P')), No_Telepon char(12), Alamat varchar(50))" +
                    "create table Obat (Kode_Obat char(6) not null primary key, Merek_Obat varchar(30) not null, Jenis_Obat varchar(30) not null, Kategori_Obat varchar(10), Harga_Obat money, Stok_Obat varchar(30), Tanggal_Produksi date, Tanggal_Kadaluwarsa date, Kode_Pelayan char(6) foreign key references Pelayan_Apotek(Kode_Pelayan))" +
                    "create table Pelayan_Apotek (Kode_Pelayan char(6) not null primary key, Nama_Pelayan varchar(30) not null, Jenis_Kelamin char(1) CHECK(Jenis_Kelamin in ('L','P')))" +
                    "create table Stock_Masuk (Kode_Masuk char(6) not null primary key, Tanggal_Masuk date not null, Jumlah_Masuk varchar(30) not null, Stock_terbaru varchar(30), Kode_Obat char(6) foreign key references Obat(Kode_Obat) not null, Kode_Supplier char(6) foreign key references Supplier(Kode_Supplier))" +
                    "create table Stock_Keluar(Kode_Keluar char(6) not null primary key, Tanggal_Keluar date not null, Jumlah_Keluar varchar(30) not null, Saldo_Masuk money, Stock_Terbaru varchar(30) not null, Kode_Obat char(6) foreign key references Obat(Kode_Obat) not null, Kode_Pembeli char(6) foreign key references Pembeli(Kode_Pembeli))", con);
                cm.ExecuteNonQuery();
                Console.WriteLine("Yeay!! Tabel Berhasil dibuat!");
                Console.ReadKey();
            }catch (Exception e)
            {
                Console.WriteLine("Sorry!! Sepertinya ada sesuatu yang salah. " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
            Console.ReadKey();
        }
        public void IsiTabel()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=LAPTOP-O4QM7APE;database=Apotek_Tiara067;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand("insert into Supplier (Kode_Supplier, Nama_Supplier, No_Telpon, Alamat) values ('KS-102','Indah Sentosa Abadi','085332436766','Sumedang,Jawa Barat')" +
                 "insert into Supplier (Kode_Supplier, Nama_Supplier, No_Telpon, Alamat) values ('KS-110','PT. Tifany UM','085677236526','Bandung,Jawa Barat')" +
                 "insert into Supplier(Kode_Supplier, Nama_Supplier, No_Telpon, Alamat) values('KS-209', 'PT. Kalbe', '088987765567', 'Jakarta Selatan')" +
                 "insert into Supplier (Kode_Supplier, Nama_Supplier, No_Telpon, Alamat) values ('KS-389','PT. Karunia Anugerah','089933422234','Surabaya,Jawa Timur')" +
                 "insert into Supplier (Kode_Supplier, Nama_Supplier, No_Telpon, Alamat) values ('KS-500','Zaqquera','087653269992','Semarang,Jawa Tengah')"+
                 "insert into Pelayan_Apotek (Kode_Pelayan, Nama_Pelayan, Jenis_Kelamin) values ('KL-110','Asep Saepudin','L')"+
                 "insert into Pelayan_Apotek (Kode_Pelayan, Nama_Pelayan, Jenis_Kelamin) values ('KL-230','Rara','P')"+
                 "insert into Pelayan_Apotek (Kode_Pelayan, Nama_Pelayan, Jenis_Kelamin) values ('KL-303','Nurrohmah','P')"+
                 "insert into Pelayan_Apotek (Kode_Pelayan, Nama_Pelayan, Jenis_Kelamin) values ('KL-403','Dimas','L')"+
                 "insert into Pelayan_Apotek (Kode_Pelayan, Nama_Pelayan, Jenis_Kelamin) values ('KL-103','Raina Gemilang','P')"+
                 "insert into Pembeli (Kode_Pembeli, Nama_Pembeli, Jenis_Kelamin, No_Telepon, Alamat) values ('KP-022','Dadang Zaenudin','L','087234564321','Sumedang, Jawa Barat')"+
                 "insert into Pembeli (Kode_Pembeli, Nama_Pembeli, Jenis_Kelamin, No_Telepon, Alamat) values ('KP-231','Iroh Kusuma','P','085223345523','Majalengka, Jawa Barat')" +
                 "insert into Pembeli(Kode_Pembeli, Nama_Pembeli, Jenis_Kelamin, No_Telepon, Alamat) values('KP-343', 'Hasyim', 'L', '085221666966', 'Cirebon, Jawa Barat')"+
                 "insert into Pembeli (Kode_Pembeli, Nama_Pembeli, Jenis_Kelamin, No_Telepon, Alamat) values ('KP-359','Iin','P','083325644877','Kuningan, Jawa Barat')" +
                 "insert into Pembeli (Kode_Pembeli, Nama_Pembeli, Jenis_Kelamin, No_Telepon, Alamat) values ('KP-698','Elin Hammida','P','085222000237','Indramayu, Jawa Barat')" +
                 "insert into Obat (Kode_Obat, Merek_Obat, Jenis_Obat, Kategori_Obat, Harga_Obat, Stok_Obat, Tanggal_Produksi, Tanggal_Kadaluwarsa, Kode_Pelayan) values ('KO-342','Ambroxol','Sirup','Keras',35000,'2 Karton', '2022-11-08' , '2025-11-08','KL-110')"+
                 "insert into Obat (Kode_Obat, Merek_Obat, Jenis_Obat, Kategori_Obat, Harga_Obat, Stok_Obat, Tanggal_Produksi, Tanggal_Kadaluwarsa, Kode_Pelayan) values ('KO-223','Paracetamol','Tablet','Keras',23000,'3 Karton', '2022-02-25', '2022-03-30' ,'KL-230')" +
                 "insert into Obat (Kode_Obat, Merek_Obat, Jenis_Obat, Kategori_Obat, Harga_Obat, Stok_Obat, Tanggal_Produksi, Tanggal_Kadaluwarsa, Kode_Pelayan) values ('KO-221','Amlodipine','Tablet','Keras',10000,'5 Karton', '2025-10-25', '2030-10-25','KL-303')" +
                 "insert into Obat (Kode_Obat, Merek_Obat, Jenis_Obat, Kategori_Obat, Harga_Obat, Stok_Obat, Tanggal_Produksi, Tanggal_Kadaluwarsa, Kode_Pelayan) values ('KO-234','Amoxicilin','Kapsul','Keras',26000,'2 Karton', '2019-09-07', '2026-09-07','KL-402')" +
                 "insert into Obat (Kode_Obat, Merek_Obat, Jenis_Obat, Kategori_Obat, Harga_Obat, Stok_Obat, Tanggal_Produksi, Tanggal_Kadaluwarsa, Kode_Pelayan) values ('KO-243','Simvastatin','Tablet','Keras',7000,'1 Karton', '2022-08-05', '2027-08-05','KL-110')"+
                  "insert into Stock_Masuk (Kode_Masuk, Tanggal_Masuk, Jumlah_Masuk, Stock_Terbaru, Kode_Obat, Kode_Supplier) values ('KM-200','2020-01-21','5 Karton','10 Karton','KO-223','KS-102')" +
                  "insert into Stock_Masuk (Kode_Masuk, Tanggal_Masuk, Jumlah_Masuk, Stock_Terbaru, Kode_Obat, Kode_Supplier) values ('KM-232','2020-03-22','2 Karton','5 Karton','KO-221','KS-110')" +
                  "insert into Stock_Masuk (Kode_Masuk, Tanggal_Masuk, Jumlah_Masuk, Stock_Terbaru, Kode_Obat, Kode_Supplier) values ('KM-223','2020-10-20','3 Karton','3 Karton','KO-234','KS-209')" +
                  "insert into Stock_Masuk (Kode_Masuk, Tanggal_Masuk, Jumlah_Masuk, Stock_Terbaru, Kode_Obat, Kode_Supplier) values ('KM-252','2021-08-18','4 Karton','6 Karton','KO-342','KS-389')" +
                  "insert into Stock_Masuk (Kode_Masuk, Tanggal_Masuk, Jumlah_Masuk, Stock_Terbaru, Kode_Obat, Kode_Supplier) values ('KM-392','2021-11-20','7 Karton','2 Karton','KO-243','KS-500')" +
                  "insert into Stock_Keluar (Kode_Keluar, Tanggal_Keluar, Jumlah_Keluar, Saldo_Masuk, Stock_Terbaru, Kode_Obat, Kode_Pembeli) values ('KK-001','2020-01-22','1 Lembar', 10000,'9 Karton','KO-221','KP-022')"+
                  "insert into Stock_Keluar (Kode_Keluar, Tanggal_Keluar, Jumlah_Keluar, Saldo_Masuk, Stock_Terbaru, Kode_Obat, Kode_Pembeli) values ('KK-012','2020-03-23','5 Lembar', 35000,'7 Karton','KO-243','KP-231')" +
                  "insert into Stock_Keluar (Kode_Keluar, Tanggal_Keluar, Jumlah_Keluar, Saldo_Masuk, Stock_Terbaru, Kode_Obat, Kode_Pembeli) values ('KK-201','2020-10-25','2 Lembar',52000,'2 Karton','KO-234','KP-343')" +
                  "insert into Stock_Keluar (Kode_Keluar, Tanggal_Keluar, Jumlah_Keluar, Saldo_Masuk, Stock_Terbaru, Kode_Obat, Kode_Pembeli) values ('KK-221','2021-08-20','10 Lembar', 230000,'3 Karton','KO-223','KP-359')" +
                  "insert into Stock_Keluar (Kode_Keluar, Tanggal_Keluar, Jumlah_Keluar, Saldo_Masuk, Stock_Terbaru, Kode_Obat, Kode_Pembeli) values ('KK-110','2021-01-22','3 botol', 105000,'5 Karton','KO-342','KP-698')", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Yeay!! Data berhasil ditambahkan!");
                Console.ReadKey();
            }catch(Exception e)
            {
                Console.WriteLine("Yeah.... Data gagal ditambahkan." + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            new Program().BuatTable();
            new Program().IsiTabel();
        }
    }
}
