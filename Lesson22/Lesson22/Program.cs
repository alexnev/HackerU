using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Lesson22
{
    class Program
    {
        static void Main(string[] args)
        {
            #region FileInfo
            // @ before string dictates that there are no special characters between ""
            FileInfo fileInfo = new FileInfo(@"C:\Users\Aviad\Desktop\MyFile.txt");
            Console.WriteLine(fileInfo.Name);
            Console.WriteLine(fileInfo.CreationTime);
            if (!fileInfo.Exists)
                fileInfo.Create();
            #endregion

            #region FileStream
            //FileStream can access and change any file it has access to            
            //When creating stream remember to close it or use the 'using' command
            FileStream fs = fileInfo.OpenWrite();
            FileStream fs2 = new FileStream(@"C:\Users\Aviad\Desktop\MyFile.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            string s = "Hi, How are you??";
            byte[] bytesofS = new UTF8Encoding(true).GetBytes(s);
            char[] chars = s.ToCharArray();
            byte[] bytes = new byte[chars.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                bytes[i] = (byte)chars[i];
            }
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
            Console.WriteLine();
            #endregion

            #region DirectoryInfo
            // you can write the path to the dir without the '\' in the end.
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\Aviad\Desktop\");
            FileInfo[] filesInDesktop = directoryInfo.GetFiles();
            foreach (FileInfo fi in filesInDesktop)
            {
                Console.WriteLine(fi.Name);
            }
            Console.WriteLine();
            DirectoryInfo[] dirsInDesktop = directoryInfo.GetDirectories();
            foreach (DirectoryInfo dir in dirsInDesktop)
            {
                Console.WriteLine(dir.Name);
            }
            #endregion

            #region serialization
            int x = 574652;
            byte[] bytesOfX = new byte[4];
            bytesOfX[3] = (byte)x;
            bytesOfX[2] = (byte)(x >> 8);
            bytesOfX[1] = (byte)(x >> 16);
            bytesOfX[0] = (byte)(x >> 24);

            int y = 0;
            y = y | bytesOfX[0];
            y = y << 8;
            y = y | bytesOfX[1];
            y = y << 8;
            y = y | bytesOfX[2];
            y = y << 8;
            y = y | bytesOfX[3];
            Console.WriteLine(y);

            //0000000000000000000
            //0000000000000000110
            //---------
            //0000000000000000110

            String s2 =
                new UTF8Encoding().GetString(new byte[] { 65, 66, 67 });
            Console.WriteLine(s2);
            #endregion

            #region Disposable
            using (Door d = new Door())
            {

            }
            #endregion
        }

        class Door : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Dispose()");
                Close();
            }

            public void Close()
            {
                //cleaning goes here.
            }
        }
    }
}
