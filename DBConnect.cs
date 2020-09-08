using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace uzsakymai
{
    class DBConnect
    {

        public static SqlConnection myCon = null;

        public static void CreateConnection()
        {
            myCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True;");
            myCon.Open();
        }
    }
}
