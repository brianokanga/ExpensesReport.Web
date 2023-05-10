using ExpensesReport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Data.Repository.IRepository
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> GetAllExpenses();
        IEnumerable<Expense> GetSearchResults(string searchString);
        void AddExpense(Expense expense);
        int UpdateExpense(Expense expense);
        Expense GetExpenseData(int id);
        void DeleteExpense(int id);
        Dictionary<string, decimal> CalculateMonthlyExpense();
        Dictionary<string, decimal> CalculateWeeklyExpense();


    }
}
