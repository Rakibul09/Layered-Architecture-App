using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredArchitectureApp.BLL;
using LayeredArchitectureApp.Model;

namespace LayeredArchitectureApp
{
    public partial class BankApp : Form
    {
        public BankApp()
        {
            InitializeComponent();
            
        }
        Manager aManager=new Manager();
        private void saveAccountButton_Click(object sender, EventArgs e)
        {
            //hjfgjtugfj
            Account anAccount = new Account();

            anAccount.CustomerName = customerNameTextBox.Text;
            anAccount.Email = emailTextBox.Text;
            anAccount.AccountNumber = accountNumberEntryTextBox.Text;
            anAccount.OpeningDate = openingDateTextBox.Text;

            MessageBox.Show(aManager.Save(anAccount));
            
            GetListViewData();
            
            customerNameTextBox.Clear();
            emailTextBox.Clear();
            accountNumberEntryTextBox.Clear();
            openingDateTextBox.Clear();
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            string accountNumber = accountNumberTransectionTextBox.Text;
            decimal amount = decimal.Parse(amountTextBox.Text);

            MessageBox.Show(aManager.Deposit(accountNumber, amount));
            GetListViewData();
            accountNumberTransectionTextBox.Clear();
            amountTextBox.Clear();
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            string accountNumber = accountNumberTransectionTextBox.Text;
            decimal amount = decimal.Parse(amountTextBox.Text);

            MessageBox.Show(aManager.Withdraw(accountNumber, amount));
            GetListViewData();
            accountNumberTransectionTextBox.Clear();
            amountTextBox.Clear();
        }

        private void BankApp_Load(object sender, EventArgs e)
        {
            GetListViewData();
        }

        private void searchAccountNumberButton_Click(object sender, EventArgs e)
        {
            string accountNumber;
            
            accountNumber = accountNumberSearchTextBox.Text;

            accountInfoListView.Items.Clear();

            foreach (var account1 in  aManager.Search(accountNumber))
            {
                ListViewItem item = new ListViewItem();

                item.Text = account1.AccountNumber;
                item.SubItems.Add(account1.CustomerName);
                item.SubItems.Add(account1.OpeningDate);
                item.SubItems.Add(account1.Balance.ToString());

                accountInfoListView.Items.Add(item);
            }
            accountNumberSearchTextBox.Clear();
        }

        private void GetListViewData()
        {
            List<Account> accounts = new List<Account>();

            accountInfoListView.Items.Clear();
            foreach (var account in aManager.GetData(accounts))
            {
                ListViewItem item = new ListViewItem();

                item.Text = account.AccountNumber.ToString();
                item.SubItems.Add(account.CustomerName);
                item.SubItems.Add(account.OpeningDate);
                item.SubItems.Add(account.Balance.ToString());

                accountInfoListView.Items.Add(item);
            }
        }
    }
}
