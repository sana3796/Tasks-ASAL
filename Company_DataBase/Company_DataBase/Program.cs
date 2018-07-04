using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;


namespace Company_DataBase
{
    class Program
    {
        //public static int  L_SSN = 30;





        static void Main(string[] args)
        {
            //connection configuration

            String ConnectionString = "Server=DESKTOP-5V4FCOT\\SQLEXPRESS;Initial Catalog=Company;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {

                    // conn.ConnectionString = "Server=(DESKTOP-5V4FCOT)\SQLEXPRESS;Database=[Company];Trusted_Connection=true";
                    conn.Open();
                    ConnectionState conState = conn.State;
                    if (conState == ConnectionState.Closed || conState == ConnectionState.Broken)
                    {
                        Console.WriteLine("Connection failed");



                    }
                    else
                    {
                        Console.WriteLine(" Connection successful \n");
                        Menu();
                        





                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Can't connect to the DB  " + ex.Message);
                    Console.Read();


                }



            }



        }
        public static void Menu()
        {
            char key;
            Console.Write("                Menu        \n");
            Console.Write("         1. Employee       \n");
            Console.Write("         2. Supervisor \n");
            Console.Write("         3. Lead \n");
            Console.Write("         4.  Exit \n");
            Console.Write("    Enter your option:   ");
            key = Console.ReadKey().KeyChar;
            if (key == '1')
            {
                string username, password;


               

                Console.WriteLine("\n *********************** Employee Sign in ********************* \n");
                Employees e = new Employees();
                // sign in by enter username and password.
                Console.Write(" Enter your username:  ");
                username = Console.ReadLine();
                while (username.Length == 0)
                {
                    Console.WriteLine("this field is required \n");
                    Console.WriteLine(" Enter your username:    ");
                    username = Console.ReadLine();

                }
                Console.Write("\n Enter your password: ");
                password = Console.ReadLine();
                while (password.Length == 0)
                {
                    Console.WriteLine("this field is required \n");
                    Console.WriteLine(" Enter your password:    ");
                    password = Console.ReadLine();

                }

                DataEmployeeDataContext empl = new DataEmployeeDataContext();
                //List of employee to store object of employee.
                List < Employee> Employee_list = new List<Employee> ();
                // fetch the data from database and store it in the employee list
                Employee_list = (from Employee in empl.Employees
                                  select Employee).ToList();
                // search for entered username and password.
                var employeeQuery = (from employee in Employee_list
                                where employee.Name == username && employee.password == password
                                select employee);//.FirstOrDefault();// solves the null case
                // verify 
                if (!employeeQuery.Any())
                {
                    Console.WriteLine("Sorry, there is no employee with this username.");
                }
                else

                    Console.WriteLine("\n username found. \n");
                System.Threading.Thread.Sleep(2000);
                //conn.Close();
                //Console.WriteLine("\n Connection closed. \n");
                Console.Clear();
                Menu();

            }
            if (key == '2')
            {
                List<Lead> lead_list = new List<Lead>();
                DataLeadDataContext datalead = new DataLeadDataContext();
                Lead leadobj = new Lead();

                lead_list = (from Lead in datalead.Leads
                                 select Lead).ToList();
                Console.Write("\n **** List of Leads: ****** \n ");
                foreach (Lead lead in lead_list)
                {
                    Console.Write(" " + lead.Name);
                    Console.Write("\n");
                }
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    Menu();
                


            }
            if(key == '3')
            {
                String Email, password, username, university;

                Console.WriteLine("\n ***********  Lead Sign up ********************* \n");
                Console.WriteLine("    Create account       ");
                Console.WriteLine(" Enter your Email:    ");
                Email = Console.ReadLine();
                while (Email.Length== 0)
                {
                    Console.WriteLine(" this field is required \n");
                    Console.WriteLine(" Enter your Email:    \n");
                    Email = Console.ReadLine();

                }
                Console.WriteLine(" Enter your username:  ");
                username = Console.ReadLine();
                while (username.Length == 0)
                {
                    Console.WriteLine("this field is required \n");
                    Console.WriteLine(" Enter your username:    ");
                    username = Console.ReadLine();

                }
                Console.WriteLine("\n Enter your password:  ");
                password = Console.ReadLine();
                while (password.Length == 0)
                {
                    Console.WriteLine("this field is required \n");
                    Console.WriteLine(" Enter your password:    ");
                    password = Console.ReadLine();

                }
                Console.WriteLine("\n Enter your university:  ");
                university = Console.ReadLine();
                DataLeadDataContext datalead = new DataLeadDataContext();
                Lead leadobj = new Lead();
                leadobj.Name = username;
                leadobj.L_Email = Email;
                leadobj.password = password;
                leadobj.university = university;
               
                Console.WriteLine(" \n **********Your Information ********** \n");
                Console.WriteLine(" Name:      " + leadobj.Name + "\n");
                Console.WriteLine(" Email:      " + leadobj.L_Email + "\n");
                Console.WriteLine(" Password:      " + leadobj.password + "\n");
                Console.WriteLine(" University:         " + leadobj.university + "\n");
                Console.WriteLine(" 1. Submit     2. Edit       ");
                Console.WriteLine("\n");
                key = Console.ReadKey().KeyChar;
                if (key == '1')
                {
                    datalead.Leads.InsertOnSubmit(leadobj);
                    datalead.SubmitChanges();

                    Console.WriteLine("\n Account created successfully. \n");

                }
                if (key == '2')
                {
                    Console.WriteLine("*** Update your Information *** \n");
                    Console.WriteLine(" Update Your Email? (y/n) \n"); key = Console.ReadKey().KeyChar;
                    if (key == 'y' | key == 'Y')
                    {
                        Console.WriteLine(" Enter your Email:    \n");
                        leadobj.L_Email = (Console.ReadLine());
                        datalead.Leads.InsertOnSubmit(leadobj);
                        datalead.SubmitChanges();
                        Console.WriteLine("\n Done....");
                        Console.WriteLine("\n Account created successfully. \n");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        Menu();


                    }
                    if (key == 'n' | key == 'N')
                    {
                        Console.WriteLine("\n Update Your Username? (y/n) \n");
                        key = Console.ReadKey().KeyChar;
                        if (key == 'y' | key == 'Y')
                        {
                            Console.WriteLine("\n Enter your username:    \n");
                            leadobj.Name = (Console.ReadLine());
                            datalead.Leads.InsertOnSubmit(leadobj);
                            datalead.SubmitChanges();
                            Console.WriteLine("\n Done....");
                            Console.WriteLine("\n Account created successfully. \n");
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                            Menu();

                        }
                        if (key == 'n' | key == 'N')
                        {
                            Console.WriteLine("\n Update Your password? (y/n) \n");
                            key = Console.ReadKey().KeyChar;
                            if (key == 'y' | key == 'Y')
                            {
                                Console.WriteLine("\n Enter your password:    \n");
                                leadobj.password = (Console.ReadLine());
                                datalead.Leads.InsertOnSubmit(leadobj);
                                datalead.SubmitChanges();
                                Console.WriteLine("\n Done....");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                Menu();
                            }
                            if (key == 'n' | key == 'N')
                            {
                                Console.WriteLine("\n Update Your university name? (y/n) \n");
                                key = Console.ReadKey().KeyChar;
                                if (key == 'y' | key == 'Y')
                                {
                                    Console.WriteLine("\n Enter your university name:    \n");
                                    leadobj.university = (Console.ReadLine());
                                    datalead.Leads.InsertOnSubmit(leadobj);
                                    datalead.SubmitChanges();
                                    Console.WriteLine("\n Done....");
                                    System.Threading.Thread.Sleep(2000);
                                    Console.Clear();
                                    Menu();
                                }
                                if (key == 'n' | key == 'N')
                                {
                                    System.Threading.Thread.Sleep(2000);
                                    Console.Clear();
                                    Menu();

                                }
                            }
                        }
                    }

                }
            }
            if (key == '4')
            {
                Console.Write("\n Are u sure? (y/n):");
                key = Console.ReadKey().KeyChar;
                if (key == 'y' | key == 'Y')
                {

                    Console.WriteLine("\n       Gooooooodbyeeeeeeeeeeee :p ");
                    System.Environment.Exit(1);
                }
                if (key == 'n' | key == 'N')
                {
                    Console.Write("\n Let's go to the main menu ");
                    Menu();
                }
                else
                {
                    Console.Write("\n You entered sth wrong, you are now in the main menu.\n");
                    Menu();
                }

            }
            else
            {
                Console.Write("\n You entered somthing wrong, try again please.\n");
                Menu();

            }

        }
    }

}
    

    

