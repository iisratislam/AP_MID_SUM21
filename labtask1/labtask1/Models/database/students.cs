using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;




namespace labtask1.Models.database


{

    public class students
    {
        SqlConnection conn;
        public students(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void Insert(student s)
        {
            string query = string.Format("insert into students values('{0}','{1}')", s.NAME, s.CGPA);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<student> GetAll()
        {
            List<student> students = new List<student>();
            string query = "select * from students";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                student s = new student()
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    NAME = reader.GetString(reader.GetOrdinal("NAME")),
                    CGPA = reader.GetInt32(reader.GetOrdinal("CGPA"))

                };
                students.Add(s);





            }
            conn.Close();
            return students;

        }
       public student Get(int id)
        {
            student s = null;
            string query = $"select * from students where Id={id}";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s = new student()
                {

                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    NAME = reader.GetString(reader.GetOrdinal("NAME")),
                    CGPA = reader.GetInt32(reader.GetOrdinal("CGPA")),

                };

            }
            conn.Close();
            return s;
            
        }
        public void update(student s)
        {
            string query = $"update students set NAME='{s.NAME}',CGPA={s.CGPA}where ID={s.ID}";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void delete(int id)
        {
            string query = $"Delete from Students WHERE ID = {id}";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
  


}
