using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tryReadingCSVFile
{

    class User
    {
        private string userName;
        private string password;

        public User() { }

        public User(string userName)
        {
            this.userName = userName;
        }

        public void generateList()
        {
            List<string> list1 = new List<string>();

            list1.Add("s");
            list1.Add("a");
            List<String> list2 = new List<String>();
            list2.Add("123");
            list2.Add("456");
            Console.Write("\n");
            Console.Write("Enter your user name:    ");
            string username1 = Console.ReadLine();
            bool exist = list1.Any(item => item.Equals(username1));


            if (exist == true)
            {


                Console.Write("correct user name ^__^ ");
                Console.Write("\n \n");
            }
            else
            {
                Console.Write("unfound user name. Enter an existence username plz:  ");
                username1 = Console.ReadLine();

                exist = list1.Any(item => item.Equals(username1));


                if (exist == true)
                {


                    Console.Write("correct user name ^__^ ");
                    Console.Write("\n \n");
                }
                else
                {
                    Console.Write("\n Sorry, You have exceeded the number of chances that u have, try later...bye \n \n ");
                    Console.Write("     ****************************************************************            \n");
                    System.Threading.Thread.Sleep(5000);
                    System.Environment.Exit(1);
                }

            }
            string usern = list1.Find(item => item == username1);
            int index = list1.IndexOf(usern);
            Console.Write("Now enter your password:    ");
            string pass1 = Console.ReadLine();
            string actPass = list2[index];
            if (actPass.Equals(pass1))
            {
                Console.Write("\n");
                Console.Write("Matched ^__^ \n");

            }
            else
            {
                Console.Write("OOOPS, this password doesn't match with your user name , try to enter the correct one:   ");

                pass1 = Console.ReadLine();
                if (actPass.Equals(pass1))
                {

                    Console.Write("Yesssss, Matched ^__^ \n");

                }
                else
                {
                    Console.Write("\n Maybe u forgot ur password, try again when u remember it :p ... bye \n \n ");
                    Console.Write("     ****************************************************************            \n");
                }

            }
        }



        public string getUserName()
        {
            return this.userName;
        }
        public string getPassword()
        {
            return this.password;
        }
        public void setUserName(string username)
        {
            this.userName = username;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
    }




}