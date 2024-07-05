using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Calendar
{
    class Event
    {
        private int eventId;
        private String title;
        private String description;
        private DateTime startDate;
        private DateTime endDate;
        private IEnumerable<DateTime> slotsList;


        public Event() { }

        public Event(int eventId, String title, String description, DateTime startDate, DateTime endDate ) {
            this.eventId = eventId;
            this.title = title;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public Event(String title, String description, DateTime startDate, DateTime endDate)
        {
            this.eventId = -1;
            this.title = title;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public int getEventId()
        {
            return this.eventId;
        }

        public String getTitle() { 
            return this.title;
        }

        public String getDescription() {
            return this.description;
        }

        public DateTime getStartDate() {
            return this.startDate;
        }

        public DateTime getEndDate()
        {
            return this.endDate;
        }


        private bool checkConflict(int employeeid, DateTime startDateAndTime, DateTime endDateAndTime)
        {
            int numberOfConflictEvents = 0;
            Boolean checkIfConflict = true;
            string connStr = " server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                String sql = "SELECT count(*) from kommareddy_event WHERE (employeeid=@id) AND ((startDateAndTime <= @startDateAndTime AND startDateAndTime >= @startDateAndTime) OR (endDateAndTime <= @startDateAndTime AND endDateAndTime >= @endDateAndTime))";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                Console.WriteLine("sql value" + sql);
                cmd.Parameters.AddWithValue("@id", employeeid);
                cmd.Parameters.AddWithValue("@startDateAndTime", startDateAndTime);
                cmd.Parameters.AddWithValue("@endDateAndTime", endDateAndTime);
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    numberOfConflictEvents = Int32.Parse(myReader[0].ToString());
                    Console.WriteLine("numberOfConflictEvents " + numberOfConflictEvents);
                }
                myReader.Close();
                if (numberOfConflictEvents > 0)
                    checkIfConflict = true;
                else
                    checkIfConflict = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("startdateandtime" + startDateAndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("enddateandtime" + endDateAndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            return checkIfConflict;
        }

        public int addEvent(int employeeId)
        {
            bool result = checkConflict(employeeId, this.startDate, this.endDate);
            Console.WriteLine("result conflict " + result);

            if (result)
            {
                return 1;
            } else {
                string connStr = " server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    string sql = "SELECT MAX(eventid) FROM kommareddy_event;";
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                    MySqlDataReader myReader = cmd.ExecuteReader();
                    if (myReader.Read())
                    {
                        this.eventId = Int32.Parse(myReader[0].ToString());
                        Console.WriteLine("newEventId" + this.eventId);
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
                Console.WriteLine("Done.");
                if (eventId == -1)
                {
                    Console.WriteLine("Error:  Cannot find and assign a new event id.");
                }
                else
                {

                    connStr = " server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
                    conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

                    try
                    {
                        this.eventId += 1;
                        Console.WriteLine("Connecting to MySQL...");
                        conn.Open();
                        string sql = "INSERT INTO kommareddy_event (eventid,title, startDateAndTime,endDateAndTime,description,employeeid,startDate,endDate) VALUES (@eventid,@title, @startDateAndTime,@endDateAndTime,@description,@id,@startDate,@endDate)";

                        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                        Console.WriteLine("sql value" + sql);

                        cmd.Parameters.AddWithValue("@eventid", this.eventId);
                        cmd.Parameters.AddWithValue("@id", employeeId);
                        cmd.Parameters.AddWithValue("@title", this.title);
                        cmd.Parameters.AddWithValue("@description", this.description);
                        cmd.Parameters.AddWithValue("@startDateAndTime", this.startDate);
                        cmd.Parameters.AddWithValue("@startDate", this.startDate.Date);
                        cmd.Parameters.AddWithValue("@endDateAndTime", this.endDate);
                        cmd.Parameters.AddWithValue("@endDate", this.endDate.Date);

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

        public ArrayList retriveEvents(int employeeId, DateTime date)
        {
            ArrayList eventList = new ArrayList();
            DataTable myTable = new DataTable();
            string connStr = " server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM kommareddy_event WHERE employeeid=@eID AND startDate=@date ORDER BY startDateAndTime ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eID", employeeId);
                cmd.Parameters.AddWithValue("@date", date.Date.ToString("yyyy-MM-dd").ToString());
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Event newEvent = new Event(Int32.Parse(row["eventid"].ToString()),
                                             row["title"].ToString(),
                                             row["description"].ToString(),
                                             DateTime.Parse(row["startDateAndTime"].ToString()),
                                             DateTime.Parse(row["endDateAndTime"].ToString()));

                eventList.Add(newEvent);
            }
            Console.WriteLine("*********" + eventList.Count);
            return eventList;
        }

        public ArrayList retriveEvents(int employeeId)
        {
            ArrayList eventList = new ArrayList();
            DataTable myTable = new DataTable();
            string connStr = " server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM kommareddy_event WHERE employeeid=@eID ORDER BY startDateAndTime ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eID", employeeId);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Event newEvent = new Event(Int32.Parse(row["eventid"].ToString()),
                                             row["title"].ToString(),
                                             row["description"].ToString(),
                                             DateTime.Parse(row["startDateAndTime"].ToString()),
                                             DateTime.Parse(row["endDateAndTime"].ToString()));

                eventList.Add(newEvent);
            }
            Console.WriteLine("*********" + eventList.Count);
            return eventList;
        }

        public int editEvent(int employeeId, DateTime newStartDate, DateTime newEndDate)
        {
            bool result = checkConflict(employeeId, newStartDate, newEndDate);
            Console.WriteLine("result conflict " + result);

            if (result && this.startDate != newStartDate && this.endDate != newEndDate)
            {
                return 1;
            } else {
                this.startDate = newStartDate;
                this.endDate = newEndDate;
                string connStr = " server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                try
                {

                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "update kommareddy_event set title=@title,startDateAndTime=@startDateAndTime,endDateAndTime=@endDateAndTime,description=@description,startDate=@startDate,endDate=@endDate where eventid=@eventid;";
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    Console.WriteLine("sql value" + sql);

                    cmd.Parameters.AddWithValue("@eventid", this.eventId);
                    cmd.Parameters.AddWithValue("@title", this.title);
                    cmd.Parameters.AddWithValue("@description", this.description);
                    cmd.Parameters.AddWithValue("@startDateAndTime", newStartDate);
                    cmd.Parameters.AddWithValue("@startDate", newStartDate.Date);
                    cmd.Parameters.AddWithValue("@endDateAndTime", newEndDate);
                    cmd.Parameters.AddWithValue("@endDate", newEndDate.Date);

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return 0;
            }
        }



        public void deleteEvent()
        {
            string connStr = " server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "delete from kommareddy_event where eventid=@eventid;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eventid", this.eventId);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public List<DateTime> getAvailableSlots(ArrayList attendees, DateTime selectedDate)
        {
            List<DateTime> allMeetingSlots = new List<DateTime>();
            List<DateTime> availableSlots = new List<DateTime>();

            DateTime startOfDay = DateTime.Today.AddHours(9);
            DateTime endOfDay = DateTime.Today.AddHours(17);

            // Create a list of all meeting slots for all attendees
            foreach (int attendee in attendees)
            {
                ArrayList eventList = retriveEvents(attendee, selectedDate);
                foreach (Event tempEvent in eventList)
                {
                    allMeetingSlots.Add(tempEvent.getStartDate());
                    allMeetingSlots.Add(tempEvent.getEndDate());
                }
            }

            allMeetingSlots.Sort();

            // If no schedules exist, add all possible slots for the day
            if (allMeetingSlots.Count == 0)
            {
                DateTime slotStart = startOfDay;
                while (slotStart + TimeSpan.FromMinutes(60) <= endOfDay)
                {
                    availableSlots.Add(slotStart);
                    slotStart += TimeSpan.FromMinutes(60);
                }
            }
            else
            {
                DateTime slotStart = startOfDay;
                DateTime firstMeetingSlot = allMeetingSlots[0];
                if (startOfDay < firstMeetingSlot)
                {
                    // Add slots from start of the day to the first meeting slot
                    DateTime slotEnd = firstMeetingSlot;
                    TimeSpan slotDuration = slotEnd - slotStart;

                    if (slotDuration >= TimeSpan.FromMinutes(60))
                    {
                        while (slotStart + TimeSpan.FromMinutes(60) <= slotEnd)
                        {
                            availableSlots.Add(slotStart);
                            slotStart += TimeSpan.FromMinutes(60);
                        }
                    }
                }

                
                
                foreach (DateTime meetingSlot in allMeetingSlots)
                {
                    DateTime slotEnd = meetingSlot;
                    TimeSpan slotDuration = slotEnd - slotStart;

                    if(slotDuration >= TimeSpan.FromMinutes(60))
                    {
                        while (slotStart + TimeSpan.FromMinutes(60) <= slotEnd)
                        {
                            availableSlots.Add(slotStart);
                            slotStart += TimeSpan.FromMinutes(60);
                        }
                    }
                    else if (slotDuration > TimeSpan.Zero)
                    {
                        slotStart = slotEnd.AddMinutes(60);
                    }
                    else
                    {
                        slotStart = slotEnd;
                    }
                }

                // Check the slot after the last meeting
                TimeSpan lastSlotDuration = endOfDay - slotStart;
                if (lastSlotDuration >= TimeSpan.FromMinutes(60))
                {
                    while (slotStart + TimeSpan.FromMinutes(60) <= endOfDay)
                    {
                        availableSlots.Add(slotStart);
                        slotStart += TimeSpan.FromMinutes(60);
                    }
                }
            }
            Console.WriteLine("availableSlots: " + availableSlots.Count);
            return availableSlots;
        }


    }
}
