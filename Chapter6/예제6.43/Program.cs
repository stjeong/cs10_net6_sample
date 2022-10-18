
/* ================= 예제 6.43: 모든 회원 정보를 반환하는 SQL 쿼리 실행 ================= */

using System;
using System.Configuration;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        using (SqlConnection sqlCon = new SqlConnection())
        {
            sqlCon.ConnectionString = connectionString;

            // DB에 연결하고,
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandText = "SELECT * FROM MemberInfo";

            SqlDataReader reader = cmd.ExecuteReader();

            // …… [reader를 이용해 레코드를 하나씩 조회] ……
        }
    }
}
