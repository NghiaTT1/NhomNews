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
    }
}

public class Item
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
}