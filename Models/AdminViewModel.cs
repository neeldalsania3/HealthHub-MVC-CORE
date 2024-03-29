using System.Data.SqlClient;
namespace HealthHub_MVC_CORE.Models
{
    public class AdminViewModel
    {
        
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True");

        public int Id { get; set; }
        public string? Name { get; set; }
        public int AmbulanceNo { get; set; }
        public string? AmbulanceStatus{ get; set; }
        public string? AmbulanceDriverName { get; set; }

        public bool InsertAmbulance(AdminViewModel admin)
        {
            String query = "insert into Ambulances((Id,Name,AmbulanceNo,AmbulanceStatus,AmbulanceDriverName) values(@Id,@Name,@AmbulanceNo,@AmbulanceStatus,@AmbulanceDriverName)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", admin.Id);
            cmd.Parameters.AddWithValue("@Name", admin.Name);
            cmd.Parameters.AddWithValue("@AmbulanceNo", admin.AmbulanceNo);
            cmd.Parameters.AddWithValue("@AmbulanceStatus", admin.AmbulanceStatus);
            cmd.Parameters.AddWithValue("@AmbulanceDriverName", admin.AmbulanceDriverName);
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
