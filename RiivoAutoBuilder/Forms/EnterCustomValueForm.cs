using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiivoAutoBuilder.Forms
{
    public partial class EnterCustomValueForm : Form
    {
        public EnterCustomValueForm()
        {
            InitializeComponent();
        }

        private void ConfirmClicked(object sender, EventArgs e)
        {
            Return();
        }

        private void CancelClicked(object sender, EventArgs e)
        {

        }
        private string Return()
        {
            string text = textBox1.Text;
            return textBox1.Text;
        }
    }
}
