using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;


namespace News
{
    public partial class Form1 : Form
    {
        List<Item> items = new List<Item>();
        public Form1()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click);
        }
        private void load()
        {
            string url = textBox1.Text;
            XmlReader xmlreader = XmlReader.Create(url);
            int index = 0;
            while (xmlreader.Read())
            {
                if (xmlreader.Name == "item")
                {
                    XmlReader pReader = xmlreader.ReadSubtree();
                    String title = "";
                    String link = "";
                    while (pReader.Read())
                    {

                        if (pReader.Name == "title")
                        {
                            XmlReader cReader = pReader.ReadSubtree();
                            while (cReader.Read())
                            {
                                if (cReader.Value != "")
                                {
                                    listBox1.Items.Add(cReader.Value);
                                    title = cReader.Value;
                                }

                            }
                        }

                        if (pReader.Name == "link")
                        {
                            XmlReader cReader = pReader.ReadSubtree();
                            while (cReader.Read())
                            {
                                if (cReader.Value != "")
                                {
                                    link = cReader.Value;
                                }

                            }
                        }



                    }
                    items.Add(new Item { Id = index, Title = title, Link = link });
                    index++;
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            items.Clear();
            load();
        }

        private void listBox1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            Item item = Array.Find(items.ToArray(), it => it.Id == index);
            //System.Diagnostics.Debug.WriteLine(item.Link.ToString());
            //MessageBox.Show(item.ToString());
            ProcessStartInfo sInfo = new ProcessStartInfo(item.Link.ToString());
            Process.Start(sInfo);
        }
    }
}

public class Item
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
}