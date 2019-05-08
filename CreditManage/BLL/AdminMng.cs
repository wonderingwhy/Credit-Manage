using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public static class AdminMng
    {
        public static int EditGood(Good good)
        {
            GoodSvc.Update(good);
            return 0;
        }
        public static int AddGood(Good good)
        {
            GoodSvc.Create(good);
            return 0;
        }
        public static int PseDelGood(int id)
        {
            Good good = GoodSvc.RetrieveById(id)[0];
            good.IsDel = true;
            GoodSvc.Update(good);
            return 0;
        }
        public static int RealDelGood(int id)
        {
            GoodSvc.Delete(id);
            return 0;
        }
        public static int QueryPersonAll(ref List<Person> persons)
        {
            persons = PersonSvc.RetrieveAll();
            return 0;
        }
        public static int QueryPersonByPhone(string phone, ref Person person)
        {
            person = PersonSvc.RetrieveByPhone(phone)[0];
            return 0;
        }
        public static int QueryPersonByName(string name, ref List<Person> persons)
        {
            persons = PersonSvc.RetrieveByName(name);
            return 0;
        }
        public static int EditPerson(Person person)
        {
            Person per = PersonSvc.RetrieveById(person.Id)[0];
            if (per.Phone != person.Phone || per.Psd != person.Psd)
            {
                return -1;
            }
            else
            {
                if (per.Value != person.Value)
                {
                    Value value = new Value();
                    value.PersonId = per.Id;
                    value.Num = person.Value - per.Value;
                    value.Date = System.DateTime.Now.ToString();
                    value.Other = "管理员修改积分";
                    ValueSvc.Create(value);
                }
                PersonSvc.Update(person);
                return 0;
            }
        }
        public static int GetBuyAll(ref List<Buy> buys, ref List<Good> goods, ref List<Person> persons)
        {
            buys = BuySvc.RetrieveAll();
            foreach (Buy buy in buys)
            {
                Person person = new Person();
                Good good = new Good();
                PersonMng.GetPersonById(buy.PersonId, ref person);
                PersonMng.GetGoodById(buy.GoodId, ref good);
                persons.Add(person);
                goods.Add(good);
            }
            return 0;
        }
        public static int CheckBuy(int id)
        {
            Buy buy = BuySvc.RetrieveById(id)[0];
            Good good = GoodSvc.RetrieveById(buy.GoodId)[0];
            Person person = PersonSvc.RetrieveById(buy.PersonId)[0];
            if (buy.IsCheck == false)
            {
                if (good.Num < buy.Num)
                {
                    return -1;
                }
                good.Num -= buy.Num;
                GoodSvc.Update(good);
                buy.IsCheck = true;
                BuySvc.Update(buy);
                Value value = new Value();
                value.PersonId = buy.PersonId;
                value.Num = Convert.ToInt32(good.Value * buy.Num);
                value.Date = System.DateTime.Now.ToString();
                value.Other = "购物获得";
                ValueSvc.Create(value);
                person.Value += value.Num;
                PersonSvc.Update(person);
                
            }
            return 0;
        }
        public static int MessageAll()
        {
            MessageSvc.RetrieveAll();
            return 0;
        }
        public static int DelMessage(int id)
        {
            MessageSvc.Delete(id);
            return 0;
        }

    }
}
