using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccount.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public float Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }

        [NotMapped]
        public User Creator { get; set; }
    }
}