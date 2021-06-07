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

        public string textboxvalue;
        public bool pressedConfirm = false;
        EnterCustomValueForm thisform;
        
        public void Setup(EnterCustomValueForm form)
        {
            thisform = form;
            textBox1.Text = textboxvalue;
        }

        private void FinishingUp()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a value", "Error");
            }
            else
            {
                textboxvalue = textBox1.Text;
                pressedConfirm = true;
                thisform.Close();
            }
        }

        private void ConfirmClicked(object sender, EventArgs e)
        {
            FinishingUp();
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            thisform.Close();
        }
    }
}
