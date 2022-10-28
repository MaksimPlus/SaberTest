using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaberTest
{
    public class ListNode
    {
        public ListNode Previous;
        public ListNode Next;
        public ListNode Random; // произвольный элемент внутри списка
        public string Data;

    }
     public class ListRandom
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public void Serialize(Stream s)
        {
            List<ListNode> list = new List<ListNode>();
            ListNode para=new ListNode();
            para=Head;
            ///Преобразовываем узлы в список
            while(para!=null)
            {
                list.Add(para);
                para=para.Next;
            }
            ///Записываем данные в файл
            using (StreamWriter sw = new StreamWriter(s))
                foreach (ListNode l in list)
                    sw.WriteLine(l.Data.ToString() + ":" + list.IndexOf(l.Random).ToString());
            Console.WriteLine("Данные успешно записаны");
        }

        public void Deserialize(Stream s)
        {
            List<ListNode> list =new List<ListNode>();
            ListNode para = new ListNode();
            Count = 0;
            Head = para;
            string data;

            try
            {
                using(StreamReader sr=new StreamReader(s))
                {
                    while((data = sr.ReadLine())!=null)
                    {
                        if (!data.Equals(""))
                        {
                            Count++;
                            para.Data=data;
                            ListNode next = new ListNode();
                            para.Next = next;
                            list.Add(para);
                            next.Previous = para;
                            para=next;
                            Tail = para.Previous;
                            Tail.Next = new ListNode();
                        }
                    }
                }

                foreach(ListNode l in list)
                {
                    l.Random = list[Convert.ToInt32(l.Data.Split(':')[1])];
                    l.Data = l.Data.Split(':')[0];
                }
            }

            catch(Exception e)
            {
                Console.WriteLine("Не удалось обработать файл, проверьте целостность файла");
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }

        }
        
    }




    public class MyList:ListRandom
    {
        /// <summary>
        /// Добавляем элементы в список
        /// </summary>
        /// <param name="node"></param>
        public void Add(string data)
        {
            ListNode node = new ListNode();
            node.Data = data;
            if (Head is null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Count++;
        }
    }
}
