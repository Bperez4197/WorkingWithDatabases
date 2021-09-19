using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithDatabases.Dal;

namespace WorkingWithDatabases
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerAdapter adapter = new CustomerAdapter();
            List<Customer> customers = adapter.GetAll();

            foreach (Customer customer in customers)
            {
                Console.WriteLine($"CustomerID: {customer.CustomerId} FirstName: {customer.FirstName} LastName: {customer.LastName} Country: {customer.Country} Email: {customer.Email}");
            }

            InvoiceAdapter Iadapter = new InvoiceAdapter();
            List<Invoice> invoices = Iadapter.GetAll();

            foreach (Invoice invoice in invoices)
            {
                Console.WriteLine($"InvoiceId: {invoice.InvoiceId} CustomerId: {invoice.CustomerId} InvoiceDate: {invoice.InvoiceDate} Total: {invoice.Total}");
            }
            Console.ReadLine();
        }
    }
}
