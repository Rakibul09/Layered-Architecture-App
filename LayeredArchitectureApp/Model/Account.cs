using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitectureApp.Model
{
    internal class Account
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }
        public string OpeningDate { get; set; }
        public decimal Balance { get; set; }
    }
}
