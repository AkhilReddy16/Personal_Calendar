using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Calendar
{
    class Meeting
    {
        private int meetingId;
        private String title;
        private String description;
        private DateTime startDate;
        private DateTime endDate;
        private String location;
        private ArrayList attendees;

        public Meeting() { }

        public Meeting(String title, String description, ArrayList attendees) {
            this.title = title;
            this.description = description;
            this.attendees = attendees;
        }

        public void setLocation(String location) {
            this.location = location;
        }

        public void setStartDate(DateTime startDate) {
            this.startDate = startDate;
        }

        public void setEndDate(DateTime endDate) {
            this.endDate = endDate;
        }

        public String displayAttendees() {
            String attendeeString = "[ ";
            foreach(int s in attendees) {
                attendeeString += s + ", ";
            }
            return attendeeString+"]";
        }

        public int saveMeeting(int managerId) {
            Event newEvent = new Event(this.title, this.description, this.startDate, this.endDate);
            foreach(int attendeeId in this.attendees) {
               int status = newEvent.addEvent(attendeeId);
                if (status == 1) {
                    return 1;
                }
            }

            string connStr = " server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT MAX(meetingid) FROM kommareddy_schedulemeeting;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    this.meetingId = Int32.Parse(myReader[0].ToString());
                    Console.WriteLine("newEventId" + this.meetingId);
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            if (meetingId == -1)
            {
                Console.WriteLine("Error:  Cannot find and assign a new event id.");
            }
            else
            {

                connStr = " server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
                conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

                try
                {
                    this.meetingId += 1;
                    Console.WriteLine("Connecting to MySQL... "+ this.attendees);
                    conn.Open();
                    string sql = "INSERT INTO kommareddy_schedulemeeting (meetingid,managerid,title,description,startDate,endDate,meetingDate,location,attendees) VALUES (@meetingid,@managerid,@title,@description,@startDate,@endDate,@meetingDate,@location,@attendees)";

                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    Console.WriteLine("sql value" + sql);

                    cmd.Parameters.AddWithValue("@meetingid", this.meetingId);
                    cmd.Parameters.AddWithValue("@managerid", managerId);
                    cmd.Parameters.AddWithValue("@title", this.title);
                    cmd.Parameters.AddWithValue("@description", this.description);
                    cmd.Parameters.AddWithValue("@startDate", this.startDate);
                    cmd.Parameters.AddWithValue("@meetingDate", this.startDate.Date);
                    cmd.Parameters.AddWithValue("@endDate", this.endDate);
                    cmd.Parameters.AddWithValue("@location", this.location);
                    cmd.Parameters.AddWithValue("@attendees", displayAttendees());
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }
            return 0;
        }
    }
}
