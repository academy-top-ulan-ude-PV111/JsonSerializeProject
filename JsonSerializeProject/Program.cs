using System.Net;
using System.Text.Json;

namespace JsonSerializeProject
{
    [Serializable]
    public class Employe
    {
        public string? Name { set; get; }
        public int Age { set; get; }
        public Company? Company { set; get; }

    }

    public class Company
    {
        public string? Title { set; get; }
        public Address? Address { set; get; }
    }
    public class Address
    {
        public string? City { set; get; }
        public string? Street { set; get; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };


            //Serialize
            //Employe employe = new Employe() { Name = "Bob", Age = 34 };

            //using (FileStream file = new("employes.json", FileMode.OpenOrCreate))
            //{
            //    string strJson = JsonSerializer.Serialize<Employe>(employe, options);
            //    Console.WriteLine($"{strJson}");

            //    JsonSerializer.Serialize(file, employe, options);
            //}

            //Deserialize

            //using (FileStream file = new("employes.json", FileMode.Open))
            //{
            //    Employe? employe = JsonSerializer.Deserialize<Employe>(file);
            //    Console.WriteLine($"Employe: name -> {employe?.Name}, age -> {employe?.Age}");
            //}

            // Collection Serialize
            //List<Company> companies = new()
            //{
            //    new(){ Title = "Yandex", Address = new(){ City = "Moscow", Street = "Tverskaya st." } },
            //    new(){ Title = "BaltFlot", Address = new(){ City = "St-Peterbug", Street = "Dostoevsky st." } },

            //    //new(){ Title = "Yandex" },
            //    //new(){ Title = "BaltFlot" }
            //};

            //List<Employe> employes = new()
            //{
            //    new(){ Name = "Joe", Age = 43, Company = companies[0] },
            //    new(){ Name = "Mike", Age = 22, Company = companies[1] },
            //    new(){ Name = "Whiliam", Age = 37, Company = companies[0] }
            //};


            //using (FileStream file = new FileStream("employes.json", FileMode.OpenOrCreate))
            //{
            //    JsonSerializer.Serialize(file, employes, options);
            //}


            // Collection Deserialize
            using (FileStream file = new("employes.json", FileMode.Open))
            {
                var employes = JsonSerializer.Deserialize<List<Employe>>(file);
                
                foreach(var item in employes!)
                {
                    Console.WriteLine($"Employe: name -> {item?.Name}, " +
                                      $" age -> {item?.Age} company -> {item?.Company?.Title}");
                    Console.WriteLine($"\tcompany city -> {item?.Company?.Address?.City}" +
                                      $" street -> {item?.Company?.Address?.Street}");
                }
                    
            }


        }
    }
}