using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Assignment2Form());
        }
    }

    //Predeinfe Class Hitter
    class hitter
    {
        public string ip; //The IP address of the hit from the log file
        public long hit_count; //use a long so that you can store a large amount of hits

        public hitter()
        {
            hit_count = 1; //upon there being found an ip to generate a hitter being created it should default to there being at least 1 hit. 
        }

        //Get IP method
        public string getIP()
        {

            return ip;
        }

        //Set IP Method
        public void setIP(string s)
        {

            this.ip = s;
        }

        //Get Hit Count Method
        public long getHitCount()
        {
            return hit_count;
        }

        //Set Hit Count Method
        public void setHitCount(long l)
        {
            this.hit_count = l;
        }
    }

}
