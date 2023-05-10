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
        IEnumerable<Expense> Search(string searchString);
        void Add(Expense expense);
        int Update(Expense expense);
        Expense GetExpenseById(int id);
        void Delete(int id);

    }
}
