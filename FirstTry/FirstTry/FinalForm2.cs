using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;


namespace FirstTry
{
    public partial class FinalForm2 : Form
    {
        public FinalForm2()
        {
            InitializeComponent();
        }

        private void FinalForm2_Load(object sender, EventArgs e)
        {

        }

        private void Print()
        {
            //PrintDocument pd = new PrintDocument();
            //PaperSize ps = new PaperSize("", 420, 540);

            //pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            //pd.PrintController = new StandardPrintController();
            //pd.DefaultPageSettings.Margins.Left = 50;
            //pd.DefaultPageSettings.Margins.Right = 50;
            //pd.DefaultPageSettings.Margins.Top = 50;
            //pd.DefaultPageSettings.Margins.Bottom = 50;
            //pd.DefaultPageSettings.PaperSize = ps;
            //pd.Print();
            //g.Dispose();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //int SPACE = 145;
           
            //Graphics g = e.Graphics;
            //g.DrawRectangle(Pens.Black, 5, 5, 410, 530);

            //Font fBody = new Font("Lucida Console", 15, FontStyle.Bold);
            //Font fBody1 = new Font("Lucida Console", 15, FontStyle.Regular);
            //Font fBody2 = new Font("Lucida Console", 9, FontStyle.Regular);

            //SolidBrush sb = new SolidBrush(Color.Black);
            
            //g.DrawString("KuloBus", fBody1, sb, 10, 120);
            //g.DrawString("------------------------------", fBody1, sb, 20, 120);
            //g.DrawString("Hermans barnjonglering", fBody1, sb, 50, 120);
            //g.DrawString("BYOB", fBody1, sb, 80, 120);          
        }
    }
    
}
