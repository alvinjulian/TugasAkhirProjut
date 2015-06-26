using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasAkhirProjut
{
    public class Circle : Shape
    {
        public static void tambah()
        {
            int jari;
            string jaris;
            bool batas = false;
            bool cekint;
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
        /////

    }
}
