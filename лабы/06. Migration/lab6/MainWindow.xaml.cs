using System;
using System.Data;
using System.Data.OracleClient;
using System.Windows;
using System.Data.SqlClient;

namespace lab1_3
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Kora
        //WIN-MO68OS486GB
        string connStr = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = Kora)(PORT = 1521))
                            (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orcl)));Password=Migrant;User ID=Migrant";

        #region Products
        private void allProds_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT * FROM Products";
            OracleConnection connection = null;
            DataTable Clients = new DataTable();

            try
            {
                connection = new OracleConnection(connStr);
                OracleCommand command = new OracleCommand(sql, connection);
                OracleDataAdapter adapter = new OracleDataAdapter(command);

                connection.Open();
                adapter.Fill(Clients);
                usersGrid.ItemsSource = Clients.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        private void addProd_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand("insert into products (ID,AVAIL,DESCRIPTION, PRICE) values (:ID,:AVAIL,:DESCRIPTION, :PRICE)", connection);
                cmd.Parameters.AddWithValue("ID", textBoxIdProd.Text);
                cmd.Parameters.AddWithValue("AVAIL",  textBoxAvailProd.Text);
                cmd.Parameters.AddWithValue("DESCRIPTION", textBoxDescrProd.Text);
                cmd.Parameters.AddWithValue("PRICE", textBoxPriceProd.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }

        private void dropProd_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {
                //using (OracleCommand cmd = new OracleCommand("delete from products where ID = :ID", connection))
                //{
                //    cmd.Parameters.AddWithValue("ID", textBoxIdProd.Text);
                //    cmd.Connection.Open();
                //    cmd.ExecuteNonQuery();
                //}
                //connection.Open();
                //OracleCommand cmd = new OracleCommand("delete from products where ID = :ID", connection);
                using (OracleCommand cmd = new OracleCommand("remvprod", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pr_id", textBoxIdProd.Text);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }

        private void changeProd_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {
                //connection.Open();
                //if (textBoxAvailProd.Text != null)
                //{
                //    OracleCommand cmd = new OracleCommand("update products set AVAIL = :AVAIL where id = :ID", connection);
                //    cmd.Parameters.AddWithValue("ID", textBoxIdProd.Text);
                //    cmd.Parameters.AddWithValue("AVAIL", textBoxAvailProd.Text);
                //    cmd.ExecuteNonQuery();
                //}
                //if (textBoxDescrProd.Text != null)
                //{
                //    OracleCommand cmd = new OracleCommand("update products set DESCRIPTION = :DESCRIPTION where id = :ID", connection);
                //    cmd.Parameters.AddWithValue("ID", textBoxIdProd.Text);
                //    cmd.Parameters.AddWithValue("DESCRIPTION", textBoxDescrProd.Text);
                //    cmd.ExecuteNonQuery();
                //}
                //if (textBoxPriceProd.Text != null)
                //{
                //    OracleCommand cmd = new OracleCommand("update products set PRICE = :PRICE where id = :ID", connection);
                //    cmd.Parameters.AddWithValue("ID", textBoxIdProd.Text);
                //    cmd.Parameters.AddWithValue("PRICE", textBoxPriceProd.Text);
                //    cmd.ExecuteNonQuery();

                //}

                using (OracleCommand cmd = new OracleCommand("upd_prod", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idd", textBoxIdProd.Text);
                    cmd.Parameters.AddWithValue("availl", Int32.Parse(textBoxAvailProd.Text));
                    cmd.Parameters.AddWithValue("descr", textBoxDescrProd.Text);
                    cmd.Parameters.AddWithValue("pricee", Int32.Parse(textBoxPriceProd.Text));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }
        #endregion Products

#region Orders
private void allOrders_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT * FROM orders";
            OracleConnection connection = null;
            DataTable Clients = new DataTable();

            try
            {
                connection = new OracleConnection(connStr);
                OracleCommand command = new OracleCommand(sql, connection);
                OracleDataAdapter adapter = new OracleDataAdapter(command);

                connection.Open();
                adapter.Fill(Clients);
                usersGridOrder.ItemsSource = Clients.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        private void changeOrder_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {

                using (OracleCommand cmd = new OracleCommand("upd_ord", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idd", textBoxIdOrder.Text);
                    cmd.Parameters.AddWithValue("CUSTt", textBoxCustOrder.Text);
                    cmd.Parameters.AddWithValue("REPRESs", textBoxReprOrder.Text);
                    cmd.Parameters.AddWithValue("DELIVEREdD", textBoxCDayOrder.SelectedDate.ToString());
                    cmd.Parameters.AddWithValue("TOTAL_COSTt", textBoxCostOrder.Text);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }

        private void dropOrder_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {
                using (OracleCommand cmd = new OracleCommand("remvorder", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pr_id", textBoxIdOrder.Text);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }

        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {
                    OracleCommand cmd = new OracleCommand("insert into orders(id,CUST,REPRES, DELIVERED, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) values (:ID, :CUST, :REPRES, :DELIVERED, :TOTAL_COST, :ORDER_DATE, :PLANNED_D_DAY)", connection);
                    cmd.Parameters.AddWithValue("ID", textBoxIdOrder.Text);
                    cmd.Parameters.AddWithValue("CUST", textBoxCustOrder.Text);
                    cmd.Parameters.AddWithValue("REPRES", textBoxReprOrder.Text);
                    cmd.Parameters.AddWithValue("DELIVERED", textBoxCDayOrder.SelectedDate);
                    cmd.Parameters.AddWithValue("TOTAL_COST", textBoxCostOrder.Text);
                    cmd.Parameters.AddWithValue("ORDER_DATE", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("PLANNED_D_DAY", (DateTime.Now + (new System.TimeSpan(20, 10, 5, 1))).ToString());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }
        #endregion Orders


        #region Customers
        private void allCustomers_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT * FROM customers";
            OracleConnection connection = null;
            DataTable Clients = new DataTable();

            try
            {
                connection = new OracleConnection(connStr);
                OracleCommand command = new OracleCommand(sql, connection);
                OracleDataAdapter adapter = new OracleDataAdapter(command);

                connection.Open();
                adapter.Fill(Clients);
                usersGridCustomer.ItemsSource = Clients.DefaultView;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        private void dropCustomer_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {
                using (OracleCommand cmd = new OracleCommand("remvcust", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pr_id", Int32.Parse(textBoxIdCustomer.Text));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }

        private void addCustomer_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {
                using (OracleCommand cmd = new OracleCommand("add_cust", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idd", Int32.Parse(textBoxIdCustomer.Text));
                    cmd.Parameters.AddWithValue("companyy", textBoxCompCustomer.Text);
                    cmd.Parameters.AddWithValue("cust_repp", Int32.Parse(textBoxReprCustomer.Text));
                    cmd.Parameters.AddWithValue("credit_limitt", decimal.Parse(textBoxCredCustomer.Text));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }

        private void changeCustomer_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {
                using (OracleCommand cmd = new OracleCommand("upd_cust", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idd", Int32.Parse(textBoxIdCustomer.Text));
                    cmd.Parameters.AddWithValue("companyy", textBoxCompCustomer.Text);
                    cmd.Parameters.AddWithValue("cust_repp", Int32.Parse(textBoxReprCustomer.Text));
                    cmd.Parameters.AddWithValue("credit_limitt", decimal.Parse(textBoxCredCustomer.Text));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }
        #endregion Customers

        #region SalesReps
        private void allSalesReps_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT * FROM SalesReprs";
            OracleConnection connection = null;
            DataTable Clients = new DataTable();

            try
            {
                connection = new OracleConnection(connStr);
                OracleCommand command = new OracleCommand(sql, connection);
                OracleDataAdapter adapter = new OracleDataAdapter(command);

                connection.Open();
                usersGridSalesReps.ItemsSource = Clients.DefaultView;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        private void dropSalesReps_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {
                using (OracleCommand cmd = new OracleCommand("remvsal", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pr_id", Int32.Parse(textBoxIdSalesReps.Text));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }

        private void addSalesReps_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {
                using (OracleCommand cmd = new OracleCommand("add_sal", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idd", Int32.Parse(textBoxIdSalesReps.Text));
                    cmd.Parameters.AddWithValue("namee", textBoxNameSalesReps.Text);
                    cmd.Parameters.AddWithValue("officee", Int32.Parse(textBoxOficeSalesReps.Text));
                    cmd.Parameters.AddWithValue("saless", decimal.Parse(textBoxSalesSalesReps.Text));
                    cmd.Parameters.AddWithValue("managerr", Int32.Parse(textBoxManagerSalesReps.Text)); 
                     cmd.Parameters.AddWithValue("hire_date", DateTime.Now.ToString());
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }
        private void changeSalesReps_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {
                using (OracleCommand cmd = new OracleCommand("upd_sal", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idd", Int32.Parse(textBoxIdSalesReps.Text));
                    cmd.Parameters.AddWithValue("namee", textBoxNameSalesReps.Text);
                    cmd.Parameters.AddWithValue("officee", Int32.Parse(textBoxOficeSalesReps.Text));
                    cmd.Parameters.AddWithValue("saless", decimal.Parse(textBoxSalesSalesReps.Text));
                    cmd.Parameters.AddWithValue("managerr", Int32.Parse(textBoxManagerSalesReps.Text));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }
        #endregion SalesReps

        #region Office
        private void allOffices_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT * FROM Offices";
            OracleConnection connection = null;
            DataTable Clients = new DataTable();

            try
            {
                connection = new OracleConnection(connStr);
                OracleCommand command = new OracleCommand(sql, connection);
                OracleDataAdapter adapter = new OracleDataAdapter(command);

                connection.Open();
                adapter.Fill(Clients);
                usersGridOffice.ItemsSource = Clients.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        private void dropOffice_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {
                using (OracleCommand cmd = new OracleCommand("remvoffice", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pr_id", Int32.Parse(textBoxIdOffice.Text));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }

        private void changeOffice_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {

                using (OracleCommand cmd = new OracleCommand("upd_office", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idd", Int32.Parse(textBoxIdOffice.Text));
                    cmd.Parameters.AddWithValue("cityy", textBoxCityOffice.Text);
                    cmd.Parameters.AddWithValue("regionn", textBoxRegionOffice.Text);
                    cmd.Parameters.AddWithValue("saless", decimal.Parse(textBoxSalesOffice.Text));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }

        private void addOffice_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection connection = new OracleConnection(connStr);
            try
            {

                using (OracleCommand cmd = new OracleCommand("add_office", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idd", Int32.Parse(textBoxIdOffice.Text));
                    cmd.Parameters.AddWithValue("cityy", textBoxCityOffice.Text);
                    cmd.Parameters.AddWithValue("regionn", textBoxRegionOffice.Text);
                    cmd.Parameters.AddWithValue("saless", decimal.Parse(textBoxSalesOffice.Text));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allProds_Click(sender, e);
            }
        }
        #endregion Office
    }
}
