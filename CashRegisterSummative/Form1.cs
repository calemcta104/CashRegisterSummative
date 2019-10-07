using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
/// <summary>
/// Created by Calem McTavish-Giagnocavo
/// October 2019
/// Cash Register Program
/// </summary>
namespace CashRegisterSummative
{
    public partial class Form1 : Form
    {
        const double BURGER_PRICE = 4.00;
        const double FRIES_PRICE = 2.50;
        const double DRINK_PRICE = 2.00;
        const double TAX = 0.13;
        double burgerNumber;
        double fryNumber;
        double drinkNumber;
        double subtotal;
        double orderTax;
        double tendered;
        double change;
        double totalCost;
        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateTotalButton_Click(object sender, EventArgs e)
        {
             //try & catch   
            try
            {
                burgerNumber = Convert.ToDouble(burgerInput.Text);
            }
            catch
            {
                burgerNumber = 0;
            }
            try
            {
                fryNumber = Convert.ToDouble(fryInput.Text);
            }
            catch
            {
                fryNumber = 0;
            }
            try
            {
                drinkNumber = Convert.ToDouble(drinkInput.Text);
            }
            catch
            {
                drinkNumber = 0;
            }
            subtotal = (burgerNumber * BURGER_PRICE) + (fryNumber * FRIES_PRICE) + (drinkNumber * DRINK_PRICE);
            subTotalOutput.Text = subtotal.ToString("C");

            orderTax = TAX * subtotal;
            taxOutput.Text = orderTax.ToString("C");

            totalCost = subtotal + orderTax;
            totalOutput.Text = totalCost.ToString("C");

        }

        private void CalculateChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                tendered = Convert.ToDouble(tenderedInput.Text);
            }

           catch
            {
                tendered = 0;
            }
            try
            {
                change = Convert.ToDouble(tenderedInput.Text);
            }

            catch
            {
                change = 0;
            }
            change = tendered - totalCost;
            changeOutput.Text = change.ToString("C");
        }

        private void NewOrderButton_Click(object sender, EventArgs e)
        {

        }

        private void ReceiptButton_Click(object sender, EventArgs e)
        {
            //graphics objects
            Graphics g = this.CreateGraphics();
            Font receiptFont = new Font("Consolas", 10, FontStyle.Bold);
            SolidBrush receiptBrush = new SolidBrush(Color.White);
            SolidBrush textBrush = new SolidBrush(Color.Black);
            Pen receiptPen = new Pen(Color.Black);
            SoundPlayer receiptSound = new SoundPlayer(Properties.Resources.receipt);

            // white background
            g.FillRectangle(receiptBrush, 244, 78, 240, 330);

            //
            Thread.Sleep(1000);
            g.DrawString(receiptPen, textBrush, );
            
        }
    }
}
