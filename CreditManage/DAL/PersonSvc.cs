using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class PersonSvc
    {
        public static void Create(Person person)
        {
            string sql = @"insert into T_Person (Phone,Password,Value,IsMale,Age,Address,
                            IsAdmin,IdCard,Name,Discription) values (@Phone,@Psd,@Value,@IsMale,
                            @Age,@Address,@IsAdmin,@IdCard,@Name,@Other)";
            SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("@Phone", person.Phone),
                new SqlParameter("@Psd", person.Psd),
                new SqlParameter("@Value", person.Value),
                new SqlParameter("@IsMale", person.IsMale),
                new SqlParameter("@Age", person.Age),
                new SqlParameter("@Address", person.Address),
                new SqlParameter("@IsAdmin", person.IsAdmin),
                new SqlParameter("@IdCard", person.IdCard),
                new SqlParameter("@Name", person.Name),
                new SqlParameter("@Other", person.Other)
                );
        }
        public static List <Person> RetrieveAll()
        {
            string sql = "select * from T_Person";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            List<Person> list = new List<Person>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Person person = new Person();
                person.Id = (int)dr["PersonId"];
                person.Phone = (string)dr["Phone"];
                person.Psd = (string)dr["Password"];
                person.Value = (int)dr["Value"];
                person.IsMale = (bool)dr["IsMale"];
                person.Age = (int)dr["Age"];
                person.Address = (string)dr["Address"];
                person.IsAdmin = (bool)dr["IsAdmin"];
                person.IdCard = (string)dr["IdCard"];
                person.Name = (string)dr["Name"];
                person.Other = (string)dr["Discription"];
                list.Add(person);
            }
            return list;
        }
        public static List <Person> RetrieveById(int id)
        {
            string sql = "select * from T_Person where PersonId=@Id";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@Id", id));
            List<Person> list = new List<Person>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Person person = new Person();
                person.Id = (int)dr["PersonId"];
                person.Phone = (string)dr["Phone"];
                person.Psd = (string)dr["Password"];
                person.Value = (int)dr["Value"];
                person.IsMale = (bool)dr["IsMale"];
                person.Age = (int)dr["Age"];
                person.Address = (string)dr["Address"];
                person.IsAdmin = (bool)dr["IsAdmin"];
                person.IdCard = (string)dr["IdCard"];
                person.Name = (string)dr["Name"];
                person.Other = (string)dr["Discription"];
                list.Add(person);
            }
            return list;
        }
        public static List <Person> RetrieveByPhone(string phone)
        {
            string sql = "select * from T_Person where Phone=@Phone";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@Phone", phone));
            List<Person> list = new List<Person>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Person person = new Person();
                person.Id = (int)dr["PersonId"];
                person.Phone = (string)dr["Phone"];
                person.Psd = (string)dr["Password"];
                person.Value = (int)dr["Value"];
                person.IsMale = (bool)dr["IsMale"];
                person.Age = (int)dr["Age"];
                person.Address = (string)dr["Address"];
                person.IsAdmin = (bool)dr["IsAdmin"];
                person.IdCard = (string)dr["IdCard"];
                person.Name = (string)dr["Name"];
                person.Other = (string)dr["Discription"];
                list.Add(person);
            }
            return list;
        }
        public static List <Person> RetrieveByName(string name)
        {
            string sql = "select * from T_Person where Name=@Name";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@Name", name));
            List<Person> list = new List<Person>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Person person = new Person();
                person.Id = (int)dr["PersonId"];
                person.Phone = (string)dr["Phone"];
                person.Psd = (string)dr["Password"];
                person.Value = (int)dr["Value"];
                person.IsMale = (bool)dr["IsMale"];
                person.Age = (int)dr["Age"];
                person.Address = (string)dr["Address"];
                person.IsAdmin = (bool)dr["IsAdmin"];
                person.IdCard = (string)dr["IdCard"];
                person.Name = (string)dr["Name"];
                person.Other = (string)dr["Discription"];
                list.Add(person);
            }
            return list;
        }
        public static void Update(Person person)
        {
            string sql = @"update T_Person set 
                        Phone=@Phone,
                        Password=@Psd,
                        Value=@Value,
                        IsMale=@IsMale,
                        Age=@Age,
                        Address=@Address,
                        IsAdmin=@IsAdmin,
                        IdCard=@Idcard,
                        Name=@Name,
                        Discription=@Other where PersonId=@Id";
            SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("@Id", person.Id),
                new SqlParameter("@Phone", person.Phone),
                new SqlParameter("@Psd", person.Psd),
                new SqlParameter("@Value", person.Value),
                new SqlParameter("@IsMale", person.IsMale),
                new SqlParameter("@Age", person.Age),
                new SqlParameter("@Address", person.Address),
                new SqlParameter("@IsAdmin", person.IsAdmin),
                new SqlParameter("@IdCard", person.IdCard),
                new SqlParameter("@Name", person.Name),
                new SqlParameter("@Other", person.Other)
                );
        }
        public static void Delete(int id)
        {
            string sql = "delete T_Person where PersonId=@Id";
            SqlHelper.ExecuteNonQuery(sql, new SqlParameter("Id", id));
        }
    }
}
