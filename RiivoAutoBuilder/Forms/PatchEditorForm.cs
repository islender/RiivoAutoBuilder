using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RiivoAutoBuilder.Forms
{
    public partial class PatchEditorForm : Form
    {
        public PatchEditorForm()
        {
            InitializeComponent();
        }

        public bool pressedConfirm = false;

        private XmlNode currentnode;
        private XmlAttributeCollection patchattributes; 

        PatchEditorForm thisform;

        public void Setup(PatchEditorForm form, XmlNode currentnode)
        {
            thisform = form;
            patchattributes = currentnode.Attributes;
            patchIDName.Text = patchattributes.GetNamedItem("id").Value;


        }


    }
}
