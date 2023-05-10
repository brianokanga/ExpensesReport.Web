using ExpensesReport.Data.Models;
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
        public IActionResult Create(Expense newExpense)
        {
            if (ModelState.IsValid)
            {
                if (newExpense.Id > 0)
                {
                    _expense.UpdateExpense(newExpense);
                }
                else
                {
                    _expense.AddExpense(newExpense);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _expense.DeleteExpense(id);
            return RedirectToAction("Index");
        }
    }
}
