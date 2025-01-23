namespace WorldCups.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<InvoiceItem> Items { get; set; }
    }
}

