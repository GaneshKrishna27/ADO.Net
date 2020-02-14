using EFDAL.Models;
using EFDAL.Context;
using System;


namespace EMS_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ProjectContext db=new ProjectContext())
            {
                Project p = new Project() { ProjectName = "vhtgh" };
                db.Add(p);
                db.SaveChanges();
            }
        }
    }
}
