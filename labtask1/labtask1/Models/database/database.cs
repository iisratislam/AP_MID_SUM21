using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace labtask1.Models.database
{
    public class database
    {
        public students students { get; set; }
        public database()
        {
            string connstring = @"Server=MSI;Database=SMS;Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connstring);
            students = new students(conn);
        }
    }
}