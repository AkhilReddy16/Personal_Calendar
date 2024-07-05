using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Calendar
{
    public partial class Form2 : Form
    {
        int month, year, listCount;
        ArrayList eventList = new ArrayList();
        public Form2()
        {
            InitializeComponent();
        }

        private void daycontainer_Paint(object sender, PaintEventArgs e)
        {

        }

        public void setEventList(ArrayList eventRecords)
        {
            eventList = eventRecords;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listCount = 0;
            displaydays();
        }

        private void displaydays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;
            DateTime startofthemonth = new DateTime(now.Year, now.Month, 1);
            Console.WriteLine(month + year);
            int days = DateTime.DaysInMonth(now.Year, now.Month);

            int daysofweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < daysofweek; i++)
            {
                BlankDay ucblank = new BlankDay();
                daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                ListBox listbox1 = new ListBox();
                listCount++;
                listbox1.Location = new System.Drawing.Point(10, 27);
                listbox1.Name = "ListBox" + listCount;
                listbox1.Size = new System.Drawing.Size(140, 90);
                listbox1.BackColor = System.Drawing.SystemColors.Info;
                listbox1.ForeColor = System.Drawing.Color.Firebrick;
                Event tempEvent;
                for (int j = 0; j < eventList.Count; j++)
                {

                    tempEvent = (Event)eventList[j];
                    String eventStart = tempEvent.getStartDate().ToString().Split(' ').FirstOrDefault();
                    String eventEnd = tempEvent.getEndDate().ToString().Split(' ').FirstOrDefault();
                    int eventStartMonth = Int32.Parse(eventStart.Split('/').FirstOrDefault());
                    int eventEndMonth = Int32.Parse(eventEnd.Split('/').FirstOrDefault());
                    int eventStartDate = Int32.Parse(eventStart.Split('/').Skip(1).FirstOrDefault());
                    int eventEndDate = Int32.Parse(eventEnd.Split('/').Skip(1).FirstOrDefault());
                    int eventStartHour = Int32.Parse(tempEvent.getStartDate().ToString().Split(' ').Skip(1).FirstOrDefault().Split(':').FirstOrDefault());
                    int eventEndHour = Int32.Parse(tempEvent.getEndDate().ToString().Split(' ').Skip(1).FirstOrDefault().Split(':').FirstOrDefault());
                    string eventStartTime = tempEvent.getStartDate().ToString().Split(' ').Skip(1).FirstOrDefault();
                    string eventEndTime = tempEvent.getEndDate().ToString().Split(' ').Skip(1).FirstOrDefault();
                    if (eventStartMonth == month && eventStartDate == i)
                    {
                        if (eventStartMonth == eventEndMonth && eventStartDate == eventEndDate)
                        {
                            if (eventStartHour < 10 && eventEndHour < 10)
                                listbox1.Items.Add(tempEvent.getTitle() + "  " + eventStartTime.Substring(0, 4) + " to " + eventEndTime.Substring(0, 4));
                            else if (eventStartHour > 10 && eventEndHour > 10)
                                listbox1.Items.Add(tempEvent.getTitle() + "  " + eventStartTime.Substring(0, 5) + " to " + eventEndTime.Substring(0, 5));
                            else if (eventStartHour > 10 && eventEndHour < 10)
                                listbox1.Items.Add(tempEvent.getTitle() + "  " + eventStartTime.Substring(0, 5) + " to " + eventEndTime.Substring(0, 4));
                            else if (eventStartHour < 10 && eventEndHour > 10)
                                listbox1.Items.Add(tempEvent.getTitle() + "  " + eventStartTime.Substring(0, 4) + " to " + eventEndTime.Substring(0, 5));
                        }
                        else
                        {
                            if (eventStartHour < 10)
                                listbox1.Items.Add(tempEvent.getTitle() + " from " + eventStartTime.Substring(0, 4));
                            else
                            {
                                listbox1.Items.Add(tempEvent.getTitle() + " from " + eventStartTime.Substring(0, 5));
                            }
                        }

                    }
                    else if (eventEndMonth == month && eventEndDate == i)
                    {
                        if (eventStartHour < 10)
                            listbox1.Items.Add(tempEvent.getTitle() + " till " + eventEndTime.Substring(0, 4));
                        else
                        {
                            listbox1.Items.Add(tempEvent.getTitle() + " till " + eventEndTime.Substring(0, 5));
                        }
                    }
                }
                NonBlankDay ucdays = new NonBlankDay();
                if (listbox1.Items.Count > 0)
                {
                    ucdays.Controls.Add(listbox1);
                }
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }


        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            month--;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;
            DateTime now = DateTime.Now;
            DateTime startofthemonth = new DateTime(year, month, 1);
            Console.WriteLine(month + year);
            int days = DateTime.DaysInMonth(year, month);

            int daysofweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < daysofweek; i++)
            {
                BlankDay ucblank = new BlankDay();
                daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                ListBox listbox1 = new ListBox();
                listCount++;
                listbox1.Location = new System.Drawing.Point(10, 27);
                listbox1.Name = "ListBox" + listCount;
                listbox1.Size = new System.Drawing.Size(140, 90);
                listbox1.BackColor = System.Drawing.SystemColors.Info;
                listbox1.ForeColor = System.Drawing.Color.Firebrick;
                Event tempEvent;
                for (int j = 0; j < eventList.Count; j++)
                {

                    tempEvent = (Event)eventList[j];
                    String eventStart = tempEvent.getStartDate().ToString().Split(' ').FirstOrDefault();
                    String eventEnd = tempEvent.getEndDate().ToString().Split(' ').FirstOrDefault();
                    int eventStartMonth = Int32.Parse(eventStart.Split('/').FirstOrDefault());
                    int eventEndMonth = Int32.Parse(eventEnd.Split('/').FirstOrDefault());
                    int eventStartDate = Int32.Parse(eventStart.Split('/').Skip(1).FirstOrDefault());
                    int eventEndDate = Int32.Parse(eventEnd.Split('/').Skip(1).FirstOrDefault());
                    int eventStartHour = Int32.Parse(tempEvent.getStartDate().ToString().Split(' ').Skip(1).FirstOrDefault().Split(':').FirstOrDefault());
                    int eventEndHour = Int32.Parse(tempEvent.getEndDate().ToString().Split(' ').Skip(1).FirstOrDefault().Split(':').FirstOrDefault());
                    string eventStartTime = tempEvent.getStartDate().ToString().Split(' ').Skip(1).FirstOrDefault();
                    string eventEndTime = tempEvent.getStartDate().ToString().Split(' ').Skip(1).FirstOrDefault();
                    if (eventStartMonth == month && eventStartDate == i)
                    {
                        if (eventStartMonth == eventEndMonth && eventStartDate == eventEndDate)
                        {
                            if (eventStartHour < 10 && eventEndHour < 10)
                                listbox1.Items.Add(tempEvent.getTitle() + "  " + eventStartTime.Substring(0, 4) + " to " + eventEndTime.Substring(0, 4));
                            else if (eventStartHour > 10 && eventEndHour > 10)
                                listbox1.Items.Add(tempEvent.getTitle() + "  " + eventStartTime.Substring(0, 5) + " to " + eventEndTime.Substring(0, 5));
                            else if (eventStartHour > 10 && eventEndHour < 10)
                                listbox1.Items.Add(tempEvent.getTitle() + "  " + eventStartTime.Substring(0, 5) + " to " + eventEndTime.Substring(0, 4));
                            else if (eventStartHour < 10 && eventEndHour > 10)
                                listbox1.Items.Add(tempEvent.getTitle() + "  " + eventStartTime.Substring(0, 4) + " to " + eventEndTime.Substring(0, 5));
                        }
                        else
                        {
                            if (eventStartHour < 10)
                                listbox1.Items.Add(tempEvent.getTitle() + " from " + eventStartTime.Substring(0, 4));
                            else
                            {
                                listbox1.Items.Add(tempEvent.getTitle() + " from " + eventStartTime.Substring(0, 5));
                            }
                        }

                    }
                    else if (eventEndMonth == month && eventEndDate == i)
                    {
                        if (eventStartHour < 10)
                            listbox1.Items.Add(tempEvent.getTitle() + " till " + eventEndTime.Substring(0, 4));
                        else
                        {
                            listbox1.Items.Add(tempEvent.getTitle() + " till " + eventEndTime.Substring(0, 5));
                        }
                    }
                }

                NonBlankDay ucdays = new NonBlankDay();
                if (listbox1.Items.Count > 0)
                {
                    ucdays.Controls.Add(listbox1);
                }
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }

        }

        private void btnnxt_Click(object sender, EventArgs e)
        {

            daycontainer.Controls.Clear();
            month++;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;
            DateTime startofthemonth = new DateTime(year, month, 1);
            Console.WriteLine(month + year);
            int days = DateTime.DaysInMonth(year, month);

            int daysofweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < daysofweek; i++)
            {
                BlankDay ucblank = new BlankDay();
                daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                ListBox listbox1 = new ListBox();
                listCount++;
                listbox1.Location = new System.Drawing.Point(10, 27);
                listbox1.Name = "ListBox" + listCount;
                listbox1.Size = new System.Drawing.Size(140, 90);
                listbox1.BackColor = System.Drawing.SystemColors.Info;
                listbox1.ForeColor = System.Drawing.Color.Firebrick;

                Event tempEvent;

                for (int j = 0; j < eventList.Count; j++)
                {

                    tempEvent = (Event)eventList[j];
                    String eventStart = tempEvent.getStartDate().ToString().Split(' ').FirstOrDefault();
                    String eventEnd = tempEvent.getEndDate().ToString().Split(' ').FirstOrDefault();
                    int eventStartMonth = Int32.Parse(eventStart.Split('/').FirstOrDefault());
                    int eventEndMonth = Int32.Parse(eventEnd.Split('/').FirstOrDefault());
                    int eventStartDate = Int32.Parse(eventStart.Split('/').Skip(1).FirstOrDefault());
                    int eventEndDate = Int32.Parse(eventEnd.Split('/').Skip(1).FirstOrDefault());
                    int eventStartHour = Int32.Parse(tempEvent.getStartDate().ToString().Split(' ').Skip(1).FirstOrDefault().Split(':').FirstOrDefault());
                    int eventEndHour = Int32.Parse(tempEvent.getEndDate().ToString().Split(' ').Skip(1).FirstOrDefault().Split(':').FirstOrDefault());
                    string eventStartTime = tempEvent.getStartDate().ToString().Split(' ').Skip(1).FirstOrDefault();
                    string eventEndTime = tempEvent.getEndDate().ToString().Split(' ').Skip(1).FirstOrDefault();
                    if (eventStartMonth == month && eventStartDate == i)
                    {
                        if (eventStartMonth == eventEndMonth && eventStartDate == eventEndDate)
                        {
                            if (eventStartHour < 10 && eventEndHour < 10)
                                listbox1.Items.Add(tempEvent.getTitle() + "  " + eventStartTime.Substring(0, 4) + " to " + eventEndTime.Substring(0, 4));
                            else if (eventStartHour > 10 && eventEndHour > 10)
                                listbox1.Items.Add(tempEvent.getTitle() + "  " + eventStartTime.Substring(0, 5) + " to " + eventEndTime.Substring(0, 5));
                            else if (eventStartHour > 10 && eventEndHour < 10)
                                listbox1.Items.Add(tempEvent.getTitle() + "  " + eventStartTime.Substring(0, 5) + " to " + eventEndTime.Substring(0, 4));
                            else if (eventStartHour < 10 && eventEndHour > 10)
                                listbox1.Items.Add(tempEvent.getTitle() + "  " + eventStartTime.Substring(0, 4) + " to " + eventEndTime.Substring(0, 5));
                        }
                        else
                        {
                            if (eventStartHour < 10)
                                listbox1.Items.Add(tempEvent.getTitle() + " from " + eventStartTime.Substring(0, 4));
                            else
                            {
                                listbox1.Items.Add(tempEvent.getTitle() + " from " + eventStartTime.Substring(0, 5));
                            }
                        }

                    }
                    else if (eventEndMonth == month && eventEndDate == i)
                    {
                        if (eventStartHour < 10)
                            listbox1.Items.Add(tempEvent.getTitle() + " till " + eventEndTime.Substring(0, 4));
                        else
                        {
                            listbox1.Items.Add(tempEvent.getTitle() + " till " + eventEndTime.Substring(0, 5));
                        }
                    }
                }
                NonBlankDay ucdays = new NonBlankDay();
                if (listbox1.Items.Count > 0)
                {
                    ucdays.Controls.Add(listbox1);
                }
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }

        }
    }
}
