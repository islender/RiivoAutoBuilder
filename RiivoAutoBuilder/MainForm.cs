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

        private string LastListBoxAccessed = null;

        private void PrepareForSaving()
        {
            // read values in different controls and apply changes to riivolution xml
            riivofile.GameID = gameIDtextbox.Text;

        }
        private void PopulateControls()
        {
            gameIDtextbox.Text = riivofile.GameID;
            sectionBox.DataSource = riivofile.GetSections();
            patchIDBox.DataSource = riivofile.GetPatchIDs();
        }

        #region MenuStrip Event Handlers
        // File
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
            sectionBox.Enabled = true;
            patchIDBox.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            #endregion

            gameIDtextbox.Text = riivofile.GameID;
            sectionBox.DataSource = riivofile.GetSections();
            patchIDBox.DataSource = riivofile.GetPatchIDs();
        }
        private void OpenButtonClicked(object sender, EventArgs e)
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

                #region Enable and disable several controls
                gameIDtextbox.Enabled = true;
                sectionBox.Enabled = true;
                patchIDBox.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                #endregion

                #region Populate several controls with data
                gameIDtextbox.Text = riivofile.GameID;

                sectionBox.DataSource = riivofile.GetSections();
                patchIDBox.DataSource = riivofile.GetPatchIDs();
                #endregion
            }
            ofd.Dispose();
        }
        private void SaveButtonClicked(object sender, EventArgs e)
        {
            PrepareForSaving();
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
        // About
        private new void HelpButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Credits: islender");
        }
        #endregion

        #region SectionBox Event Handlers
        private void SectionBoxIndexChanged(object sender, EventArgs e)
        {
            LastListBoxAccessed = "sectionBox";
            choiceBox.Enabled = false;
            patchesBox.Enabled = false;

            ListBox.SelectedObjectCollection test = sectionBox.SelectedItems;
            if (test.Count == 0)
            {
                optionBox.Enabled = false;
                choiceBox.Enabled = false;
                patchesBox.Enabled = false;

                return;
            }
            else
            {
                if (riivofile.GrabSelectedIndex(0) != sectionBox.SelectedIndex)
                {
                    // update index of other controls to the default value/index (0) as they get autoselected. prevents a bug
                    riivofile.UpdateSelectedIndex(1, optionBox.SelectedIndex);
                    riivofile.UpdateSelectedIndex(2, choiceBox.SelectedIndex);
                    riivofile.UpdateSelectedIndex(3, patchesBox.SelectedIndex);
                }
                riivofile.UpdateSelectedIndex(0, sectionBox.SelectedIndex);
                optionBox.DataSource = riivofile.GetOptions();
                optionBox.Enabled = true;

            }
        }
        #endregion

        #region OptionBox Event Handlers
        private void OptionBoxIndexChanged(object sender, EventArgs e)
        {
            LastListBoxAccessed = "optionBox";
            patchesBox.Enabled = false;

            ListBox.SelectedObjectCollection test = optionBox.SelectedItems;
            if (test.Count == 0)
            {
                choiceBox.Enabled = false;
                patchesBox.Enabled = false;

                return;
            }
            else
            {
                if (riivofile.GrabSelectedIndex(0) != sectionBox.SelectedIndex)
                {
                    // update index of other controls to the default value/index (0) as they get autoselected. prevents a bug
                    riivofile.UpdateSelectedIndex(2, choiceBox.SelectedIndex);
                    riivofile.UpdateSelectedIndex(3, patchesBox.SelectedIndex);
                }
                riivofile.UpdateSelectedIndex(1, optionBox.SelectedIndex);
                choiceBox.DataSource = riivofile.GetChoices();
                choiceBox.Enabled = true;
            }
        }
        #endregion

        #region ChoiceBox Event Handlers
        private void ChoiceBoxIndexChanged(object sender, EventArgs e)
        {
            LastListBoxAccessed = "choiceBox";
            ListBox.SelectedObjectCollection test = choiceBox.SelectedItems;
            if (test.Count == 0)
            {
                patchesBox.Enabled = false;

                return;
            }
            else
            {
                if (riivofile.GrabSelectedIndex(0) != sectionBox.SelectedIndex)
                {
                    // update index of other controls to the default value/index (0) as they get autoselected. prevents a bug
                    riivofile.UpdateSelectedIndex(3, patchesBox.SelectedIndex);
                }
                riivofile.UpdateSelectedIndex(2, choiceBox.SelectedIndex);
                patchesBox.DataSource = riivofile.GetPatches();
                patchesBox.Enabled = true;
                
            }
        }
        #endregion

        #region PatchesBox Event Handlers
        private void PatchesBoxIndexChanged(object sender, EventArgs e)
        {
            LastListBoxAccessed = "patchesBox";
            ListBox.SelectedObjectCollection test = patchesBox.SelectedItems;
            if (test.Count == 0)
            {
                return;
            }
            else
            {
                riivofile.UpdateSelectedIndex(3, patchesBox.SelectedIndex);
            }
        }
        #endregion

        #region PatchIDBox Event Handlers
        private void PatchIDBoxIndexChanged(object sender, EventArgs e)
        {
            LastListBoxAccessed = "patchIDBox";
            ListBox.SelectedObjectCollection test = patchIDBox.SelectedItems;
            if (test.Count == 0)
            {
                return;
            }
            else
            {
                riivofile.UpdateSelectedIndex(4, patchIDBox.SelectedIndex);
            }
        }
        #endregion

        #region ContextMenuStrip Event Handlers
        private void ContextMenuOpened(object sender, CancelEventArgs e)
        {
            Control control = ((ContextMenuStrip)(sender)).SourceControl;
            Console.WriteLine("context menu opened on: {0}",control.Name.ToString());
            LastListBoxAccessed = control.Name.ToString();
        }
        private void ContextMenuEditPressed(object sender, EventArgs e)
        {
            Console.WriteLine("edit pressed");
            if (LastListBoxAccessed == "sectionBox" )
            {
                Console.WriteLine("context menu opened on: sectionBox");

            }
            else if (LastListBoxAccessed == "optionBox")
            {
                Console.WriteLine("context menu opened on: optionBox");
            }
            else if (LastListBoxAccessed == "choiceBox")
            {
                Console.WriteLine("context menu opened on: choiceBox");
            }
            else if (LastListBoxAccessed == "patchesBox")
            {
                Console.WriteLine("context menu opened on: patchesBox");
            }
            else if (LastListBoxAccessed == "patchIDBox")
            {
                Console.WriteLine("context menu opened on: patchIDBox");
            }
        }
        private void ContextMenuAddPressed(object sender, EventArgs e)
        {
            Console.WriteLine("add node pressed");

        }
        private void ContextMenuRemovePressed(object sender, EventArgs e)
        {
            Console.WriteLine("remove node pressed");

        }
        private void ContextMenuMoveUpPressed(object sender, EventArgs e)
        {
            Console.WriteLine("move up pressed");

        }
        private void ContextMenuMoveDownPressed(object sender, EventArgs e)
        {
            Console.WriteLine("move down pressed");

        }

        #endregion

        // everything under here is for debugging
        #region debug
        private void traversebutton_Click(object sender, EventArgs e)
        {
            riivofile.StartOptionsTraversal();
        }
        private void patchcountbutton_Click(object sender, EventArgs e)
        {
            
        }
        private void printtoconsole(object sender, EventArgs e)
        {
            riivofile.PrintToConsole();
        }

        private void customtextokclicked(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void europe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void gameIDtextbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            riivofile.EditSelectedNodeName("section", temptextbox.Text);
            PopulateControls();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            riivofile.EditSelectedNodeName("option", temptextbox.Text);
            PopulateControls();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            riivofile.EditSelectedNodeName("choice", temptextbox.Text);
            PopulateControls();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            riivofile.EditSelectedNodeName("patch", temptextbox.Text);
            PopulateControls();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            riivofile.EditSelectedNodeName("patchid", temptextbox.Text);
            PopulateControls();
        }


    }
}
