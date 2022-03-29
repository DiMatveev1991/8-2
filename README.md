# 8-2
# Выполнил без рекурсии, сначало выполнил задание потом посмотрел подсказки
##Слабая сторона такого подхода заключается в том, что если какой-либо из подкаталогов в указанном корне вызовет DirectoryNotFoundException или UnauthorizedAccessException, то весь метод не будет выполнен и каталоги не будут возвращены. Это же относится и к использованию метода GetFiles. Если необходимо обработать эти исключения в определенных вложенных папках, необходимо вручную пройти по дереву каталога, как показано в приведенных ниже примерах.
##с рекрекурсией как пример так будет работать и все исключения должный прилететь:
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn
{

    public class RecursiveFileSearch
    {
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

        static void Main()
        {
            Console.WriteLine("ВВЕДИТЕ ПУТЬ ДИРРЕКТОРИИ:");
            string URL = Console.ReadLine();

            try
            {
                long d=0;
                System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(URL);
                long C =  WalkDirectoryTree(root, ref d);
                Console.WriteLine("ДАННАЯ ПАПКА ЗАНИМАЕТ: " + C + " БАЙТ");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }



        }


        static long WalkDirectoryTree(System.IO.DirectoryInfo root, ref long d)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            try { files = root.GetFiles("."); }
            catch (UnauthorizedAccessException e) { log.Add(e.Message); }

            catch (System.IO.DirectoryNotFoundException e) { Console.WriteLine(e.Message); }

            if (files != null)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    d = d +files[i].Length;
                }
            }
            subDirs = root.GetDirectories();
          
            for (int j = 0; j < subDirs.Length; j++)
            {
                WalkDirectoryTree(subDirs[j],ref d);
            }
            return d;
           
        }
    }
}
