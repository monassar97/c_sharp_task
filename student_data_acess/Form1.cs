using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace student_data_acess
{
    public partial class Form1 : Form
    {
        OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\pc\Downloads\database.accdb");
        OleDbDataAdapter Da;
        DataTable Dt = new DataTable();
        OleDbCommand cmd;

        public Form1()
        {
            InitializeComponent();
            FillDatagridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void FillDatagridView()
        {
            Dt.Clear();
            Da = new OleDbDataAdapter("Select * From TBL_Students", cn);
            Da.Fill(Dt);
            dataGridView1.DataSource = Dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("Insert Into TBL_Students(ID,Address,Age,FullName) Values ('" + textBox1.Text + "' , '" + textBox2.Text + "' , " + Convert.ToInt32(textBox3.Text) + " , '" + textBox4.Text + "')", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            FillDatagridView();
            MessageBox.Show("Added Sucessfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("Update TBL_Students SET FullName ='"+ textBox2.Text +"' , Age = '"+ Convert.ToInt32(textBox3.Text)+"', Address= '"+ textBox4.Text +"' WHERE ID= '"+textBox1.Text+"'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            FillDatagridView();
            MessageBox.Show("Updated Sucessfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand("Delete From TBL_Students where ID = '" + textBox1.Text + "' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            FillDatagridView();
            MessageBox.Show("Deleted Sucessfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_MultiSelectChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
