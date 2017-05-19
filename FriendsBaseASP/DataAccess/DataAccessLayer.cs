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

        public string UpdateData(Friend friend)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_znajomego", friend.id);
                cmd.Parameters.AddWithValue("@Imie_znajomego", friend.name);
                cmd.Parameters.AddWithValue("@Nazwisko_znajomego", friend.lastName);
                cmd.Parameters.AddWithValue("@Query", 2);

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

        public string DeleteData(Friend friend)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_znajomego", friend.id);
                cmd.Parameters.AddWithValue("@Imie_znajomego", null);
                cmd.Parameters.AddWithValue("@Nazwisko_znajomego", null);
                cmd.Parameters.AddWithValue("@Query", 3);

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

        public List<Friend> SelectAllData()
        {
            SqlConnection con = null;

            DataSet ds = null;
            List<Friend> friends = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_znajomego", null);
                cmd.Parameters.AddWithValue("@Imie_znajomego", null);
                cmd.Parameters.AddWithValue("@Nazwisko_znajomego", null);
                cmd.Parameters.AddWithValue("@Query", 4);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                friends = new List<Friend>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Friend friend = new Friend();
                    friend.id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id_znajomego"].ToString());
                    friend.name = ds.Tables[0].Rows[i]["Imie_znajomego"].ToString();
                    friend.lastName = ds.Tables[0].Rows[i]["Nazwisko_znajomego"].ToString();

                    friends.Add(friend);
                }
                return friends;
            }
            catch
            {
                return friends;
            }
            finally
            {
                con.Close();
            }
        }

        public Friend SelectDataById(string friendId)
        {
            SqlConnection con = null;
            DataSet ds = null;
            Friend friend = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_znajomego", friendId);
                cmd.Parameters.AddWithValue("@Imie_znajomego", null);
                cmd.Parameters.AddWithValue("@Nazwisko_znajomego", null);
                cmd.Parameters.AddWithValue("@Query", 5);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    friend = new Friend();
                    friend.id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id_znajomego"].ToString());
                    friend.name = ds.Tables[0].Rows[i]["Imie_znajomego"].ToString();
                    friend.lastName = ds.Tables[0].Rows[i]["Nazwisko_znajomego"].ToString();
                }
                return friend;
            }
            catch
            {
                return friend;
            }
            finally
            {
                con.Close();
            }
        }


    }
}