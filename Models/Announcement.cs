using Humanizer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HealthHub_MVC_CORE.Models;

public  class Announcement
{

    SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True");

    public int Id { get; set; }

    public string? Announcements { get; set; } 

    public string? AnnouncementFor { get; set; } 

    public string? Enddate { get; set; }
    public bool AddAnnouncement(Announcement anc)
    {
        string query = "insert into Announcements (Announcements,AnnouncementFor,Enddate) values(@Announcements,@AnnouncementFor,@Enddate)";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Announcements", anc.Announcements);
        cmd.Parameters.AddWithValue("@AnnouncementFor", anc.AnnouncementFor);
        cmd.Parameters.AddWithValue("@Enddate", anc.Enddate);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i >= 1)
        {
            return true;
        }
        return false;
    }
    public List<Announcement> getData()
    {
        List<Announcement> lstannouncement = new List<Announcement>();
        SqlDataAdapter apt = new SqlDataAdapter("select * from Announcements", con);
        DataSet ds = new DataSet();
        apt.Fill(ds);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            lstannouncement.Add(new Announcement
            {
                Id = Convert.ToInt32(dr["Id"]),
                Announcements = dr["Announcements"].ToString(),
                AnnouncementFor = dr["AnnouncementFor"].ToString(),
                Enddate = dr["Enddate"].ToString(),
            });
        }
        return lstannouncement;
    }
    public Announcement getData(string id)
    {
        Announcement anc = new Announcement();
        SqlCommand cmd = new SqlCommand("select * from Announcements WHERE Id = '" + id + "'", con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                anc.Id = Convert.ToInt32(dr["Id"]);
                anc.Announcements = dr["Announcements"].ToString();
                anc.AnnouncementFor = dr["AnnouncementFor"].ToString();
                anc.Enddate = dr["Enddate"].ToString();
            }
        }
        con.Close();

        return anc;
    }
    public bool update(Announcement anc)
    {
        SqlCommand cmd = new SqlCommand("update Announcements set Announcements=@Announcements, AnnouncementFor = @AnnouncementFor, Enddate = @Enddate where Id = @Id", con);
        cmd.Parameters.AddWithValue("@Id", anc.Id);
        cmd.Parameters.AddWithValue("@Announcements", anc.Announcements);
        cmd.Parameters.AddWithValue("@AnnouncementFor", anc.AnnouncementFor);
        cmd.Parameters.AddWithValue("@Enddate", anc.Enddate);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }

    public bool delete(int Id)
    {
        using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True"))
        {
            string query = "DELETE FROM Announcements WHERE Id = @Id";
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
