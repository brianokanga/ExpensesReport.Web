using ExpensesReport.Data.Data;
using ExpensesReport.Data.Models;
using ExpensesReport.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Data.Repository
{
    internal class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Expense expense)
        {
            try
            {
                _context.Expense.Add(expense);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            try
            {
                var expenses = _context.Expense.ToList();
                return expenses;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Expense GetExpenseById(int id)
        {
            try
            {
                var expense = _context.Expense.Find(id);
                return expense;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Expense> Search(string searchString)
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

        public int Update(Expense expense)
        {
            try
            {
                _context.Entry(expense).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Expense emp = _context.Expense.Find(id);
                _context.Expense.Remove(emp);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
