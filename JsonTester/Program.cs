using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;

namespace JsonTester
{
    class Program
    {


        static void Main(string[] args)
        {
            ReadTheFile();

        }

      static  void ReadTheFile()
        {
            DateTime TestStart;
            DateTime TestLoaded;
            DateTime TestPrinted;


            string filepath = @"C:\Users\Huy-Plejd\Desktop\Projects\JsonTester\test.txt";

            TestStart = DateTime.Now;

            List<User> userList = new List<User>();

             var jsonString = File.ReadAllText(filepath);

             userList = JsonConvert.DeserializeObject<List<User>>(jsonString);

            TestLoaded = DateTime.Now;
            foreach (var item in userList)
            {
                Console.WriteLine(item.ID + item.Name + item.Address);
            }
            TestPrinted = DateTime.Now;

            Console.WriteLine("Test started at: " +TestStart);
            Console.WriteLine("Test finished loading at: " + TestLoaded);
            Console.WriteLine("Test print finished at: " + TestPrinted);
            Console.WriteLine("Items in the list: " + userList.Count);
        }
        static void CreateAndWriteToFile()
        {
            string filepath = @"C:\Users\Huy-Plejd\Desktop\Projects\JsonTester\test.txt";

            Console.WriteLine(DateTime.Now);
            List<User> userList = new List<User>() {

            new User(){
            ID = 1,
            Name = "Huy",
            Address = "Gbg"},

            new User(){
            ID = 2,
            Name = "Andreas",
            Address = "Molndahl"},

            new User(){
            ID = 3,
            Name = "Andre",
            Address = "Torslada"},
            new User(){
            ID = 4,
            Name = "Mattis",
            Address = "Skogen"},
             };

            for (int i = 5; i < 1000000; i++)
            {
                userList.Add(new User() { ID = i, Name = RandomString(5), Address = RandomString(10) });
            }
            Console.WriteLine("Done");
            Console.WriteLine(DateTime.Now);



            string json = System.Text.Json.JsonSerializer.Serialize(userList);
            File.WriteAllText(filepath, json);
        }
  
        public class User
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
