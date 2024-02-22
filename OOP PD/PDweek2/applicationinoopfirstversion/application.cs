using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    internal class application
    {
        public string name;
        public string password;
        public string role;
    }
    internal class busdata
    {
        public string busid;
        public string busname;
        public string busstartinglocation; 
        public string busendinglocation;
        public string busdeparturetime;
        public string busarrivaltime;
        public string ticketprice;
        public string ticketstatufeedbackusername;
        public string feedbackpoints;

    }

    class feedback
    {
        public string name;
        public string points;
    }
}
