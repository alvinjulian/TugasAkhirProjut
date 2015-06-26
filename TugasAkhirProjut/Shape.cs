﻿using System;
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

        public static void hapusshape()
        {
            bool kondisi;
            int pilih = 0;
            string pilihan;
            do
            {
                printMenuhapus();
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
                    Circle.hapus();
                    break;
                case 2:
                    // square
                    Square.hapus();
                    break;
                case 3:
                    //rect
                    Rectangle.hapus();
                    break;
                case 4:
                    //main menu
                    Program.Main();
                    break;
                default:
                    break;
            }
        }
        static void printMenuhapus()
        {

            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tHapus Shape");
            Console.WriteLine("\t\t\t\t\t\t\t\t===================");
            Console.WriteLine("1. Hapus Circle\n");
            Console.WriteLine("2. Hapus Square\n");
            Console.WriteLine("3. Hapus Rectangle\n");
            Console.WriteLine("4. Main Menu\n");
        }

        protected static void hapuskefile(int size, string filein)
        {
            string sizes = size.ToString();
            int counter = 0;
            string line;
            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\"+filein+".txt";
            string filecp = dir + @"\" + filein + "cp.txt";
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);
                //mengecek apakah nama, kalau ada gak melakukan apa2 kalau ada nulis file dengan mengabaikan nama
                if (result[0] != sizes)
                {
                    if (!File.Exists(filecp))
                    {
                        // Create a file to write to. kalau belom ada filenya 
                        try
                        {
                            using (StreamWriter swnew = File.CreateText(filecp))
                            {
                                swnew.WriteLine(result[0]);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                    }
                    //kalau ud ada file yang mau ditulis
                    else
                    {


                        try
                        {
                            using (FileStream fs = new FileStream(filecp, FileMode.Append, FileAccess.Write))
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                sw.WriteLine(result[0]);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
                else
                {
                    counter++;
                }
            }
            sr.Close();
            string nilai;
            if (filein == "circle")
            {
                nilai = "jari-jari";
            }
            else
            {
                nilai = "sisi";
            }
            if (counter > 0)
            {
                Console.WriteLine("Penghapusan " + filein + " dengan {0} {1} Sejumlah {2} Berhasil!\n",nilai,sizes,counter);
            }
            else
            {
                Console.WriteLine(filein + " dengan {0} {1} Tidak ada!\n", nilai,sizes);
            }
        }

        protected static void hapuskefile(int panjang, int lebar)
        {
            string panjangS = panjang.ToString();
            string lebarS = lebar.ToString();
            int counter = 0;
            string line;
            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\rectangle.txt";
            string filecp = dir + @"\rectanglecp.txt";
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);
                //mengecek apakah nama, kalau ada gak melakukan apa2 kalau ada nulis file dengan mengabaikan nama
                if (result[0] != panjangS && result[1]!= lebarS)
                {
                    if (!File.Exists(filecp))
                    {
                        // Create a file to write to. kalau belom ada filenya 
                        try
                        {
                            using (StreamWriter swnew = File.CreateText(filecp))
                            {
                                swnew.WriteLine(result[0]+"\t"+result[1]);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                    }
                    //kalau ud ada file yang mau ditulis
                    else
                    {


                        try
                        {
                            using (FileStream fs = new FileStream(filecp, FileMode.Append, FileAccess.Write))
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                sw.WriteLine(result[0]+"\t"+result[1]);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
                else
                {
                    counter++;
                }
            }
            sr.Close();
            if (counter > 0)
            {
                Console.WriteLine("Penghapusan rectangle dengan panjang {0} dan lebar {1} Berhasil!\n", panjangS, lebarS);
            }
            else
            {
                Console.WriteLine("rectangle dengan panjang {0} dan lebar {1} Tidak ada!\n", panjangS,lebarS);
            }
        }
        protected static void copyfile(string filein) //untuk copy isi file dan delete
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\" + filein + "cp.txt";
            string target = dir + @"\" + filein + ".txt";
            //copy file di folder yg sama.. hati2 penamaanya yaa
            System.IO.File.Copy(file, target, true);

            //delete cp nya sekarang
            File.Delete(file);
            // Keep console window open in debug mode.
            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
        }
        /////

    }
}
