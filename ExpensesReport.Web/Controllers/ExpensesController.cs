﻿using ExpensesReport.Data.Models;
using ExpensesReport.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesReport.Web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseRepository _expense;

        public ExpensesController(IExpenseRepository expense)
        {
            _expense = expense;
        }

        public IActionResult Index(string searching)
        {
            List<Expense> lists = new List<Expense>();
            lists = _expense.GetAllExpenses().ToList();

            if (string.IsNullOrEmpty(searching))
            {
                lists = _expense.GetSearchResults(searching).ToList();
            }
            return View(lists);
        }

        [HttpGet]
        public IActionResult AddEditExpense(int id)
        {
            Expense model = new Expense();
            if(id > 0)
            {
                model = _expense.GetExpenseData(id);
            }
            return PartialView("_AddEditView",model);
        }

        [HttpPost]
        public IActionResult AddEditExpense(Expense model)
        {
            if (model.Id > 0)
            {
                _expense.UpdateExpense(model);
            }
            else
            {
                _expense.AddExpense(model);
            }
            return View(Index);
        }
    }
}
