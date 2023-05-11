using ExpensesReport.Data.Data;
using ExpensesReport.Data.Models;
using ExpensesReport.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Data.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            try
            {
                var expenses = _context.Expenses.ToList();
                return expenses;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Expense> GetSearchResults(string searchString)
        {
            try
            {
                var searchExpenses = GetAllExpenses().Where(x => x.Title.Contains(searchString));
                return searchExpenses;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddExpense(Expense expense)
        {
            try
            {
                _context.Expenses.Add(expense);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateExpense(Expense expense)
        {
            try
            {
                _context.Entry(expense).State = EntityState.Modified;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Expense GetExpenseData(int id)
        {
            try
            {
                var expense = _context.Expenses.Find(id);
                return expense;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteExpense(int id)
        {
            try
            {
                Expense emp = _context.Expenses.Find(id);
                _context.Expenses.Remove(emp);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //REPORTS
        public Dictionary<string, decimal> CalculateMonthlyExpense()
        {
            List<Expense> expenses = new List<Expense>();

            Dictionary<string, decimal> dicMonthlySum = new Dictionary<string, decimal>();

            decimal foodSum = (decimal)_context.Expenses.Where
                (cat => cat.Category == "Food" && cat.ExpenseDate > DateTime.Now.AddMonths(-7))
                .Select(cat => cat.Amount)
                .Sum();

            decimal travelSum = (decimal)_context.Expenses.Where
                (cat => cat.Category == "Travel" && cat.ExpenseDate > DateTime.Now.AddMonths(-7))
                .Select(cat => cat.Amount)
                .Sum();

            decimal shoppingSum = (decimal)_context.Expenses.Where
                (cat => cat.Category == "Shopping" && cat.ExpenseDate > DateTime.Now.AddMonths(-7))
                .Select(cat => cat.Amount)
                .Sum();

            decimal healthSum = (decimal)_context.Expenses.Where
                (cat => cat.Category == "Health" && cat.ExpenseDate > DateTime.Now.AddMonths(-7))
                .Select(cat => cat.Amount)
                .Sum();

            dicMonthlySum.Add("Food", foodSum);
            dicMonthlySum.Add("Travel", travelSum);
            dicMonthlySum.Add("Shopping", shoppingSum);
            dicMonthlySum.Add("Health", healthSum);

            return dicMonthlySum;
        }
        public Dictionary<string, decimal> CalculateWeeklyExpense()
        {
            List<Expense> expenses = new List<Expense>();
            Dictionary<string, decimal> dicWeeklySum = new Dictionary<string, decimal>();

            decimal foodSum = (decimal)_context.Expenses.Where
                (cat => cat.Category == "Food" && cat.ExpenseDate > DateTime.Now.AddDays(-28))
                .Select(cat => cat.Amount)
                .Sum();

            decimal shoppingSum = (decimal)_context.Expenses.Where
                (cat => cat.Category == "Shopping" && cat.ExpenseDate > DateTime.Now.AddDays(-28))
                .Select(cat => cat.Amount)
                .Sum();

            decimal travelSum = (decimal)_context.Expenses.Where
                (cat => cat.Category == "Travel" && cat.ExpenseDate > DateTime.Now.AddDays(-28))
                .Select(cat => cat.Amount)
                .Sum();

            decimal healthSum = (decimal)_context.Expenses.Where
                (cat => cat.Category == "Health" && cat.ExpenseDate > DateTime.Now.AddDays(-28))
                .Select(cat => cat.Amount)
                .Sum();

            dicWeeklySum.Add("Food", foodSum);
            dicWeeklySum.Add("Travel", travelSum);
            dicWeeklySum.Add("Shopping", shoppingSum);
            dicWeeklySum.Add("Health", healthSum);

            return dicWeeklySum;
        }
    }
}
