using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Repository;
using Antra.CompanyApp.Data.Model;
namespace Antra.CompanyApp.ConsoleApp
{
    class ManageDept
    {
        IRepository<Dept> deptRepository;
        public ManageDept()
        {
            deptRepository = new DeptRepository();
        }

        void AddDepartment()
        {
            Dept d = new Dept();
            Console.Write("Enter Name = ");
            d.DName = Console.ReadLine();
            Console.Write("Enter Location = ");
            d.Loc = Console.ReadLine();
            if(deptRepository.Insert(d) > 0)
                Console.WriteLine("Department Added successfully");
            else
                Console.WriteLine("Some error has occured");
        }
        public void Run()
        {
            AddDepartment();
        }
    }
}
