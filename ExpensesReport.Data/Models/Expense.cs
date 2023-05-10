using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Data.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public DateTime ExpenseDate { get; set; }

        [Required]
        public String Category { get; set;}
    }
}
