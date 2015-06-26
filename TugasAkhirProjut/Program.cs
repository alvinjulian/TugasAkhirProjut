using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;

namespace TugasAkhirProjut
{
    class Program
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
        public static void Main()
        {
            ///rubah warna sama ukuran window
            ///

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            
            bool kondisi;
            int pilih = 0;
            string pilihan;
            do
            {
                printMenu();
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
                    // tampilin shape
                    break;
                case 2:
                    // tambah shape
                    Shape.tambahshape();
                    break;
                case 3:
                    //delete shape
                    Shape.hapusshape();
                    break;
                case 4:
                    //exit
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            
        }

        static void printMenu()
        {
            
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tMenu Utama");
            Console.WriteLine("\t\t\t\t\t\t\t\t===================");
            Console.WriteLine("1. Tampilkan Shape\n");
            Console.WriteLine("2. Tambah Shape\n");
            Console.WriteLine("3. Delete Shape\n");
            Console.WriteLine("4. Exit Program\n");
        }
        
    
    }
    
}

