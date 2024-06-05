using Microsoft.AspNetCore.Mvc;
using OfficeTransactions.Data;
using OfficeTransactions.Models;

namespace OfficeTransactions.Controllers
{
    public class TrasactionController : Controller
    {
        public readonly TransactionsDbContext _context;
        public TrasactionController(TransactionsDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            List<Transaction> transactions = _context.trasactions.ToList().OrderByDescending(t=>t.Id).ToList();
            return View(transactions);
        }
        public IActionResult Create() { 
            return View(new Transaction());
        }
        [HttpPost]
        public IActionResult Create(string type,int amount,string description)
        {
            
            List<Transaction> ts = _context.trasactions.ToList();
            int balance = 0;
            if (type == "Credit")
            {
                balance=amount;
            }
            else
            {
                balance = -amount;
            }
            if (ts.Count>0)
            {
                foreach (var i in ts)
                {
                    if (i.Type.ToString() == "Debit")
                    {
                        balance -= i.Amount;
                    }
                    else if (i.Type.ToString() == "Credit")
                    {
                        balance += i.Amount;
                    }
                }
            }
            /*else
            {
                balance = amount;
            }*/
            Transaction transaction = new Transaction()
            {
                Date = DateTime.Now,
                Description= description,
                Type = type,
                Amount = amount,
                Balance=balance
                
            };
            _context.Add(transaction);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
