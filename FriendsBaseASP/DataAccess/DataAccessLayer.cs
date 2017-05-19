using FriendsBaseASP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FriendsBaseASP.DataAccess
{
    public class DataAccessLayer
    {
        public string InsertData(Friend friend)
        {

            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_znajomego", 0);
                cmd.Parameters.AddWithValue("@Imie_znajomego", friend.name);
                cmd.Parameters.AddWithValue("@Nazwisko_znajomego", friend.lastName);
                cmd.Parameters.AddWithValue("@Query", 1);

                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

    }
}