using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace RiivoAutoBuilder
{
    class RiivolutionFile
    {
        #region XML and Nodes
        private XmlDocument xml = new XmlDocument();
        public XmlNode wiidisc;
        public XmlNode options;
        public XmlNodeList sectionlist;
        public XmlNodeList patcheslist;
        #endregion

        #region New nodes and traversal code
        public List<string> section_collection = new List<string>();
        public List<string> option_collection = new List<string>();
        public List<string> choice_collection = new List<string>();
        public List<string> patch_collection = new List<string>();
        public List<string> patchid_collection = new List<string>();
        // show how many of each node there are
        public int section_;
        public int option_;
        public int choice_;
        public int patch_;
        public int patchid_;

        public void StartOptionsTraversal()
        {
            section_ = 0;
            option_ = 0;
            choice_ = 0;
            patch_ = 0;
            TraverseOptions(options);
        }
        public void TraverseOptions(XmlNode node)
        {
            Console.WriteLine("one traversal:");
            Console.WriteLine("child nodes? {0}",node.HasChildNodes);
            if (node.HasChildNodes == true) // checks if current node has any children
            {
                XmlNodeList list = node.ChildNodes;
                int count = list.Count;
                for (int i = 0; i < count; i++)
                {
                    TraverseOptions(list[i]);
                }
                
                if (node.LocalName == "section") 
                {
                    Console.WriteLine("Adding section...");
                    string nodename = GetFirstAttributeName(node);
                    section_ += 1;
                    section_collection.Add(nodename);
                }
                if (node.LocalName == "option")
                {
                    Console.WriteLine("Adding option...");
                    string nodename = GetFirstAttributeName(node);
                    option_ += 1;
                    option_collection.Add(nodename);
                }
                if (node.LocalName == "choice")
                {
                    Console.WriteLine("Adding choice...");
                    string nodename = GetFirstAttributeName(node);
                    choice_ += 1;
                    choice_collection.Add(nodename);
                }
                if (node.LocalName == "patch") 
                {
                    Console.WriteLine("Adding patch...");
                    string nodename = GetFirstAttributeName(node);
                    patch_ += 1;
                    patch_collection.Add(nodename);
                }
                Console.WriteLine("section: {0} option: {1} choice: {2} patch: {3}", section_, option_, choice_, patch_);
            }
            else
            {
                if (node.LocalName == "section")
                {
                    Console.WriteLine("Adding section...");
                    string nodename = GetFirstAttributeName(node);
                    section_ += 1;
                    section_collection.Add(nodename);
                }
                if (node.LocalName == "option")
                {
                    Console.WriteLine("Adding option...");
                    string nodename = GetFirstAttributeName(node);
                    option_ += 1;
                    option_collection.Add(nodename);
                }
                if (node.LocalName == "choice")
                {
                    Console.WriteLine("Adding choice...");
                    string nodename = GetFirstAttributeName(node);
                    choice_ += 1;
                    choice_collection.Add(nodename);
                }
                if (node.LocalName == "patch")
                {
                    Console.WriteLine("Adding patch...");
                    string nodename = GetFirstAttributeName(node);
                    Console.WriteLine("attribute name: {0}", nodename);
                    patch_ += 1;
                    patch_collection.Add(nodename);
                }
                Console.WriteLine("section: {0} option: {1} choice: {2} patch: {3}", section_, option_, choice_, patch_);
            }
            
                
        }

        public string GetFirstAttributeName(XmlNode node)
        {
            XmlAttributeCollection attributes = node.Attributes;
            Console.WriteLine(node.LocalName);
            Console.WriteLine(attributes.Count);
            XmlAttribute attrib = attributes[0];
            string name = attrib.Value;
            return name;

        }

        // public void EditTraversal(XmlNode node,int nodeindex,string nodename)
        #endregion

        private string newFilePath;
        private bool changedSinceLastSave;
        private List<int> selectedIndexes = new List<int> { 0, 0, 0, 0, 0 }; // {section, option, choice, patch, patchid}

        public void LoadFromTemplate()
        {
            try
            {
                xml.PreserveWhitespace = false;
                xml.Load("Templates/Template.xml");
                ReadXML();
            }
            catch
            {
                throw;
            }
        }
        public void LoadXML(string filePath)
        {
            newFilePath = filePath; // allows for "Save As" functionality later
            try
            {
                xml.PreserveWhitespace = false; // ensure nodes are listed without "#whitespace"
                xml.Load(filePath); // load xml at target directory
                ReadXML();
            }
            catch
            {
                throw;
            }
        }
        private void ReadXML()
        {
            #region Get all the nodes
            this.wiidisc = xml.SelectSingleNode("wiidisc"); // Get wiidisc (root) node as an "XmlNode"
            this.options = wiidisc.SelectSingleNode("options"); // get first (and only) <options> node
            this.sectionlist = options.SelectNodes("section"); // get all <section>s
            this.patcheslist = wiidisc.SelectNodes("patch"); // get all <patch>es
            #endregion
        }
        public void UpdateSelectedIndex(int index, int value)
        {
            selectedIndexes.Insert(index, value);
        }
        public void Save()
        {
            try
            {
                xml.Save(newFilePath);
                MessageBox.Show("Saving successful!");
                changedSinceLastSave = false;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Error: Save directory not selected. Please choose 'Save As' first");
                return;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Error: Save directory not selected. Please choose 'Save As' first");
                return;
            }
            catch
            {
                MessageBox.Show("Error: Unknown error, please try again");
                return;
            }
        }
        public void EditAttribute()
        {

        }

        public string NewFilePath
        {
            get
            {
                return newFilePath;
            }
            set
            {
                newFilePath = value;
            }
        }
        public bool ChangedSinceSave
        {
            get
            {
                return changedSinceLastSave;
            }
            set
            {
                changedSinceLastSave = value;
            }
        }

        public string GameID
        {
            get
            {
                XmlNode id = wiidisc.SelectSingleNode("id");
                XmlAttributeCollection idAttributes = id.Attributes; // get attributes of gameid
                XmlNode id2 = idAttributes["game"]; // searches for game attribute
                return id2.Value;
            }
            set
            {
                XmlNode id = wiidisc.SelectSingleNode("id");
                XmlAttributeCollection idAttributes = id.Attributes; // get attributes of gameid
                XmlNode id2 = idAttributes["game"]; // searches for game attribute
                id2.Value = value;
            }
        }
        public string WiidiscRoot
        {
            get
            {
                XmlAttributeCollection attribs = wiidisc.Attributes;
                XmlNode root = attribs["root"];
                return root.Value;
            }
            set
            {
                XmlAttributeCollection attribs = wiidisc.Attributes;
                XmlNode root = attribs["root"];
                root.Value = value;
            }
        }
        
        public List<string> Regions
        {
            get
            {
                List<string> regioncodes = new List<string>();
                XmlNodeList regions = wiidisc.SelectNodes("region");
                for (int i = 0; i < regions.Count; i++)
                {
                    XmlNode node = regions.Item(i);
                    XmlAttributeCollection attribs = node.Attributes; // get attributes of gameid
                    XmlNode attr2 = attribs["type"]; // searches for game attribute
                    regioncodes.Add(attr2.Value);
                }
                return regioncodes;
            }
            set
            {

            }
        }
        public List<string> Sections
        {
            get
            {
                List<string> newlist = new List<string>();
                for (int i = 0; i < sectionlist.Count; i++)
                {
                    XmlNode node = sectionlist.Item(i);
                    XmlAttributeCollection attribcollect = node.Attributes;
                    XmlNode attrib = attribcollect.Item(0);
                    newlist.Add(attrib.Value);
                }
                return newlist;
            }
            set
            {

            }
        }
        public List<string> Options
        {
            get
            {
                XmlNode selected_section = sectionlist.Item(selectedIndexes[0]);
                XmlNodeList nodelist = selected_section.ChildNodes;
                List<string> newlist = new List<string>();
                for (int i = 0; i < nodelist.Count; i++)
                {
                    XmlNode node = nodelist.Item(i);
                    XmlAttributeCollection attribcollect = node.Attributes;
                    XmlNode attrib = attribcollect.Item(0);
                    newlist.Add(attrib.Value);
                }
                return newlist;
            }
            set
            {

            }
        }
        public List<string> Choices
        {
            get
            {
                XmlNode selected_section = sectionlist.Item(selectedIndexes[0]);
                XmlNodeList nodelist1 = selected_section.ChildNodes;
                XmlNode selected_option = nodelist1.Item(selectedIndexes[1]);
                XmlNodeList nodelist = selected_option.ChildNodes;

                List<string> newlist = new List<string>();
                for (int i = 0; i < nodelist.Count; i++)
                {
                    XmlNode node = nodelist.Item(i);
                    XmlAttributeCollection attribcollect = node.Attributes;
                    XmlNode attrib = attribcollect.Item(0);
                    newlist.Add(attrib.Value);
                }
                return newlist;
            }
            set
            {

            }
        }
        public List<string> Patches
        {
            get
            {
                XmlNode selected_section = sectionlist.Item(selectedIndexes[0]);
                XmlNodeList nodelist1 = selected_section.ChildNodes;
                XmlNode selected_option = nodelist1.Item(selectedIndexes[1]);
                XmlNodeList nodelist2 = selected_option.ChildNodes;
                XmlNode selected_choice = nodelist2.Item(selectedIndexes[2]);
                XmlNodeList nodelist = selected_choice.ChildNodes;

                List<string> newlist = new List<string>();
                for (int i = 0; i < nodelist.Count; i++)
                {
                    XmlNode node = nodelist.Item(i);
                    XmlAttributeCollection attribcollect = node.Attributes;
                    XmlNode attrib = attribcollect.Item(0);
                    newlist.Add(attrib.Value);
                }
                return newlist;
            }
            set
            {
                XmlNode selected_section = sectionlist.Item(selectedIndexes[0]);
                XmlNodeList nodelist1 = selected_section.ChildNodes;
                XmlNode selected_option = nodelist1.Item(selectedIndexes[1]);
                XmlNodeList nodelist2 = selected_option.ChildNodes;
                XmlNode selected_choice = nodelist2.Item(selectedIndexes[2]);

                List<string> listt = this.Patches;
                int size = listt.Count;

                selected_choice.AppendChild(xml.CreateElement("patch"));
                XmlNodeList childnodes = selected_choice.ChildNodes;
                int thing = childnodes.Count;


            }
        }
        public List<string> PatchIDs
        {
            get
            {
                List<string> newlist = new List<string>();
                for (int i = 0; i < patcheslist.Count; i++)
                {
                    XmlNode node = patcheslist.Item(i);
                    XmlAttributeCollection attribcollect = node.Attributes;
                    XmlNode attrib = attribcollect.Item(0);
                    newlist.Add(attrib.Value);
                }
                return newlist;
            }
            set
            {

            }
        }

    }

    class WiidiscNode
    {
        public string version
        {
            get
            {
                return version;
            }
            set
            {
                this.version = value;
            }
        }
        public string root
        {
            get
            {
                return root;
            }
            set
            {
                this.root = value;
            }
        }

        public void Apply()
        {
            
        }

    }
}
