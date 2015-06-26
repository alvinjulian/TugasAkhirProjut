using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /////

    }
}
