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
    public class Circle : Shape
    {
        public static void tambah()
        {
            int jari;
            string jaris;
            bool cekint;
            bool batas = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tTambah Circle");
                Console.WriteLine("\t\t\t\t\t\t\t==================\n");
                Console.Write("Masukan Jari-Jari: ");
                jaris = Console.ReadLine();
                cekint = int.TryParse(jaris, out jari);
                if (jari >= 0 && cekint == true)
                {
                    batas = true;
                    continue;

                }
                else
                {
                    Console.WriteLine("Jari-jari yang dimasukan tidak valid!\nTekan sembarang tombol untuk kembali memasukan umur");
                    Console.ReadKey();
                }

            } while (batas == false);
            ///masukan ke file...
            // lwad class shape?
            ///
            tambahkefile(jari,"circle");
            /////
            Console.WriteLine("\n\nData berhasil disimpan! Tekan sembarang tombol untuk kembali....");
            Console.ReadKey();
            tambahshape();

        }

        public static void hapus()
        {
            int jari;
            string jaris;
            bool cekint;
            bool batas = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tHapus Circle");
                Console.WriteLine("\t\t\t\t\t\t\t==================\n");
                Console.Write("Masukan Jari-Jari yang akan di hapus :  ");
                jaris = Console.ReadLine();
                cekint = int.TryParse(jaris, out jari);
                if (jari >= 0 && cekint == true)
                {
                    batas = true;
                    continue;

                }
                else
                {
                    Console.WriteLine("Jari-jari yang dimasukan tidak valid!\nTekan sembarang tombol untuk kembali memasukan umur");
                    Console.ReadKey();
                }

            } while (batas == false);
            ///hapus filenya
            /// lwad shape class
            /// 
            hapuskefile(jari, "circle");
            //copy dri cp ke asli
            copyfile("circle");

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
                menulihat("Circle");
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
                    // circle keliling
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
            Console.WriteLine("\t\t\t\t\t\t\t\tLihat Circle");
            Console.WriteLine("\t\t\t\t\t\t\t\t===================");
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\circle.txt";
            string[] scores = File.ReadAllLines(file);
            var orderedScores = scores.OrderBy(x => int.Parse(x.Split('\t')[0]));
            int counter = 0;
            Console.WriteLine("No.\t" + hit + "\t\tJari-jari");
            foreach (var score in orderedScores)
            {
                counter++;
                /// kode buat nampilin file dan jumlah gitu...
                double jari = Convert.ToDouble(score);
                double hasil = rumus(jari,hit);
                Console.WriteLine(counter+".\t"+hasil+"\t\t\t"+jari);
            }
            Console.WriteLine("\nTekan sembarang untuk kembali ke menu lihat circle");
            Console.ReadKey();
            lihat();
        }
        /////

    }
}
