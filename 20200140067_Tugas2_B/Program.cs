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
                    "create table Obat (Kode_Obat char(6) not null primary key, Merek_Obat varchar(30) not null, Jenis_Obat varchar(30) not null, Kategori_Obat varchar(10), Harga_Obat money, Stok_Obat varchar(30), Tanggal_Produksi date, Tanggal_Kadaluwarsa date, Kode_Pelayan char(6))" +
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
                  "insert into Pembeli (Kode_Pembeli, Nama_Pembeli, Jenis_Kelamin, No_Telepon, Alamat) values ('KP-698','Elin Hammida','P','085222000237','Indramayu, Jawa Barat')", con);
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
