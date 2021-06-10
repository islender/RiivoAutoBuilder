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
    public partial class PatchEditorForm : Form
    {
        public PatchEditorForm()
        {
            InitializeComponent();
        }

        public string textboxvalue;
        public bool pressedConfirm = false;
        PatchEditorForm thisform;

        public void Setup(PatchEditorForm form)
        {
            thisform = form;
            textBox1.Text = textboxvalue;
        }

    }
}
