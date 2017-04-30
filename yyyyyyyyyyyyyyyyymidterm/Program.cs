using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yyyyyyyyyyyyyyyyymidterm
{
    class Program
    {
        static void Main(string[] args)
        {

            PrintList(GetList());

            List<Books> Catalogue = GetList();

            Return(Catalogue);

            Checkout(Catalogue);

            ////add more books and test

            //Catalogue.Add(new Books("my so called life", "timmy", "available", "NA"));
            //Catalogue.Add(new Books("crap my pants", "timmy", "available", "NA"));
            //Catalogue.Add(new Books("pooped onmy shoe", "timmy", "available", "NA"));




            //Console.Write("Search for a Book by author: ");
            //string Search = Console.ReadLine().ToLower();

            ////adds books to dictionary list

            //Dictionary<string, Books> mydictionary = new Dictionary<string, Books>();

            //foreach (var item in Catalogue)
            //{
            //    mydictionary.Add(item.BTitle.ToLower(), item);
            //}


            //if (mydictionary.Contains(Search, )
            //{

            //}


            //Console.WriteLine(mydictionary[Search.ToLower()].BAuthor);


            //foreach (var item in Catalogue)
            //    {

            //    string Authorlower = item.BAuthor.ToLower();

            //    if (Authorlower == Search)
            //        {
            //        Console.WriteLine("Yes we have: ");
            //            Console.WriteLine("Title:\t" + item.BTitle);
            //            Console.WriteLine("Author:\t" + item.BAuthor);
            //            Console.WriteLine("Status:\t" + item.BStatus);
            //            Console.WriteLine("DueDate:\t" + item.BDueDate);
            //            Console.WriteLine("\n=====================================\n");
            //        }

            //    }







        }

        public static void Return(List<Books> inputCatalogue)
        {
            Console.Write("Return: ");
            string ItemToReturn = Console.ReadLine().ToLower();
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.Now;
            int count = 0;
            foreach (var item in inputCatalogue)
            {
                string Titlelower = item.BTitle.ToLower();
                if (Titlelower == ItemToReturn && !(item.BStatus == "Avaiable"))
                {
                    item.BStatus = "Available";
                    item.BDueDate = "N/A";
                    Console.WriteLine($"thank you for returning {item.BTitle}.");
                    //if (Convert.ToDouble(item.BDueDate) > Convert.ToDouble(myDateTime))
                    //{
                    //    Console.WriteLine("your item is late you owe us money");
                    //}
                }
                else
                {
                    count++;
                }

            }
            if (count == inputCatalogue.Count)
            {
                Console.WriteLine("that book is already returned or not in our system");
            }

            WriteToText(inputCatalogue);


        }


        
        public static void Checkout(List<Books> inputCatalogue)
        {
            Console.Write("Check out: ");
            string ItemToCheckOut = Console.ReadLine().ToLower();
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.Now;
            int count = 0;
            foreach (var item in inputCatalogue)
            {
                string Titlelower = item.BTitle.ToLower();
                if (Titlelower == ItemToCheckOut && !(item.BStatus == "Checked-out"))
                {
                    item.BStatus = "Checked-out";
                    item.BDueDate = myDateTime.AddDays(14).ToShortDateString();
                    Console.WriteLine($"{item.BTitle} is checked out.");
                    Console.WriteLine($"and is due on {item.BDueDate}");
                }
                else
                {
                    count++;
                }

            }
            if (count == inputCatalogue.Count)
            {
                Console.WriteLine("not available");
            }

            WriteToText(inputCatalogue);
            
        }

        public static List<Books> GetList()
        {

            //new list called catalogue
            List<Books> Catalogue = new List<Books>();
            StreamReader reader = new StreamReader("../../OurDataBase.txt ");
            //this is one line from text file or one book
            char[] comma = { ',' };
            for (int i = 0; i < 14; i++)

            {
                string line = reader.ReadLine();
                //string[] book = new string[4];
                string[] book = line.Split(comma);
                string Title = book[0];
                string Author = book[1];
                string Status = book[2];
                string DueDate = book[3];
                Catalogue.Add(new Books(Title, Author, Status, DueDate));
            }
            reader.Close();
            return Catalogue;
        }

        public static void PrintList(List<Books> InputList)
        {
            foreach (var item in InputList)
            {
                Console.WriteLine("Title:\t" + item.BTitle);
                Console.WriteLine("Author:\t" + item.BAuthor);
                Console.WriteLine("Status:\t" + item.BStatus);
                Console.WriteLine("DueDate:\t" + item.BDueDate);
                Console.WriteLine("\n=====================================\n");
            }
        }


        public static void WriteToText(List<Books> inputList)
        {
            StreamWriter sw = new StreamWriter("../../OurDataBase.txt", false);

            foreach (var item in inputList)
            {
                sw.WriteLine(item.BTitle + "," + item.BAuthor + "," + item.BStatus + ","
                    + item.BDueDate);

            }
            sw.Close();
        }
    




    }
}
