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
    public class Shape
    {

        public static void tambahshape()
        {
            bool kondisi;
            int pilih = 0;
            string pilihan;
            do
            {
                printMenutambah();
                Console.Write("Masukan pilihan anda : ");
                pilihan = Console.ReadLine();
                kondisi = int.TryParse(pilihan, out pilih);
                if (kondisi == true && pilih > 0 && pilih < 5)
                {
                    continue;
                }
                Console.WriteLine("\nPilihan yang anda masukan salah!");
                Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                Console.ReadLine();
            } while (pilih < 1 || pilih > 4);

            switch (pilih)
            {
                case 1:
                    // circle
                    Circle.tambah();
                    break;
                case 2:
                    // square
                    Square.tambah();
                    break;
                case 3:
                    //rect
                    Rectangle.tambah();
                    break;
                case 4:
                    //main menu
                    Program.Main();
                    break;
                default:
                    break;
            }
        }
        static void printMenutambah()
        {

            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tTambah Shape");
            Console.WriteLine("\t\t\t\t\t\t\t\t===================");
            Console.WriteLine("1. Tambah Circle\n");
            Console.WriteLine("2. Tambah Square\n");
            Console.WriteLine("3. Tambah Rectangle\n");
            Console.WriteLine("4. Main Menu\n");
        }

        protected static void tambahkefile(int size,string filein)
        {
            string sizeS = size.ToString();
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\"+filein+".txt";
            //StreamReader sr = new StreamReader(file);
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(size);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected static void tambahkefile(int panjang,int lebar)
        {
            string panjangS = panjang.ToString();
            string lebarS = lebar.ToString();
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\rectangle.txt";
            //StreamReader sr = new StreamReader(file);
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(panjang+"\t"+lebar);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /////

    }
}
