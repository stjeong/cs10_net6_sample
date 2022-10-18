
/* ================= 예제 6.45: 매개변수화된 쿼리 사용 ================= */

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
        string name = "Cooper";
        DateTime birth = new DateTime(1990, 2, 7);
        string email = "cooper@hotmail.com";
        int family = 5;

        using (SqlConnection sqlCon = new SqlConnection())
        {
            sqlCon.ConnectionString = connectionString;
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            
            // @Name 매개변수 준비
            SqlParameter paramName = new SqlParameter("Name", SqlDbType.NVarChar, 20);
            paramName.Value = name;
            
            // @Birth 매개변수 준비
            SqlParameter paramBirth = new SqlParameter("Birth", SqlDbType.Date);
            paramBirth.Value = birth;
            
            // @Email 매개변수 준비
            SqlParameter paramEmail = new SqlParameter("Email", SqlDbType.NVarChar, 100);
            paramEmail.Value = email;
            
            // @Family 매개변수 준비
            SqlParameter paramFamily = new SqlParameter("Family", SqlDbType.TinyInt);
            paramFamily.Value = family;
            
            // cmd.Parameters 컬렉션에 SqlParameter 개체를 추가
            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramBirth);
            cmd.Parameters.Add(paramEmail);
            cmd.Parameters.Add(paramFamily);

            cmd.CommandText = "INSERT INTO MemberInfo(Name, Birth, Email, Family) VALUES(@Name, @Birth, @Email, @Family)";
            cmd.ExecuteNonQuery();
        }
    }
}
