
/* ================= 예제 6.44: DataReader를 이용한 테이블 내용 조회 ================= */

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

            while (reader.Read()) // 읽어야 할 데이터가 남아 있다면 true, 없다면 false를 반환
            {
                string name = reader.GetString(0);
                DateTime birth = reader.GetDateTime(1);
                string email = reader.GetString(2);
                byte family = reader.GetByte(3);
                Console.WriteLine("{0}, {1}, {2}, {3}", name, birth, email, family);
            }

            reader.Close();
        }
    }
}
