using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaberTest
{

    internal class Program
    {
        static void Main(string[] args)
        {

        MyList first = new MyList();
        first.Add("Tom");
        first.Add("Max");
        first.Add("Ivan");
        first.Add("12345!");
        FileStream fs = new FileStream("Array.txt", FileMode.Create);
        first.Serialize(fs);
        

        ListRandom second = new ListRandom();
        fs = new FileStream("Array.txt", FileMode.Open); 
        second.Deserialize(fs);
        Console.Read();

            
        }
    }
}
