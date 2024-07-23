using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StoreManagementSystem
{
    public partial class UpdateForm : Form
    {
        private Home parentForm;
        private SqlConnection connection;

        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        int recordID;
      

        public UpdateForm(Home parent, SqlConnection connection)
        {
            InitializeComponent();
            parentForm = parent;
            this.connection = connection;

            ShowData();
        }


        public void ShowData()
        {
            
            sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Products", connection);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            // Format
            dataGridView1.Columns["unit_cost"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["selling_price"].DefaultCellStyle.Format = "N2";
            dataGridView1.ReadOnly = true;
        }

        public void RefreshDataGrid()
        {
            // Refresh the DataTable
            dataTable.Clear();
            sqlDataAdapter.Fill(dataTable);

            // Refresh the DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataTable;
            
            // Format
            dataGridView1.Columns["unit_cost"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["selling_price"].DefaultCellStyle.Format = "N2";
            dataGridView1.ReadOnly = true;
        }


        /// <summary>
        /// Get the values from the data grid view which the user clicked on
        /// and put those values in the textboxes and numeric up downs.
        /// </summary>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            recordID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            idTextBox.Text = recordID.ToString();
            descriptionTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            unitCostNumeric.Value = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            sellingPriceNumeric.Value = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            inStockNumeric.Value = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
        }

        
        /// <summary>
        /// Update a product 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(idTextBox.Text);
                string description = descriptionTextBox.Text;
                decimal unitCost = unitCostNumeric.Value;
                decimal sellingPrice = sellingPriceNumeric.Value;
                decimal inStock = inStockNumeric.Value;

                // Construct SQL UPDATE statement
                string updateQuery = "UPDATE Products SET description = @Description, " +
                                                       "unit_cost = @UnitCost, " +
                                                       "selling_price = @SellingPrice, " +
                                                       "in_stock = @InStock " +
                                                       "WHERE product_id = @ProductID";


                // Create and configure SqlCommand object
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Add parameters to the SqlCommand object
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@UnitCost", unitCost);
                    command.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                    command.Parameters.AddWithValue("@InStock", inStock);
                    command.Parameters.AddWithValue("@ProductID", id); // Parameter for product ID

                    // Execute the UPDATE statement
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the product was updated
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Product with ID " + id + " not found.");
                    }
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            // Update home table and refresh grid
            parentForm.RefreshDataGrid();
            RefreshDataGrid();
        }

        
        /// <summary>
        /// Search for a product by the description 
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string description = searchTextBox.Text;
            string query = "SELECT * FROM Products WHERE description LIKE '%" + description + "%'";
            FormUtils.Search(searchTextBox, connection, dataGridView1);
            parentForm.ShowData(query);
            parentForm.RefreshDataGrid(); 
        }

        /// <summary>
        /// Return to the home form
        /// </summary>
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            FormUtils.ReturnHome(this);
        }
    }
}
