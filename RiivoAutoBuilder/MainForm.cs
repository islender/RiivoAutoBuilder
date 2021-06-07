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

        private void PrepareForSaving()
        {
            // read values in different controls and apply changes to riivolution xml
            rii.GameID = gameIDtextbox.Text;
        }

        private void PopulateControls()
        {
            gameIDtextbox.Text = rii.GameID;
            sectionBox.DataSource = rii.GetSections();
            patchIDBox.DataSource = rii.GetPatchIDs();
        }
        private void PostLoadConfigControls()
        {
            gameIDtextbox.Enabled = true;
            sectionBox.Enabled = true;
            patchIDBox.Enabled = true;
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
        private bool ChangedSinceSaveCanProceed() 
        {
            if (rii.ChangedSinceSave == true)
            {
                var result = MessageBox.Show("You have unsaved changes, do you want to save?", "Issue", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    rii.Save();
                    if (rii.ChangedSinceSave == false)
                    {
                        Console.WriteLine("Saved changes");
                        rii.NewFilePath = null;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Failed to save changes");
                        return false;
                    }

                }
                if (result == DialogResult.No) // no code because it will jump to the try catch statements
                {
                    Console.WriteLine("Discarded changes");
                    rii.NewFilePath = null;
                    rii.ChangedSinceSave = false;
                    return true;
                }
                if (result == DialogResult.Cancel) // if user presses "x" or "cancel"
                {
                    Console.WriteLine("Cancelled");
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

        // MenuStrip Event Handlers

        private void NewButtonClicked(object sender, EventArgs e)
        {
            bool proceed = ChangedSinceSaveCanProceed();

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
            bool proceed = ChangedSinceSaveCanProceed();
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

        // About

        private new void HelpButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Credits: islender");
        }

        // SectionBox Event Handlers

        private void SectionBoxIndexChanged(object sender, EventArgs e)
        {
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
                if (rii.GrabSelectedIndex(0) != sectionBox.SelectedIndex)
                {
                    // update index of other controls to the default value/index (0) as they get autoselected. prevents a bug
                    rii.UpdateSelectedIndex(1, optionBox.SelectedIndex);
                    rii.UpdateSelectedIndex(2, choiceBox.SelectedIndex);
                    rii.UpdateSelectedIndex(3, patchesBox.SelectedIndex);
                }
                rii.UpdateSelectedIndex(0, sectionBox.SelectedIndex);
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
                if (rii.GrabSelectedIndex(0) != sectionBox.SelectedIndex)
                {
                    // update index of other controls to the default value/index (0) as they get autoselected. prevents a bug
                    rii.UpdateSelectedIndex(2, choiceBox.SelectedIndex);
                    rii.UpdateSelectedIndex(3, patchesBox.SelectedIndex);
                }
                rii.UpdateSelectedIndex(1, optionBox.SelectedIndex);
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
                patchesBox.Enabled = false;

                return;
            }
            else
            {
                if (rii.GrabSelectedIndex(0) != sectionBox.SelectedIndex)
                {
                    // update index of other controls to the default value/index (0) as they get autoselected. prevents a bug
                    rii.UpdateSelectedIndex(3, patchesBox.SelectedIndex);
                }
                rii.UpdateSelectedIndex(2, choiceBox.SelectedIndex);
                patchesBox.DataSource = rii.GetPatches();
                patchesBox.Enabled = true;
                
            }
        }

        private void ChoiceBoxClicked(object sender, MouseEventArgs e)
        {
            LastListBoxAccessed = "choiceBox";
        }

        // PatchesBox Event Handlers

        private void PatchesBoxIndexChanged(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection test = patchesBox.SelectedItems;
            if (test.Count == 0)
            {
                return;
            }
            else
            {
                rii.UpdateSelectedIndex(3, patchesBox.SelectedIndex);
            }
        }

        private void PatchesBoxClicked(object sender, MouseEventArgs e)
        {
            LastListBoxAccessed = "patchesBox";

        }

        // PatchIDBox Event Handlers

        private void PatchIDBoxIndexChanged(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection test = patchIDBox.SelectedItems;
            if (test.Count == 0)
            {
                return;
            }
            else
            {
                rii.UpdateSelectedIndex(4, patchIDBox.SelectedIndex);
            }
        }

        private void PatchIDBoxClicked(object sender, MouseEventArgs e)
        {
            LastListBoxAccessed = "patchIDBox";

        }

        // ContextMenuStrip Event Handlers

        private void ContextMenuOpened(object sender, CancelEventArgs e)
        {
            Control control = ((ContextMenuStrip)(sender)).SourceControl;
            // Console.WriteLine("context menu opened on: {0}",control.Name.ToString());
            LastListBoxAccessed = control.Name.ToString();
            
        }

        private void ContextMenuEditPressed(object sender, EventArgs e)
        {
            if (LastListBoxAccessed == "sectionBox")
            {
                EnterCustomValueForm ecvf = new EnterCustomValueForm();
                ecvf.textboxvalue = rii.GetSelectedNodeName("section");
                ecvf.Setup(ecvf);
                ecvf.ShowDialog();
                string storedvalue = ecvf.textboxvalue;
                if (ecvf.pressedConfirm == true)
                {
                    try
                    {
                        rii.EditSelectedNodeName("section", storedvalue);
                        rii.ChangedSinceSave = true;
                        PopulateControls();
                    }

                    catch
                    {
                        Console.WriteLine("Error writing custom value");
                    }
                    ecvf.Dispose();
                }
                else
                {
                    ecvf.Dispose();
                    return;
                }
            }
            else if (LastListBoxAccessed == "optionBox")
            {
                EnterCustomValueForm ecvf = new EnterCustomValueForm();
                ecvf.textboxvalue = rii.GetSelectedNodeName("option");
                ecvf.Setup(ecvf);
                ecvf.ShowDialog();
                string storedvalue = ecvf.textboxvalue;
                if (ecvf.pressedConfirm == true)
                {
                    try
                    {
                        rii.EditSelectedNodeName("option", storedvalue);
                        rii.ChangedSinceSave = true;
                        PopulateControls();
                    }

                    catch
                    {
                        Console.WriteLine("Error writing custom value");
                    }
                    ecvf.Dispose();
                }
                else
                {
                    ecvf.Dispose();
                    return;
                }
            }
            else if (LastListBoxAccessed == "choiceBox")
            {
                EnterCustomValueForm ecvf = new EnterCustomValueForm();
                ecvf.textboxvalue = rii.GetSelectedNodeName("choice");
                ecvf.Setup(ecvf);
                ecvf.ShowDialog();
                string storedvalue = ecvf.textboxvalue;
                if (ecvf.pressedConfirm == true)
                {
                    try
                    {
                        rii.EditSelectedNodeName("choice", storedvalue);
                        rii.ChangedSinceSave = true;
                        PopulateControls();
                    }

                    catch
                    {
                        Console.WriteLine("Error writing custom value");
                    }
                    ecvf.Dispose();
                }
                else
                {
                    ecvf.Dispose();
                    return;
                }
            }
            else if (LastListBoxAccessed == "patchesBox")
            {
                EnterCustomValueForm ecvf = new EnterCustomValueForm();
                ecvf.textboxvalue = rii.GetSelectedNodeName("patch");
                ecvf.Setup(ecvf);
                ecvf.ShowDialog();
                string storedvalue = ecvf.textboxvalue;
                if (ecvf.pressedConfirm == true)
                {
                    try
                    {
                        rii.EditSelectedNodeName("patch", storedvalue);
                        rii.ChangedSinceSave = true;
                        PopulateControls();
                    }

                    catch
                    {
                        Console.WriteLine("Error writing custom value");
                    }
                    ecvf.Dispose();
                }
                else
                {
                    ecvf.Dispose();
                    return;
                }
            }
            else if (LastListBoxAccessed == "patchIDBox")
            {
                EnterCustomValueForm ecvf = new EnterCustomValueForm();
                ecvf.textboxvalue = rii.GetSelectedNodeName("patchid");
                ecvf.Setup(ecvf);
                ecvf.ShowDialog();
                string storedvalue = ecvf.textboxvalue;
                if (ecvf.pressedConfirm == true)
                {
                    try
                    {
                        rii.EditSelectedNodeName("patchid", storedvalue);
                        rii.ChangedSinceSave = true;
                        PopulateControls();
                    }

                    catch
                    {
                        Console.WriteLine("Error writing custom value");
                    }
                    ecvf.Dispose();
                }
                else
                {
                    ecvf.Dispose();
                    return;
                }
            }
            else
            {
                return;
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

        // everything under here is for debugging

        private void PrintToConsole(object sender, EventArgs e)
        {
            rii.PrintToConsole();
        }
    }
}
