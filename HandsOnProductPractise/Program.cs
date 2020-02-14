using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HandsOnProductPractise
{
    class Program
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3238117\SQLEXPRESS;Initial Catalog=PracticeDB;Persist Security Info=True;User ID=sa;Password=pass@word1");
        SqlCommand cmd = null;
        
        public void Add(int id,string name,int price,int stock)
        {
            try
            {
                cmd = new SqlCommand("Insert into product values(@id,@name,@price,@stock)", con);
               
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@stock", stock);
                con.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.HasRows)
                //{
                //    dr.Read();
                //    Console.WriteLine("Id:{0}, Name:{1}, Price:{2}, Stock:{3}",
                //        dr["id"], dr["name"], dr["price"], dr["stock"]);
                //}
                
                cmd.ExecuteNonQuery();
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
        
        public void Get(int id)
        {
            try
            {
                cmd = new SqlCommand("Select * from product where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Console.WriteLine("Id:{0}, Name:{1}, Price:{2}, Stock:{3}",
                              dr["id"], dr["name"], dr["price"], dr["stock"]);
                }
                else
                    Console.WriteLine("invalid entry");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void GetAll()
        {
            try
            {
                cmd = new SqlCommand("Select * from Product", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("Id:{0}, Name:{1}, Price:{2}, Stock:{3}",
                               dr["id"], dr["name"], dr["price"], dr["stock"]);
                    }
                }
                else
                    Console.WriteLine("Table Empty");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                cmd = new SqlCommand("Delete from Product where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                
               
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            //int id = int.Parse(Console.ReadLine());
            //string name = Console.ReadLine();
            //int price = int.Parse(Console.ReadLine());
            //int stock = int.Parse(Console.ReadLine());
            //obj.Add(id, name, price, stock);
            //obj.Get(1);
            //obj.GetAll();
            obj.Delete(5);
        }
    }
}
