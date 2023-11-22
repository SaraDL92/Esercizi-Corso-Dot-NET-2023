using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    internal class File
    {

        public File()
        {

        }


        public void WriteOnFile<T>(string percorso, List<T> Data)
        {
            using (StreamWriter sw = new StreamWriter(percorso))
            {
                foreach (var item in Data)
                {
                    sw.WriteLine(item.ToString());



                }
            }
        }


    }
}