using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//log4net
namespace Company_DataBase
{
    class Employees
    {
        private string username, password, role;
        private int E_SSN;
        public Employees(){}
        public string getUsername()
        {
            return this.username;

        }
        public void E_Sign_in()
        {
            String ConnectionString = "Server=DESKTOP-5V4FCOT\\SQLEXPRESS;Initial Catalog=Company;Integrated Security=True";
            SqlConnection conn = new SqlConnection(ConnectionString);
            
            Console.Write(" Enter your username:  ");
            username= Console.ReadLine();
            Console.Write(" Enter your SSN:  ");
            E_SSN = int.Parse(Console.ReadLine());

            Console.Write("\n Enter your password: ");
            password= Console.ReadLine();
            Console.Write("\n Enter your Role: ");
            role = Console.ReadLine();
            string query = "INSERT INTO Employee(Name, password) VALUES(' "+username + +E_SSN+""+password+""+""+role+")";
            SqlCommand ins = new SqlCommand(query,conn);
            conn.Open();
            ins.ExecuteNonQuery();
            Console.WriteLine("\n data base stored. \n");

        }
        public void setUsername()
        {
            this.username = username;
        }
        public string getPassword()
        {
            return this.password;

        }
        public void setPassword()
        {
            this.password= password;
        }
        public int getE_SSN()
        {
            return this.E_SSN;

        }
        public void setE_SSN()
        {
            this.E_SSN= E_SSN;
        }



    }
}
