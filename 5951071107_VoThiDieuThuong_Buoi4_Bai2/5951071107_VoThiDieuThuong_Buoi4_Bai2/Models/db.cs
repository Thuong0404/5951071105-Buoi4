using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace _5951071107_VoThiDieuThuong_Buoi4_Bai2.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection( "Data Source=LAPTOP-E01MG43U/SQLEXPRESS02;Initial Catalog=DemoCURD2;Integrated Security=SSPI");


        //SELECT 
        public DataSet Empget(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
               
                SqlCommand com = new SqlCommand("tbl_Employed", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Dr_no", emp.Sr_no);
                com.Parameters.AddWithValue("@Emo_name", emp.Emp_name);
                com.Parameters.AddWithValue("@City", emp.City);
                com.Parameters.AddWithValue("@STATE", emp.State);
                com.Parameters.AddWithValue("@Country", emp.Country);
                com.Parameters.AddWithValue("@Department", emp.Department);
                com.Parameters.AddWithValue("@flag", emp.flag);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "OK";
                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return ds;
            }

        }

        internal DataSet Empget(Employee emp, out object msg)
        {
            throw new NotImplementedException();
        }

        //them và cập nhập
        public string Empdml(Employee emp, out string msg)
        {
            msg = "";
            try
            {
               
                SqlCommand com = new SqlCommand("tbl_Employed", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                com.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                com.Parameters.AddWithValue("@City", emp.City);
                com.Parameters.AddWithValue("@STATE", emp.State);
                com.Parameters.AddWithValue("@Country", emp.Country);
                com.Parameters.AddWithValue("@Department", emp.Department);
                com.Parameters.AddWithValue("@flag", emp.flag);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "OK";
                return msg;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                msg = ex.Message;
                return msg;

            }

        }

    }
}
