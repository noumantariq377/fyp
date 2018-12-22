using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using testappli.Models;

namespace testappli.database_access_layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        // Add Record

        public void Add_record(Student rs)
        {
            SqlCommand com = new SqlCommand("Sp_Student_register", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@std_name",rs.std_name);
            com.Parameters.AddWithValue("@f_name",rs.f_name );
            com.Parameters.AddWithValue("@Department",rs.Department );
            com.Parameters.AddWithValue("@semester", rs.semester);
            com.Parameters.AddWithValue("@roll_no",rs.roll_no);
            com.Parameters.AddWithValue("@cnic",rs.cnic);
            com.Parameters.AddWithValue("@mob_no",rs.mob_no );
            com.Parameters.AddWithValue("@google_id",rs.google_id);
            com.Parameters.AddWithValue("@passworrd", rs.passworrd);

            con.Open();

            com.ExecuteNonQuery();

            con.Close();

        }

        //Display all record

        public DataSet get_record()
        {

            SqlCommand com = new SqlCommand("Sp_Student_get", con);

            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;

        }

        // Update all record

        public void update_record(Student rs)
        {

            SqlCommand com = new SqlCommand("Sp_Student_Update", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sid", rs.sid);
            com.Parameters.AddWithValue("@std_name", rs.std_name);
            com.Parameters.AddWithValue("@f_name", rs.f_name);
            com.Parameters.AddWithValue("@Department", rs.Department);
            com.Parameters.AddWithValue("@semester", rs.semester);
            com.Parameters.AddWithValue("@roll_no", rs.roll_no);
            com.Parameters.AddWithValue("@cnic", rs.cnic);
            com.Parameters.AddWithValue("@mob_no", rs.mob_no);
            com.Parameters.AddWithValue("@google_id", rs.google_id);
            com.Parameters.AddWithValue("@passworrd", rs.passworrd);

            con.Open();

            com.ExecuteNonQuery();

            con.Close();

        }

        // Get Record by id

        public DataSet get_recordbyid(int id)
        {

            SqlCommand com = new SqlCommand("Sp_Student_byid", con);

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@sid", id);

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;

        }

        // Delete record

        public void deletedata(int id)
        {

            SqlCommand com = new SqlCommand("Sp_Student_delete", con);

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@sid", id);

            con.Open();

            com.ExecuteNonQuery();

            con.Close();

        }

    }
}
   