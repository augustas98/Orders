using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace uzsakymai
{
    public partial class OrderInformation : Form
    {
        public OrderInformation()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = Int32.MaxValue;
            numericUpDown2.Maximum = Int32.MaxValue;
        }

        private void Upsert()
        {
            DBConnect.CreateConnection();
            SqlConnection con = DBConnect.myCon;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Execute [Upsert] @id,@created_at,@updated_at,@delivered_at," +
            "@recipient,@recipient_address,@quantity,@will_pick_up_himself";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(numericUpDown1.Value);
            cmd.Parameters.Add("@created_at", SqlDbType.Date).Value = dateTimePicker1.Text.ToString();
            cmd.Parameters.Add("@updated_at", SqlDbType.Date).Value = dateTimePicker2.Text.ToString();
            cmd.Parameters.Add("@delivered_at", SqlDbType.Date).Value = dateTimePicker3.Text.ToString();
            cmd.Parameters.Add("@recipient", SqlDbType.NVarChar, 50).Value = textBox2.Text.ToString();
            cmd.Parameters.Add("@recipient_address", SqlDbType.NVarChar, 100).Value = textBox3.Text.ToString();
            cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = Convert.ToInt32(numericUpDown2.Value);
            cmd.Parameters.Add("@will_pick_up_himself", SqlDbType.Bit).Value = checkBox1.Checked;
            cmd.ExecuteNonQuery();
            con.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Upsert();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
