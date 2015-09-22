using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Net.Mail;

namespace FirstTry
{
    public partial class FinalPage : Form
    {
        public FinalPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  MailAddress ma = new MailAddress("sq.martin91@gmail.com");
            MailMessage mm = new MailMessage("Albert", "sq.martin91@gmail.com", "VS test", "undrar om detta funkar lalalalal");
        }

    }
}
