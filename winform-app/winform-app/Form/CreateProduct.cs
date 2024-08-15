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
    public partial class CreateProduct : Form
    {
        private ProductService _productService;
        public CreateProduct()
        {
            InitializeComponent();
            _productService = new ProductService();
            
        }
        private void CreateProduct_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ProductModel productModel = new ProductModel();
                productModel.Title = txtTitle.Text;
                productModel.Description = txtDesc.Text;
                productModel.ImageUrl = txtImg.Text;
                productModel.CreatedAt = DateTime.Now;
                productModel.Price = Convert.ToDecimal(txtPrice.Text);
                productModel.Tags = txtTags.Text;
                productModel.Published = checkPublished.Checked;
                productModel.StockQuantity = Convert.ToInt32(txtStock.Text);
                _productService.Create(productModel);
                MessageBox.Show("Add product success","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
