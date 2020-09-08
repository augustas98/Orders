using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace uzsakymai
{
    class DBConnect
    {

        public static SqlConnection myCon = null;

        public static void CreateConnection()
        {

            try
            {
                myCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True;");
                myCon.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Exception caught: Connection to the database failed", e.ToString());
                Environment.Exit(1);
            }
        }

    }
}
