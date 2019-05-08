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
    public static class ValueSvc
    {
        public static void Create(Value value)
        {
            string sql = @"insert into T_Value(PersonId,Num,Date,Discription) values(
                            @PersonId,@Num,@Date,@Other)";
            SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("@PersonId", value.PersonId),
                new SqlParameter("@Num", value.Num),
                new SqlParameter("@Date", value.Date),
                new SqlParameter("@Other", value.Other)
                );
        }
        public static List<Value> RetrieveAll()
        {
            string sql = "select * from T_Value";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            List<Value> list = new List<Value>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Value value = new Value();
                value.Id = (int)dr["ValueId"];
                value.PersonId = (int)dr["PersonId"];
                value.Num = (int)dr["Num"];
                value.Date = (string)dr["Date"];
                value.Other = (string)dr["Discription"];
                list.Add(value);
            }
            return list;
        }
        public static List<Value> RetrieveById(int id)
        {
            string sql = @"select * from T_Value where ValueId=@Id";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@Id", id));
            List<Value> list = new List<Value>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Value value = new Value();
                value.Id = (int)dr["ValueId"];
                value.PersonId = (int)dr["PersonId"];
                value.Num = (int)dr["Num"];
                value.Date = (string)dr["Date"];
                value.Other = (string)dr["Discription"];

                list.Add(value);
            }
            return list;
        }
        public static List<Value> RetrieveByPersonId(int personId)
        {
            string sql = @"select * from T_Value where PersonId=@PersonId";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@PersonId", personId));
            List<Value> list = new List<Value>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Value value = new Value();
                value.Id = (int)dr["ValueId"];
                value.PersonId = (int)dr["PersonId"];
                value.Num = (int)dr["Num"];
                value.Date = (string)dr["Date"];
                value.Other = (string)dr["Discription"];

                list.Add(value);
            }
            return list;
        }
        public static void Update(Value value)
        {
            string sql = @"update T_Value set
                        PersonId=@PersonId,
                        Num=@Num,
                        Date=@Date,
                        Discription=@Other where ValueId=@Id";
            SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("@Id", value.Id),
                new SqlParameter("@PersonId", value.PersonId),
                new SqlParameter("@Num", value.Num),
                new SqlParameter("@Date", value.Date),
                new SqlParameter("@Other", value.Other)
                );
        }
        public static void Delete(int id)
        {
            string sql = "delete T_Value where ValueId=@Id";
            SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@Id", id));
        }
    }
}
