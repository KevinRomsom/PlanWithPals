using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace Logic
{
    public class UserLogic
    {
        DALUser daluser = new DALUser();
        public bool checkLogin(User user)
        {
            

            bool result = false;
            string modelemailaddress = user.Emailaddress;
            string modelpassword = user.Password;

            string dalemailaddress = daluser.GetEmailaddress(modelemailaddress);
            string dalpassword = daluser.GetPassword(modelpassword);

            if (modelemailaddress == dalemailaddress && modelpassword == dalpassword)
            {
                result = true;
            }
            return result;
        }

        public string pushToDB(User user)
        {
            string name = user.Name;
            string surname = user.Surname;
            string emailaddress = user.Emailaddress;
            string password = user.Password;
            string address = user.Address;
            string city = user.City;

            string status = "";
            if (checkExistence(emailaddress))
            {
                daluser.InsertIntoDB(name, surname, emailaddress, password, address, city);
                status = "succes";
            }
            else
            {
                status = "failed"; 
            }

            return status;
        }

        public bool checkExistence(string emailaddress)
        {
            bool result = false;
            string email = daluser.GetEmailaddress(emailaddress);

            if(email == null || email == "")
            {
                result = true;
            }

            return result;
        }
    }
}
