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
    public static class BuySvc
    {
        public static void Create(Buy buy)
        {
            string sql = @"insert into T_Buy(PersonId,GoodId,Num,IsCheck,Date) values(
                            @PersonId,@GoodId,@Num,@IsCheck,@Date)";
            SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("@PersonId", buy.PersonId),
                new SqlParameter("@GoodId", buy.GoodId),
                new SqlParameter("@Num", buy.Num),
                new SqlParameter("@IsCheck", buy.IsCheck),
                new SqlParameter("@Date", buy.Date)
                );
        }
        public static List <Buy> RetrieveAll()
        {
            string sql = "select * from T_Buy";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            List<Buy> list = new List<Buy>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Buy buy = new Buy();
                buy.Id = (int)dr["BuyId"];
                buy.PersonId = (int)dr["PersonId"];
                buy.GoodId = (int)dr["GoodId"];
                buy.Num = (int)dr["Num"];
                buy.IsCheck = (bool)dr["IsCheck"];
                buy.Date = (string)dr["Date"];
                list.Add(buy);
            }
            return list;
        }
        public static List<Buy> RetrieveById(int id)
        {
            string sql = "select * from T_Buy where BuyId=@Id";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@Id", id));
            List<Buy> list = new List<Buy>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Buy buy = new Buy();
                buy.Id = (int)dr["BuyId"];
                buy.PersonId = (int)dr["PersonId"];
                buy.GoodId = (int)dr["GoodId"];
                buy.Num = (int)dr["Num"];
                buy.IsCheck = (bool)dr["IsCheck"];
                buy.Date = (string)dr["Date"];
                list.Add(buy);
            }
            return list;
        }
        public static List<Buy> RetrieveByPerson(int personId)
        {
            string sql = "select * from T_Buy where PersonId=@PersonId";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@PersonId", personId));
            List<Buy> list = new List<Buy>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Buy buy = new Buy();
                buy.Id = (int)dr["BuyId"];
                buy.PersonId = (int)dr["PersonId"];
                buy.GoodId = (int)dr["GoodId"];
                buy.Num = (int)dr["Num"];
                buy.IsCheck = (bool)dr["IsCheck"];
                buy.Date = (string)dr["Date"];
                list.Add(buy);
            }
            return list;
        }
        public static List<Buy> RetrieveByGood(int goodId)
        {
            string sql = "select * from T_Buy where GoodId=@GoodId";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@GoodId", goodId));
            List<Buy> list = new List<Buy>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Buy buy = new Buy();
                buy.Id = (int)dr["BuyId"];
                buy.PersonId = (int)dr["PersonId"];
                buy.GoodId = (int)dr["GoodId"];
                buy.Num = (int)dr["Num"];
                buy.IsCheck = (bool)dr["IsCheck"];
                buy.Date = (string)dr["Date"];
                list.Add(buy);
            }
            return list;
        }        
        public static void Update(Buy buy)
        {
            string sql = @"update T_Buy set 
                        PersonId=@PersonId,
                        GoodId=@GoodId,
                        Num=@Num,
                        IsCheck=@IsCheck,
                        Date=@Date where BuyId=@Id";
            SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("@Id", buy.Id),
                new SqlParameter("@PersonId", buy.PersonId),
                new SqlParameter("@GoodId", buy.GoodId),
                new SqlParameter("@Num", buy.Num),
                new SqlParameter("@IsCheck", buy.IsCheck),
                new SqlParameter("@Date", buy.Date)
                );
        }
        public static void Delete(int id)
        {
            string sql = "delete T_Buy where BuyId=@Id";
            SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@Id", id));
        }
    }
}
