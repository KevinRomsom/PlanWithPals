using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace Logic
{
    public class ActivityLogic
    {
        DALActivity dalactivity = new DALActivity();
        public void pushToDB(Activity activity)
        {
            string activityname = activity.ActivityName;
            string address = activity.Address;
            string city = activity.City;
            DateTime datetime = activity.DateTime;

            dalactivity.InsertActivityIntoDB(activityname, address, city, datetime);

        }

        public List<string> PassActivities()
        {
            List<string> activitylist = new List<string>();

            activitylist = dalactivity.getActivities();

            return activitylist;
        }
    }
}
