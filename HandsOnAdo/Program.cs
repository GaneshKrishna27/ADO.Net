using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HandsOnAdo
{
    class Program
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3238117\SQLEXPRESS;Initial Catalog=PracticeDB;Persist Security Info=True;User ID=sa;Password=pass@word1");
        SqlCommand cmd = null;
        public void Add()
        {
            try
            {
                cmd = new SqlCommand("Insert into project values(@pid,@pname,@sdate,@edate,@City)", con);
                cmd.Parameters.AddWithValue("@pid", "p0001");
                cmd.Parameters.AddWithValue("@pname", "boboo");
                cmd.Parameters.AddWithValue("@sdate", DateTime.Parse("12.2.2019"));
                cmd.Parameters.AddWithValue("@edate", DateTime.Parse("10.2.2020"));
                cmd.Parameters.AddWithValue("@City", "eluru");
                con.Open(); //open connection
                cmd.ExecuteNonQuery();//excute query (dml)
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();//close connection
            }
        }

        public void GetProjectById(string pid)
        {
            try
            {
                cmd = new SqlCommand("select * from Project where Pid=@pid", con);
                cmd.Parameters.AddWithValue("@pid", pid);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();//execute select statement
                if (dr.HasRows) //check rows existence
                {
                    dr.Read();
                    Console.WriteLine("Id:{0} Name:{1} Sdate:{2} Edate:{3} City:{4}",
                        dr["pid"], dr["pname"], dr["sdate"], dr["edate"], dr["City"]);
                }
                else
                    Console.WriteLine("invalid project id");
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetAllProjects()
        {
            try
            {
                cmd = new SqlCommand("Select * from Project", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("Id:{0} Name:{1} Sdate:{2} Edate:{3} City:{4}",
                        dr["pid"], dr["pname"], dr["sdate"], dr["edate"], dr["City"]);
                    }
                }
                else
                    Console.WriteLine("Table Empty");
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            //obj.GetProjectById("p0001");
            obj.GetAllProjects();
            //obj.Add();
        }
    }
}
