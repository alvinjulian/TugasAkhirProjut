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
        //public abstract void hitung(int sisi);
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

        public static void tampilshape()
        {
            bool kondisi;
            int pilih = 0;
            string pilihan;
            do
            {
                printMenutampil();
                Console.Write("Masukan pilihan anda : ");
                pilihan = Console.ReadLine();
                kondisi = int.TryParse(pilihan, out pilih);
                if (kondisi == true && pilih > 0 && pilih < 6)
                {
                    continue;
                }
                Console.WriteLine("\nPilihan yang anda masukan salah!");
                Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                Console.ReadLine();
            } while (pilih < 1 || pilih > 5);

            switch (pilih)
            {
                case 1:
                   /// smua data
                    lihat();
                    break;
                case 2:
                    // circle
                    Circle.lihat();
                    break;
                case 3:
                    // square
                    Square.lihat();
                    break;
                case 4:
                    //rect
                    Rectangle.lihat();
                    break;
                case 5:
                    //main menu
                    Program.Main();
                    break;
                default:
                    break;
            }
        }
        public static void lihat()
        {

            bool kondisi;
            int pilih = 0;
            string pilihan;
            do
            {
                menulihat("Semua Shape");
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
        static void printMenutampil()
        {

            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tTampil Shape");
            Console.WriteLine("\t\t\t\t\t\t\t\t===================");
            Console.WriteLine("1. Tampil Semua Shape\n");
            Console.WriteLine("2. Tampil Circle\n");
            Console.WriteLine("3. Tampil Square\n");
            Console.WriteLine("4. Tampil Rectangle\n");
            Console.WriteLine("5. Main Menu\n");
        }
        public static void menulihat(string shapes)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tLihat " + shapes);
            Console.WriteLine("\t\t\t\t\t\t\t\t===================");
            Console.WriteLine("1. Urutkan Bedasarkan Luas\n");
            Console.WriteLine("2. Urutkan Bedasarkan Keliling\n");
            Console.WriteLine("3. Menu Tampil Shape\n");
        }
        public static double rumus(double ja,string hit)
        {
            if (hit == "Luas")
                return ja * ja * 3.14;
            else
                return 2*ja * 3.14;
        }
        public static int rumus(int ja, string hit)
        {
            if (hit == "Luas")
                return ja * ja;
            else
                return 4 * ja;
        }

        public static int rumus(int panjang,int lebar, string hit)
        {
            if (hit == "Luas")
                return panjang *lebar;
            else
                return ((2*panjang)+(2*lebar));
        }

        public static void sorting(string hit)
        {

            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\rectangle.txt";
            string filecp = dir + @"\lihat.txt";
            bacafile(file, filecp, hit);
            file = dir + @"\circle.txt";

            bacafile1(file, filecp, hit,"cir");
            file = dir + @"\square.txt";

            bacafile1(file, filecp, hit,"squa");
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tLihat Semua Shape");
            Console.WriteLine("\t\t\t\t\t\t\t\t===================");
            file = dir + @"\lihat.txt";
            string[] scores = File.ReadAllLines(file);
            var orderedScores = scores.OrderBy(x => int.Parse(x.Split('\t')[1]));
            int counter = 0;
           // if (hit == "Luas")
                //Console.WriteLine("No.\t" + hit + "\t\tPanjang\tLebar");
            //else
               // Console.WriteLine("No.\t" + hit + "\tPanjang\tLebar");

            foreach (var score in orderedScores)
            {
                counter++;
                Console.WriteLine(score);
            }
            File.Delete(file);
            Console.WriteLine("\nTekan sembarang untuk kembali ke menu lihat semua shape");
            Console.ReadKey();
            lihat();
        }
        public static void bacafile1(string file, string filecp, string hit,string shape)
        {

            string line;
            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                double hasil = 0;
                string[] result = rgx.Split(line);
                if (shape == "squa")
                    hasil = rumus(Convert.ToInt16(result[0]), hit);
                else
                    hasil = rumus(Convert.ToDouble(result[0]), hit);
                //untuk rect 
                if (!File.Exists(filecp))
                {

                    // Create a file to write to. kalau belom ada filenya 
                    using (StreamWriter swnew = File.CreateText(filecp))
                    {
                        swnew.WriteLine(hasil + "\t" + result[0]);
                    }
                }
                //kalau ud ada file yang mau ditulis
                else
                {
                    using (FileStream fs = new FileStream(filecp, FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(hasil + "\t" + result[0] );
                    }
                }
            }
            sr.Close();
        }
        public static void bacafile(string file, string filecp,string hit)
        {
            string line;
            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);
            //ini pake try catch
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                
                string[] result = rgx.Split(line);
                int hasil = rumus(Convert.ToInt16(result[0]), Convert.ToInt16(result[1]), hit);
                //untuk rect 
                if (!File.Exists(filecp))
                {

                    // Create a file to write to. kalau belom ada filenya 
                    using (StreamWriter swnew = File.CreateText(filecp))
                    {
                        swnew.WriteLine(hasil + "\t" + result[0] + "\t" + result[1] );
                    }
                }
                //kalau ud ada file yang mau ditulis
                else 
                {
                    using (FileStream fs = new FileStream(filecp, FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(hasil + "\t" + result[0] + "\t" + result[1] );
                    }
                }
            }
            sr.Close();
        }
        /////

    }
}
