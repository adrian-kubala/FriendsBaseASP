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
        SqlConnection connection = new SqlConnection(Properties.Resources.socialMediaDatabaseConnectionString);
        SqlCommand command;

        private void SetCommand(string text)
        {
            command = new SqlCommand(text, connection);
        }

        public string InsertData(Friend friend)
        {
            string result = "";
            try
            {
                SetCommand("INSERT INTO Znajomy(Imie_znajomego, Nazwisko_znajomego)VALUES(@Imie_znajomego, @Nazwisko_znajomego)");
                command.Parameters.AddWithValue("@Imie_znajomego", friend.name);
                command.Parameters.AddWithValue("@Nazwisko_znajomego", friend.lastName);

                connection.Open();
                result = command.ExecuteScalar().ToString();
                connection.Close();

                return result;
            }
            catch
            {
                return result = "";
            }
        }

        public string UpdateData(Friend friend)
        {
            string result = "";
            try
            {
                SetCommand("UPDATE Znajomy SET Imie_znajomego = @Imie_znajomego, Nazwisko_znajomego = @Nazwisko_znajomego WHERE Znajomy.Id_znajomego = @Id_znajomego");
                command.Parameters.AddWithValue("@Id_znajomego", friend.id);
                command.Parameters.AddWithValue("@Imie_znajomego", friend.name);
                command.Parameters.AddWithValue("@Nazwisko_znajomego", friend.lastName);

                connection.Open();
                result = command.ExecuteScalar().ToString();
                connection.Close();

                return result;
            }
            catch
            {
                return result = "";
            }
        }

        public string DeleteData(Friend friend)
        {
            string result = "";
            try
            {
                SetCommand("DELETE FROM Znajomy WHERE Znajomy.Id_znajomego = @Id_znajomego");
                command.Parameters.AddWithValue("@Id_znajomego", friend.id);

                connection.Open();
                result = command.ExecuteScalar().ToString();
                connection.Close();

                return result;
            }
            catch
            {
                return result = "";
            }
        }

        public List<Friend> SelectAllData()
        {
            DataSet ds = null;
            List<Friend> friends = null;
            try
            {
                SetCommand("SELECT * FROM Znajomy");

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                ds = new DataSet();
                da.Fill(ds);
                connection.Close();

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
        }

        public Friend SelectDataById(string friendId)
        {
            DataSet ds = null;
            Friend friend = null;
            try
            {
                SetCommand("SELECT * FROM Znajomy WHERE Znajomy.Id_znajomego = @Id_znajomego");
                command.Parameters.AddWithValue("@Id_znajomego", friendId);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                ds = new DataSet();
                da.Fill(ds);
                connection.Close();

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
        }

    }
}