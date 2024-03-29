using System.Data;
using System.Data.SqlClient;
namespace HealthHub_MVC_CORE.Models;
public  class Ambulance
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? AmbulanceNo { get; set; }

    public string? AmbulanceStatus { get; set; }

    public string? AmbulanceDriverName { get; set; }


    SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True");


    public bool InsertAmbulance(Ambulance amb)
    {
            String query = "insert into Ambulances(Name,AmbulanceNo,AmbulanceStatus,AmbulanceDriverName) values(@Name,@AmbulanceNo,@AmbulanceStatus,@AmbulanceDriverName)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", amb.Name);
            cmd.Parameters.AddWithValue("@AmbulanceNo", amb.AmbulanceNo);
            cmd.Parameters.AddWithValue("@AmbulanceStatus", amb.AmbulanceStatus);
            cmd.Parameters.AddWithValue("@AmbulanceDriverName", amb.AmbulanceDriverName);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
    }
    public List<Ambulance> getData()
    {
        List<Ambulance> lstambulance = new List<Ambulance>();
        SqlDataAdapter apt = new SqlDataAdapter("select * from Ambulances", con);
        DataSet ds = new DataSet();
        apt.Fill(ds);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            lstambulance.Add(new Ambulance
            {
                Id = Convert.ToInt32(dr["Id"]),
                Name = dr["Name"].ToString(),
                AmbulanceNo = dr["AmbulanceNo"].ToString(),
                AmbulanceStatus = dr["AmbulanceStatus"].ToString(),
                AmbulanceDriverName = dr["AmbulanceDriverName"].ToString()
            });
        }
        return lstambulance;
    }
    public Ambulance getData(string id)
    {
        Ambulance amb = new Ambulance();
        SqlCommand cmd = new SqlCommand("select * from Ambulances WHERE Id = '" + id + "'", con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                amb.Id = Convert.ToInt32(dr["Id"]);
                amb.Name = dr["Name"].ToString();
                amb.AmbulanceNo = dr["AmbulanceNo"].ToString();
                amb.AmbulanceStatus = dr["AmbulanceStatus"].ToString();
                amb.AmbulanceDriverName = dr["AmbulanceDriverName"].ToString();
            }
        }
        con.Close();

        return amb;
    }
    public bool update(Ambulance amb)
    {
        SqlCommand cmd = new SqlCommand("update Ambulances set Name=@Name, AmbulanceNo = @AmbulanceNo, AmbulanceStatus = @AmbulanceStatus ,AmbulanceDriverName= @AmbulanceDriverName where Id = @Id", con);
        cmd.Parameters.AddWithValue("@Id", amb.Id);
        cmd.Parameters.AddWithValue("@Name", amb.Name);
        cmd.Parameters.AddWithValue("@AmbulanceNo", amb.AmbulanceNo);
        cmd.Parameters.AddWithValue("@AmbulanceStatus", amb.AmbulanceStatus);
        cmd.Parameters.AddWithValue("@AmbulanceDriverName", amb.AmbulanceDriverName);
        con.Open();
        int i = cmd.ExecuteNonQuery ();
        con.Close();
        return i >= 1;
    }

    public bool delete(int Id)
    {
        using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True"))
        {
            string query = "DELETE FROM Ambulances WHERE Id = @Id";
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
