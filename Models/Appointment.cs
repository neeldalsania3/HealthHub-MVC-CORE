using System.Data;
using System.Data.SqlClient;

namespace HealthHub_MVC_CORE.Models;

public  class Appointment
{

    SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True");

    public int Id { get; set; }

    public string? Patientname { get; set; } 

    public string? Doctorname { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public string? Problem { get; set; }

    public string? Status { get; set; }
    public bool AddAppoinment(Appointment app)
    {
        string query = "insert into Appointment (Patientname,Doctorname,AppointmentDate,Problem) values(@Patientname,@Doctorname,@AppointmentDate,@Problem)";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Patientname", app.Patientname);
        cmd.Parameters.AddWithValue("@Doctorname", app.Doctorname);
        cmd.Parameters.AddWithValue("@AppointmentDate", app.AppointmentDate);
        cmd.Parameters.AddWithValue("@Problem", app.Problem);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i >= 1)
        {
            return true;
        }
        return false;
    }

    public List<Appointment> getData()
    {
        List<Appointment> lstappointment = new List<Appointment>();
        SqlDataAdapter apt = new SqlDataAdapter("select * from Appointment", con);
        DataSet ds = new DataSet();
        apt.Fill(ds);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            lstappointment.Add(new Appointment
            {
                Id = Convert.ToInt32(dr["Id"]),
                Patientname = dr["Patientname"].ToString(),
                Doctorname = dr["Doctorname"].ToString(),
                AppointmentDate =Convert.ToDateTime( dr["AppointmentDate"]),
                Problem = dr["Problem"].ToString(),
                Status = dr["Status"].ToString(),
            });
        }
        return lstappointment;
    }
    public Appointment getData(string id)
    {
        Appointment app = new Appointment();
        SqlCommand cmd = new SqlCommand("select * from Appointment WHERE Id = '" + id + "'", con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                app.Id = Convert.ToInt32(dr["Id"]);
                app.Patientname = dr["Patientname"].ToString();
                app.Doctorname = dr["Doctorname"].ToString();
                app.AppointmentDate = Convert.ToDateTime(dr["AppointmentDate"]);
                app.Problem = dr["Problem"].ToString();
                app.Status = dr["Status"].ToString();
            }
        }
        con.Close();

        return app;
    }
    public bool update(Appointment app)
    {
        SqlCommand cmd = new SqlCommand("update Appointment set Status=@Status where Id = @Id", con);
        cmd.Parameters.AddWithValue("@Id", app.Id);
        cmd.Parameters.AddWithValue("@Status", app.Status);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }

    public bool delete(int Id)
    {
        using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True"))
        {
            string query = "DELETE FROM Appointment WHERE Id = @Id";
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
