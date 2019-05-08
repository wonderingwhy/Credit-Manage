using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public static class GoodSvc
    {
        public static void Create(Good good)
        {
            string sql = @"insert into T_Good(Name,Value,Num,IsDel,Img,Discription) values(
                            @Name,@Value,@Num,@IsDel,@Img,@Other)";
            SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("@Name",good.Name),
                new SqlParameter("@Value",good.Value),
                new SqlParameter("@Num",good.Num),
                new SqlParameter("@IsDel",good.IsDel),
                new SqlParameter("@Img",good.Img),
                new SqlParameter("@Other",good.Other)
                );
        }
        public static List <Good> RetrieveAll()
        {
            string sql = "select * from T_Good";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            List<Good> list = new List<Good>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Good good = new Good();
                good.Id = (int)dr["GoodId"];
                good.Num = (int)dr["Num"];
                good.IsDel = (bool)dr["IsDel"];
                good.Img = (string)dr["Img"];
                good.Value = (double)dr["Value"];
                good.Name = (string)dr["Name"];
                good.Other = (string)dr["Discription"];
                list.Add(good);
            }
            return list;
        }
        public static List <Good> RetrieveById(int id)
        {
            string sql = "select * from T_Good where GoodId=@Id";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@Id", id));
            List<Good> list = new List<Good>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[0];
                Good good = new Good();
                good.Id = (int)dr["GoodId"];
                good.Num = (int)dr["Num"];
                good.IsDel = (bool)dr["IsDel"];
                good.Img = (string)dr["Img"];
                good.Value = (double)dr["Value"];
                good.Name = (string)dr["Name"];
                good.Other = (string)dr["Discription"];
                list.Add(good);
            }
            return list;
        }
        public static List <Good> RetrieveByName(string name)
        {
            string sql = "select * from T_Good where IsDel=0 and Name=@Name";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@Name", name));
            List<Good> list = new List<Good>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[0];
                Good good = new Good();
                good.Id = (int)dr["GoodId"];
                good.Num = (int)dr["Num"];
                good.IsDel = (bool)dr["IsDel"];
                good.Img = (string)dr["Img"];
                good.Value = (double)dr["Value"];
                good.Name = (string)dr["Name"];
                good.Other = (string)dr["Discription"];
                list.Add(good);
            }
            return list;
        }
        public static void Update(Good good)
        {
            string sql = @"update T_Good set 
                        Value=@Value,
                        Name=@Name,
                        Num=@Num,
                        IsDel=@IsDel,
                        Img=@Img,
                        Discription=@Other where GoodId=@Id";
            SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("@Id", good.Id),
                new SqlParameter("@Num", good.Num),
                new SqlParameter("@Img", good.Img),
                new SqlParameter("@Value", good.Value),
                new SqlParameter("@IsDel", good.IsDel),
                new SqlParameter("@Name", good.Name),
                new SqlParameter("@Other", good.Other)
                );
        }
        public static void Delete(int id)
        {
            string sql = "Delete T_Good where GoodId=@Id";
            SqlHelper.ExecuteNonQuery(sql,new SqlParameter("@Id", id));
        }
    }
}
