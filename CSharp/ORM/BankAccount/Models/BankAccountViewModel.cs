using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccount.Models
{
    [NotMapped]
    public class BankAccountViewModel
    {
        public User CurrentUser { get; set; }
        public Transaction Transaction { get; set; }
        public List<Transaction> AllUserTransactions { get; set; }
    }
}