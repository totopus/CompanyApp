using System;

namespace OctopusParadise.CompanyApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageCustomer manageCustomer = new ManageCustomer();
            manageCustomer.Run();
        }
    }
}
