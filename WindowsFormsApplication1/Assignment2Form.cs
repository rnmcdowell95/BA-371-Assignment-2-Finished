using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    //Assignment2form is based on the form class.
    public partial class Assignment2Form : Form
    {
        //Assignment 2 Constructor
        public Assignment2Form()
        {
            //Form Method call when initilaizing Assignment2form.
            InitializeComponent();
        }

        //Method executed when the "Exit" button is clicked by user.
        private void exit_Button_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        //Method executed when the "Select Log File" button is clicked by user.
        private void selectLogFile_Button_Click(object sender, EventArgs e)
        {
            //Initiates a stream variable and opens up the OpenFileDialog window.
            //This allows a file to be picked to open
            System.IO.Stream myStream = null;
            //Limits this to .txt files
            openLogFileDialog.Filter = "text files (*.txt)|*.txt";
            openLogFileDialog.FilterIndex = 2;
            openLogFileDialog.RestoreDirectory = true;

            //Logic to ensure the file is properly opened.
            //This involves a try catch to see if the file is avaliable that also generates an error message if it is not.           
           
            if (openLogFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //If the try succeeds the file's file path will be written out into the filePath_Textbox in the GUI.
                    if ((myStream = openLogFileDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            filePath_Textbox.Text = openLogFileDialog.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Since this genereated an error we "break" out of the "selectLogFile Button Method"
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        //Method executed when the "Go" button is clicked by user.
        private void go_Button_Click(object sender, EventArgs e)
        {
            //Definition of variables to be used in this section of code
            //Stores the File Path that was found by during the "selectLogFile_Button_Click" method as a string
                string filePath = filePath_Textbox.Text;
            //A string used to for storing the IP Address as it is found in the file.
                string ipString;
            // An integer used to count the number of unique IP Addresses found in the log file.
                int uniqueIPsFound = 0;
            //An unsigned integer used to count the number of times the special IP address is found that is not supposed to be in the top 100 IP addresses.
                uint specialIPHitCounter = 0;
            //A string array used to hold the different lines of text from the log file to enable the IP addresses to be extracted.
                string[] logLine;
            //A bool used in the logic below to determine if the IP address found is a new IP address.
                bool ipNew;
            //This double is used to hold the mean for the top 100 IP address hits
                double hitMean = 0;
            //This double is used as a place holder in the calculation for the mean of the top 100 IP Address hits.
                double holder = 0;

            //Try catch to ensure that a proper file path is used.
            try
            {
                //This checks to ensure a proper file path is used.
                if(!System.IO.File.Exists(filePath))
                {       
                    throw new System.IO.FileNotFoundException();
                }
            }
            catch
            {
                //If the file path doesn't point to a proper file an error message is returned.
                MessageBox.Show("A valid File path was not provided!");
                //Since this genereated an error we "break" out of the "Go Button Method"
                return;
            }



            //This line reads all of the lines from the log file into an array of strings for further processing.
            string[] unsortedLog = System.IO.File.ReadAllLines(filePath);

            //Allocateds memory for an array of hitter class objects. The amount of room generated is based on the number of lines in the log file.
            //While this is more than we need it also leaves the program open to the possibility that every single line in the log file is a hit generated from a unique IP address.
            hitter[] hitters = new hitter[unsortedLog.Length];

            //Clear the Display before anything is posted.
            display_Box.Items.Clear();

            for(int i = 0; i < unsortedLog.Length; i ++)
            {
                //This sets the ipNew Bool Value to true at the beging of each iteration of the for loop.
                ipNew = true;

                //A try catch is used to attempt to split the lines of the log file and take the IP Adress from each line.
                //A fail would mean that the log file is not formatted properly (i.e. some error on the wbe pages fault) or it is not a proper log file.
                try
                {
                    //Below is the template for what each line of the log file is supposed to look like.
                    //server-id⎵requester-ip⎵-⎵-⎵[date time of the request]⎵"the request"⎵HTTP-return-code⎵number-of-bytes-served⎵some-more-stuff
                    logLine = unsortedLog[i].Split(' ');
                    //We only want the second part of the line as that is the part that contains the IP Address.
                    ipString = logLine[1];

                }

                catch (System.Exception)
                {
                    //This creates an error message box that lets the user know the file they provided did not have the proper formats.
                    MessageBox.Show("Selected file is not properly formatted (IP addresses could not be properly detected).");
                    //Since this genereated an error we "break" out of the "Go Button Method"
                    return;
                }

                //This is a test that detects if the IP Address that we just took from the log file is indeed an ip address.
                System.Net.IPAddress ipAddress = null;
                if (System.Net.IPAddress.TryParse(ipString, out ipAddress) == false)
                {
                    //This creates an error message box that lets the user know the file they provided did not have the proper formats.
                    MessageBox.Show("Selected file is not properly formatted(IP addresses could not be properly detected).");
                    //Since this genereated an error we "break" out of the "Go Button Method"
                    return;
                }

                //This checks through the list of unique IP addresses found already and checks to see if the IP address in this line is unique or not.
                for (int j = 0; j <uniqueIPsFound; j++)
                    {
                        //Tests the ip address of the string against the ip address of hitters array to see if it matches any of the current entries
                        if ((hitters[j].getIP() == ipString))
                        {
                        //Adds one to the hitter count for the hitter whose IP it matches 
                        hitters[j].setHitCount(hitters[j].getHitCount() + 1);

                        //Sets the variable to false so that it knows for this iteration the IP address was not a new IP address
                        ipNew = false;
                        }
                       

                    }

                //This makes sure the IP Address is new and it allows the user to 
                if (ipNew == true)
                {
                    //If the special IP address is found this well increase the counter for that IP Address instead of putting a new entry in the array of hitters.
                    if (ipString == "140.211.167.204")
                    {
                        //This increase the special IP address count
                        specialIPHitCounter++;
                    }
                    //If it wasn't the special IP a new entry in the array is made.
                    else
                    {
                        //generates a new hitter for the unique IP address.
                        hitters[uniqueIPsFound] = new hitter();
                        //sets the IP address of the new hitter to the IP address taken from the log
                        hitters[uniqueIPsFound].setIP(ipString);
                        //This increase the count of the different IP address founds which allows us to cycle through them in the previous for loop.
                        uniqueIPsFound++;
                    }

                }

            }


            //Data processing

            //New hitter array that is the size of how many unique ip address that were found during the processing of the log.
            hitter[] hittersList = new hitter[uniqueIPsFound];

            //This for loop takes the list of the IP addresses out of the hitters array to allow the sorting algorithm to sort the hitters in decending order without dealing with any null entries.
            for (int i = 0; i < uniqueIPsFound; i++)
            {
                //Copies the data from hitters to hittersList
                hittersList[i] = hitters[i];
            }
            

            //This algorithm sorts the data in descending order.
            Array.Sort(hittersList, delegate (hitter x, hitter y) { return y.hit_count.CompareTo(x.hit_count); });

            //This for loops calculates the mean for the top 100 entries.
            for(int i = 0; i < 100; i++)
            {
                //This adds the hit count for each of the top 100 IP addresses in one place.
                holder += hittersList[i].getHitCount();

                //Once i gets to its last iteration it calculates the mean
                if(i == 99)
                {
                    //Calculating the mean of the top 100 IP addresses.
                    hitMean = holder / 100;
                }
            }
            
            //This for loop prints the top 100 entries to the textbox.
            for (int i = 0; i < 100; i++)
            {
                display_Box.Items.Add(hittersList[i].getIP() + "  -  " + hittersList[i].getHitCount());
            }

            //This section prints out the additional information required.
            //Space Holder Bar
            display_Box.Items.Add("______________________");
            //Prints out the number of times the special IP address was encountered in the log file.
            display_Box.Items.Add("Special IP address: 140.211.167.204 Hits: " + specialIPHitCounter);
            //Prints out the IP address with the maximum number of hits and how many hits it had.
            display_Box.Items.Add("Maximum Hitter: " + hittersList[0].getIP() + " number of hits: " + hittersList[0].getHitCount());
            //Prints out the IP address with the minimum number of hits and how many hits it had.
            display_Box.Items.Add("Minimum Hitter: " + hittersList[99].getIP() + " number of hits: " + hittersList[99].getHitCount());
            //Prints out the mean number of hits.
            display_Box.Items.Add("Mean Number of hits: " + hitMean);
        }

        private void display_Textbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
