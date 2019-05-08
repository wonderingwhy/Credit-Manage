using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class PersonMng
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns>-1: fail; 0: success</returns>
        public static int Reg(Person person)
        {
            if (PersonSvc.RetrieveByPhone(person.Phone).Count > 0)
            {
                return -1;
            }
            else
            {
                PersonSvc.Create(person);
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns>-3: >1; -2 <=0; -1 fail; 0:success </returns>
        public static int Log(ref Person person)
        {
            List <Person> list = PersonSvc.RetrieveByPhone(person.Phone);
            if (list.Count > 1)
            {
                return -3;
            }
            else if (list.Count <= 0)
            {
                return -2;
            }
            else if (list[0].Psd.Equals(person.Psd) == false)
            {
                return -1;
            }
            else
            {
                person = list[0];
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns>-2: >1; -1: <=0; 0: success </returns>
        public static int Detail(int id, ref Person person)
        {
            List<Person> list = PersonSvc.RetrieveById(id);
            if (list.Count > 1)
            {
                return -2;
            }
            else if(list.Count <= 0) 
            {
                return -1;
            }
            else
            {
                person=list[0];
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="list"></param>
        /// <returns>-3: >1; -2: <0; -1: fail; 0: success </returns>
        public static int Edit(Person person)
        {
            PersonSvc.Update(person);
            return 0;
        }
        public static int GetGood(ref List<Good> goods)
        {
            goods = GoodSvc.RetrieveAll();
            return 0;
        }
        public static int GetGoodByName(string name, List<Good> goods)
        {
            goods = GoodSvc.RetrieveByName(name);
            return 0;
        }
        public static int GetGoodById(int id, ref Good good)
        {
            good = GoodSvc.RetrieveById(id)[0];
            return 0;
        }
        public static int GetPersonById(int id, ref Person person)
        {
            person = PersonSvc.RetrieveById(id)[0];
            return 0;
        }
        public static int AddBuy(Buy buy)
        {
            BuySvc.Create(buy);
            return 0;
        }
        public static int GetBuy(int id, ref List<Buy> buys, ref List<Good> goods, ref List<Person> persons)
        {
            buys = BuySvc.RetrieveByPerson(id);
            foreach (Buy buy in buys)
            {
                Person person = new Person();
                Good good = new Good();
                GetPersonById(buy.PersonId, ref person);
                GetGoodById(buy.GoodId, ref good);
                persons.Add(person);
                goods.Add(good);
            }
            return 0;
        }
        public static int GetValue(int id, ref List<Value> values)
        {
            values = ValueSvc.RetrieveByPersonId(id);
            return 0;
        }
        public static int GetMessageFrom(int id, ref List<Message> messages)
        {
            messages = MessageSvc.RetrieveByFrom(id);
            foreach (Message message in messages)
            {
                if (message.IsDelFrom == true)
                {
                    messages.Remove(message);
                }
            }
            return 0;
        }
        public static int GetMessageTo(int id, ref List<Message> messages)
        {
            messages = MessageSvc.RetrieveByTo(id);
            foreach (Message message in messages)
            {
                if (message.IsDelTo == true)
                {
                    messages.Remove(message);
                }
            }
            return 0;
        }
        public static int DeleteMessageFrom(int id)
        {
            Message message = MessageSvc.RetrieveById(id)[0];
            message.IsDelFrom = true;
            MessageSvc.Update(message);
            return 0;
        }
        public static int DeleteMessageTo(int id)
        {
            Message message = MessageSvc.RetrieveById(id)[0];
            message.IsDelTo = true;
            MessageSvc.Update(message);
            return 0;
        }
        public static int Send(Message message)
        {
            MessageSvc.Create(message);
            return 0;
        }
        
    }
}
