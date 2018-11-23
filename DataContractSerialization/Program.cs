using System;
using System.IO;
using System.Runtime.Serialization;

namespace DataContractSerialization
{
    [DataContract(Name = "emp", Namespace = "http://pragmatic.bg/example")]
    public class Employee
    {
        [DataMember(Name = "n")]
        public string Name { get; set; }

        [DataMember(Name = "addr")]
        public Address Address { get; set; }
    }

    [DataContract(Name = "addr")]
    public class Address
    {
        [DataMember(Name = "c")]
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

            DataContractSerializer serializer = new DataContractSerializer(typeof(Employee));

            // serializing 
            using (var stream = File.Create("serialized.xml"))
            {
                serializer.WriteObject(stream, emp);
            }

            // deserializing 
            using (var stream = File.OpenRead("serialized.xml"))
            {
                var deserializedEmployee = (Employee)serializer.ReadObject(stream);

                Console.WriteLine($"Name = { deserializedEmployee.Name }, " +
                                  $"Address.City = { deserializedEmployee.Address.City }");

            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
