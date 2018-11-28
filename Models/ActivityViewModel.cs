using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ActivityViewModel
    {
        public string ActivityName { get; set; }

        public ActivityViewModel(string activityname)
        {
            this.ActivityName = activityname;
        }
    }
}
