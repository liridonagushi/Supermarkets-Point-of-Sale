using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using System.Xml;

namespace DMobile
{
    public partial class checkXml : Form
    {
        public checkXml()
        {
            InitializeComponent();
        }

        private static bool exists(string CPUID)
        {
            string path;
            string xmlfile = "\\xmlfile.xml";
            path = Environment.CurrentDirectory + xmlfile;
            XDocument xmlDoc = XDocument.Load(path);

            bool doesexists = (from data in xmlDoc.Element("usertype").Elements("CPU")
                               where (string)data.Attribute("id") == CPUID
                           select data).Any();
            return doesexists;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exists("bvcn");
        }
    }
}