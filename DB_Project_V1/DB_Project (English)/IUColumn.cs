using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_project
{
    public partial class IUColumn : UserControl
    {
        public string Data = "";
        public IUColumn(string ColumnName, string data = "")
        {
            InitializeComponent();
            label1.Text = ColumnName;
            textBox1.Text = data;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Data = textBox1.Text;
        }
        public void ResetTextBox()
        {
            textBox1.Text = "";
        }
    }
}
