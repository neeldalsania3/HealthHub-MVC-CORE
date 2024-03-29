using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HealthHub_MVC_CORE.Models;

public partial class Department
{

    SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True");

    public int Id { get; set; }

    public string? Name { get; set; } 
    public string? Description { get; set; }

    public string? Status { get; set; } 
    public bool AddDepartment(Department dep)
    {
        string query = "insert into Departments (Name,Description,Status) values(@Name,@Description,@Status)";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Name", dep.Name);
        cmd.Parameters.AddWithValue("@Description", dep.Description);
        cmd.Parameters.AddWithValue("@Status", dep.Status);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i >= 1)
        {
            return true;
        }
        return false;
    }
    public List<Department> getData()
    {
        List<Department> lstdepartment = new List<Department>();
        SqlDataAdapter apt = new SqlDataAdapter("select * from Departments", con);
        DataSet ds = new DataSet();
        apt.Fill(ds);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            lstdepartment.Add(new Department
            {
                Id = Convert.ToInt32(dr["Id"]),
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Status = dr["Status"].ToString(),
            });
        }
        return lstdepartment;
    }
    public Department getData(string id)
    {
        Department anc = new Department();
        SqlCommand cmd = new SqlCommand("select * from Departments WHERE Id = '" + id + "'", con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                anc.Id = Convert.ToInt32(dr["Id"]);
                anc.Name = dr["Name"].ToString();
                anc.Description = dr["Description"].ToString();
                anc.Status = dr["Status"].ToString();
            }
        }
        con.Close();

        return anc;
    }
    public bool update(Department anc)
    {
        SqlCommand cmd = new SqlCommand("update Departments set Name=@Name, Description = @Description, Status = @Status where Id = @Id", con);
        cmd.Parameters.AddWithValue("@Id", anc.Id);
        cmd.Parameters.AddWithValue("@Name", anc.Name);
        cmd.Parameters.AddWithValue("@Description", anc.Description);
        cmd.Parameters.AddWithValue("@Status", anc.Status);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }

    public bool delete(int Id)
    {
        using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True"))
        {
            string query = "DELETE FROM Departments WHERE Id = @Id";
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
