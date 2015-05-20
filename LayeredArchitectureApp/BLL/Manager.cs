using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredArchitectureApp.DAL;
using LayeredArchitectureApp.Model;

namespace LayeredArchitectureApp.BLL
{
    class Manager
    {
        Gateway gateway = new Gateway();

        public string Save(Account anAccount)
        {
            int value;
            if (anAccount.AccountNumber.Length > 7)
            {
                value = gateway.Save(anAccount);
                if (value > 0)
                    return "Saved successfully";
                else
                {
                    return "Save failed";
                }
            }
            else
            {
                return "Account Number must be of 8 digits.";
            }

            
        }

        public string Deposit(string accountNumber,decimal amount)
        {
            int rowsEffected;
            rowsEffected=gateway.Deposit(accountNumber, amount);
            if (rowsEffected > 0)
            {
                return "Succesfully Updated";
            }
            else
            {
                return "Update failed";
            }

        }

        public string Withdraw(string accountNumber, decimal amount)
        {
            int rowsEffected;
            decimal currentBalance;

            currentBalance = gateway.GetBalance(accountNumber);
            if (currentBalance < amount)
            {
                return "Not enough balance";
            }
            else
            {
                rowsEffected = gateway.Withdraw(accountNumber, amount);

                if (rowsEffected > 0)
                {
                    return "Succesfully Updated";
                }
                else
                {
                    return "Update failed";
                }
            }
        }
        public List<Account> GetData(List<Account> accounts)
        {
            return gateway.GetData(accounts);
        }

        public List<Account> Search(String accountNumber)
        {
            return gateway.search(accountNumber);
        }
    }
}
