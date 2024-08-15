using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform_app.Model;
using winform_app.Services;

namespace winform_app
{
    public partial class MainForm : Form
    {
            public MainForm()
            {
                InitializeComponent();
            }

            private void MainForm_Load(object sender, EventArgs e)
            {
                FillGridView();
            }

            void FillGridView()
            {
                try
                {
                    ProductService serviceB = new ProductService();
                    var products = serviceB.List();
                    dgvProducts.DataSource = products;

                    AddImageColumn();

                    foreach (DataGridViewRow row in dgvProducts.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string imageUrl = row.Cells["ImageUrl"].Value.ToString();
                            Task.Run(() => LoadImageAsync(row, imageUrl));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            private void AddImageColumn()
            {
                if (dgvProducts.Columns["Image"] == null)
                {
                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                    imageColumn.Name = "Image";
                    imageColumn.HeaderText = "Image";
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; 
                    dgvProducts.Columns.Insert(2, imageColumn);
                }
            }

            private async Task LoadImageAsync(DataGridViewRow row, string imageUrl)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(imageUrl);
                        response.EnsureSuccessStatusCode();
                        byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            Image img = Image.FromStream(ms);
                            this.Invoke((Action)delegate
                            {
                                row.Cells["Image"].Value = img;
                                int imageHeight = img.Height;
                                row.Height = imageHeight > 100 ? 100 : imageHeight; 
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke((Action)delegate
                    {
                        row.Cells["Image"].Value = null; 
                    });
                    Console.WriteLine(ex.Message);
                }
            }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CreateProduct createProduct = new CreateProduct();
                createProduct.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FillGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducts.SelectedRows.Count == 1)
                {
                    var selectedProduct = (ProductModel)dgvProducts.SelectedRows[0].DataBoundItem;
                    EditProduct editProductForm = new EditProduct(selectedProduct);
                    editProductForm.ShowDialog();
                    FillGridView();
                }
                else
                {
                    MessageBox.Show("Please select one product to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducts.SelectedRows.Count == 1)
                {
                    var selectedProduct = (ProductModel)dgvProducts.SelectedRows[0].DataBoundItem;
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete the product: {selectedProduct.Title}?",
                                                          "Confirm Deletion",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        ProductService _productService = new ProductService();
                        _productService.Delete(selectedProduct.Id);
                        FillGridView();
                        MessageBox.Show("Delete product success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnCreateFromUrl_Click(object sender, EventArgs e)
        {
            string url = richTxtCatalogUrl.Text;
            try
            {
                if (!int.TryParse(rtbQuantity.Text, out int urlQuantity))
                    throw new Exception("Quantity input must be an integer");
                rtbLogs.Clear();
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string htmlContent = await response.Content.ReadAsStringAsync();
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(htmlContent);
                    string xpath = "//*[@id=\"content\"]//div[@class='product_thumbnail_wrapper ']/a";
                    var nodes = doc.DocumentNode.SelectNodes(xpath);
                    if (nodes == null)
                    {
                        MessageBox.Show("No product URLs found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    List<string> productUrls = new List<string>();
                    foreach (var node in nodes)
                    {
                        var productUrl = node.GetAttributeValue("href", string.Empty);
                        if (!string.IsNullOrEmpty(productUrl) && (productUrls.Count() < urlQuantity))
                        {
                            rtbLogs.AppendText($"Crawling {productUrl}\n");
                            HttpResponseMessage productResponse = await client.GetAsync(productUrl);
                            productResponse.EnsureSuccessStatusCode();
                            string productHtmlContent = await productResponse.Content.ReadAsStringAsync();

                            HtmlAgilityPack.HtmlDocument productDoc = new HtmlAgilityPack.HtmlDocument();
                            productDoc.LoadHtml(productHtmlContent);
                            productUrls.Add(productUrl);
                        }
                    }
                    foreach (var product in productUrls)
                    {
                        TakeSingleProduct(product);
                    }
                    if (productUrls.Count == 0)
                    {
                        MessageBox.Show("No product url found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void TakeSingleProduct(string product)
        {
            try
            {
                ProductService _prodService = new ProductService();
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage proResponse = await client.GetAsync(product);
                    proResponse.EnsureSuccessStatusCode();
                    string htmlContent = await proResponse.Content.ReadAsStringAsync();
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(htmlContent);
                    string productTitleXPath = "//*[@id=\"content\"]//h1";
                    string productPriceXPath = "//*[@class=\"product_infos\"]//p[@class='price']//*[@class='woocommerce-Price-amount amount']//bdi";
                    string productImageXPath = "//*[@id=\"content\"]//div[@class='product-images-wrapper']//a";
                    string productDescriptionXPath = "//*[@class='product_infos']//div[@class='woocommerce-product-details__short-description']";
                    var productTitleNode = doc.DocumentNode.SelectSingleNode(productTitleXPath);
                    var productPriceNode = doc.DocumentNode.SelectSingleNode(productPriceXPath);
                    var productImageNode = doc.DocumentNode.SelectSingleNode(productImageXPath);
                    var productDescriptionNode = doc.DocumentNode.SelectSingleNode(productDescriptionXPath);
                    ProductModel model = new ProductModel();
                    if (productTitleNode != null)
                    {
                        var productTitle = productTitleNode.InnerText.Trim();
                        model.Title = productTitle;
                    }
                    if (productPriceNode != null)
                    {
                        productPriceNode.RemoveChild(productPriceNode.ChildNodes[0]);
                        var str = productPriceNode.InnerText.Trim();
                        string except = ".";
                        var productPrice = Regex.Replace(str, @"[^a-zA-Z0-9" + except + "]+", string.Empty);
                        model.Price = Convert.ToDecimal(productPrice);
                    }
                    if (productImageNode != null)
                    {
                        var productImage = productImageNode.GetAttributeValue("href", string.Empty);
                        model.ImageUrl = productImage;
                    }
                    if (productDescriptionNode != null)
                    {
                        var productDescription = productDescriptionNode.InnerText.Trim();
                        model.Description = productDescription;
                    }

                    model.CreatedAt = DateTime.Now;
                    model.StockQuantity = 0;
                    model.Published = false;
                    model.Tags = "";
                    if (!_prodService.Exists(model))
                    {
                        _prodService.Create(model);
                    }
                    else
                    {
                        rtbLogs.AppendText($" {product} has exists in database\n");
                    }
                    FillGridView();
                }
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

        private void richTxtCatalogUrl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
