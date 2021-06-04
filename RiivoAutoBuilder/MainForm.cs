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
using System.IO;

namespace RiivoAutoBuilder
{
    public partial class MainForm : Form
    {
        RiivolutionFile riivofile = new RiivolutionFile();
        public MainForm()
        {
            InitializeComponent();
        }

        #region MenuStrip Event Handlers
        private void NewButtonClicked(object sender, EventArgs e)
        {
            if (riivofile.ChangedSinceSave)
            {
                var result = MessageBox.Show("You have unsaved changes, do you want to save?", "Creating new file...", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    Console.WriteLine("Saved changes");
                    riivofile.Save();
                    if (riivofile.ChangedSinceSave == false)
                    {
                        riivofile.LoadFromTemplate();
                        riivofile.NewFilePath = null;
                        riivofile.ChangedSinceSave = false;
                    }
                    else
                    {
                        return;
                    }
                }
                if (result == DialogResult.No) // no code because it will jump to the try catch statements
                {
                    Console.WriteLine("Discarded changes");
                    riivofile.LoadFromTemplate();
                    riivofile.NewFilePath = null;
                    riivofile.ChangedSinceSave = false;
                }
                if (result == DialogResult.Cancel) // if user presses "x" or "cancel"
                {
                    Console.WriteLine("Cancelled");
                    return;
                }
            }
            else
            {
                riivofile.LoadFromTemplate();
                riivofile.NewFilePath = null;
                riivofile.ChangedSinceSave = false;
            }
            #region Enable and disable several controls
            gameIDtextbox.Enabled = true;

            s_minusbutton.Enabled = true;
            s_plusbutton.Enabled = true;
            sectionBox.Enabled = true;

            id_minusbutton.Enabled = true;
            id_plusbutton.Enabled = true;
            patchIDBox.Enabled = true;

            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            #endregion

            gameIDtextbox.Text = riivofile.GameID;
            sectionBox.DataSource = riivofile.Sections;
            patchIDBox.DataSource = riivofile.PatchIDs;
        }
        private void LoadButtonClicked(object sender, EventArgs e)
        {
            string xmlfilepath;

            #region OpenFileDialog stuff
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML Files|*.xml|All Files|*.*";
            ofd.Title = "Open Riivolution XML";
            DialogResult ofdr = ofd.ShowDialog();
            xmlfilepath = ofd.FileName;
            #endregion

            if (ofdr == DialogResult.OK)
            {
                riivofile.LoadXML(xmlfilepath);

                gameIDtextbox.Text = riivofile.GameID;

                #region Enable and disable several controls
                gameIDtextbox.Enabled = true;

                s_minusbutton.Enabled = true;
                s_plusbutton.Enabled = true;
                sectionBox.Enabled = true;

                id_minusbutton.Enabled = true;
                id_plusbutton.Enabled = true;
                patchIDBox.Enabled = true;

                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                #endregion

                sectionBox.DataSource = riivofile.Sections;
                patchIDBox.DataSource = riivofile.PatchIDs;
            }
            ofd.Dispose();
        }
        private void SaveButtonClicked(object sender, EventArgs e)
        {
            riivofile.Save();
        }
        private void SaveAsButtonClicked(object sender, EventArgs e)
        {
            #region SaveFileDialog stuff
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML Files|*.xml|All Files|*.*";
            sfd.Title = "Select XML Save Location";
            DialogResult sfdr = sfd.ShowDialog();
            #endregion

            if (sfdr == DialogResult.OK)
            {
                riivofile.NewFilePath = sfd.FileName;
                riivofile.Save();
            }
            sfd.Dispose();
        }
        #endregion

        #region SectionBox Event Handlers
        private void sectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region controls
            c_minusbutton.Enabled = false;
            c_plusbutton.Enabled = false;
            choiceBox.Enabled = false;

            p_minusbutton.Enabled = false;
            p_plusbutton.Enabled = false;
            patchesBox.Enabled = false;
            #endregion

            ListBox.SelectedObjectCollection test = sectionBox.SelectedItems;
            if (test.Count == 0)
            {
                #region controls
                o_minusbutton.Enabled = false;
                o_plusbutton.Enabled = false;
                optionBox.Enabled = false;

                c_minusbutton.Enabled = false;
                c_plusbutton.Enabled = false;
                choiceBox.Enabled = false;

                p_minusbutton.Enabled = false;
                p_plusbutton.Enabled = false;
                patchesBox.Enabled = false;
                #endregion

                return;
            }
            else
            {
                riivofile.UpdateSelectedIndex(0, sectionBox.SelectedIndex);
                optionBox.DataSource = riivofile.Options;

                #region controls
                o_minusbutton.Enabled = true;
                o_plusbutton.Enabled = true;
                optionBox.Enabled = true;
                #endregion
            }
        }
        #endregion

        #region OptionBox Event Handlers
        private void optionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region controls
            p_minusbutton.Enabled = false;
            p_plusbutton.Enabled = false;
            patchesBox.Enabled = false;
            #endregion

            ListBox.SelectedObjectCollection test = optionBox.SelectedItems;
            if (test.Count == 0)
            {
                #region controls
                c_minusbutton.Enabled = false;
                c_plusbutton.Enabled = false;
                choiceBox.Enabled = false;

                p_minusbutton.Enabled = false;
                p_plusbutton.Enabled = false;
                patchesBox.Enabled = false;
                #endregion

                return;
            }
            else
            {
                riivofile.UpdateSelectedIndex(1, optionBox.SelectedIndex);
                choiceBox.DataSource = riivofile.Choices;

                #region controls
                c_minusbutton.Enabled = true;
                c_plusbutton.Enabled = true;
                choiceBox.Enabled = true;
                #endregion
            }
        }
        #endregion

        #region ChoiceBox Event Handlers
        private void choiceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection test = choiceBox.SelectedItems;
            if (test.Count == 0)
            {
                #region controls
                p_minusbutton.Enabled = false;
                patchesBox.Enabled = false;
                #endregion
                return;
            }
            else
            {
                riivofile.UpdateSelectedIndex(2, choiceBox.SelectedIndex);
                patchesBox.DataSource = riivofile.Patches;

                #region controls
                p_minusbutton.Enabled = true;
                patchesBox.Enabled = true;
                #endregion
                
            }
        }
        #endregion

        #region PatchesBox Event Handlers
        private void PatchesMinusClicked(object sender, EventArgs e)
        {

        }
        private void PatchesPlusClicked(object sender, EventArgs e)
        {


        }
        #endregion

        #region PatchIDBox Event Handlers
        private void PatchIDsMinusClicked(object sender, EventArgs e)
        {

        }

        private void PatchIDsPlusClicked(object sender, EventArgs e)
        {

        }

        private void PatchIDsEditClicked(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection test = patchIDBox.SelectedItems;
            if (test.Count == 0)
            {
                return;
            }
            else
            {
                int temptt = patchIDBox.SelectedIndex;
                string streng = temptextbox.Text; // gets text from within temp textbox 
                 // parses patchid index and the name to change the patchid to
            }
        }
        #endregion

        private void patchIDBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void traversebutton_Click(object sender, EventArgs e)
        {
            riivofile.StartOptionsTraversal();
        }

        private void patchcountbutton_Click(object sender, EventArgs e)
        {
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Credits: islender\nLicenses: MIT");
        }

        private void gameIDToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
