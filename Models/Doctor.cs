
using System.Data;
using System.Data.SqlClient;
namespace HealthHub_MVC_CORE.Models
{
    public class Doctor
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True");

        public int Id { get; set; }

        public string? Name { get; set; } 

        public string? Department { get; set; }

        public string? EmploymentStatus { get; set; }

        public string? Specification { get; set; }
        public bool AddDoctor(Doctor doc)
        {
            string query = "insert into Doctor (Name,Department,EmploymentStatus,Specification) values(@Name,@Department,@EmploymentStatus,@Specification)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", doc.Name);
            cmd.Parameters.AddWithValue("@Department", doc.Department);
            cmd.Parameters.AddWithValue("@EmploymentStatus", doc.EmploymentStatus);
            cmd.Parameters.AddWithValue("@Specification", doc.Specification);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public List<Doctor> getData()
        {
            List<Doctor> lstdoctor = new List<Doctor>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from Doctor", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstdoctor.Add(new Doctor
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Department = dr["Department"].ToString(),
                    EmploymentStatus = dr["EmploymentStatus"].ToString(),
                    Specification = dr["Specification"].ToString(),
                });
            }
            return lstdoctor;
        }
        public Doctor getData(string id)
        {
            Doctor anc = new Doctor();
            SqlCommand cmd = new SqlCommand("select * from Doctor WHERE Id = '" + id + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    anc.Id = Convert.ToInt32(dr["Id"]);
                    anc.Name = dr["Name"].ToString();
                    anc.Department = dr["Department"].ToString();
                    anc.EmploymentStatus = dr["EmploymentStatus"].ToString();
                    anc.Specification = dr["Specification"].ToString();
                }
            }
            con.Close();

            return anc;
        }
        public bool update(Doctor anc)
        {
            SqlCommand cmd = new SqlCommand("update Doctor set Name=@Name, Department = @Department, EmploymentStatus = @EmploymentStatus,Specification=@Specification  where Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", anc.Id);
            cmd.Parameters.AddWithValue("@Name", anc.Name);
            cmd.Parameters.AddWithValue("@Department", anc.Department);
            cmd.Parameters.AddWithValue("@EmploymentStatus", anc.EmploymentStatus);
            cmd.Parameters.AddWithValue("@Specification", anc.Specification);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i >= 1;
        }

        public bool delete(int Id)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True"))
            {
                string query = "DELETE FROM Doctor WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
