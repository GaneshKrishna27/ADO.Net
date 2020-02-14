using HandsOnEFCodeFirst.Context;
using HandsOnEFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HandsOnEFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StudentContext db=new StudentContext())
            {
                //imsert new record
                Student s = new Models.Student() { Sname = "krish", Age = 21, Std = "btech" };
                db.student.Add(s);
                db.SaveChanges();
                //fetch record
                //Student s = db.student.Find(1);
                //Console.WriteLine("Welcome {0}", s.Sname);

                //fetch one record using non primary key
                Student s1 = db.student.SingleOrDefault(i => i.Sname == "Rohan");
                List<Student> list = db.student.Where(i => i.Age == 10).ToList();
                List<Student> list1 = db.student.Where(i => i.Age == 10&&i.Std=="II").ToList();

                //Student s2 = db.student.Find(3);
                //s2.Age = 20;
                //db.student.Update(s2);
                //db.SaveChanges();

                //delete
                //Student s3 = db.student.SingleOrDefault(i => i.Id == 2);
                //db.student.Remove(s3);
                //db.SaveChanges();

            }
        }
    }
}
