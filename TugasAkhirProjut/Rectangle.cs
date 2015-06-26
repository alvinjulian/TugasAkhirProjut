using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /////

    }
}
