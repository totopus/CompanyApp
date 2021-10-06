﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace OctopusParadise.CompanyApp.Data.Repository
{
    class DbContext
    {
        public int Execute(string cmdText, Dictionary<string,object> parameters)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=CompanyDB;
                                                          Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = cmdText;
                if (parameters != null)
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                
                cmd.Connection = connection;
                int r = cmd.ExecuteNonQuery(); //call method
                return r;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                cmd.Dispose();
            }
            return 0;
        }

        public DataTable Query(string cmdText, Dictionary<string,object> parameters)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=CompanyDB;
                                                          Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = cmdText;
                if (parameters != null)
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                cmd.Dispose();
            }
            return null;
        }
    }
}
