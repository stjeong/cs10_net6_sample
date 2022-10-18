
/* ================= 예제 6.53: DataSet을 이용한 데이터베이스 연동 ================= */

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class MemberInfoDAC
{
    SqlConnection _sqlCon;
    DataTable _table;

    public MemberInfoDAC(SqlConnection sqlCon)
    {
        _sqlCon = sqlCon;

        DataColumn nameCol = new DataColumn("Name", typeof(string));
        DataColumn birthCol = new DataColumn("Birth", typeof(DateTime));
        DataColumn emailCol = new DataColumn("Email", typeof(string));
        DataColumn familyCol = new DataColumn("Family", typeof(byte));

        _table = new DataTable("MemberInfo");
        _table.Columns.Add(nameCol);
        _table.Columns.Add(birthCol);
        _table.Columns.Add(emailCol);
        _table.Columns.Add(familyCol);
    }

    public DataRow NewRow()
    {
        return _table.NewRow();
    }

    void FillParameters(SqlCommand cmd, DataRow item)
    {
        SqlParameter paramName = new SqlParameter("Name", SqlDbType.NVarChar, 20);
        paramName.Value = item["Name"];

        SqlParameter paramBirth = new SqlParameter("Birth", SqlDbType.Date);
        paramBirth.Value = item["Birth"];

        SqlParameter paramEmail = new SqlParameter("Email", SqlDbType.NVarChar, 100);
        paramEmail.Value = item["Email"];

        SqlParameter paramFamily = new SqlParameter("Family", SqlDbType.TinyInt);
        paramFamily.Value = item["Family"];

        cmd.Parameters.Add(paramName);
        cmd.Parameters.Add(paramBirth);
        cmd.Parameters.Add(paramEmail);
        cmd.Parameters.Add(paramFamily);
    }

    public void Insert(DataRow item)
    {
        string txt = "INSERT INTO MemberInfo(Name, Birth, Email, Family) VALUES (@Name, @Birth, @Email, @Family)";

        SqlCommand cmd = new SqlCommand(txt, _sqlCon);
        FillParameters(cmd, item);
        cmd.ExecuteNonQuery();
    }

    public void Update(DataRow item)
    {
        string txt = "UPDATE MemberInfo SET Name=@Name, Birth=@Birth, Family=@Family WHERE Email=@Email";

        SqlCommand cmd = new SqlCommand(txt, _sqlCon);
        FillParameters(cmd, item);
        cmd.ExecuteNonQuery();
    }

    public void Delete(DataRow item)
    {
        string txt = "DELETE FROM MemberInfo WHERE Email=@Email";

        SqlCommand cmd = new SqlCommand(txt, _sqlCon);
        FillParameters(cmd, item);
        cmd.ExecuteNonQuery();
    }

    public DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM MemberInfo", _sqlCon);
        sda.Fill(ds, "MemberInfo");
        return ds;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();

            MemberInfoDAC dac = new MemberInfoDAC(sqlCon);

            DataRow newItem = dac.NewRow();
            newItem["Name"] = "Jennifer";
            newItem["Birth"] = new DateTime(1985, 5, 6);
            newItem["Email"] = "jennifer@jennifersoft.com";
            newItem["Family"] = 0;
            dac.Insert(newItem);

            newItem["Name"] = "Jenny";
            dac.Update(newItem);

            DataSet ds = dac.SelectAll();

            foreach (DataRow member in ds.Tables["MemberInfo"].Rows)
            {
                Console.WriteLine(member["Email"]);
            }

            dac.Delete(newItem);
        }
    }
}