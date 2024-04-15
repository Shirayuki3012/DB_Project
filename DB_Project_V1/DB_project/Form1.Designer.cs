namespace DB_project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            comboBox1 = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            comboBox2 = new ComboBox();
            openFileDialog2 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 14);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(77, 29);
            label1.TabIndex = 0;
            label1.Text = "CSDL";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(106, 11);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(981, 36);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(1093, 10);
            button1.Name = "button1";
            button1.Size = new Size(45, 36);
            button1.TabIndex = 2;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 56);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(65, 29);
            label2.TabIndex = 3;
            label2.Text = "Bảng";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "" });
            comboBox1.Location = new Point(106, 53);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(513, 37);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "MDF File|*.mdf";
            openFileDialog1.Title = "Mở CSDL";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 141);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1400, 511);
            dataGridView1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(106, 96);
            button2.Name = "button2";
            button2.Size = new Size(167, 39);
            button2.TabIndex = 6;
            button2.Text = "Nhập dữ liệu";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(279, 96);
            button3.Name = "button3";
            button3.Size = new Size(167, 39);
            button3.TabIndex = 7;
            button3.Text = "Xuất dữ liệu";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(452, 96);
            button4.Name = "button4";
            button4.Size = new Size(167, 39);
            button4.TabIndex = 8;
            button4.Text = "Xóa toàn bộ";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Hiện cấu trúc bảng", "Hiện dữ liệu", "Hiện thông tin khóa chính", "Hiện thông tin khóa ngoại", "Hiện thông tin cơ sở dữ liệu", "Hiện Meta Data", "Hiện thông tin tất cả các bảng " });
            comboBox2.Location = new Point(625, 53);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(513, 37);
            comboBox2.TabIndex = 9;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            openFileDialog2.Filter = "Text File|*.txt";
            openFileDialog2.Title = "Chọn dữ liệu đầu vào";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "TXT File|*.txt";
            saveFileDialog1.Title = "Xuất dữ liệu";
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(625, 96);
            button5.Name = "button5";
            button5.Size = new Size(167, 39);
            button5.TabIndex = 10;
            button5.Text = "Ghi đè";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Enabled = false;
            button6.Location = new Point(798, 96);
            button6.Name = "button6";
            button6.Size = new Size(167, 39);
            button6.TabIndex = 11;
            button6.Text = "Thêm dữ liệu";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Enabled = false;
            button7.Location = new Point(971, 96);
            button7.Name = "button7";
            button7.Size = new Size(167, 39);
            button7.TabIndex = 12;
            button7.Text = "Sửa dữ liệu";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Enabled = false;
            button8.Location = new Point(1144, 96);
            button8.Name = "button8";
            button8.Size = new Size(167, 39);
            button8.TabIndex = 13;
            button8.Text = "Xóa dữ liệu";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 652);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(comboBox2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 3, 5, 3);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            SizeChanged += Form1_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private ComboBox comboBox1;
        private OpenFileDialog openFileDialog1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ComboBox comboBox2;
        private OpenFileDialog openFileDialog2;
        private SaveFileDialog saveFileDialog1;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
    }
}