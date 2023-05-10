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
            if (string.IsNullOrEmpty(searching))
            {
                lists = _expense.GetAllExpenses().ToList();
            }
            else
            {
                lists = _expense.Search(searching).ToList();
            }
            return View(lists);
        }

        [HttpGet]
        public IActionResult ExpenseData(int id)
        {
            Expense model = new Expense();
            if(id > 0)
            {
                model = _expense.GetExpenseById(id);
            }
            return PartialView("_AddEditView",model);
        }

        [HttpPost]
        public IActionResult ExpenseData(Expense model)
        {
            if (model.Id > 0)
            {
                _expense.Update(model);
            }
            else
            {
                _expense.Add(model);

            }
            return View(Index);
        }
    }
}
