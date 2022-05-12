using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace LAB_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            InitializeComponent();
        }

        static Exec_controlEntities db = new Exec_controlEntities();

        #region Products
        private void addProd_Click(object sender, RoutedEventArgs e)
        {
            PRODUCTS prod = new PRODUCTS();
            db.PRODUCTS.Add(new PRODUCTS {ID = textBoxIdProd.Text, AVAIL = Int32.Parse(textBoxAvailProd.Text), DESCRIPTION = textBoxDescrProd.Text, PRICE = Int32.Parse(textBoxPriceProd.Text) });
            db.SaveChanges();
            allProds_Click(sender, e);
        }

        private void dropProd_Click(object sender, RoutedEventArgs e)
        {
            PRODUCTS prod = db.PRODUCTS.Remove(db.PRODUCTS.Where(p =>(p.ID == textBoxIdProd.Text)).Single());
            db.SaveChanges();
            allProds_Click(sender, e);
        }

        private void changeProd_Click(object sender, RoutedEventArgs e)
        {
            if (db.PRODUCTS.Where(p => (p.ID == textBoxIdProd.Text)).Single() != null)
            db.Entry(new PRODUCTS { ID = textBoxIdProd.Text, AVAIL = Int32.Parse(textBoxAvailProd.Text), DESCRIPTION = textBoxDescrProd.Text, PRICE = Int32.Parse(textBoxPriceProd.Text) }).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            allProds_Click(sender,e);
        }

        private void allProds_Click(object sender, RoutedEventArgs e)
        {
            db = new Exec_controlEntities();
            if (db.PRODUCTS.Count() != 0)
            {
                usersGrid.ItemsSource = db.PRODUCTS.ToList();
            }
        }
        #endregion Products


        #region Orders
        private void allOrders_Click(object sender, RoutedEventArgs e)
        {
            db = new Exec_controlEntities();
            if (db.ORDERS.Count() != 0)
            {
                usersGridOrder.ItemsSource = db.ORDERS.ToList();
            }
        }

        private void changeOrder_Click(object sender, RoutedEventArgs e)
        {
            //if (db.ORDERS.Where(p => (p.ID == Int32.Parse(textBoxIdOrder.Text))).Single() != null)
                db.Entry(new ORDERS { ID = Int32.Parse(textBoxIdOrder.Text), CUST = Int32.Parse(textBoxCustOrder.Text), REPRES = Int32.Parse(textBoxReprOrder.Text), TOTAL_COST = Int32.Parse(textBoxCostOrder.Text), ORDER_DATE = DateTime.Now, PLANNED_D_DAY = DateTime.Now + (new System.TimeSpan(20, 10, 5, 1)), DELIVERED = textBoxCDayOrder.SelectedDate }).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            allOrders_Click(sender, e);
        }

        private void dropOrder_Click(object sender, RoutedEventArgs e)
        {
            ORDERS prod = db.ORDERS.Remove(db.ORDERS.Where(p => (p.ID == Int32.Parse(textBoxIdOrder.Text))).Single());
            db.SaveChanges();
            allOrders_Click(sender, e);
        }

        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            db.ORDERS.Add(new ORDERS {  CUST = Int32.Parse(textBoxCustOrder.Text), REPRES = Int32.Parse(textBoxReprOrder.Text), TOTAL_COST = Int32.Parse(textBoxCostOrder.Text), ORDER_DATE = DateTime.Now, PLANNED_D_DAY = DateTime.Now + (new System.TimeSpan(20, 10, 5, 1)), DELIVERED = textBoxCDayOrder.SelectedDate });
            db.SaveChanges();
            allOrders_Click(sender, e);
        }
        #endregion Orders

        #region Customers
        private void addCustomer_Click(object sender, RoutedEventArgs e)
        {
            db.CUSTOMERS.Add(new CUSTOMERS { CUST_NUM = Int32.Parse(textBoxIdCustomer.Text), COMPANY = textBoxCompCustomer.Text, CUST_REP = Int32.Parse(textBoxReprCustomer.Text), CREDIT_LIMIT = decimal.Parse(textBoxCredCustomer.Text) });
            db.SaveChanges();
            allCustomers_Click(sender, e);
        }

        private void dropCustomer_Click(object sender, RoutedEventArgs e)
        {
            db.CUSTOMERS.Remove(db.CUSTOMERS.Where(p => (p.CUST_NUM == Int32.Parse(textBoxIdCustomer.Text))).Single());
            db.SaveChanges();
            allCustomers_Click(sender, e);
        }

        private void changeCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (db.CUSTOMERS.Where(p => (p.CUST_NUM == Int32.Parse(textBoxIdCustomer.Text))).Single() != null)
                db.Entry(new CUSTOMERS { CUST_NUM = Int32.Parse(textBoxIdCustomer.Text), COMPANY = textBoxCompCustomer.Text, CUST_REP = Int32.Parse(textBoxReprCustomer.Text), CREDIT_LIMIT = decimal.Parse(textBoxCredCustomer.Text) }).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            allCustomers_Click(sender, e);
        }

        private void allCustomers_Click(object sender, RoutedEventArgs e)
        {
            db = new Exec_controlEntities();
            if (db.CUSTOMERS.Count() != 0)
            {
                usersGridCustomer.ItemsSource = db.CUSTOMERS.ToList();
            }
        }
        #endregion Customers

        #region SalesReps
        private void addSalesReps_Click(object sender, RoutedEventArgs e)
        {
            db.SALESREPRS.Add(new SALESREPRS { ID = Int32.Parse(textBoxIdSalesReps.Text), NAME = textBoxNameSalesReps.Text, POSITION = "Trainee", HIRE_DATE = DateTime.Now, OFFICE = Int32.Parse(textBoxOficeSalesReps.Text), 
                SALES = decimal.Parse(textBoxSalesSalesReps.Text),
                MANAGER = Int32.Parse(textBoxManagerSalesReps.Text)
            });
            db.SaveChanges();
            allSalesRepss_Click(sender, e);
        }

        private void dropSalesReps_Click(object sender, RoutedEventArgs e)
        {
            db.SALESREPRS.Remove(db.SALESREPRS.Where(p => (p.ID == Int32.Parse(textBoxIdSalesReps.Text))).Single());
            db.SaveChanges();
            allSalesRepss_Click(sender, e);
        }

        private void changeSalesReps_Click(object sender, RoutedEventArgs e)
        {
            db.Entry(new SALESREPRS { ID = Int32.Parse(textBoxIdSalesReps.Text), NAME = textBoxNameSalesReps.Text, POSITION = "Trainee", HIRE_DATE = DateTime.Now, 
                OFFICE = Int32.Parse(textBoxOficeSalesReps.Text), SALES = decimal.Parse(textBoxSalesSalesReps.Text), MANAGER = Int32.Parse(textBoxManagerSalesReps.Text) }).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            allSalesRepss_Click(sender, e);
        }

        private void allSalesRepss_Click(object sender, RoutedEventArgs e)
        {
            db = new Exec_controlEntities();
            if (db.SALESREPRS.Count() != 0)
            {
                usersGridSalesReps.ItemsSource = db.SALESREPRS.ToList();
            }
        }
        #endregion SalesReps

        #region Office
        private void addOffice_Click(object sender, RoutedEventArgs e)
        {
            db.OFFICES.Add(new OFFICES { ID = Int32.Parse(textBoxIdOffice.Text), CITY = textBoxCityOffice.Text, REGION = textBoxRegionOffice.Text, SALES = decimal.Parse(textBoxSalesOffice.Text) });
            db.SaveChanges();
            allOffices_Click(sender, e);
        }

        private void dropOffice_Click(object sender, RoutedEventArgs e)
        {
            db.OFFICES.Remove(db.OFFICES.Where(p => (p.ID == Int32.Parse(textBoxIdOffice.Text))).Single());
            db.SaveChanges();
            allOffices_Click(sender, e);
        }

        private void changeOffice_Click(object sender, RoutedEventArgs e)
        {
            db.Entry(new OFFICES { ID = Int32.Parse(textBoxIdOffice.Text), CITY = textBoxCityOffice.Text, REGION = textBoxRegionOffice.Text, SALES = decimal.Parse(textBoxSalesOffice.Text) }).State = System.Data.Entity.EntityState.Modified;
            allOffices_Click(sender, e);
        }

        private void allOffices_Click(object sender, RoutedEventArgs e)
        {
            db = new Exec_controlEntities();
            if (db.OFFICES.Count() != 0)
            {
                usersGridOffice.ItemsSource = db.OFFICES.ToList();
            }
        }
        #endregion Office

        #region Current Overdue
        private void curOrders_Click(object sender, RoutedEventArgs e)
        {
            usersGridOrder.ItemsSource = db.current_ordv.ToList();
        }

        private void overOrders_Click(object sender, RoutedEventArgs e)
        {
            usersGridOrder.ItemsSource = db.overdue_ordv.ToList();
        }
        #endregion Current Overdue

        #region Lab4

        private void interesect_Click(object sender, RoutedEventArgs e)
        {
            geogrGrid.ItemsSource = db.intersection();
        }

        private void dist_Click(object sender, RoutedEventArgs e)
        {
            db = new Exec_controlEntities();
            geogrGrid.ItemsSource = db.Position.ToList();
            db.OFFICES_Dist();
        }

        private void addPoint_Click(object sender, RoutedEventArgs e)
        {
            db.AddPoint(String.IsNullOrEmpty(Xtext.Text) ? 3:Convert.ToInt32(Xtext.Text) , String.IsNullOrEmpty(Ytext.Text)? 4:Convert.ToInt32(Ytext.Text));
            db = new Exec_controlEntities();
            geogrGrid.ItemsSource = db.Position.ToList();
        }
        #endregion Lab4
    }
}
