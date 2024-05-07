using rental_cars_application.core.database.RentalCarsDatasetTableAdapters;
using rental_cars_application.modules.invoices.data.repositories;
using rental_cars_application.modules.receipts.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.receipts.data.repositories
{
    internal class ReceiptsRepoImpl : ReceiptsRepo
    {
        public static List<ReceiptModel> customerReceipts = new List<ReceiptModel>();   
        private receiptsTableAdapter rta = new receiptsTableAdapter();
        public override string AddNewReceipt(int invoiceId,string note)
        {
            try
            {
                rta.InsertQuery(invoiceId, note, DateTime.Now.ToString());
                return string.Empty;

            }
            catch (Exception ex) { return ex.Message; }    
        }

        public override string GetCustomerReceipts()
        {
            try {
                var data = rta.GetData();

                for (int i = 0; i < data.Rows.Count; i++)
                {

                    int receiptId = int.Parse(data[i]["receipt_id"].ToString());
                    int invoiceId = int.Parse(data[i]["invoice_id"].ToString());
                    string note = data[i]["note"].ToString();
                    string date = data[i]["date"].ToString();

                    ReceiptModel rm = new ReceiptModel(receiptId, invoiceId, date, note);

                    customerReceipts.Add(rm);


                }
                return string.Empty;    

            }
            catch(Exception ex) { return ex.Message; }   
        }
    }
}
