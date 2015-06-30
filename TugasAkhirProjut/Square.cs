using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TugasAkhirProjut
{
    public class Square : Shape
    {
        public static void tambah()
        {
            int sisi;
            string sisis;
            bool batas = false;
            bool cekint;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tTambah Square");
                Console.WriteLine("\t\t\t\t\t\t\t==================\n");
                Console.Write("Masukan Sisi: ");
                sisis = Console.ReadLine();
                cekint = int.TryParse(sisis, out sisi);
                if (sisi >= 0 && cekint == true)
                {
                    batas = true;
                    continue;

                }
                else
                {
                    Console.WriteLine("Sisi yang dimasukan tidak valid!\nTekan sembarang tombol untuk kembali memasukan umur");
                    Console.ReadKey();
                }

            } while (batas == false);
            ///masukan ke file...
            // lwad class shape?
            ///
            tambahkefile(sisi,"square");
            /////
            Console.WriteLine("\n\nData berhasil disimpan! Tekan sembarang tombol untuk kembali....");
            Console.ReadKey();
            tambahshape();

        }

        public static void hapus()
        {
            int sisi;
            string sisis;
            bool cekint;
            bool batas = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tHapus Circle");
                Console.WriteLine("\t\t\t\t\t\t\t==================\n");
                Console.Write("Masukan Sisi yang akan di hapus :  ");
                sisis = Console.ReadLine();
                cekint = int.TryParse(sisis, out sisi);
                if (sisi >= 0 && cekint == true)
                {
                    batas = true;
                    continue;

                }
                else
                {
                    Console.WriteLine("Sisi yang dimasukan tidak valid!\nTekan sembarang tombol untuk kembali memasukan umur");
                    Console.ReadKey();
                }

            } while (batas == false);
            ///hapus filenya
            /// lwad shape class
            /// 
            hapuskefile(sisi, "square");
            //copy dri cp ke asli
            copyfile("square");

            Console.WriteLine("\nTekan sembarang tombol untuk kembali....");
            Console.ReadKey();
            hapusshape();


        }


        public static void lihat()
        {

            bool kondisi;
            int pilih = 0;
            string pilihan;
            do
            {
                menulihat("Square");
                Console.Write("Masukan pilihan anda : ");
                pilihan = Console.ReadLine();
                kondisi = int.TryParse(pilihan, out pilih);
                if (kondisi == true && pilih > 0 && pilih < 4)
                {
                    continue;
                }
                Console.WriteLine("\nPilihan yang anda masukan salah!");
                Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                Console.ReadLine();
            } while (pilih < 1 || pilih > 3);

            switch (pilih)
            {
                case 1:
                    /// LUAS
                    ///
                    sorting("Luas");
                    break;
                case 2:
                    // keliling
                    sorting("Keliling");
                    break;
                case 3:
                    //main menu tampil shape
                    tampilshape();
                    break;
                default:
                    break;
            }
        }
        public static void sorting(string hit)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tLihat Square");
            Console.WriteLine("\t\t\t\t\t\t\t\t===================");
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\square.txt";
            string[] scores = File.ReadAllLines(file);
            var orderedScores = scores.OrderBy(x => int.Parse(x.Split('\t')[0]));
            int counter = 0;
            Console.WriteLine("No.\t" + hit + "\t\tSisi");
            foreach (var score in orderedScores)
            {
                counter++;
                /// kode buat nampilin file dan jumlah gitu...
                int jari = Convert.ToInt16(score);
                int hasil = rumus(jari, hit);
                Console.WriteLine(counter + ".\t" + hasil + "\t\t\t" + jari);
            }
            Console.WriteLine("\nTekan sembarang untuk kembali ke menu lihat square");
            Console.ReadKey();
            lihat();
        }
        /////

    }
}
