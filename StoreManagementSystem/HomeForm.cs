using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StoreManagementSystem
{
    public partial class Home : Form
    {
        public SqlConnection Connection;
        public string connectionString = @"Data Source=.\SQLEXPRESS01; Initial Catalog = Store; Integrated Security = True";
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
       

        public Home()
        {
            InitializeComponent();
            Connection = new SqlConnection(connectionString);
            Connection.Open();
            ShowData("SELECT * FROM Products");       
        }


        /// <summary>
        /// Populates the DataGridView with data retrieved from the database
        /// </summary>
        /// <param name="query">The query used to fetch data from the database</param>
        public void ShowData(string query)
        {
            // Retrive and store data in dataTable 
            sqlDataAdapter = new SqlDataAdapter(query, connectionString);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            // Set the data source for the dataGridView
            dataGridView1.DataSource = dataTable;
           
            // Formatting
            dataGridView1.Columns["unit_cost"].DefaultCellStyle.Format = "N2"; 
            dataGridView1.Columns["selling_price"].DefaultCellStyle.Format = "N2";
            dataGridView1.ReadOnly = true;
        }


        /// <summary>
        /// // Refresh the dataTable and dataGridView
        /// </summary>
        public void RefreshDataGrid()
        {
            dataTable.Clear();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataTable;
        }

        
        // Open the form the user clicks on 
       
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            // Pass the current form and database connection
            FormUtils.ShowForm(this, new AddForm(this, Connection));
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            FormUtils.ShowForm(this, new DeleteForm(this, Connection));
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            FormUtils.ShowForm(this, new UpdateForm(this, Connection));
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            FormUtils.ShowForm(this, new SearchForm(this, Connection));
        }
    }
}
