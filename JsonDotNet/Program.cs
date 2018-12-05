using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDotNet
{
    public class Employee
    {
        public string Name { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var emp = new Employee
            {
                Name = "Joro",
                Address = new Address
                {
                    City = "Varna"
                }
            };

            //using (var wr = File.CreateText("serialized.json"))
            //{
            //    wr.WriteLine(JsonConvert.SerializeObject(emp));
            //}

            File.WriteAllText("serialized.json", JsonConvert.SerializeObject(emp));

            var deserializedEmployee = 
                JsonConvert.DeserializeObject<Employee>(
                    File.ReadAllText("serialized.json"));

            Console.WriteLine($"Name = { deserializedEmployee.Name }, " +
                $"Address.City = { deserializedEmployee.Address.City }" );

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
