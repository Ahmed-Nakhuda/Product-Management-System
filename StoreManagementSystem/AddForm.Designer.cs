namespace StoreManagementSystem
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.returnButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.unitCostNumeric = new System.Windows.Forms.NumericUpDown();
            this.sellingPriceNumeric = new System.Windows.Forms.NumericUpDown();
            this.inStockNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unitCostNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellingPriceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inStockNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.returnButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.unitCostNumeric);
            this.groupBox1.Controls.Add(this.sellingPriceNumeric);
            this.groupBox1.Controls.Add(this.inStockNumeric);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.descriptionTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(465, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add a Product";
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(230, 248);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(106, 50);
            this.returnButton.TabIndex = 6;
            this.returnButton.Text = "Return";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(118, 248);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(106, 50);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // unitCostNumeric
            // 
            this.unitCostNumeric.DecimalPlaces = 2;
            this.unitCostNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.unitCostNumeric.Location = new System.Drawing.Point(204, 92);
            this.unitCostNumeric.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.unitCostNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.unitCostNumeric.Name = "unitCostNumeric";
            this.unitCostNumeric.Size = new System.Drawing.Size(180, 30);
            this.unitCostNumeric.TabIndex = 2;
            // 
            // sellingPriceNumeric
            // 
            this.sellingPriceNumeric.DecimalPlaces = 2;
            this.sellingPriceNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.sellingPriceNumeric.Location = new System.Drawing.Point(204, 136);
            this.sellingPriceNumeric.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sellingPriceNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sellingPriceNumeric.Name = "sellingPriceNumeric";
            this.sellingPriceNumeric.Size = new System.Drawing.Size(180, 30);
            this.sellingPriceNumeric.TabIndex = 3;
            // 
            // inStockNumeric
            // 
            this.inStockNumeric.Location = new System.Drawing.Point(204, 183);
            this.inStockNumeric.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inStockNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.inStockNumeric.Name = "inStockNumeric";
            this.inStockNumeric.Size = new System.Drawing.Size(180, 30);
            this.inStockNumeric.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 183);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "In Stock:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Selling Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unit Cost:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(204, 43);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(180, 30);
            this.descriptionTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description:";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 339);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unitCostNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellingPriceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inStockNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown unitCostNumeric;
        private System.Windows.Forms.NumericUpDown sellingPriceNumeric;
        private System.Windows.Forms.NumericUpDown inStockNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button returnButton;
    }
}