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
using RiivoAutoBuilder.Forms;

namespace RiivoAutoBuilder
{
    public partial class MainForm : Form
    {
        RiivolutionFile rii = new RiivolutionFile();
        public MainForm()
        {
            InitializeComponent();
        }

        private string LastListBoxAccessed = null;
        private List<int> PreviousSelectedIndexes;

        /// <summary>
        /// Read values in different controls and apply the changes to the XmlDocument loaded
        /// </summary>
        private void PrepareForSaving() 
        {
            
            rii.GameID = gameIDtextbox.Text;
        }
        /// <summary>
        /// Fill controls with fresh data from the current XmlDocument loaded
        /// </summary>
        private void PopulateControls()
        {
            gameIDtextbox.Text = rii.GameID;
            sectionBox.DataSource = rii.GetSections();
            patchidBox.DataSource = rii.GetPatchIDs();

            sectionBox.SelectedIndex = rii.GetSelectedIndex(0);
            optionBox.SelectedIndex = rii.GetSelectedIndex(1);
            choiceBox.SelectedIndex = rii.GetSelectedIndex(2);
            patchBox.SelectedIndex = rii.GetSelectedIndex(3);
            patchidBox.SelectedIndex = rii.GetSelectedIndex(4);

        }
        /// <summary>
        /// Enable several controls after loading an XmlDocument successfully
        /// </summary>
        private void PostLoadConfigControls()
        {
            gameIDtextbox.Enabled = true;
            sectionBox.Enabled = true;
            patchidBox.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
        }
        /// <summary>
        /// Checks if there have been changes made to the XmlDocument since the last save.
        /// Also brings up a MessageBox noting unsaved changes.
        /// 
        /// True: shows that all issues have been solved, allows caller to load new file.
        /// False: prevents caller from loading a new file.
        /// </summary>
        /// <returns></returns>
        private bool YouHaveUnsavedChanges() 
        {
            if (rii.ChangedSinceSave == true)
            {
                var result = MessageBox.Show("You have unsaved changes, do you want to save?", "Warning", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    rii.Save();
                    if (rii.ChangedSinceSave == false)
                    {
                        rii.NewFilePath = null;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Failed to save changes","Error");
                        return false;
                    }

                }
                if (result == DialogResult.No) // no code because it will jump to the try catch statements
                {
                    rii.NewFilePath = null;
                    rii.ChangedSinceSave = false;
                    return true;
                }
                if (result == DialogResult.Cancel) // if user presses "x" or "cancel"
                {
                    return false;
                }
                return false;
                
            }
            else if (rii.ChangedSinceSave == false)
            {
                rii.NewFilePath = null;
                return true;
            }
            return false;
        }

        private void OpenCustomValueFormEditor(string whichNodeType)
        {
            EnterCustomValueForm ecvf = new EnterCustomValueForm();
            ecvf.textboxvalue = rii.GetSelectedNodeName(whichNodeType);
            ecvf.Setup(ecvf);
            ecvf.ShowDialog();
            string storedvalue = ecvf.textboxvalue;
            if (ecvf.pressedConfirm == true)
            {
                try
                {
                    rii.EditSelectedNodeName(whichNodeType, storedvalue);
                    rii.ChangedSinceSave = true;
                    PreviousSelectedIndexes = rii.GetSelectedIndexList();
                    PopulateControls();
                }

                catch
                {
                    MessageBox.Show("Error writing custom value","Error");
                }
                ecvf.Dispose();
            }
            else
            {
                ecvf.Dispose();
                return;
            }
        }
        // MenuStrip Event Handlers

        private void NewButtonClicked(object sender, EventArgs e)
        {
            bool proceed = YouHaveUnsavedChanges();

            if (proceed)
            {
                rii.LoadFromTemplate();
                rii.NewFilePath = null;
                rii.ChangedSinceSave = false;

                PostLoadConfigControls();
                PopulateControls();
            }
        }

        private void OpenButtonClicked(object sender, EventArgs e)
        {
            bool proceed = YouHaveUnsavedChanges();
            if (proceed)
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
                    rii.LoadXML(xmlfilepath);

                    PostLoadConfigControls();
                    PopulateControls();
                }
                ofd.Dispose();
            }

        }

        private void SaveButtonClicked(object sender, EventArgs e)
        {
            PrepareForSaving();
            rii.Save();
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
                rii.NewFilePath = sfd.FileName;
                rii.Save();
            }
            sfd.Dispose();
        }

        private new void HelpButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Credits: islender");
        }

        private void IsoBuilderButtonClicked(object sender, EventArgs e)
        {

        }

        // SectionBox Event Handlers

        private void SectionBoxIndexChanged(object sender, EventArgs e)
        {
            choiceBox.Enabled = false;
            patchBox.Enabled = false;

            ListBox.SelectedObjectCollection test = sectionBox.SelectedItems;
            if (test.Count == 0)
            {
                optionBox.Enabled = false;
                choiceBox.Enabled = false;
                patchBox.Enabled = false;

                return;
            }
            else
            {
                if (rii.GetSelectedIndex(0) != sectionBox.SelectedIndex)
                {
                    // update index of other controls to the default value/index (0) as they get autoselected. prevents a bug
                    rii.SetSelectedIndex(1, optionBox.SelectedIndex);
                    rii.SetSelectedIndex(2, choiceBox.SelectedIndex);
                    rii.SetSelectedIndex(3, patchBox.SelectedIndex);
                }
                rii.SetSelectedIndex(0, sectionBox.SelectedIndex);
                optionBox.DataSource = rii.GetOptions();
                optionBox.Enabled = true;

            }
        }

        private void SectionBoxClicked(object sender, MouseEventArgs e)
        {
            LastListBoxAccessed = "sectionBox";
        }

        // OptionBox Event Handlers

        private void OptionBoxIndexChanged(object sender, EventArgs e)
        {

            patchBox.Enabled = false;

            ListBox.SelectedObjectCollection test = optionBox.SelectedItems;
            if (test.Count == 0)
            {
                choiceBox.Enabled = false;
                patchBox.Enabled = false;

                return;
            }
            else
            {
                if (rii.GetSelectedIndex(0) != sectionBox.SelectedIndex)
                {
                    // update index of other controls to the default value/index (0) as they get autoselected. prevents a bug
                    rii.SetSelectedIndex(2, choiceBox.SelectedIndex);
                    rii.SetSelectedIndex(3, patchBox.SelectedIndex);
                }
                rii.SetSelectedIndex(1, optionBox.SelectedIndex);
                choiceBox.DataSource = rii.GetChoices();
                choiceBox.Enabled = true;
            }
        }

        private void OptionBoxClicked(object sender, MouseEventArgs e)
        {
            LastListBoxAccessed = "optionBox";
        }
        
        // ChoiceBox Event Handlers

        private void ChoiceBoxIndexChanged(object sender, EventArgs e)
        {

            ListBox.SelectedObjectCollection test = choiceBox.SelectedItems;
            if (test.Count == 0)
            {
                patchBox.Enabled = false;

                return;
            }
            else
            {
                if (rii.GetSelectedIndex(0) != sectionBox.SelectedIndex)
                {
                    // update index of other controls to the default value/index (0) as they get autoselected. prevents a bug
                    rii.SetSelectedIndex(3, patchBox.SelectedIndex);
                }
                rii.SetSelectedIndex(2, choiceBox.SelectedIndex);
                patchBox.DataSource = rii.GetPatches();
                patchBox.Enabled = true;
                
            }
        }

        private void ChoiceBoxClicked(object sender, MouseEventArgs e)
        {
            LastListBoxAccessed = "choiceBox";
        }

        // PatchBox Event Handlers

        private void PatchBoxIndexChanged(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection test = patchBox.SelectedItems;
            if (test.Count == 0)
            {
                return;
            }
            else
            {
                rii.SetSelectedIndex(3, patchBox.SelectedIndex);
            }
        }

        private void PatchBoxClicked(object sender, MouseEventArgs e)
        {
            LastListBoxAccessed = "patchBox";

        }

        // PatchidBox Event Handlers

        private void PatchidBoxIndexChanged(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection test = patchidBox.SelectedItems;
            if (test.Count == 0)
            {
                return;
            }
            else
            {
                rii.SetSelectedIndex(4, patchidBox.SelectedIndex);
            }
        }

        private void PatchidBoxClicked(object sender, MouseEventArgs e)
        {
            LastListBoxAccessed = "patchidBox";

        }

        // ContextMenuStrip Event Handlers

        private void ContextMenuOpened(object sender, CancelEventArgs e)
        {
            Control control = ((ContextMenuStrip)(sender)).SourceControl;
            LastListBoxAccessed = control.Name.ToString();
            
        }

        private void ContextMenuEditPressed(object sender, EventArgs e)
        {
            #region obsolete code (commented out)
            /*
            if (LastListBoxAccessed == "sectionBox")
            {
                OpenCustomValueFormEditor("section");
            }
            else if (LastListBoxAccessed == "optionBox")
            {
                OpenCustomValueFormEditor("option");
            }
            else if (LastListBoxAccessed == "choiceBox")
            {
                OpenCustomValueFormEditor("choice");
            }
            else if (LastListBoxAccessed == "patchBox")
            {
                OpenCustomValueFormEditor("patch");
            }
            else if (LastListBoxAccessed == "patchidBox")
            {
                OpenCustomValueFormEditor("patchid");
            }
            else
            {
                return;
            }*/
            #endregion
            if (LastListBoxAccessed == "patchidBox")
            {


                PatchEditorForm pef = new PatchEditorForm();
                pef.Setup(pef, rii.FindSelectedNode("patchid"));
                pef.ShowDialog();
            }
            else
            {
                OpenCustomValueFormEditor(LastListBoxAccessed.Replace("Box", ""));
            }
            
            
        }

        private void ContextMenuAddPressed(object sender, EventArgs e)
        {
            try
            {
                rii.AddNewNode(LastListBoxAccessed.Replace("Box", ""));
                rii.ChangedSinceSave = true;
            }
            catch
            {
                MessageBox.Show("Error adding a new node to this category","Error");
            }
            PopulateControls();
        }

        private void ContextMenuRemovePressed(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this node and all subnodes?","Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    rii.DeleteSelectedNode(LastListBoxAccessed.Replace("Box", ""));
                    rii.ChangedSinceSave = true;
                }
                catch
                {
                    MessageBox.Show("Error deleting selected node","Error");
                }
                PopulateControls();
            }
            else if (result == DialogResult.No)
            {
                return;
            }

        }

        private void ContextMenuMoveUpPressed(object sender, EventArgs e)
        {


        }

        private void ContextMenuMoveDownPressed(object sender, EventArgs e)
        {

        }
        //

        // Global Properties events
        private void GameIDTextChanged(object sender, EventArgs e)
        {
            rii.ChangedSinceSave = true;
        }
        // everything under here is for debugging

        private void PrintToConsole(object sender, EventArgs e)
        {
            rii.PrintToConsole();
        }

    }
}
