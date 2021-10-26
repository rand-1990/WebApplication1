using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class DataBaseConnection
        //كلاس بي عمليات فتح الاتصال والغلق والاضافة والحذف واستدعي واكون منه اوبجكت احسن ما كل شويه اعيد كود
    {
        private SqlConnection connection;

        public bool throwExceptions { get; set; }

        //Constructor
        public DataBaseConnection()
        {
            //connection = new SqlConnection(@"Data Source=DELL-LAPTOP\SQLEXPRESS;Initial Catalog=ELearning;Integrated Security=True");
            //Data Source=.\SQLEXPRESS;Initial Catalog=ELearning;Integrated Security=True
          //  connection = new SqlConnection(@"Data Source=DELL-LAPTOP\SQLEXPRESS;Initial Catalog=ELearning;Integrated Security=True");
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ELearning;Integrated Security=True");


        }
        public SqlConnection GetSqlConnection()
        {
            return connection;
        }
        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                if (throwExceptions)
                {
                    throw ex;
                }
                return false;
            }
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                return true;
            }
            catch (SqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                if (throwExceptions)
                {
                    throw ex;
                }
                return false;
            }
        }

        //Executes a SQL statement against the connection and returns the number of rows affected
        public int ExcuteNonQuery(string query,string v="0")
        {
            int effectedRows = -1;
            try
            {
                //open connection
                OpenConnection();

                //create command and assign the query and connection from the constructor
                SqlCommand cmd = new SqlCommand(query, connection);

                //Execute command
                
                    effectedRows = cmd.ExecuteNonQuery();
           
                // Close Connection
                connection.Close();

            }
            catch (SqlException ex)
            {
                if (throwExceptions)
                    throw ex;
            }
            return effectedRows;
        }

        //Insert statement
        public int Insert(string tablename, string[] columns, string[] values)
        {
            string cols = columns[0];
            for (int i = 1; i < columns.Length; i++)
            {
                cols += "," + columns[i];
            }

            string vals = "'" + values[0] + "'";
            for (int i = 1; i < values.Length; i++)
            {
                vals += ",'" + values[i] + "'";
            }
            string query = "";
          
                query = "INSERT INTO " + tablename + " (" + cols + ")  VALUES(" + vals + ");";

         
            return ExcuteNonQuery(query);
         
        }

        //Update statement
        public void Update(string tablename, string[] columns, string[] values, string condition)
        {
            string vals = "";
            for (int i = 0; i < values.Length; i++)
            {
                vals += columns[i] + "=" + "'" + values[i] + "', ";
            }
            // Remove Last Comma (,)
            vals = vals.Substring(0, vals.Length - 2);

            string query = "UPDATE " + tablename + " SET " + vals + " WHERE " + condition;

            ExcuteNonQuery(query);
        }

        //Delete statement
        public void Delete(string tablename, string condition)
        {
            string query = "DELETE FROM " + tablename + " where " + condition;

            ExcuteNonQuery(query);
        }

        //Select statement
        public object[][] Select(string tablename, string[] columns, string condition)
        {
            string cols = columns[0];
            for (int i = 1; i < columns.Length; i++)
            {
                cols += "," + columns[i];
            }

            string query = "SELECT " + cols + " FROM " + tablename;

            if (condition != "")
            {
                query += " WHERE " + condition;
            }

            //Open connection
            if (this.OpenConnection() == true)
            {

                //Create Command
                SqlCommand cmd = new SqlCommand(query, connection);
                //Create a data reader and Execute the command
                SqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                int ColCount = dataReader.FieldCount;
                List<object[]> rows = new List<object[]>();


                while (dataReader.Read())
                {
                    List<object> row = new List<object>();
                    for (int i = 0; i < ColCount; i++)
                    {
                        row.Add(dataReader[i]);
                    }
                    rows.Add(row.ToArray());
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return rows.ToArray();
            }
            else
            {
                return null;
            }
        }

        //Select statement
        public DataTable SelectAsDataTable(string tablename, string[] columns, string condition)
        {
            string cols = columns[0];
            for (int i = 1; i < columns.Length; i++)
            {
                cols += "," + columns[i];
            }

            string query = "SELECT " + cols + " FROM " + tablename;

            if (condition != "")
            {
                query += " WHERE " + condition;
            }

            //Open connection
            if (this.OpenConnection() == true)
            {

                //Create Command
                SqlCommand cmd = new SqlCommand(query, connection);
                //Create a data adapter to Execute the command
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
                mySqlDataAdapter.SelectCommand = cmd;
                // Fill the DataTable From the Adapter
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return dataTable;
            }
            else
            {
                return null;
            }
        }

        //Get the Max ID in a table
        public int GetLastIdNumber(string tablename)
        {
            string query = "SELECT MAX(id) as max FROM " + tablename;
            int maxID = -1;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                SqlCommand cmd = new SqlCommand(query, connection);
                //Create a data reader and Execute the command
                SqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                dataReader.Read();
                try
                {
                    maxID =Int32.Parse(dataReader["max"].ToString());
                }
                catch (Exception ee)
                {
                    string mes = ee.Message;
                    int y = 10;

                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                return maxID;
            }
            else
            {
                return maxID;
            }
        }

        //Count statement
        public int CountRowsInTable(string tablename)
        {
            string query = "SELECT Count(*) FROM " + tablename;
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                SqlCommand cmd = new SqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
    }
}