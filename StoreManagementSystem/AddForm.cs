using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StoreManagementSystem
{
    public partial class AddForm : Form
    {
        private Home parentForm;
        private SqlConnection connection;


        public AddForm(Home parent, SqlConnection connection)
        {
            InitializeComponent();
            parentForm = parent;
            this.connection = connection;
        }


        /// <summary>
        /// Insert a product into the database
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve values from the form
                string description = descriptionTextBox.Text;
                decimal unitCost = unitCostNumeric.Value;
                decimal sellingPrice = sellingPriceNumeric.Value;
                decimal inStock = inStockNumeric.Value;

                string insertQuery = "INSERT INTO Products (description, unit_cost, selling_price, in_stock) " +
                                     "VALUES (@Description, @UnitCost, @SellingPrice, @InStock)";

                // Create and configure SqlCommand object
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Add parameters to the SqlCommand object
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@UnitCost", unitCost);
                    command.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                    command.Parameters.AddWithValue("@InStock", inStock);

                    // Execute the INSERT statement
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product added successfully.");
                        parentForm.RefreshDataGrid();
                        descriptionTextBox.Text = "";
                        unitCostNumeric.Value = 0.00M;
                        sellingPriceNumeric.Value = 0.00M;
                        inStockNumeric.Value = 0;
                    }

                    else
                    {
                        MessageBox.Show("Error adding product");
                    }
                }
            }
           
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        /// <summary>
        /// Return to home form
        /// </summary>
        private void ReturnButton_Click(object sender, EventArgs e)
        {
           FormUtils.ReturnHome(this);
        }
    }
}
