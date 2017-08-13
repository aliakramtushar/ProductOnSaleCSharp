using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer;
using Entities;

namespace UILayer
{
    public partial class PosSystem : Form
    {
        PosBusiness _pos = new PosBusiness();
        Product _product = new Product();
        static List<Product> list = new List<Product>();
        private double sum;
        LoginForm log = new LoginForm();
        public PosSystem()
        {
            InitializeComponent();
            dataGridView1.Columns.Add(_product.id,"Code");
            dataGridView1.Columns.Add(_product.name, "Description");
            dataGridView1.Columns.Add(_product.quantities.ToString(), "Quantity");
            dataGridView1.Columns.Add(_product.sell_price.ToString(), "Unit Price");
            dataGridView1.Columns.Add(_product.discount.ToString(), "Discount");
            dataGridView1.Columns.Add(_product.totalprice.ToString(), "Total Price");
            timer_Now.Start();
        }
        
        
        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            log.Show();
        }

        private void timer_Now_Tick(object sender, EventArgs e)
        {
            labelClock.Text = string.Format("{0:hh:mm:ss tt}", DateTime.Now);
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                string[] divide = tBoxCode.Text.Split('-');
                string tableValue = divide[0];
                string productValue = divide[1];
                _product = _pos.GetProduct(productValue, _product);
                textBoxProductCode.Text = tBoxCode.Text;
                textBoxName.Text = _product.name;
                textBoxUnitPrice.Text = _product.sell_price.ToString();
                tBoxCode.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("No input was given.", "Input", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                
            }
            
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Product _product = new Product();
                _product.id = textBoxProductCode.Text;
                _product.name = textBoxName.Text;
                _product.quantities = Convert.ToInt32(textBoxQuantity.Text);
                _product.sell_price = Convert.ToDouble(textBoxUnitPrice.Text);
                _product.discount = (((Convert.ToInt32(textBoxQuantity.Text)) * (Convert.ToDouble(textBoxUnitPrice.Text))) * ((Convert.ToDouble(textBoxDiscount.Text)) / 100));
                _product.totalprice = (((Convert.ToInt32(textBoxQuantity.Text)) * (Convert.ToDouble(textBoxUnitPrice.Text)) - (Convert.ToDouble(_product.discount))));
                this.dataGridView1.Rows.Add(_product.id, _product.name, _product.quantities, _product.sell_price, _product.discount, _product.totalprice);
                sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                }

                labelSubTotal.Text = sum.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("No input was given.", "Input", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxProductCode.Text = "";
            textBoxName.Text = "";
            textBoxQuantity.Text = "";
            textBoxUnitPrice.Text = "";
            textBoxDiscount.Text = "";
            

        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            string temp = tBoxCode.Text;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == temp)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }
        }

        private void btnStartOver_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            btnClear.PerformClick();
            btnCancel.PerformClick();
        }

        private void PrintReceipt()
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument;

            printDocument.PrintPage += PrintDocument_PrintPage;

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Font font = new Font("Courier New",10);

            float fontHeight = font.GetHeight();

            int startX = 10, startY = 10, offset = 110;
            
            graphics.DrawString("Friend Super Shop", new Font("Courier New",18), new SolidBrush(Color.Blue),startX+90,startY);
            graphics.DrawString("444, North Ibrahimpur", new Font("Courier New", 12), new SolidBrush(Color.Black), startX+100, startY+30);
            graphics.DrawString("Mirpur-14, Dhaka-1206.", new Font("Courier New", 12), new SolidBrush(Color.Black), startX+100, startY+50);
            graphics.DrawString("Tel: xxx-xxxx", new Font("Courier New", 12), new SolidBrush(Color.Black), startX+150, startY+70);
            graphics.DrawString("Code        Des     Qty    Rate     Dis      Amount(tk)", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + 90);
            graphics.DrawString("----     ----   ----  -----  -----  -----------", new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + 100);
            

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string productCode = dataGridView1.Rows[i].Cells[0].Value.ToString().PadRight(10);
                string productName = dataGridView1.Rows[i].Cells[1].Value.ToString().PadRight(11);
                string productQuantity = dataGridView1.Rows[i].Cells[2].Value.ToString().PadRight(7);
                string productUnitPrice = dataGridView1.Rows[i].Cells[3].Value.ToString().PadRight(9);
                string productDiscount = dataGridView1.Rows[i].Cells[4].Value.ToString().PadRight(11);
                string productTotal = dataGridView1.Rows[i].Cells[5].Value.ToString().PadRight(1);

                string printLine = productCode + productName + productQuantity + productUnitPrice + productDiscount +
                                   productTotal;

                graphics.DrawString(printLine,font,new SolidBrush(Color.Black),startX,startY+offset );

                offset = offset + (int) fontHeight + 5;
            }

            offset = offset + 20;
            graphics.DrawString("Total Amount:".PadRight(10)+string.Format("{0:C}", textBoxTotal.Text), font, new SolidBrush(Color.Red), startX, startY+offset+20);
            graphics.DrawString("Total Vat:".PadRight(10) + string.Format("{0:C}", labelVat.Text+"%"), font, new SolidBrush(Color.Red), startX, startY + offset+40);
            graphics.DrawString("Paid Amount:".PadRight(10) + string.Format("{0:C}", textBoxCash.Text), font, new SolidBrush(Color.Red), startX, startY + offset+60);
            graphics.DrawString("Exchange:".PadRight(10) + string.Format("{0:C}", textBoxExchange.Text), font, new SolidBrush(Color.Red), startX, startY + offset+80);
            graphics.DrawString("Have a nice day", new Font("Courier New", 12,FontStyle.Bold), new SolidBrush(Color.Blue), startX+150, startY+offset+120);
            graphics.DrawString("Even a better one tomorrow", new Font("Courier New", 12,FontStyle.Bold), new SolidBrush(Color.Blue), startX+90, startY +offset+135);



        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int quantity;
                string[] value = dataGridView1.Rows[i].Cells[0].Value.ToString().Split('-');
                string value1 = value[1];
                quantity = _pos.GetQuantity(Convert.ToInt32(value1)) -
                           (Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value));
                _pos.UpdateStocked(Convert.ToInt32(value1),quantity);
            }
            string temp = ((Convert.ToDouble(labelSubTotal.Text))* ((Convert.ToDouble(labelVat.Text))/100)).ToString(CultureInfo.CurrentCulture);
            textBoxTotal.Text = (Convert.ToDouble(temp) + Convert.ToDouble(labelSubTotal.Text)).ToString();
            panelPrint.Visible = true;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            textBoxExchange.Text = ((Convert.ToDouble(textBoxCash.Text))-(Convert.ToDouble(textBoxTotal.Text))).ToString(CultureInfo.CurrentCulture);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelPrint.Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PrintReceipt();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("POS SYSTEM \n Version: 1.0.5A2 \n ","About POS SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
