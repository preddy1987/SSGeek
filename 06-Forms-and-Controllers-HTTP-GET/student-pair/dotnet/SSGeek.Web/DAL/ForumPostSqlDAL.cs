using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using SSGeek.Web.Models;

namespace SSGeek.Web.DAL
{
    public class ForumPostSqlDAL : IForumPostDAL
    {
        private string connectionString;
        private string getAllPost = "Select * from forum_post";
        private string postYourNewPost = "Insert into forum_post (username,message,subject,post_date)" +
            " Values (@username,@message,@subject,@postdate);" +
            "SELECT CAST(SCOPE_IDENTITY() as int);";


        public ForumPostSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<ForumPost> GetAllPosts()
        {
            List<ForumPost> output = new List<ForumPost>();


                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    
                    SqlCommand cmd = new SqlCommand(getAllPost, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a Post
                    ForumPost post = new ForumPost();
                    post.Message = Convert.ToString(reader["message"]);
                    post.Subject = Convert.ToString(reader["subject"]);
                    post.Username = Convert.ToString(reader["username"]);
                    post.PostDate = Convert.ToDateTime(reader["post_date"]);
                    output.Add(post);
                    }
                }
            return output;
        }

        public bool SaveNewPost(ForumPost post)
        {
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();


                    SqlCommand cmd = new SqlCommand(postYourNewPost, conn);

                    cmd.Parameters.AddWithValue("@username", post.Username);
                    cmd.Parameters.AddWithValue("@message", post.Message);
                    cmd.Parameters.AddWithValue("@subject", post.Subject);
                    cmd.Parameters.AddWithValue("@postdate", DateTime.Now.ToString());
                   
                    cmd.ExecuteScalar();
                }
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
            
        }
    }

