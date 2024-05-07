using rental_cars_application.core.database.RentalCarsDatasetTableAdapters;
using rental_cars_application.core.utilities;
using rental_cars_application.modules.invoices.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.invoices.data.repositories
{
    internal class InvoicesRepoImpl : InvoicesRepo
    {
        public static List<InvoiceModel> customerInvoices = new List<InvoiceModel>(); 
        invoicesTableAdapter invoicesTableAdapter = new invoicesTableAdapter();
        public override string GetCustomerInvoices()
        {
            try {

                var tableData = invoicesTableAdapter.GetData();

                for(int i = 0; i < tableData.Rows.Count; i++)
                {
                    int customerId = int.Parse(tableData[i]["customer_id"].ToString());

                    if(AppData.userData.userId == customerId) {

                        int invoiceId = int.Parse(tableData[i]["invoice_id"].ToString());
                        int employeeId = int.Parse(tableData[i]["employee_id"].ToString());
                        string invoiceDate = tableData[i]["invoice_date"].ToString();
                        float totalAmount = float.Parse(tableData[i]["total_amount"].ToString());
                        string paymentMethod = tableData[i]["payment_method"].ToString();
                        string paymentDate = tableData[i]["payment_date"].ToString();
                        float taxes = float.Parse(tableData[i]["taxes"].ToString());
                        float discount = float.Parse(tableData[i]["discount"].ToString());
                        string notes = tableData[i]["note"].ToString();

                        InvoiceModel invoice = new InvoiceModel(invoiceId,customerId,employeeId,invoiceDate,totalAmount,paymentMethod,paymentDate,taxes,discount,notes);


                        customerInvoices.Add(invoice);
                    }

                }

                return string.Empty;

            }
            catch(Exception ex){
                return ex.Message;
            }
        }

        public override string AddNewInvoice(int employeeId,float totalAmount,float taxes,float discount,string note)
        {
            try {
                invoicesTableAdapter.InsertQuery(AppData.userData.userId, employeeId, DateTime.Now.ToString(), totalAmount, AppData.userData.paymentMethod, DateTime.Now.ToString(), taxes, discount, note);
                return string.Empty;
            }
            catch(Exception ex) { return ex.Message; }   
        }

        public override int GetInvoiceId()
        {
            try
            {

                var tableData = invoicesTableAdapter.GetData();

                for (int i = 0; i < tableData.Rows.Count; i++)
                {
                    int employeeId = int.Parse(tableData[i]["employee_id"].ToString());

                    if (AppData.userData.userId == employeeId)
                    {

                        int invoiceId = int.Parse(tableData[i]["invoice_id"].ToString());
                        return invoiceId;
                    }

                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
            
        }
    }
