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
    public class Rectangle : Shape
    {
        public static void tambah()
        {
            int panjang;
            int lebar;
            string ukurans;
            bool batas = false;
            bool cekint;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tTambah Rectangle");
                Console.WriteLine("\t\t\t\t\t\t\t==================\n");
                Console.Write("Masukan Panjang: ");
                ukurans = Console.ReadLine();
                cekint = int.TryParse(ukurans, out panjang);
                if (panjang >= 0 && cekint == true)
                {
                    batas = true;
                    continue;

                }
                else
                {
                    Console.WriteLine("Panjang yang dimasukan tidak valid!\nTekan sembarang tombol untuk kembali memasukan umur");
                    Console.ReadKey();
                }

            } while (batas == false);
            batas = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tTambah Rectangle");
                Console.WriteLine("\t\t\t\t\t\t\t==================\n");
                Console.Write("Masukan Panjang: {0} ",panjang);
                Console.Write("\nMasukan Lebar: ");
                ukurans = Console.ReadLine();
                cekint = int.TryParse(ukurans, out lebar);
                if (lebar <= panjang && cekint == true)
                {
                    batas = true;
                    continue;

                }
                else
                {
                    Console.WriteLine("Lebar yang dimasukan tidak valid! ( Harus lebih kecil dari Panjang )\nTekan sembarang tombol untuk kembali memasukan umur");
                    Console.ReadKey();
                }

            } while (batas == false);
            ///masukan ke file...
            // lwad class shape?
            ///
            tambahkefile(panjang,lebar);
            /////
            Console.WriteLine("\n\nData berhasil disimpan! Tekan sembarang tombol untuk kembali....");
            Console.ReadKey();
            tambahshape();

        }

        public static void hapus()
        {
            int panjang;
            int lebar;
            string ukurans;
            bool batas = false;
            bool cekint;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tHapus Rectangle");
                Console.WriteLine("\t\t\t\t\t\t\t==================\n");
                Console.Write("Masukan Panjang yang ingin dihapus: ");
                ukurans = Console.ReadLine();
                cekint = int.TryParse(ukurans, out panjang);
                if (panjang >= 0 && cekint == true)
                {
                    batas = true;
                    continue;

                }
                else
                {
                    Console.WriteLine("Panjang yang dimasukan tidak valid!\nTekan sembarang tombol untuk kembali memasukan umur");
                    Console.ReadKey();
                }

            } while (batas == false);
            batas = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tHapus Rectangle");
                Console.WriteLine("\t\t\t\t\t\t\t==================\n");
                Console.Write("Masukan Panjang yang ingin dihapus: {0} ", panjang);
                Console.Write("\nMasukan Lebaryang ingin dihapus : ");
                ukurans = Console.ReadLine();
                cekint = int.TryParse(ukurans, out lebar);
                if (lebar <= panjang && cekint == true)
                {
                    batas = true;
                    continue;

                }
                else
                {
                    Console.WriteLine("Lebar yang dimasukan tidak valid! ( Harus lebih kecil dari Panjang )\nTekan sembarang tombol untuk kembali memasukan umur");
                    Console.ReadKey();
                }

            } while (batas == false);
            ///hapus filenya
            /// lwad shape class
            /// 
            hapuskefile(panjang,lebar);
            ////copy dri cp ke asli
            copyfile("rectangle");

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
                menulihat("Rectangle");
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
            Console.WriteLine("\t\t\t\t\t\t\t\tLihat Rectangle");
            Console.WriteLine("\t\t\t\t\t\t\t\t===================");
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\rectangle.txt";
            string[] scores = File.ReadAllLines(file);
            var orderedScores = scores.OrderBy(x => int.Parse(x.Split('\t')[0]));
            int counter = 0;
            //Console.WriteLine("No.\t" + hit + "\t\tPanjang\tLebar");
            foreach (var score in orderedScores)
            {
                counter++;
                int panjang = Convert.ToInt16(score[0]);
                Console.WriteLine(score[0]);
                Console.WriteLine(panjang);
                ///// kode buat nampilin file dan jumlah gitu...
                //int panjang = Convert.ToInt16(score[0]);
                //int lebar = Convert.ToInt16(score[1]);
                //int hasil = rumus(panjang,lebar, hit);
                //Console.WriteLine(counter + ".\t" + hasil + "\t\t\t" + panjang+"\t\t"+lebar);
            }
            Console.WriteLine("\nTekan sembarang untuk kembali ke menu lihat rectangle");
            Console.ReadKey();
            lihat();
        }
        /////
        /////

    }
}
