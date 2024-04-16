﻿using System.Data.SqlClient;
using System.Data;

namespace DB_project
{
    internal class DB
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        //Connect DB to database
        public void connect(string path, ComboBox? cb = null)
        {
            if (cn.State==ConnectionState.Open)
            {
                cn.Close(); 
            }
            cn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
            cn.Open();

            cmd.Connection= cn;

            if (cb != null)
            {
                DataTable dt = cn.GetSchema("Tables");
                cb.DataSource = dt;
                cb.DisplayMember = "TABLE_NAME";
            }
        }

        //Get data of the table
        public void getData(string table, DataGridView view)
        {
            if (cn.State == ConnectionState.Open)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + table, cn);
                da.Fill(dt);
                view.DataSource = dt;
            }    
        }

        //Get the Schema Table of Table
        public void getTableData(string CollectionName, DataGridView view, string tablename = "")
        {
            if (cn.State == ConnectionState.Open) 
            {
                DataTable dt;
                if (tablename != "")
                    dt = cn.GetSchema(CollectionName, new[] { null, null, tablename });
                else
                    dt=cn.GetSchema(CollectionName);
                view.DataSource = dt;
            }
        }
        public string getColumnDataByIndex(string CollectionName, int index, string TableName = "")
        {
            if (cn.State == ConnectionState.Open)
            {
                string kq = "";
                DataTable dt = getSchemaTable(CollectionName, TableName);
                foreach (DataRow dr in dt.Rows)
                {
                    kq += "|" + dr[index].ToString();
                }
                return kq.Substring(1);
            }
            return "";
        }
        public string getColumnDataByColumnName(string CollectionName, string ColumnName, string TableName = "")
        {
            if (cn.State == ConnectionState.Open)
            {
                string kq = "";
                DataTable dt = getSchemaTable(CollectionName, TableName);
                foreach (DataRow dr in dt.Rows)
                {
                    kq += "|" + dr[ColumnName].ToString();
                }
                return kq.Substring(1);
            }
            return "";
        }

        //Get the Schema Table return DataTable
        private DataTable getSchemaTable(string CollectionName, string TableName = "")
        {
            DataTable dt;
            if (TableName != "")
                dt = cn.GetSchema(CollectionName, new[] { null, null, TableName });
            else
                dt = cn.GetSchema(CollectionName);
            return dt;
        }

        //Get the type of datatypes, need to create query
        private Boolean[] get_type(string TableName)
        {
            int i = 0;
            DataTable dt = getSchemaTable("Columns", TableName);    
            string type = "char|nchar|varchar|nvarchar|text|ntext|date";
            Boolean[] Type = new Boolean[dt.Rows.Count];
            foreach (DataRow dr in dt.Rows)
            {
                Type[i] = type.IndexOf(dr[7].ToString()) != -1;
                i++;
            }
            return Type;
        }

        //Import Data from .txt file to database
        public void ImportData(string tablename, string path, string ColumnName, Boolean OverWrite = false, int PCols = 0)
        {
            Boolean[] type = get_type(tablename);
            Boolean Set_II = true;
            try
            {
                cmd.CommandText = "SET IDENTITY_INSERT " + tablename + " ON";
                cmd.ExecuteNonQuery();
            }
            catch 
            {
                Set_II= false;
            }
            //Read from file
            StreamReader sr =new StreamReader(path);
            string[] rc_set = sr.ReadToEnd().Replace("\r", "").Split("\n");
            sr.Close();

            //This variable contains the exception message
            string exx = "";
            foreach (string line in rc_set)
            {
                if (line != "")
                {                  
                    try
                    {
                        cmd.CommandText = CreateInsertQuery(tablename, ColumnName, line.Replace("\t", "|"));
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //If user want to overwrite the duplicate record, update the data instead of insert new record
                        if (OverWrite)
                        {
                            cmd.CommandText = CreateUpdateQuery(tablename, ColumnName, line.Replace("\t", "|"), PCols);
                            cmd.ExecuteNonQuery();
                        }
                        else
                            exx += ex.ToString() + "\n";
                    }
                }
            }
            if (exx!="")
            {
                //Show exception message
                MessageBox.Show("Import Data catch Exception\n" + exx, "Exception Show", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            if (Set_II)
            {
                cmd.CommandText = "SET IDENTITY_INSERT " + tablename + " OFF";
                cmd.ExecuteNonQuery();
            }
        }

        //Get the data From DataGridView and export to .txt file
        public void ExportData(string path, DataGridView view)
        {
            StreamWriter sw = new StreamWriter(path);
            foreach (DataGridViewRow row in view.Rows)
            {
                string line = "";
                foreach (DataGridViewCell cell in row.Cells)
                {
                    line += "\t" + cell.Value.ToString();
                }
                sw.WriteLine(line.Substring(1));
            }
            sw.Close();
        }

        //Delete All table's data
        public void DeleteData(string tablename)
        {
            cmd.CommandText = "DELETE FROM " + tablename;
            cmd.ExecuteNonQuery();
        }
        public string CreateInsertQuery(string TableName, string ColumnName, string ValueList)
        {
            Boolean[] type = get_type(TableName);
            int i = 0;
            string values = "";
            //Định dạng giá trị nhập
            foreach (string line2 in ValueList.Split("|"))
            {
                if (type[i])
                    values += ", " + "'" + line2 + "'";
                else
                    values += ", " + line2;
                i++;
            }
            values = values.Substring(2);
            return "INSERT INTO " + TableName + "(" + ColumnName.Replace("|", ", ") + ") VALUES(" + values + ")";
        }
        public string CreateUpdateQuery(string TableName, string ColumnName, string ValueList, int PCols, string PValues = "")
        {
            Boolean[] type = get_type(TableName);
            if (PValues == "")
            {
                PValues = ValueList;
            } 
                
            int i = 0;
            string where = "";
            string set = "";
            string[] data = ValueList.Split("|");
            foreach(string Col in ColumnName.Split("|"))
            {
                if (PCols % 2 == 1)
                {
                    if (type[i])
                        where += " AND " + Col + " = '" + data[i] + "'";
                    else
                        where += " AND " + Col + " = " + data[i];
                }
                if (type[i])
                    set += ", " + Col + " = '" + data[i] + "'";
                else
                    set += ", " + Col + " = " + data[i];
                PCols /= 2; 
                i++;
            }
            where = where.Substring(5);
            set = set.Substring(2);

            return "UPDATE " + TableName + " SET " + set + " WHERE " + where;
        }
        public string CreateDeleteQuery(string TableName, string ColumnName, string[] ValueList, int PCols)
        {
            Boolean[] type = get_type(TableName);
            int i = 0;
            string where = "";
            foreach (string p in ColumnName.Split("|"))
            {
                if (p != "")
                {
                    if (PCols % 2 == 1)
                    {
                        if (type[i])
                        {
                            ValueList[i] = "'" + ValueList[i].Replace("|", "', '") + "'";
                        }
                        else
                        {
                            ValueList[i] = ValueList[i].Replace("|", ", ");
                        }
                        where += " AND " + p + " IN (" + ValueList[i] + ")";
                    }
                    PCols /= 2;
                    i++;
                }
            }
            where = where.Substring(5);
            return "DELETE FROM " + TableName + " WHERE " + where;
        }

        //Excute the input query (commandtext)
        public Boolean QueryTool(string commandtext)
        {
            try
            {
                cmd.CommandText = commandtext;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Catch Error\n" + ex.ToString(),"Command can't be execute", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
