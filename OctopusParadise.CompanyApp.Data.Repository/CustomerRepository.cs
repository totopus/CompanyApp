using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using OctopusParadise.CompanyApp.Data.Model;
using System.Data.SqlClient;

namespace OctopusParadise.CompanyApp.Data.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        DbContext db;
        public CustomerRepository()
        {
            db = new DbContext();
        }
        public int Delete(int id)
        {
            string cmd = @"delete from customer where id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return db.Execute(cmd, parameters);

        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> lstCollection = new List<Customer>();
            DataTable dt = db.Query(@"Select id,firstname,lastname,mobile,email,
                                    city,state from customer",null);
            if (dt != null)
            {
                foreach(DataRow dataRow in dt.Rows)
                {
                    Customer c = new Customer();
                    c.Id = Convert.ToInt32(dataRow["Id"]);
                    c.FirstName = Convert.ToString(dataRow["firstname"]);
                    c.LastName = Convert.ToString(dataRow["lastname"]);
                    c.Mobile = Convert.ToString(dataRow["mobile"]);
                    c.Email = Convert.ToString(dataRow["email"]);
                    c.City = Convert.ToString(dataRow["city"]);
                    c.State = Convert.ToString(dataRow["state"]);
                    lstCollection.Add(c);
                }
            }
            return lstCollection;
        }

        public Customer GetById(int id)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@id", id);
            DataTable dt = db.Query(@"Select Id,firstname, lastname, mobile, email,
                                    city, state from customer where id=@id", p);
            if (dt !=null && dt.Rows.Count>0)
            {
                Customer c = new Customer();
                DataRow dataRow = dt.Rows[0];
                c.Id = Convert.ToInt32(dataRow["Id"]);
                c.FirstName = Convert.ToString(dataRow["firstname"]);
                c.LastName = Convert.ToString(dataRow["lastname"]);
                c.Mobile = Convert.ToString(dataRow["mobile"]);
                c.Email = Convert.ToString(dataRow["email"]);
                c.City = Convert.ToString(dataRow["city"]);
                c.State = Convert.ToString(dataRow["state"]);
                return c;
            }
            return null;
        }

        public int Insert(Customer item)
        {
            string cmd = @"Insert into customer values(@firstname,@lastname,@mobile,@email,@city,@state)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@firstname", item.FirstName);
            parameters.Add("@lastname", item.LastName);
            parameters.Add("@mobile", item.Mobile);
            parameters.Add("@email", item.Email);
            parameters.Add("@city", item.City);
            parameters.Add("@state", item.State);
            return db.Execute(cmd, parameters);
        }

        public int Update(Customer item)
        {
            string cmd = @"update customer set firstname=@firstname,lastname=@lastname,mobile=@mobile,
                            email=@email,city=@city,state=@state where id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", item.Id);
            parameters.Add("@firstname", item.FirstName);
            parameters.Add("@lastname", item.LastName);
            parameters.Add("@mobile", item.Mobile);
            parameters.Add("@email", item.Email);
            parameters.Add("@city", item.City);
            parameters.Add("@state", item.State);
            return db.Execute(cmd, parameters);

        }
    }
}
