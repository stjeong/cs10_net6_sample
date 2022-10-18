
/* ================= 예제 6.48: MemberInfoDAC + POCO를 이용한 데이터베이스 연동 ================= */

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class MemberInfo
{
    public string Name;
    public DateTime Birth;
    public string Email;
    public byte Family;
}

// DAC(Data Access Component for MemberInfo)
public class MemberInfoDAC
{
    SqlConnection _sqlCon;

    public MemberInfoDAC(SqlConnection sqlCon)
    {
        _sqlCon = sqlCon;
    }

    void FillParameters(SqlCommand cmd, MemberInfo item)
    {
        SqlParameter paramName = new SqlParameter("Name", SqlDbType.NVarChar, 20);
        paramName.Value = item.Name;

        SqlParameter paramBirth = new SqlParameter("Birth", SqlDbType.Date);
        paramBirth.Value = item.Birth;

        SqlParameter paramEmail = new SqlParameter("Email", SqlDbType.NVarChar, 100);
        paramEmail.Value = item.Email;

        SqlParameter paramFamily = new SqlParameter("Family", SqlDbType.TinyInt);
        paramFamily.Value = item.Family;

        cmd.Parameters.Add(paramName);
        cmd.Parameters.Add(paramBirth);
        cmd.Parameters.Add(paramEmail);
        cmd.Parameters.Add(paramFamily);
    }

    public void Insert(MemberInfo item)
    {
        string txt = "INSERT INTO MemberInfo(Name, Birth, Email, Family) VALUES (@Name, @Birth, @Email, @Family)";

        SqlCommand cmd = new SqlCommand(txt, _sqlCon);
        FillParameters(cmd, item);
        cmd.ExecuteNonQuery();
    }

    public void Update(MemberInfo item)
    {
        string txt = "UPDATE MemberInfo SET Name=@Name, Birth=@Birth, Family=@Family WHERE Email=@Email";

        SqlCommand cmd = new SqlCommand(txt, _sqlCon);
        FillParameters(cmd, item);
        cmd.ExecuteNonQuery();
    }

    public void Delete(MemberInfo item)
    {
        string txt = "DELETE FROM MemberInfo WHERE Email=@Email";

        SqlCommand cmd = new SqlCommand(txt, _sqlCon);
        FillParameters(cmd, item);
        cmd.ExecuteNonQuery();
    }

    public MemberInfo[] SelectAll()
    {
        string txt = "SELECT * FROM MemberInfo";

        ArrayList list = new ArrayList();
        SqlCommand cmd = new SqlCommand(txt, _sqlCon);

        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                MemberInfo item = new MemberInfo();
                item.Name = reader.GetString(0);
                item.Birth = reader.GetDateTime(1);
                item.Email = reader.GetString(2);
                item.Family = reader.GetByte(3);
                list.Add(item);
            }
        }

        return list.ToArray(typeof(MemberInfo)) as MemberInfo[];
    }
}

class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        MemberInfo item = new MemberInfo();
        item.Name = "Jennifer";
        item.Birth = new DateTime(1985, 5, 6);
        item.Email = "jennifer@jennifersoft.com";
        item.Family = 0;

        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();

            MemberInfoDAC dac = new MemberInfoDAC(sqlCon);
            dac.Insert(item); // 신규 데이터를 추가하고

            item.Name = "Jenny";
            dac.Update(item); // 데이터 내용을 업데이트하고

            MemberInfo[] list = dac.SelectAll(); // 데이터를 조회하고

            foreach (MemberInfo member in list)
            {
                Console.WriteLine(member.Email);
            }

            dac.Delete(item); // 데이터를 삭제한다.
        }
    }
}
