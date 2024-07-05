using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Personal_Calendar
{
    public partial class Form1 : Form
    {
        Employee employee = new Employee();
        ArrayList eventList = new ArrayList();
        Event selectedEvent = new Event();
        ArrayList reportees = new ArrayList();
        Meeting meeting = new Meeting();
        List<DateTime> availableSlots = new List<DateTime>();

        public Form1()
        {
            InitializeComponent();
        }

        private void exitEmployeeButton_Click(object sender, EventArgs e)
        {
            employee = new Employee();
            employeeCalendar.Visible = false;
            loginTableLayout.Visible = true;
        }

        private void eventListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEvent = (Event)eventList[eventListView.SelectedIndex];
            editeventListbox.Items.Clear();
            viewEventText.Text = "Event Title: "+ selectedEvent.getTitle()+
                "\n Event Description: "+ selectedEvent.getDescription()+
                "\n Event Start Date & Time: "+selectedEvent.getStartDate()+
                "\n Event End Date & Time: " + selectedEvent.getEndDate();
            viewEventLayout.Visible = true;
            viewTableLayout.Visible = false;
        }

        private void viewEventEmployee_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            Console.WriteLine("Akhil: "+ selectedDate.ToString("yyyy-MM-dd")+"  id: "+ employee.getEmployeeId());
            Event newEvent = new Event();
            eventListView.Items.Clear();
            eventList = newEvent.retriveEvents(employee.getEmployeeId(), selectedDate);
            if (eventList.Count > 0)
            {
                Event tempEvent;
                for (int i = 0; i < eventList.Count; i++)
                {
                    tempEvent = (Event)eventList[i];
                    eventListView.Items.Add("                                      " + tempEvent.getTitle());
                }
                viewTableLayout.Visible = true;
                employeeCalendar.Visible = false;
            }
            else {
                deleteEventMessageLabel.Text = "no events to View.";
                deleteMessageTableLayout.Visible = true;
                employeeCalendar.Visible = false;
            }
        }

        private void editEventEmployee_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar2.SelectionStart;
            Console.WriteLine("Akhil: " + selectedDate.ToString("yyyy-MM-dd") + "  id: " + employee.getEmployeeId());
            Event newEvent = new Event();
            eventList = newEvent.retriveEvents(employee.getEmployeeId(), selectedDate);
            if (eventList.Count > 0)
            {
                Event tempEvent;
                for (int i = 0; i < eventList.Count; i++)
                {
                    tempEvent = (Event)eventList[i];
                    editeventListbox.Items.Add("                                      " + tempEvent.getTitle());
                }
                editEventTableLayout.Visible = true;
                employeeCalendar.Visible = false;
            }
            else
            {
                deleteEventMessageLabel.Text = "no events to Edit.";
                deleteMessageTableLayout.Visible = true;
                employeeCalendar.Visible = false;
            }
        }

        private void deleteEventEmployee_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar2.SelectionStart;
            Console.WriteLine("Akhil: " + selectedDate.ToString("yyyy-MM-dd") + "  id: " + employee.getEmployeeId());
            Event newEvent = new Event();
            eventList = newEvent.retriveEvents(employee.getEmployeeId(), selectedDate);
            if (eventList.Count > 0)
            {
                Event tempEvent;
                for (int i = 0; i < eventList.Count; i++)
                {
                    tempEvent = (Event)eventList[i];
                    deleteEventList.Items.Add("                                      " + tempEvent.getTitle());
                }
                deleteEventTableLayout.Visible = true;
                employeeCalendar.Visible = false;
            }
            else
            {
                deleteEventMessageLabel.Text = "no events to Delete.";
                deleteMessageTableLayout.Visible = true;
                employeeCalendar.Visible = false;
            }
        }

        private void viewEventManager_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar2.SelectionStart;
            Console.WriteLine("Akhil: " + selectedDate.ToString("yyyy-MM-dd") + "  id: " + employee.getEmployeeId());
            Event newEvent = new Event();
            eventList = newEvent.retriveEvents(employee.getEmployeeId(), selectedDate);
            eventListView.Items.Clear();
            if (eventList.Count > 0)
            {
                Event tempEvent;
                for (int i = 0; i < eventList.Count; i++)
                {
                    tempEvent = (Event)eventList[i];
                    eventListView.Items.Add("                                      " + tempEvent.getTitle());
                }
                viewTableLayout.Visible = true;
                managerCalendar.Visible = false;
            }
            else {
                deleteEventMessageLabel.Text = "no events to View.";
                deleteMessageTableLayout.Visible = true;
                managerCalendar.Visible = false;
            }
        }

        private void editEventManager_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar2.SelectionStart;
            Console.WriteLine("Akhil: " + selectedDate.ToString("yyyy-MM-dd") + "  id: " + employee.getEmployeeId());
            Event newEvent = new Event();
            eventList = newEvent.retriveEvents(employee.getEmployeeId(), selectedDate);
            if (eventList.Count > 0)
            {
                Event tempEvent;
                for (int i = 0; i < eventList.Count; i++)
                {
                    tempEvent = (Event)eventList[i];
                    editeventListbox.Items.Add("                                      " + tempEvent.getTitle());
                }
                editEventTableLayout.Visible = true;
                managerCalendar.Visible = false;
            }
            else
            {
                deleteEventMessageLabel.Text = "no events to edit.";
                deleteMessageTableLayout.Visible = true;
                managerCalendar.Visible = false;
            }
        }

        private void deleteEventManager_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar2.SelectionStart;
            Console.WriteLine("Akhil: " + selectedDate.ToString("yyyy-MM-dd") + "  id: " + employee.getEmployeeId());
            Event newEvent = new Event();
            eventList = newEvent.retriveEvents(employee.getEmployeeId(), selectedDate);
            if (eventList.Count > 0)
            {
                Event tempEvent;
                for (int i = 0; i < eventList.Count; i++)
                {
                    tempEvent = (Event)eventList[i];
                    deleteEventList.Items.Add("                                      " + tempEvent.getTitle());
                }
                deleteEventTableLayout.Visible = true;
                managerCalendar.Visible = false;
            } else {
                deleteEventMessageLabel.Text = "no events to delete.";
                deleteMessageTableLayout.Visible = true;
                managerCalendar.Visible = false;
            }
        }

        private void logoutManager_Click(object sender, EventArgs e)
        {
            employee = new Employee();
            managerCalendar.Visible = false;
            loginTableLayout.Visible = true;
        }

        private void backButtonView_Click(object sender, EventArgs e)
        {
            viewTableLayout.Visible = false;
            if (isManager())
                managerCalendar.Visible = true;
            else
                employeeCalendar.Visible = true;
        }

        private void addEventEmployeeButton_Click(object sender, EventArgs e)
        {
            addEventEmployeeTableLayout.Visible = true;
            employeeCalendar.Visible = false;
        }

        private void addEventManager_Click(object sender, EventArgs e)
        {
            addEventEmployeeTableLayout.Visible = true;
            managerCalendar.Visible = false;
        }

        private void backAddEventEmployee_Click(object sender, EventArgs e)
        {
            addEventEmployeeTableLayout.Visible = false;
            if(isManager())
                managerCalendar.Visible = true;
            else
                employeeCalendar.Visible = true;
        }

        private void scheduleMeetingManager_Click(object sender, EventArgs e)
        {
            reportees = employee.getManagerEmployees(employee.getEmployeeId());
            meetingAttendesTextBox.Items.Clear();
            for (int i = 0; i < reportees.Count; i++)
            {
                int reporteeId = (int)reportees[i];
                meetingAttendesTextBox.Items.Add(reporteeId);
            }
            schedulemeetingTableLayout.Visible = true;
            managerCalendar.Visible = false;
        }

        private Boolean validateEmployeeId(Employee employee, int employeeId)
        {
            return employee.getEmployeeId() != -1 && employee.getEmployeeId() == employeeId;
        }

        private Boolean validatePassword(Employee employee, String employeeId)
        {
            return employee.getPassword() != null && employeeId.Equals(employee.getPassword());
        }

        private Boolean isManager()
        {
            return employee.getRole() != null && employee.getRole().ToLower().Equals("manager");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int employeeId;
            int.TryParse(userIdTextBox.Text, out employeeId);
            employee.getEmployeeIdPassword(employeeId);

            String password = passwordTextBox.Text;

            userIdTextBox.Text = "";
            passwordTextBox.Text = "";

            if (!validateEmployeeId(employee, employeeId))
            {
                loginTableLayout.Visible = false;
                invalidLoginLayout.Visible = true;
            }
            else if (!validatePassword(employee, password))
            {
                loginTableLayout.Visible = false;
                invalidLoginLayout.Visible = true;
            }
            else if (isManager())
            {
                managerCalendar.Visible = true;
                loginTableLayout.Visible = false;
            }
            else
            {
                employeeCalendar.Visible = true;
                loginTableLayout.Visible = false;
            }
        }

        private void saveAddEventEmployee_Click(object sender, EventArgs e)
        {
            Event newEvent = new Event(eventTitleAddEventTextBox.Text,
                                       descriptionaddEventTextBox.Text,
                                       addEventStartDateDateandTimePicker.Value,
                                       addEventEndTimeDateandTimePicker.Value);
            int addStatus = newEvent.addEvent(employee.getEmployeeId());
            addEventEmployeeTableLayout.Visible = false;
            if (addStatus == 1) {
                addEventErrorMessageTableLayout.Visible = true;
            } else {
                addEventMessageTableLayout.Visible = true;
            }
            eventTitleAddEventTextBox.Text = "";
            descriptionaddEventTextBox.Text = "";
        }

        private void saveMeetingButton_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            ArrayList attendeesList = new ArrayList();
            for (int i = 0; i < meetingAttendesTextBox.SelectedIndices.Count; i++) {
                attendeesList.Add(reportees[meetingAttendesTextBox.SelectedIndices[i]]);
            }
            Console.WriteLine("attendeesList: " + attendeesList.Count);
            meeting = new Meeting(meetingEventTitleTextBox.Text, meetingDescriptionTexBoxt.Text, attendeesList);
            meetingEventTitleTextBox.Text = "";
            meetingDescriptionTexBoxt.Text = "";
            meetingAttendesTextBox.Items.Clear();
            availableSlots = selectedEvent.getAvailableSlots(attendeesList, selectedDate);
            for (int i = 0; i < availableSlots.Count; i++)
            {
                Console.WriteLine("time slot: "+ availableSlots[i]);
                timeslotListBox.Items.Add(((DateTime)availableSlots[i]).ToString("hh:mm tt") + "-"
                    + ((DateTime)availableSlots[i]).AddHours(1).ToString("hh:mm tt"));
            }
            
            attendesTimeslotAvalabilityTableLayout.Visible = true;
            schedulemeetingTableLayout.Visible = false;
        }

        private void backMeetingButton_Click(object sender, EventArgs e)
        {
            meetingEventTitleTextBox.Text = "";
            meetingDescriptionTexBoxt.Text = "";
            meetingAttendesTextBox.Items.Clear();
            managerCalendar.Visible = true;
            schedulemeetingTableLayout.Visible = false;
        }

        private void viewMonthlyManager_Click(object sender, EventArgs e)
        {
            eventList = selectedEvent.retriveEvents(employee.getEmployeeId());
            Form2 f2 = new Form2();
            f2.setEventList(eventList);
            f2.Show();
            //managerCalendar.Visible = false;
            //viewMonthlyCalendarTableLayout.Visible = true;
        }

        private void viewMonthlyCalendarEmployeeButton_Click(object sender, EventArgs e)
        {
            eventList = selectedEvent.retriveEvents(employee.getEmployeeId());
            Form2 f2 = new Form2();
            f2.setEventList(eventList);
            f2.Show();
            //employeeCalendar.Visible = false;
            //viewMonthlyCalendarTableLayout.Visible = true;
        }

        private void editupdationBackButton_Click(object sender, EventArgs e)
        {
            editMessageTableLayout.Visible = false;
            if (isManager())
                managerCalendar.Visible = true;
            else
                employeeCalendar.Visible = true;

        }

        private void addEventMessageBackButton_Click(object sender, EventArgs e)
        {
            addEventMessageTableLayout.Visible = false;
            if (isManager())
                managerCalendar.Visible = true;
            else
                employeeCalendar.Visible = true;
        }

        private void editEventFormSaveButton_Click(object sender, EventArgs e)
        {
            selectedEvent = new Event(selectedEvent.getEventId(),
                                      editEventeventTitleTextBox.Text,
                                      editEventDescriptionTetBox.Text,
                                      selectedEvent.getStartDate(),
                                      selectedEvent.getEndDate()) ;
            int editCode = selectedEvent.editEvent(employee.getEmployeeId(), editEventStartDateDateandTimePicker.Value,
                                      editEventEndDateDateandTimePicker.Value);
            editEventFormTableLayout.Visible = false;
            if(editCode == 1)
                addEventErrorMessageTableLayout.Visible = true;
            else
                editMessageTableLayout.Visible = true;
        }

        private void backButtonDelete_Click(object sender, EventArgs e)
        {
            deleteEventTableLayout.Visible = false;
            if (isManager())
                managerCalendar.Visible = true;
            else
                employeeCalendar.Visible = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteEventMessageLabel.Text = "The event is Deleted Successfully."; 
            deleteMessageTableLayout.Visible = true;
            deleteEventTableLayout.Visible = false;
        }

        private void deleteMessageBackButton_Click(object sender, EventArgs e)
        {
            deleteMessageTableLayout.Visible = false;
            if (isManager())
                managerCalendar.Visible = true;
            else
                employeeCalendar.Visible = true;
        }

        private void loginClearAllButton_Click(object sender, EventArgs e)
        {
            userIdTextBox.Text = "";
            passwordTextBox.Text = "";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            loginTableLayout.Visible = true;
            invalidLoginLayout.Visible = false;
        }

        private void backButton1_Click(object sender, EventArgs e)
        {
            viewEventLayout.Visible = false;
            viewTableLayout.Visible = true;
        }

        private void editEventFormBackButton_Click(object sender, EventArgs e)
        {
            if (isManager())
                managerCalendar.Visible = true;
            else
                employeeCalendar.Visible = true;
            editEventFormTableLayout.Visible = false;
        }

        private void backEditButton_Click(object sender, EventArgs e)
        {
            if (isManager())
                managerCalendar.Visible = true;
            else
                employeeCalendar.Visible = true;
            editEventTableLayout.Visible = false;
        }

        private void editeventListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEvent = (Event)eventList[editeventListbox.SelectedIndex];
            editeventListbox.Items.Clear();
            editEventeventTitleTextBox.Text = selectedEvent.getTitle();
            editEventStartDateDateandTimePicker.Value = selectedEvent.getStartDate();
            editEventEndDateDateandTimePicker.Value = selectedEvent.getEndDate();
            editEventDescriptionTetBox.Text = selectedEvent.getDescription();
            editEventTableLayout.Visible = false;
            editEventFormTableLayout.Visible = true;
        }

        private void backAddEventErrorButton_Click(object sender, EventArgs e)
        {
            addEventErrorMessageTableLayout.Visible = false;
            if (isManager())
                managerCalendar.Visible = true;
            else
                employeeCalendar.Visible = true;
        }

        private void deleteEventList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEvent = (Event)eventList[deleteEventList.SelectedIndex];
            selectedEvent.deleteEvent();
            deleteMessageTableLayout.Visible = true;
            deleteEventTableLayout.Visible = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("timeslotListBox.SelectedIndex: " + timeslotListBox.SelectedIndex);
            meeting.setStartDate((DateTime)availableSlots[timeslotListBox.SelectedIndex]);
            meeting.setEndDate(((DateTime)availableSlots[timeslotListBox.SelectedIndex]).AddHours(1));
            meeting.setLocation(locationTextBox.Text);
            int status = meeting.saveMeeting(employee.getEmployeeId());
            timeslotListBox.Items.Clear();
            locationTextBox.Text = "";
            attendesTimeslotAvalabilityTableLayout.Visible = false;
            meetingMessageTableLayout.Visible = true;
        }

        private void timeslotBackButton_Click(object sender, EventArgs e)
        {
            meetingAttendesTextBox.Items.Clear();
            locationTextBox.Text = "";
            attendesTimeslotAvalabilityTableLayout.Visible = false;
            schedulemeetingTableLayout.Visible = true;
        }

        private void backMeetingMessageButton_Click(object sender, EventArgs e)
        {
            meetingAttendesTextBox.Items.Clear();
            locationTextBox.Text = "";
            meetingMessageTableLayout.Visible = false;
            managerCalendar.Visible = true;
        }
    }
}
