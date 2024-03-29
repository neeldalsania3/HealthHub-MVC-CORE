using System.Data.SqlClient;

namespace HealthHub_MVC_CORE.Models
{
    public class UserModel
    {
        
       SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True");
       
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }

        public bool Insert(UserModel user)
        {
            string query = "insert into Users(Email,Name,Password) values(@Email,@Name,@Password)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Email", user.Email); 
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

    } 


}
