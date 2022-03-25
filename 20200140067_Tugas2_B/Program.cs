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
                con = new SqlConnection(("data source=LAPTOP-O4QM7APE;database=Apotek_Tiara067;Integrated Security = TRUE"));
                con.Open();

                SqlCommand cm = new SqlCommand("create table Supplier (Kode_Supplier char(6) not null primary key, Nama_Supplier varchar(30) not null, No_Telpon char(12) not null, Alamat varchar (50))" +
                    "create table Pembeli (Kode_Pembeli char(6) not null primary key, Nama_Pembeli varchar(30) not null, Jenis_Kelamin char(1) CHECK (Jenis_Kelamin in ('L','P')), No_Telepon char(12), Alamat varchar(50))" +
                    "create table Obat (Kode_Obat char(6) not null primary key, Merek_Obat varchar(30) not null, Jenis_Obat varchar(30) not null, Kategori_Obat varchar(10), Harga_Obat money, Stok_Obat varchar(30), Tanggal_Produksi date, Tanggal_Kadaluwarsa date, Kode_Pelayan char(6))" +
                    "create table Pelayan_Apotek (Kode_Pelayan char(6) not null primary key, Nama_Karyawan varchar(30) not null, Jenis_Kelamin char(1) CHECK(Jenis_Kelamin in ('L','P')))" +
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
        static void Main(string[] args)
        {
            new Program().BuatTable();
        }
    }
}
