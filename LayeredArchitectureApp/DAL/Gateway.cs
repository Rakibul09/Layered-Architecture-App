using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredArchitectureApp.Model;

namespace LayeredArchitectureApp.DAL
{
    class Gateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["bankDBConnectionString"].ConnectionString;

        
        public int Save(Account anAccount)
        {
            
            string query = "INSERT INTO table_Customer VALUES ('" + anAccount.CustomerName + "', '" + anAccount.AccountNumber + "', '" + anAccount.Email + "', '" + anAccount.OpeningDate + "', '" + anAccount.Balance + "')";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public decimal GetBalance(string accountNumber)
        {
            decimal balance=0;
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT Balance FROM Table_Customer WHERE Account_Number = '" + accountNumber + "'";


            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                balance = decimal.Parse(reader["Balance"].ToString());

            }
            connection.Close();
            return balance;
        }

        public int Withdraw(string accountNumber, decimal amount)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE Table_Customer SET Balance-='" + amount + "' WHERE Account_Number='" +
                                accountNumber + "' ";


            SqlCommand command = new SqlCommand(query, connection);


            connection.Open();
            int rowseffected = command.ExecuteNonQuery();
            connection.Close();

            return rowseffected;
        }
        public int Deposit(string accountNumber, decimal amount)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE Table_Customer SET Balance+='" + amount + "' WHERE Account_Number='" +
                                accountNumber + "' ";


            SqlCommand command = new SqlCommand(query, connection);


            connection.Open();
            int rowseffected = command.ExecuteNonQuery();
            connection.Close();

            return rowseffected;

        }

        public List<Account> GetData(List<Account> accounts)
        {
            accounts = new List<Account>();
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT Account_Number,Customer_Name,Opening_Date,Balance FROM Table_Customer";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Account account = new Account();

                account.AccountNumber = reader["Account_Number"].ToString();

                account.CustomerName = reader["customer_Name"].ToString();

                account.OpeningDate = reader["Opening_Date"].ToString();

                account.Balance = decimal.Parse(reader["Balance"].ToString());
                
                accounts.Add(account);
            }

            reader.Close();
            connection.Close();
            return accounts;
        }

        public List<Account> search(string accountNumber)
        {
            List<Account> accounts = new List<Account>();
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT Account_Number,Customer_Name,Opening_Date,Balance FROM table_Customer WHERE (Account_Number LIKE'" + accountNumber + "%')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Account account1 = new Account();

                account1.AccountNumber = reader["Account_Number"].ToString();

                account1.CustomerName = reader["customer_Name"].ToString();

                account1.OpeningDate = reader["Opening_Date"].ToString();

                account1.Balance = decimal.Parse(reader["Balance"].ToString());

                accounts.Add(account1);
            }

            reader.Close();
            connection.Close();
            return accounts;
        }
    }
}
