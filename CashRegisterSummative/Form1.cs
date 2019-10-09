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
        //Global variables
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
             //try & catch for food input variables  
            try
            {
                burgerNumber = Convert.ToInt16(burgerInput.Text);
            }
            catch
            {
                burgerNumber = 0;
            }
            try
            {
                fryNumber = Convert.ToInt16(fryInput.Text);
            }
            catch
            {
                fryNumber = 0;
            }
            try
            {
                drinkNumber = Convert.ToInt16(drinkInput.Text);
            }
            catch
            {
                drinkNumber = 0;
            }
            //sub&total&tax calcs.
            subtotal = (burgerNumber * BURGER_PRICE) + (fryNumber * FRIES_PRICE) + (drinkNumber * DRINK_PRICE);
            subTotalOutput.Text = subtotal.ToString("C");

            orderTax = TAX * subtotal;
            taxOutput.Text = orderTax.ToString("C");

            totalCost = subtotal + orderTax;
            totalOutput.Text = totalCost.ToString("C");

        }

        private void CalculateChangeButton_Click(object sender, EventArgs e)
        {
            //try&catch for change and tendered variables
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
            //change and tendered calcs.
            change = tendered - totalCost;
            changeOutput.Text = change.ToString("C");
        }

        private void NewOrderButton_Click(object sender, EventArgs e)
        {
            //Graphics & Clear
            Graphics g = this.CreateGraphics();
            g.Clear(Color.FromArgb(192,0,0));

            //Clearing inputs
            burgerInput.Text = "";
            fryInput.Text = "";
            drinkInput.Text = "";
            subTotalOutput.Text = "";
            totalOutput.Text = "";
            taxOutput.Text = "";
            changeOutput.Text = "";
            tenderedInput.Text = "";

        }

        private void ReceiptButton_Click(object sender, EventArgs e)
        {
            //graphics objects
            Graphics g = this.CreateGraphics();
            Font receiptFont2 = new Font("Consolas", 10, FontStyle.Bold);
            Font receiptFont = new Font("Consolas", 12, FontStyle.Bold);
            SolidBrush receiptBrush = new SolidBrush(Color.White);
            SolidBrush textBrush = new SolidBrush(Color.Black);
            Pen receiptPen = new Pen(Color.Black);
            SoundPlayer receiptSound = new SoundPlayer(Properties.Resources.receipt);

            // white background
            g.FillRectangle(receiptBrush, 244, 78, 240, 330);

            //receipt text
            Thread.Sleep(1000);
            receiptSound.Play();
            Thread.Sleep(900);
            g.DrawString("Hambuguh", receiptFont, textBrush, 320, 100);
         
            Thread.Sleep(1500);
            receiptSound.Play();
            Thread.Sleep(900);
            g.DrawString("Order Number 4761", receiptFont2, textBrush, 255, 140);
            Thread.Sleep(1500);
            receiptSound.Play();
            Thread.Sleep(900);
            g.DrawString("February 30 2020", receiptFont2, textBrush, 255, 150);
            Thread.Sleep(1500);

            receiptSound.Play();
            Thread.Sleep(900);
            g.DrawString("Burgers:     x" + burgerNumber + " @ " + BURGER_PRICE.ToString("C") , receiptFont2, textBrush, 255, 190);
            Thread.Sleep(900);
            receiptSound.Play();
            Thread.Sleep(900);
            g.DrawString("Fries:       x" + fryNumber + " @ " + FRIES_PRICE.ToString("C"), receiptFont2, textBrush, 255, 200);
            Thread.Sleep(900);
            receiptSound.Play();
            Thread.Sleep(900);
            g.DrawString("Drinks:      x" + drinkNumber + " @ " + DRINK_PRICE.ToString("C"), receiptFont2, textBrush, 255, 210);
            receiptSound.Play();
            Thread.Sleep(900);
            g.DrawString("Subtotal:         " + subtotal.ToString("C"), receiptFont2, textBrush, 255, 230);
            Thread.Sleep(900);
            receiptSound.Play();
            Thread.Sleep(900);
            g.DrawString("Order Tax:        " + orderTax.ToString("C"), receiptFont2, textBrush, 255, 240);
            Thread.Sleep(900);
            receiptSound.Play();
            Thread.Sleep(900);
            g.DrawString("Total:            " + totalCost.ToString("C"), receiptFont2, textBrush, 255, 250);
            Thread.Sleep(900);

            receiptSound.Play();
            Thread.Sleep(900);
            g.DrawString("Tendered:         " + tendered.ToString("C"), receiptFont2, textBrush, 255, 270);
            Thread.Sleep(900);
            receiptSound.Play();
            Thread.Sleep(900);
            g.DrawString("Change:           " + change.ToString("C"), receiptFont2, textBrush, 255, 280);
            Thread.Sleep(900);

            receiptSound.Play();
            Thread.Sleep(900);
            g.DrawString("Have a wonderful day!", receiptFont2, textBrush, 275, 300);
        }
    }
}
