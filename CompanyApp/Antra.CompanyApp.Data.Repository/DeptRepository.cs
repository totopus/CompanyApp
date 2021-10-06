using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Model;

namespace Antra.CompanyApp.Data.Repository
{
    public class DeptRepository : IRepository<Dept>
    {
        DbContext db;
        public DeptRepository()
        {
            db = new DbContext();
        }
        public int Delete(int id)
        {
            string cmd = "delete from Dept where id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return db.Execute(cmd, parameters);

        }

        public IEnumerable<Dept> GetAll()
        {
            throw new NotImplementedException();
        }

        public Dept GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Dept item)
        {
            string cmd = "Insert into Dept values (@dname,@loc)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@dname", item.DName);
            parameters.Add("@loc", item.Loc);
           
            return db.Execute(cmd, parameters);
        }

        public int Update(Dept item)
        {
            string cmd = "update Dept set dname =@dname, loc=@loc where id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@dname", item.DName);
            parameters.Add("@loc", item.Loc);
            parameters.Add("@id", item.Id);
            return db.Execute(cmd, parameters);
        }
    }
}
