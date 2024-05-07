using rental_cars_application.core.database.RentalCarsDatasetTableAdapters;
using rental_cars_application.core.utilities;
using rental_cars_application.modules.home.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.core.get_data
{
    internal class GetTransactionsFromDB : GetData
    {
        public static List<TransactionModel> transactions  = new List<TransactionModel>();
        private static transactionsTableAdapter transactionsTable = new transactionsTableAdapter();

        // Get transactions
        public static string GetTransactions() {

            try {

                var transactionsData = transactionsTable.GetData();


                for (int i = 0; i < transactionsData.Count; i++)
                {


                    int transactionId = int.Parse(transactionsData[i]["transaction_id"].ToString());
                    int customerId = int.Parse(transactionsData[i]["customer_id"].ToString());
                    int employeeId = int.Parse(transactionsData[i]["employee_id"].ToString());
                    int vehicleId = int.Parse(transactionsData[i]["vehicle_id"].ToString());
                    string status = transactionsData[i]["status"] as string;
                    string transactionType = transactionsData[i]["transaction_type"] as string;
                    string note = transactionsData[i]["Note"] as string;
                    float amount = float.Parse(transactionsData[i]["amount"].ToString());
                    string paymentMethod = transactionsData[i]["payment_method"] as string;
                    string date = transactionsData[i]["date"] as string;


                    TransactionModel transaction = new TransactionModel(transactionId, customerId, employeeId, vehicleId, status,
                 transactionType, note, amount, paymentMethod, date);


                    transactions.Add(transaction);


                }

                return string.Empty;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }
    
    // Add a new transaction
    public static string AddTransaction(int employeeId,int vehicleId,string status,string transactionType,string note,float amount,string paymentMethod)
        {
            try {
                transactionsTable.InsertQuery(AppData.userData.userId,employeeId,vehicleId,status,transactionType,note,amount,paymentMethod,DateTime.Now.ToString());
                return string.Empty;
            } catch (Exception ex) {
                return ex.Message;
            }
        }

    }
}
