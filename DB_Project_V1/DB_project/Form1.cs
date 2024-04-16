namespace DB_project
{
    public partial class Form1 : Form
    {
        DB DB = new DB();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DB.connect(openFileDialog1.FileName, comboBox1);
                textBox1.Text = openFileDialog1.FileName;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = comboBox2.SelectedIndex == 1;
                button8.Enabled = comboBox2.SelectedIndex == 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                DB.ImportData(comboBox1.Text, openFileDialog2.FileName, DB.getColumnDataByColumnName("Columns", "Column_Name", comboBox1.Text));
                LoadDataGridView();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        public void LoadDataGridView()
        {
            button7.Enabled = false;
            button8.Enabled = false;
            if (comboBox2.SelectedIndex == 0)
            {
                DB.getTableData("Columns", dataGridView1, comboBox1.Text);
                return;
            }
            if (comboBox2.SelectedIndex == 1)
            {
                DB.getData(comboBox1.Text, dataGridView1);
                button7.Enabled = button2.Enabled;
                button8.Enabled = button3.Enabled;
                return;
            }
            if (comboBox2.SelectedIndex == 2)
            {
                DB.getTableData("IndexColumns", dataGridView1, comboBox1.Text);
                return;
            }
            if (comboBox2.SelectedIndex == 3)
            {
                DB.getTableData("ForeignKeys", dataGridView1);
            }
            if (comboBox2.SelectedIndex == 4)
            {
                DB.getTableData("Databases", dataGridView1);
                return;
            }
            if (comboBox2.SelectedIndex == 5)
            {
                DB.getTableData("MetaDataCollections", dataGridView1);
                return;
            }
            if (comboBox2.SelectedIndex == 6)
            {
                DB.getTableData("Tables", dataGridView1);
                return;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa toàn bộ dữ liệu của bảng " + comboBox1.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DB.DeleteData(comboBox1.Text);
                LoadDataGridView();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Height = this.Height - 188;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                DB.ExportData(saveFileDialog1.FileName, dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                int index = 0;
                String position = DB.getColumnDataByColumnName("IndexColumns", "ordinal_position", comboBox1.Text);
                foreach (string i in position.Split("|"))
                {
                    index += (int)Math.Pow(2, int.Parse(i) - 1);
                }
                DB.ImportData(comboBox1.Text, openFileDialog2.FileName, DB.getColumnDataByColumnName("Columns", "COLUMN_NAME", comboBox1.Text), true, index);
                LoadDataGridView();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index = 0;
            String position = DB.getColumnDataByColumnName("IndexColumns", "ordinal_position", comboBox1.Text);
            foreach (string i in position.Split("|"))
            {
                index += (int)Math.Pow(2, int.Parse(i) - 1);
            }
            InsertUpdate IU = new InsertUpdate(this, textBox1.Text, comboBox1.Text, DB.getColumnDataByColumnName("Columns", "COLUMN_NAME", comboBox1.Text), index);
            IU.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = 0;
            String position = DB.getColumnDataByColumnName("IndexColumns", "ordinal_position", comboBox1.Text);
            foreach (string i in position.Split("|"))
            {
                index += (int)Math.Pow(2, int.Parse(i) - 1);
            }

            string Data = "";
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];
            foreach (DataGridViewCell dataGridViewCell in row.Cells)
            {
                Data += "|" + dataGridViewCell.Value.ToString();
            }
            Data = Data.Substring(1);
            InsertUpdate IU = new InsertUpdate(this, textBox1.Text, comboBox1.Text, DB.getColumnDataByColumnName("Columns", "COLUMN_NAME", comboBox1.Text), index, Data);
            IU.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa các bản ghi đã chọn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int index = 0;
                String position = DB.getColumnDataByColumnName("IndexColumns", "ordinal_position", comboBox1.Text);
                foreach (string i in position.Split("|"))
                {
                    index += (int)Math.Pow(2, int.Parse(i) - 1);
                }

                string[] Data = new string[dataGridView1.ColumnCount];
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        Data[i] += "|" + row.Cells[i].Value.ToString();
                    }
                }

                string ColumnName = "";
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    Data[i] = Data[i].Substring(1);
                    ColumnName += "|" + dataGridView1.Columns[i].Name.ToString();
                }

                if (DB.QueryTool(DB.CreateDeleteQuery(comboBox1.Text, ColumnName.Substring(1), Data, index)))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
            }
        }
    }
}
