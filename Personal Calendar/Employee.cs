

using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;

namespace Personal_Calendar
{
    class Employee
    {
        private int employeeId;
        private String password;
        private int managerId;
        private String role;

        public int getEmployeeId()
        {
            return this.employeeId;
        }

        public String getPassword()
        {
            return this.password;
        }

        public String getRole()
        {
            return this.role;
        }

        public void getEmployeeIdPassword(int employeeId)
        {
            DataTable myTable = new DataTable();
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM kommareddy_employee WHERE employeeid = @employeeId";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            foreach (DataRow row in myTable.Rows)
            {
                this.employeeId = (int)row["employeeid"];
                this.password = (string)row["password"];
                this.managerId = (int)row["managerid"];
                this.role = (string)row["role"];
            }
            Console.WriteLine("employee: " + this.ToString());
            return;
        }

        public ArrayList getManagerEmployees(int managerId) {
            ArrayList employees = new ArrayList();
            DataTable myTable = new DataTable();
            string connStr = " server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT employeeid FROM kommareddy_employee WHERE managerid=@eID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eID", managerId);
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
                int newId = Int32.Parse(row["employeeid"].ToString());

                employees.Add(newId);
            }
            Console.WriteLine("employees:  " + employees.Count);
            return employees;
        }
    }
}
