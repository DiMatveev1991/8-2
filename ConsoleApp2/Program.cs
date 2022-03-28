using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("ВВЕДИТЕ ПУТЬ ДИРРЕКТОРИИ:");
            string URL =Console.ReadLine();
            try
            {
                long C = nextclass.SearchFile(URL);
                Console.WriteLine("ДАННАЯ ПАПКА ЗАНИМАЕТ: " + C + " БАЙТ");
            }
            catch (Exception ex)    
            { Console.WriteLine(ex.Message); }  
        }
    }
   class nextclass
    {
     internal static long SearchFile(string patch)
        {
           try
            {
                Directory.Exists(patch);
            }
            catch (Exception e)
            {
                Console.WriteLine("Возникла ошибка:"+ e.Message);
            }
           string[] ReultSearch = Directory.GetFiles(patch, "*.*", SearchOption.AllDirectories);
            
            long C = 0; 
            for (int i=0;i<ReultSearch.Length; i++)
            {
               FileInfo d = new FileInfo(ReultSearch[i]);  
               C=C+d.Length;    
            }
            return C;   
        }
    }
}

