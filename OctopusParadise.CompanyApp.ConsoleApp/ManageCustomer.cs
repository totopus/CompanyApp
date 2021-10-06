using System;
using System.Collections.Generic;
using System.Text;
using OctopusParadise.CompanyApp.Data.Repository;
using OctopusParadise.CompanyApp.Data.Model;

namespace OctopusParadise.CompanyApp.ConsoleApp
{
    class ManageCustomer
    {
        IRepository<Customer> customerRepository;
        public ManageCustomer()
        {
            customerRepository = new CustomerRepository();
        }
        void AddCustomer()
        {
            Customer c = new Customer();
            Console.Write("Enter First Name: ");
            c.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            c.LastName = Console.ReadLine();
            Console.Write("Enter Mobile: ");
            c.Mobile = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            c.Email = Console.ReadLine();
            Console.Write("Enter City: ");
            c.City = Console.ReadLine();
            Console.Write("Enter State: ");
            c.State = Console.ReadLine();
            if (customerRepository.Insert(c)>0)
                Console.WriteLine("Customer Added Successfully");
            else
                Console.WriteLine("Some Error has Occured");
        }

        
        void PrintCustomers()
        {
            var collection = customerRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id} \t {item.FirstName} \t {item.LastName} \t {item.Mobile} \t {item.Email} \t {item.City} \t {item.State}");
            }
        }

        void PrintCustomerById()
        {
            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Customer item = customerRepository.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"{item.Id} \t {item.FirstName} \t {item.LastName} \t {item.Mobile} \t {item.Email} \t {item.City} \t {item.State}");
            }
            else
            {
                Console.WriteLine("No Record Found");
            }
        }
        public void Run()
        {
            AddCustomer();
        }
    }
}
