using System;
using Market.Models;
using Market.Context;
namespace DemoMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyContext db = new MyContext())
            {
                Item i = new Item() { Item_name = "One Plus 7t" };
                Order o = new Order() { Item_Id = 1, OrderDate = Convert.ToDateTime("05.01.1998") };
                db.Add(o);
                //db.SaveChanges();
                db.Add(i);
                db.SaveChanges();
            }


        }
    }
}
