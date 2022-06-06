using System;
using System.Data;
using System.Data.OracleClient;
using System.Windows;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace lab1_3
{

    public partial class MainWindow : Window
    {
        static string connStr = @"Data Source=C:\Program Files\Sqlite\exec_control.db";
        public MainWindow()
        {
            InitializeComponent();
        }
        //Kora
        //WIN-MO68OS486GB
        //string connStr = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = Kora)(PORT = 1521))
        //                    (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = orcl)));Password=Migrant;User ID=Migrant";

        #region Products
        private void allProds_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT * FROM Products";
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            SQLiteConnection connection = null;

            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource

                usersGrid.ItemsSource = dt.DefaultView;
                connection.Close();
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
            string sql = $"insert into products (ID,AVAIL,DESCRIPTION, PRICE) values (?,?,?,?)";
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                cmd.Parameters.AddWithValue("ID", textBoxIdProd.Text);
                cmd.Parameters.AddWithValue("AVAIL", Int64.Parse(textBoxAvailProd.Text));
                cmd.Parameters.AddWithValue("DESCRIPTION", Int64.Parse(textBoxDescrProd.Text));
                cmd.Parameters.AddWithValue("PRICE", Int64.Parse(textBoxPriceProd.Text));
                cmd.ExecuteScalar();
                connection.Close();
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
            string sql = $"delete FROM Products where (id = ?);";
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                cmd.Parameters.AddWithValue("id", (textBoxIdProd.Text).ToString());
                cmd.ExecuteScalar();
                connection.Close();
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
            SQLiteConnection connection = null;
            try
            {

                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = "update products set ";
                int c = 0;
                if (textBoxAvailProd.Text != null && textBoxAvailProd.Text != "")
                {
                    cmd.CommandText += " AVAIL = ?";
                    cmd.Parameters.AddWithValue("AVAIL", textBoxAvailProd.Text);
                    c++;
                }
                if (textBoxDescrProd.Text != null && textBoxDescrProd.Text != "")
                {
                    if (c>0) cmd.CommandText += ",";
                    cmd.CommandText += " DESCRIPTION = ?";
                    cmd.Parameters.AddWithValue("DESCRIPTION", textBoxDescrProd.Text);
                    c++;
                }
                if (textBoxPriceProd.Text != null && textBoxPriceProd.Text != "")
                {
                    if (c > 0) cmd.CommandText += ",";
                    cmd.CommandText += " PRICE = ?";
                    cmd.Parameters.AddWithValue("PRICE", textBoxPriceProd.Text);
                    c++;
                }
                cmd.CommandText += " where id = ?";
                cmd.Parameters.AddWithValue("ID", textBoxIdProd.Text);
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
        #endregion Products

        #region Orders
        private void allOrders_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT ID,CUST,REPRES,TOTAL_COST,order_date FROM orders";
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            SQLiteConnection connection = null;

            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource

                usersGridOrder.ItemsSource = dt.DefaultView;
                connection.Close();
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
            int c = 0;
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = $"update orders set ";

                if (textBoxCustOrder.Text != null && textBoxCustOrder.Text != "")
                {
                    cmd.CommandText += " CUST = ?";
                    cmd.Parameters.AddWithValue("CUST", textBoxCustOrder.Text);
                    c++;
                }
                if (textBoxReprOrder.Text != null && textBoxReprOrder.Text != "")
                {
                    if (c > 0) cmd.CommandText += ",";
                    cmd.CommandText += " REPRES = ?";
                    cmd.Parameters.AddWithValue("REPRES", textBoxReprOrder.Text);
                    c++;
                }
                if (textBoxCostOrder.Text != null && textBoxCostOrder.Text != "")
                {
                    if (c > 0) cmd.CommandText += ",";
                    cmd.CommandText += " TOTAL_COST = ?";
                    cmd.Parameters.AddWithValue("TOTAL_COST", textBoxCostOrder.Text);
                    c++;
                }
                cmd.CommandText += "order_date = ?, planned_d_day = ? where id = ?";
                cmd.Parameters.AddWithValue("ORDER_DATE", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("PLANNED_D_DAY", (DateTime.Now + (new System.TimeSpan(20, 10, 5, 1))).Date);
                cmd.Parameters.AddWithValue("ID", textBoxIdOrder.Text);
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allOrders_Click(sender, e);
            }
        }

        private void dropOrder_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"delete FROM orders where (id = ?);";
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                cmd.Parameters.AddWithValue("id", (textBoxIdOrder.Text).ToString());
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allOrders_Click(sender, e);
            }
        }

        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"insert into orders(id,CUST,REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) values (?, ?, ?, ?, ?, ?)";
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                cmd.Parameters.AddWithValue("ID", textBoxIdOrder.Text);
                cmd.Parameters.AddWithValue("CUST", textBoxCustOrder.Text);
                cmd.Parameters.AddWithValue("REPRES", textBoxReprOrder.Text);
                cmd.Parameters.AddWithValue("TOTAL_COST", textBoxCostOrder.Text);
                cmd.Parameters.AddWithValue("ORDER_DATE", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("PLANNED_D_DAY", (DateTime.Now + (new System.TimeSpan(20, 10, 5, 1))).Date);
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allOrders_Click(sender, e);
            }
        }
        #endregion Orders


        #region Customers
        private void allCustomers_Click(object sender, RoutedEventArgs e)
                {
                    string sql = $"SELECT * FROM customers";
                SQLiteDataAdapter ad;
                DataTable dt = new DataTable();
                SQLiteConnection connection = null;

                    try
                    {
                        connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                        cmd = connection.CreateCommand();
                        cmd.CommandText = sql;  //set the passed query
                        ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource

                usersGridCustomer.ItemsSource = dt.DefaultView;
                        connection.Close();
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
            string sql = $"delete FROM customers where (id = ?);";
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                cmd.Parameters.AddWithValue("id", (textBoxIdCustomer.Text).ToString());
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allCustomers_Click(sender, e);
            }
        }

        private void addCustomer_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"insert into customers(id,company,cust_rep, credit_limit) values (?, ?, ?, ?)";
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                cmd.Parameters.AddWithValue("id", Int32.Parse(textBoxIdCustomer.Text));
                cmd.Parameters.AddWithValue("company", textBoxCompCustomer.Text);
                cmd.Parameters.AddWithValue("cust_rep", Int32.Parse(textBoxReprCustomer.Text));
                cmd.Parameters.AddWithValue("credit_limit", decimal.Parse(textBoxCredCustomer.Text));
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allCustomers_Click(sender, e);
            }
        }

        private void changeCustomer_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"update customers set";
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                int c = 0;
                if (textBoxCompCustomer.Text != null && textBoxCompCustomer.Text != "")
                {
                    cmd.CommandText += " company = ?";
                    cmd.Parameters.AddWithValue("company", textBoxCompCustomer.Text);
                    c++;
                }
                if (textBoxReprCustomer.Text != null && textBoxReprCustomer.Text != "")
                {
                    if (c > 0) cmd.CommandText += ",";
                    cmd.CommandText += " cust_rep = ?";
                    cmd.Parameters.AddWithValue("cust_rep", Int32.Parse(textBoxReprCustomer.Text));
                    c++;
                }
                if (textBoxCredCustomer.Text != null && textBoxCredCustomer.Text != "")
                {
                    if (c > 0) cmd.CommandText += ",";
                    cmd.CommandText += " credit_limit = ?";
                    cmd.Parameters.AddWithValue("credit_limit", decimal.Parse(textBoxCredCustomer.Text));
                    c++;
                }
                cmd.CommandText += " where id = ?";
                cmd.Parameters.AddWithValue("id", Int32.Parse(textBoxIdCustomer.Text));
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allCustomers_Click(sender, e);
            }
        }
        #endregion Customers

        #region SalesReps
        private void allSalesReps_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT * FROM salesreprs";
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            SQLiteConnection connection = null;

            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource

                usersGridSalesReps.ItemsSource = dt.DefaultView;
                connection.Close();
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
            string sql = $"delete FROM salesreprs where (id = ?);";
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                cmd.Parameters.AddWithValue("id", (textBoxIdSalesReps.Text).ToString());
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allSalesReps_Click(sender, e);
            }
        }

        private void addSalesReps_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"insert into salesreprs (ID,NAME,OFFICE,HIRE_DATE,MANAGER,SALES) values (?,?,?,?,?,?)";
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                cmd.Parameters.AddWithValue("id", Int32.Parse(textBoxIdSalesReps.Text));
                cmd.Parameters.AddWithValue("name", textBoxNameSalesReps.Text);
                cmd.Parameters.AddWithValue("office", Int32.Parse(textBoxOficeSalesReps.Text));
                cmd.Parameters.AddWithValue("hire_date", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("manager", Int32.Parse(textBoxManagerSalesReps.Text));
                cmd.Parameters.AddWithValue("sales", decimal.Parse(textBoxSalesSalesReps.Text));
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allSalesReps_Click(sender, e);
            }
        }
        private void changeSalesReps_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"update salesreprs set";
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                int c = 0;
                if (textBoxNameSalesReps.Text != null && textBoxNameSalesReps.Text != "")
                {
                    cmd.CommandText += " name = ?";
                    cmd.Parameters.AddWithValue("name", textBoxNameSalesReps.Text);
                    c++;
                }
                if (textBoxRegionOffice.Text != null && textBoxRegionOffice.Text != "")
                {
                    if (c > 0) cmd.CommandText += ",";
                    cmd.CommandText += " office = ?";
                    cmd.Parameters.AddWithValue("office", Int32.Parse(textBoxOficeSalesReps.Text));
                    c++;
                }
                if (textBoxManagerSalesReps.Text != null && textBoxManagerSalesReps.Text != "")
                {
                    if (c > 0) cmd.CommandText += ",";
                    cmd.CommandText += " manager = ?";
                    cmd.Parameters.AddWithValue("manager", Int32.Parse(textBoxManagerSalesReps.Text));
                    c++;
                }
                if (textBoxSalesSalesReps.Text != null && textBoxSalesSalesReps.Text != "")
                {
                    if (c > 0) cmd.CommandText += ",";
                    cmd.CommandText += " sales = ?";
                    cmd.Parameters.AddWithValue("sales", decimal.Parse(textBoxSalesSalesReps.Text));
                    c++;
                }
                cmd.CommandText += " , hire_date=? where id = ?";
                cmd.Parameters.AddWithValue("hire_date", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("id", Int32.Parse(textBoxIdSalesReps.Text));

                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allSalesReps_Click(sender, e);
            }
        }
        #endregion SalesReps

        #region Office
        private void allOffices_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT * FROM Offices";
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            SQLiteConnection connection = null;

            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource

                usersGridOffice.ItemsSource = dt.DefaultView;
                connection.Close();
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
            string sql = $"delete FROM offices where (id = ?);";
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                cmd.Parameters.AddWithValue("id", (textBoxIdOffice.Text).ToString());
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allOffices_Click(sender, e);
            }
        }

        private void changeOffice_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"update offices set";
            int c = 0;
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql; 
                if (textBoxCityOffice.Text != null && textBoxCityOffice.Text != "")
                {
                    cmd.CommandText += " city = ?";
                    cmd.Parameters.AddWithValue("city", textBoxCityOffice.Text);
                    c++;
                }
                if (textBoxRegionOffice.Text != null && textBoxRegionOffice.Text != "")
                {
                    if (c > 0) cmd.CommandText += ",";
                    cmd.CommandText += " region = ?";
                    cmd.Parameters.AddWithValue("region", textBoxRegionOffice.Text);
                    c++;
                }
                if (textBoxSalesOffice.Text != null && textBoxSalesOffice.Text != "")
                {
                    if (c > 0) cmd.CommandText += ",";
                    cmd.CommandText += " sales = ?";
                    cmd.Parameters.AddWithValue("sales", decimal.Parse(textBoxSalesOffice.Text));
                    c++;
                }
                cmd.CommandText += " where id = ?";
                cmd.Parameters.AddWithValue("id", Int32.Parse(textBoxIdOffice.Text));
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allOffices_Click(sender, e);
            }
        }

        private void addOffice_Click(object sender, RoutedEventArgs e)
        {
            string sql = $"insert into offices (ID,CITY,REGION,SALES) values (?,?,?,?)";
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connStr);
                SQLiteCommand cmd;
                connection.Open();  //Initiate connection to the db
                cmd = connection.CreateCommand();
                cmd.CommandText = sql;  //set the passed query
                cmd.Parameters.AddWithValue("id", Int32.Parse(textBoxIdOffice.Text));
                cmd.Parameters.AddWithValue("city", textBoxCityOffice.Text);
                cmd.Parameters.AddWithValue("region", textBoxRegionOffice.Text);
                cmd.Parameters.AddWithValue("sales", decimal.Parse(textBoxSalesOffice.Text));
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                allOffices_Click(sender, e);
            }
        }
        #endregion Office
    }
}
