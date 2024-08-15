using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform_app.Model;
using winform_app.Services;

namespace winform_app
{
    
    public partial class EditProduct : Form
    {
        private ProductService _productService;
        private ProductModel _product;

        public EditProduct(ProductModel product)
        {
            InitializeComponent();
            _productService = new ProductService();
            _product = product;
            txtTitle.Text = _product.Title;
            txtDesc.Text = _product.Description;
            txtPrice.Text = _product.Price.ToString();
            txtImg.Text = _product.ImageUrl;
            checkPublished.Checked = _product.Published;
            txtTags.Text = _product.Tags;
            txtStock.Text = Convert.ToString(_product.StockQuantity);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _product.Title = txtTitle.Text;
                _product.Description = txtDesc.Text;
                _product.Price = decimal.Parse(txtPrice.Text);
                _product.ImageUrl = txtImg.Text;
                _product.Published = checkPublished.Checked;
                _product.Tags = txtTags.Text;
                _product.StockQuantity = Convert.ToInt32(txtStock.Text);
                _productService.Edit(_product);
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
