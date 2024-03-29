using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace HealthHub_MVC_CORE.Models;

public partial class Medicine
{

    SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True");

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; } 

    public int Quantity { get; set; }

    public int Price { get; set; }
    public bool AddMedicine(Medicine med)
    {
        string query = "insert into Medicines (Name,Description,Quantity,Price) values(@Name,@Description,@Quantity,@Price)";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Name", med.Name);
        cmd.Parameters.AddWithValue("@Description", med.Description);
        cmd.Parameters.AddWithValue("@Quantity", med.Quantity);
        cmd.Parameters.AddWithValue("@Price", med.Price);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i >= 1)
        {
            return true;
        }
        return false;
    }
    public List<Medicine> getData()
    {
        List<Medicine> lstmedicine = new List<Medicine>();
        SqlDataAdapter apt = new SqlDataAdapter("select * from Medicines", con);
        DataSet ds = new DataSet();
        apt.Fill(ds);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            lstmedicine.Add(new Medicine
            {
                Id = Convert.ToInt32(dr["Id"]),
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Quantity = Convert.ToInt32(dr["Quantity"]),
                Price = Convert.ToInt32(dr["Price"]),
            });
        }
        return lstmedicine;
    }
    public Medicine getData(string id)
    {
        Medicine anc = new Medicine();
        SqlCommand cmd = new SqlCommand("select * from Medicines WHERE Id = '" + id + "'", con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                anc.Id = Convert.ToInt32(dr["Id"]);
                anc.Name = dr["Name"].ToString();
                anc.Description = dr["Description"].ToString();
                anc.Quantity = Convert.ToInt32(dr["Quantity"]);
                anc.Price = Convert.ToInt32(dr["Price"]);
            }
        }
        con.Close();

        return anc;
    }
    public bool update(Medicine anc)
    {
        SqlCommand cmd = new SqlCommand("update Medicines set Name=@Name, Description = @Description, Quantity = @Quantity,Price=@Price  where Id = @Id", con);
        cmd.Parameters.AddWithValue("@Id", anc.Id);
        cmd.Parameters.AddWithValue("@Name", anc.Name);
        cmd.Parameters.AddWithValue("@Description", anc.Description);
        cmd.Parameters.AddWithValue("@Quantity", anc.Quantity);
        cmd.Parameters.AddWithValue("@Price", anc.Price);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }

    public bool delete(int Id)
    {
        using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-6JD5I26;Initial Catalog=hospital;Integrated Security=True;TrustServerCertificate=True"))
        {
            string query = "DELETE FROM Medicines WHERE Id = @Id";
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
