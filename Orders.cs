using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace uzsakymai
{
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderInformation myform = new OrderInformation();
            myform.ShowDialog();
            LoadGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderInformation myform = new OrderInformation();
            myform.numericUpDown1.Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            myform.numericUpDown1.ReadOnly = true;
            myform.numericUpDown1.Increment = 0;
            myform.numericUpDown2.Maximum = Int32.MaxValue;
            myform.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["Created at"].Value.ToString();
            myform.dateTimePicker2.Text = dataGridView1.CurrentRow.Cells["Updated at"].Value.ToString();
            myform.dateTimePicker3.Text = dataGridView1.CurrentRow.Cells["Delivered at"].Value.ToString();
            myform.textBox2.Text = dataGridView1.CurrentRow.Cells["Recipient"].Value.ToString();
            myform.textBox3.Text = dataGridView1.CurrentRow.Cells["Recipient address"].Value.ToString();
            myform.numericUpDown2.Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Quantity"].Value.ToString());
            myform.checkBox1.Checked = (bool)dataGridView1.CurrentRow.Cells["Pick up state"].Value;
            myform.ShowDialog();
            LoadGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            DeleteRow(id);
            LoadGrid();
        }

        private void LoadGrid()
        {
            DBConnect.CreateConnection();
            SqlConnection connection = DBConnect.myCon;
            SqlDataAdapter dataadapter = new SqlDataAdapter("[Select]", connection);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "orders_table");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "orders_table";
        }
        
        private void DeleteRow(int id)
        {
            DBConnect.CreateConnection();
            SqlConnection con = DBConnect.myCon;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Execute [Delete] @id";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
