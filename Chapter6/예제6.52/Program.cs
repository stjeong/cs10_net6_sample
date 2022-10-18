
/* ================= 예제 6.52: DataSet 기반의 MemberInfoDAC 정의 ================= */

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
    }
}
