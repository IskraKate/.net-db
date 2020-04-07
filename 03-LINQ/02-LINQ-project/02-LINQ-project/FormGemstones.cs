using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _02_LINQ_project
{
    public partial class FormGemstone : Form
    {
        private List<Gem> _listGems;
        
        public FormGemstone()
        {
            InitializeComponent();
            FillListBox();
        }

        public void FillListBox()
        {
            XDocument xDoc = XDocument.Load(@"C:\Users\katei\source\repos\.net-db\03-LINQ\02-LINQ-project\Resources\Gemstones.xml");
            var items = from x in xDoc.Element("gemstones").Elements("gemstone")
                        select new Gem
                        {
                            Name = x.Element("name").Value,
                            Color = x.Element("color").Value,
                            Opacity =x.Element("opacity").Value,
                            Type = x.Element("type").Value,
                            Description = x.Element("description").Value
                        };

            _listGems = new List<Gem>(items);


            foreach (var item in items)
            {
                listBoxGems.Items.Add(item.Name);
            }
        }

        private void listBoxGems_SelectedIndexChanged(object sender, EventArgs e)
        {
           var gemstoneInfo = new FormGemtsoneInfo();
            gemstoneInfo.richTextBoxGems.ReadOnly = true;
            gemstoneInfo.richTextBoxGems.BackColor = Color.White;
            foreach (var gem in _listGems)
            {
                if(gem.Name == listBoxGems.SelectedItem.ToString())
                {
                    string opacity;
                    if(gem.Opacity.Equals("1"))
                    {
                        opacity = "Clear";
                    }
                    else
                    {
                        opacity = "Opaque";
                    }

                    gemstoneInfo.richTextBoxGems.Text = $"Name: {gem.Name} \n\n\nColor: { gem.Color} \n\n\nOpacity: {opacity} \n\n\nType: {gem.Type} \n\n\nDescription: {gem.Description}";
                }
            }
            gemstoneInfo.Show();

        }

        public void ColorCheck(CheckBox checkBox)
        {
            listBoxGems.Items.Clear();
            foreach (var gem in _listGems)
            {
                if (gem.Color == checkBox.Text)
                {
                    listBoxGems.Items.Add(gem.Name);
                }
            }
        }

        public void ColorUncheck()
        {
            listBoxGems.Items.Clear();
            foreach (var gems in _listGems)
            {
                listBoxGems.Items.Add(gems.Name);
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;

            if (checkBox.Checked)
                ColorCheck(checkBox);
            else
                ColorUncheck();
        }
    }
}
