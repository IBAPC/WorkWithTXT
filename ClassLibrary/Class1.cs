using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary
{
    public class Class1
    {
        public string OpenFile(string filename)
        {
            string s = "";
            try
            {
                StreamReader sr = new StreamReader(filename,
                Encoding.GetEncoding(1251));
                // создание нового входного потока, установка кодировки
                s = sr.ReadToEnd();
                sr.Close(); // закрытие входного потока
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error: " + exc.Message);
            }
            return s;
        }

        public string SaveFile(string filename, string text)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    File.WriteAllText(filename, text);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error: " + exc.Message);
            }
            return text;
        }
    }
}
