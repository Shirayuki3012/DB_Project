namespace DB_project
{
    public partial class InsertUpdate : Form
    {
        string TName, Cols, D;
        int PCols;
        DB DB = new DB();
        Form1 Form1;
        public InsertUpdate(Form1 F, string path, string TableName, string Columns, int PrimaryKey, string Data = "")
        {
            Form1 = F;
            InitializeComponent();
            DB.connect(path);
            D=Data;
            TName= TableName;
            PCols = PrimaryKey;
            Cols = Columns;
            if (Data == "")
            {
                label1.Text = "Thêm bản ghi";
                button1.Text = "Thêm";
            }
            else
            {
                label1.Text = "Sửa bản ghi";
                button1.Text = "Sửa";
            }
            string[] column = Columns.Split('|');
            string[] data = Data.Split('|');
            Boolean single = column.Length < 4;
            if (single)
            {
                this.Width = 543;
                button1.Location = new Point(153, 0);
                button2.Location = new Point(263, 0);
            }
            else
            {
                this.Width = 1068;
                button1.Location = new Point(420, 0);
                button2.Location = new Point(530, 0);
            }
            if (single)
            {
                
                for (int i = 0; i < column.Length; i++)
                {
                    IUColumn iUColumn;
                    if (Data != "")
                    {
                        iUColumn = new IUColumn(column[i], data[i]);
                    }
                    else
                    {
                        iUColumn = new IUColumn(column[i]);
                    }
                    iUColumn.Location = new Point(0, 45 + 70 * i);
                    iUColumn.Name = column[i];
                    this.Controls.Add(iUColumn);
                }
                button1.Location = new Point(button1.Location.X, 45 + 70 * column.Length);
                button2.Location = new Point(button2.Location.X, button1.Location.Y);
            }
            else
            {
                for (int i = 0; i < column.Length; i++)
                {
                    IUColumn iUColumn;
                    if (Data != "")
                    {
                        iUColumn = new IUColumn(column[i], data[i]);
                    }
                    else
                    {
                        iUColumn = new IUColumn(column[i]);
                    }
                    iUColumn.Location = new Point(525 * (i % 2), 45 + 70 * (i / 2));
                    iUColumn.Name = column[i];
                    this.Controls.Add(iUColumn);
                }
                button1.Location = new Point(button1.Location.X, 45 + 70 * (column.Length / 2 + column.Length % 2));
                button2.Location = new Point(button2.Location.X, button1.Location.Y);
            }
            this.Height = button1.Location.Y + 100;
        }
        private void InsertUpdate_Load(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string data = "";
            foreach (string Column in Cols.Split("|"))
            {
                IUColumn iUColumn = (IUColumn)this.Controls[Column];
                data += "|" + iUColumn.Data;
            }
            data = data.Substring(1);

            if (button1.Text == "Thêm") 
            {
                if (DB.QueryTool(DB.CreateInsertQuery(TName, Cols, data)))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (string Column in Cols.Split("|"))
                    {
                        IUColumn iUColumn = (IUColumn)this.Controls[Column];
                        iUColumn.ResetTextBox();
                    }
                    Form1.LoadDataGridView();
                }
            }    
            else
            {
                if (DB.QueryTool(DB.CreateUpdateQuery(TName, Cols, data, PCols, D)))
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1.LoadDataGridView();
            }
        }
    }
}
