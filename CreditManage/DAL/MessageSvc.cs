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
    public static class MessageSvc
    {
        public static void Create(Message message)
        {
            String sql = @"insert into T_Message ([From],[To],Content,Date,IsRead,IsDelFrom,
                            IsDelTo) values (@From,@To,@Content,@Date,@IsRead,@IsDelFrom,@IsDelTo)";
            SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("@From", message.From),
                new SqlParameter("@To", message.To),
                new SqlParameter("@Content", message.Content),
                new SqlParameter("@Date", message.Date),
                new SqlParameter("@IsRead", message.IsRead),
                new SqlParameter("@IsDelFrom", message.IsDelFrom),
                new SqlParameter("@IsDelTo", message.IsDelTo)
                );
        }
        public static List<Message> RetrieveAll()
        {
            string sql = "select * from T_Message";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            List<Message> list = new List<Message>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Message message = new Message();
                message.Id = (int)dr["MessageId"];
                message.From = (int)dr["From"];
                message.To = (int)dr["To"];
                message.Content = (string)dr["Content"];
                message.IsRead = (bool)dr["IsRead"];
                message.IsDelFrom = (bool)dr["IsDelFrom"];
                message.IsDelTo = (bool)dr["IsDelTo"];
                message.Date = (string)dr["Date"];
                list.Add(message);
            }
            return list;
        }
        public static List<Message> RetrieveById(int id)
        {
            string sql = "select * from T_Message where MessageId=@Id";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@Id", id));
            List<Message> list = new List<Message>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Message message = new Message();
                message.Id = (int)dr["MessageId"];
                message.From = (int)dr["From"];
                message.To = (int)dr["To"];
                message.Content = (string)dr["Content"];
                message.IsRead = (bool)dr["IsRead"];
                message.IsDelFrom = (bool)dr["IsDelFrom"];
                message.IsDelTo = (bool)dr["IsDelTo"];
                message.Date = (string)dr["Date"];
                list.Add(message);
            }
            return list;
        }
        public static List<Message> RetrieveByFrom(int From)
        {
            string sql = "select * from T_Message where [From]=@From and isDelFrom=0";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@From", From));
            List<Message> list = new List<Message>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Message message = new Message();
                message.Id = (int)dr["MessageId"];
                message.From = (int)dr["From"];
                message.To = (int)dr["To"];
                message.Content = (string)dr["Content"];
                message.IsRead = (bool)dr["IsRead"];
                message.IsDelFrom = (bool)dr["IsDelFrom"];
                message.IsDelTo = (bool)dr["IsDelTo"];
                message.Date = (string)dr["Date"];
                list.Add(message);
            }
            return list;
        }
        public static List<Message> RetrieveByTo(int To)
        {
            string sql = "select * from T_Message where [To]=@To and isDelTo=0";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("@To", To));
            List<Message> list = new List<Message>();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DataRow dr = dt.Rows[i];
                Message message = new Message();
                message.Id = (int)dr["MessageId"];
                message.From = (int)dr["From"];
                message.To = (int)dr["To"];
                message.Content = (string)dr["Content"];
                message.IsRead = (bool)dr["IsRead"];
                message.IsDelFrom = (bool)dr["IsDelFrom"];
                message.IsDelTo = (bool)dr["IsDelTo"];
                message.Date = (string)dr["Date"];
                list.Add(message);
            }
            return list;
        }
        public static void Update(Message message)
        {
            string sql = @"update T_Message set 
                        [From]=@From,
                        [To]=@To,
                        Content=@Content,
                        Date=@Date,
                        IsRead=@IsRead,
                        IsDelFrom=@IsDelFrom,
                        IsDelTo=@IsDelTo where MessageId=@Id";
            SqlHelper.ExecuteNonQuery(sql,
                new SqlParameter("@Id", message.Id),
                new SqlParameter("@From", message.From),
                new SqlParameter("@To", message.To),
                new SqlParameter("@Content", message.Content),
                new SqlParameter("@Date", message.Date),
                new SqlParameter("@IsRead", message.IsRead),
                new SqlParameter("@IsDelFrom", message.IsDelFrom),
                new SqlParameter("@IsDelTo", message.IsDelTo)
                );
        }
        public static void Delete(int id)
        {
            string sql = "delete T_Message where MessageId=@Id";
            SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@Id", id));
        }
    }
}
