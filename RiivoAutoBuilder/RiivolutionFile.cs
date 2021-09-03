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
        // XML and other nodes
        private XmlDocument xml = new XmlDocument();
        private XmlNode wiidisc;
        private XmlNode options;
        private XmlNode id;
        //

        // Main nodes collections
        private XmlNodeList sectionlist;
        private XmlNodeList optionslist;
        private XmlNodeList choiceslist;
        private XmlNodeList patcheslist;
        private XmlNodeList patchidslist;
        //

        // New node reading system testing
        public List<string> section_collection = new List<string>();
        public List<string> option_collection = new List<string>();
        public List<string> choice_collection = new List<string>();
        public List<string> patch_collection = new List<string>();
        public List<string> patchid_collection = new List<string>();


        #region Misc variables
        private string newFilePath;
        private bool changedSinceLastSave;
        // keeps track of the indexes of the currently selected node in the groupBoxes
        private List<int> selectedIndexes = new List<int> { 0, 0, 0, 0, 0 }; // {section, option, choice, patch, patchid}
        #endregion

        #region Loading, reading and saving methods
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
            // Get other nodes
            wiidisc = xml.SelectSingleNode("wiidisc"); // Get wiidisc (root) node as an "XmlNode"
            options = wiidisc.SelectSingleNode("options"); // get first (and only) <options> node
            id = wiidisc.SelectSingleNode("id"); // self explanatory
            //

            // Get main nodes
            sectionlist = xml.GetElementsByTagName("section");
            optionslist = xml.GetElementsByTagName("option");
            choiceslist = xml.GetElementsByTagName("choice");
            patcheslist = options.SelectNodes("./descendant::patch"); 
            patchidslist = wiidisc.SelectNodes("patch");
            //
        }
        public void Save()
        {
            try
            {
                xml.Save(newFilePath);
                changedSinceLastSave = false;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Save directory not selected. Please choose 'Save As' first","Error");
                return;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Save directory not selected. Please choose 'Save As' first","Error");
                return;
            }
            catch
            {
                MessageBox.Show("Unknown error, please try again","Error");
                return;
            }
        }
        #endregion

        // Selected index stuff
        public void SetSelectedIndex(int index, int value) { selectedIndexes.Insert(index, value); }
        public int GetSelectedIndex(int index) { return selectedIndexes[index]; }
        public List<int> GetSelectedIndexList() { return selectedIndexes; }

        // Debugging methods
        public void PrintToConsole()
        {
            xml.Save(Console.Out);
        }
        //

        #region Obsolete Methods
        // Tree traversal methods

        /*
        [Obsolete]
        public string GetFirstAttributeName(XmlNode node)
        {
            XmlAttributeCollection attributes = node.Attributes;
            Console.WriteLine(node.LocalName);
            Console.WriteLine(attributes.Count);
            XmlAttribute attrib = attributes[0];
            string name = attrib.Value;
            return name;

        }
        [Obsolete]
        public void StartOptionsTraversal()
        {
            section_count = 0;
            option_count = 0;
            choice_count = 0;
            patch_count = 0;
            TraverseOptions(options);
        }
        [Obsolete]
        public void TraverseOptions(XmlNode node)
        {
            Console.WriteLine("one traversal:");
            Console.WriteLine("child nodes? {0}", node.HasChildNodes);
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
                    section_count += 1;
                    section_collection.Add(nodename);
                }
                if (node.LocalName == "option")
                {
                    Console.WriteLine("Adding option...");
                    string nodename = GetFirstAttributeName(node);
                    option_count += 1;
                    option_collection.Add(nodename);
                }
                if (node.LocalName == "choice")
                {
                    Console.WriteLine("Adding choice...");
                    string nodename = GetFirstAttributeName(node);
                    choice_count += 1;
                    choice_collection.Add(nodename);
                }
                if (node.LocalName == "patch")
                {
                    Console.WriteLine("Adding patch...");
                    string nodename = GetFirstAttributeName(node);
                    patch_count += 1;
                    patch_collection.Add(nodename);
                }
                Console.WriteLine("section: {0} option: {1} choice: {2} patch: {3}", section_count, option_count, choice_count, patch_count);
            }
            else
            {
                if (node.LocalName == "section")
                {
                    Console.WriteLine("Adding section...");
                    string nodename = GetFirstAttributeName(node);
                    section_count += 1;
                    section_collection.Add(nodename);
                }
                if (node.LocalName == "option")
                {
                    Console.WriteLine("Adding option...");
                    string nodename = GetFirstAttributeName(node);
                    option_count += 1;
                    option_collection.Add(nodename);
                }
                if (node.LocalName == "choice")
                {
                    Console.WriteLine("Adding choice...");
                    string nodename = GetFirstAttributeName(node);
                    choice_count += 1;
                    choice_collection.Add(nodename);
                }
                if (node.LocalName == "patch")
                {
                    Console.WriteLine("Adding patch...");
                    string nodename = GetFirstAttributeName(node);
                    Console.WriteLine("attribute name: {0}", nodename);
                    patch_count += 1;
                    patch_collection.Add(nodename);
                }
                Console.WriteLine("section: {0} option: {1} choice: {2} patch: {3}", section_count, option_count, choice_count, patch_count);
            }


        }
        //
        */
        #endregion

        // Code for getting and editing nodes and adding and removing them and stuff
        public XmlNode FindSelectedNode(string nodetype)
        {
            if (nodetype == "section")
            {
                XmlNodeList n1 = options.ChildNodes;
                XmlNode editablenode = n1.Item(selectedIndexes[0]);
                return editablenode;
            }
            else if (nodetype == "option")
            {
                XmlNodeList n1 = options.ChildNodes;
                XmlNode n2 = n1.Item(selectedIndexes[0]);
                XmlNodeList n3 = n2.ChildNodes;
                XmlNode editablenode = n3.Item(selectedIndexes[1]);
                return editablenode;
            }
            else if (nodetype == "choice")
            {
                XmlNodeList n1 = options.ChildNodes;
                XmlNode n2 = n1.Item(selectedIndexes[0]);
                XmlNodeList n3 = n2.ChildNodes;
                XmlNode n4 = n3.Item(selectedIndexes[1]);
                XmlNodeList n5 = n4.ChildNodes;
                XmlNode editablenode = n5.Item(selectedIndexes[2]);
                return editablenode;
            }
            else if (nodetype == "patch")
            {
                XmlNodeList n1 = options.ChildNodes;
                XmlNode n2 = n1.Item(selectedIndexes[0]);
                XmlNodeList n3 = n2.ChildNodes;
                XmlNode n4 = n3.Item(selectedIndexes[1]);
                XmlNodeList n5 = n4.ChildNodes;
                XmlNode n6 = n5.Item(selectedIndexes[2]);
                XmlNodeList n7 = n6.ChildNodes;
                XmlNode editablenode = n7.Item(selectedIndexes[3]);
                return editablenode;
            }
            else if (nodetype == "patchid")
            {
                XmlNode editablenode = patchidslist.Item(selectedIndexes[4]);
                return editablenode;
            }
            else 
            {
                MessageBox.Show("Invalid node type, aborting...","Error");
                return null;
            }
            
        }
        public void EditSelectedNodeName(string nodetype, string value)
        {
            XmlNode node = FindSelectedNode(nodetype); // nodetype determines what the name of the node is for editing, example: patch or section
            XmlAttributeCollection attribs = node.Attributes;
            XmlNode attrib = attribs.Item(0);
            attrib.InnerText = value;
        }
        public string GetSelectedNodeName(string nodetype)
        {
            XmlNode node = FindSelectedNode(nodetype);
            XmlAttributeCollection attribs = node.Attributes;
            XmlNode attrib = attribs.Item(0);
            return attrib.InnerText;
        }
        public void DeleteSelectedNode(string nodetype)
        {
            if (nodetype == "section")
            {
                options.RemoveChild(FindSelectedNode("section"));
            }
            else if (nodetype == "option")
            {
                FindSelectedNode("section").RemoveChild(FindSelectedNode("option"));
            }
            else if (nodetype == "choice")
            {
                FindSelectedNode("option").RemoveChild(FindSelectedNode("choice"));
            }
            else if (nodetype == "patch")
            {
                FindSelectedNode("choice").RemoveChild(FindSelectedNode("patch"));
            }
            else if (nodetype == "patchid")
            {
                wiidisc.RemoveChild(patchidslist.Item(selectedIndexes[4]));
                patchidslist = wiidisc.SelectNodes("patch");
            }
        }
        public void AddNewNode(string nodetype)
        {
            XmlDocument temp = new XmlDocument();

            if (nodetype == "section")
            {
                string loadthis = "<section name=\"NewSection\"></section>";
                temp.LoadXml(loadthis);
                XmlNode insertthis = xml.ImportNode(temp.SelectSingleNode("section"),false);
                //
                options.AppendChild(insertthis);
            }
            else if (nodetype == "option")
            {
                string loadthis = "<option name=\"NewOption\"></option>";
                temp.LoadXml(loadthis);
                XmlNode insertthis = xml.ImportNode(temp.SelectSingleNode("option"), false);
                //
                XmlNode parent = FindSelectedNode("section");
                parent.AppendChild(insertthis);
            }
            else if (nodetype == "choice")
            {
                string loadthis = "<choice name=\"NewChoice\"></choice>";
                temp.LoadXml(loadthis);
                XmlNode insertthis = xml.ImportNode(temp.SelectSingleNode("choice"), false);
                //
                XmlNode parent = FindSelectedNode("option");
                parent.AppendChild(insertthis);
            }
            else if (nodetype == "patch")
            {
                string loadthis = "<patch id=\"MyPatch\"></patch>";
                temp.LoadXml(loadthis);
                XmlNode insertthis = xml.ImportNode(temp.SelectSingleNode("patch"), false);
                //
                XmlNode parent = FindSelectedNode("choice");
                parent.AppendChild(insertthis);
            }
            else if (nodetype == "patchid")
            {
                string loadthis = "<patch id=\"MyPatch\"></patch>";
                temp.LoadXml(loadthis);
                XmlNode insertthis = xml.ImportNode(temp.SelectSingleNode("patch"), false);
                //
                wiidisc.AppendChild(insertthis);

                // Refresh patcheslist to contain new patchids
                patchidslist = wiidisc.SelectNodes("patch");
            }

        }

        // Misc properties
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

        // Properties and lists for other stuff
        // stuff for manipulating id tag at top of xml document
        public string GameID
        {
            get
            {
                XmlAttributeCollection idAttributes = id.Attributes; // get attributes of gameid
                XmlNode id2 = idAttributes["game"]; // searches for game attribute
                return id2.Value;
            }
            set
            {
                XmlAttributeCollection idAttributes = id.Attributes; // get attributes of gameid
                XmlNode id2 = idAttributes["game"]; // searches for game attribute
                id2.Value = value;
            }
        }
        public string DeveloperID
        {
            get
            {
                XmlAttributeCollection idAttributes = id.Attributes;
                XmlNode id2 = idAttributes["developer"]; 
                return id2.Value;
            }
            set
            {
                XmlAttributeCollection idAttributes = id.Attributes; 
                XmlNode id2 = idAttributes["developer"]; 
                id2.Value = value;
            }
        }
        public string DiscNumberID
        {
            get
            {
                XmlAttributeCollection idAttributes = id.Attributes; 
                XmlNode id2 = idAttributes["disc"];
                return id2.Value;
            }
            set
            {
                XmlAttributeCollection idAttributes = id.Attributes; 
                XmlNode id2 = idAttributes["disc"]; 
                id2.Value = value;
            }
        }
        public string GameVersionID
        {
            get
            {
                XmlAttributeCollection idAttributes = id.Attributes; 
                XmlNode id2 = idAttributes["version"];
                return id2.Value;
            }
            set
            {
                XmlAttributeCollection idAttributes = id.Attributes;
                XmlNode id2 = idAttributes["version"]; 
                id2.Value = value;
            }
        }

        public List<string> GetRegions()
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

        // Get lists of main nodes to parse to groupBoxes and other controls
        public List<string> GetSections()
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
        public List<string> GetOptions()
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
        public List<string> GetChoices()
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
        public List<string> GetPatches()
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
        public List<string> GetPatchIDs()
        {
            List<string> newlist = new List<string>();
            for (int i = 0; i < patchidslist.Count; i++)
            {
                XmlNode node = patchidslist.Item(i);
                XmlAttributeCollection attribcollect = node.Attributes;
                XmlNode attrib = attribcollect.Item(0);
                newlist.Add(attrib.Value);
            }
            return newlist;
        }
    }

}
