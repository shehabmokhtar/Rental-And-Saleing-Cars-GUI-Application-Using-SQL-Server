using rental_cars_application.core.utilities;
using rental_cars_application.modules.authantication.data.models;
using rental_cars_application.modules.home.data.models;
using rental_cars_application.modules.home.data.repositories.employe_repo;
using rental_cars_application.modules.home.presentation.forms.customer;
using rental_cars_application.modules.home.presentation.forms.employee;
using rental_cars_application.modules.invoices.data.repositories;
using rental_cars_application.modules.messages.data.repositories;
using rental_cars_application.modules.payment_methods.presentation.forms;
using rental_cars_application.modules.receipts.data.repositories;
using rental_cars_application.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rental_cars_application.modules.home.presentation.items
{
    public partial class VehicleItem : UserControl
    {
        private VehiclesRepoImpl vehiclesRepoImpl = new VehiclesRepoImpl();
        private VehicleModel vehicle;
        private bool isSale;
        private ReceiptsRepoImpl receiptsRepoImpl = new ReceiptsRepoImpl();
        private InvoicesRepoImpl invoicesRepoImpl = new InvoicesRepoImpl();
        private MessageRepoImpl messageRepoImpl = new MessageRepoImpl();


        public VehicleItem(VehicleModel vehicle)
        {
            InitializeComponent();
            this.vehicle = vehicle;
            isSale = vehicle.salePrice != 0;
            button1.Visible = AppData.userData.role == "employee"? vehicle.salePrice != 0 ? false:true:false;
            button2.Visible = AppData.userData.role == "employee" ?true: false;
            button3.Visible = AppData.userData.role == "employee" ? true : false;
            label15.Visible = AppData.userData.role == "employee" ? true : false;
            label18.Text =  isSale? "For Sale":"For Rent";
            button4.Visible = AppData.userData.role == "employee"?false:true;
            button4.Text = isSale ? "Buy" : "Rent";
            label1.Text = vehicle.manufacturer;
            label2.Text = vehicle.model;
            label7.Text = vehicle.year;
            label17.Text = vehicle.droveKilometers;
            label11.Text = vehicle.transmission;    
            label13.Text = vehicle.engineCc;
            label16.Text = Utilities.GetPriceLabel(vehicle.salePrice);
            label5.Text = Utilities.GetSellingOrRentingPrice(vehicle.salePrice,vehicle.dailyRentalPrice);
            Utilities.IsTheVehicleAvailableOrNot(label15,vehicle.available);
       Image image = Utilities.LoadImageFromUrl(vehicle.imageUrl);
            pictureBox1.Image = image;
        }

        // Manufactourrer
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void VehicleItem_Load(object sender, EventArgs e)
        {

        }

        // Image
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }


        // Engine cc    
        private void label13_Click(object sender, EventArgs e)
        {

        }

        // Model
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Year
        private void label7_Click(object sender, EventArgs e)
        {

        }

        // Drove kilometers
        private void label17_Click(object sender, EventArgs e)
        {

        }

        // Transmission
        private void label11_Click(object sender, EventArgs e)
        {

        }

        // Sale
        private void label5_Click(object sender, EventArgs e)
        {

        }
        
        // Sale or rent price
        private void label16_Click(object sender, EventArgs e)
        {

        }

        // Track button
        private void button1_Click(object sender, EventArgs e)
        {

            if(vehicle.available == 0)
            { int invoiceId = invoicesRepoImpl.GetInvoiceId();
                receiptsRepoImpl.AddNewReceipt(invoiceId, "");
                EmployeeHomeForm employeeForm = new EmployeeHomeForm();
                TrackVehicleForm trackForm = new TrackVehicleForm(vehicle.customerId,vehicle.currentLocation);
                Utilities.NavigateToNewForm(employeeForm, trackForm);
            }
            else
            {
                MessageBox.Show("The Vehicle not rented yet");
            }

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        // Vehicle Status
        private void label15_Click(object sender, EventArgs e)
        {

        }

        // Edit button
        private void button2_Click(object sender, EventArgs e)
        {
            EditVehicleForm editVehicleForm = new EditVehicleForm(vehicle);
            EmployeeHomeForm employeeHomeForm = new EmployeeHomeForm();
            Utilities.NavigateToNewForm(employeeHomeForm, editVehicleForm);
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        // Delete button
        private void button3_Click(object sender, EventArgs e)
        {
            string r = vehiclesRepoImpl.DeleteVehicleById(vehicle.id);

            if(r == string.Empty)
            {
               DialogResult dr =  MessageBox.Show("Vehicle Deleted Successfully","Success",MessageBoxButtons.OK);
               if(dr == DialogResult.OK) {
                    EmployeeHomeForm employeeHomeForm = new EmployeeHomeForm();
                    Utilities.NavigateToNewForm(employeeHomeForm, employeeHomeForm);
            
                }
            }
            else
            {
                MessageBox.Show(r);
            }
        }

        // Sale or rent button
        private void button4_Click(object sender, EventArgs e)
        {
                    CustomerHomeForm customerHomeForm = new CustomerHomeForm();


            if (AppData.userData.paymentMethod == "") {

                CustomerPaymentMethodForm customerPaymentMethodForm = new CustomerPaymentMethodForm(vehicle);  
            Utilities.NavigateToNewForm(customerHomeForm, customerPaymentMethodForm);


            }
            else
            {
                if (isSale)
                {
                    BuyForm buyOrRentForm = new BuyForm(vehicle);
             Utilities.NavigateToNewForm(customerHomeForm, buyOrRentForm);
                }
                else
                {
                    RentForm rentForm = new RentForm(vehicle);
              Utilities.NavigateToNewForm(customerHomeForm, rentForm);
                }
            }
        }
    }
}
