using Microsoft.AspNetCore.Mvc;
using WorldCups.Models;

namespace WorldCups.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Details(int id) { var invoice = GetInvoiceById(id); if (invoice == null) { return NotFound(); } return View(invoice); }
        private Invoice GetInvoiceById(int id)
        {
            return new Invoice { Id = id, Number = "123", Date = DateTime.Now, DueDate = DateTime.Now.AddDays(7), CustomerName = "العميل الوهمي", CustomerEmail = "client@example.com", Items = new List<InvoiceItem> { new InvoiceItem { Name = "منتج 1", Price = 300.00m }, new InvoiceItem { Name = "منتج 2", Price = 150.00m }, new InvoiceItem { Name = "منتج 3", Price = 50.00m } } };
        }
    }
}
