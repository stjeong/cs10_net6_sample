
/* ================= 예제 6.51: DataSet과 연동되는 DataAdapter ================= */

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
        DataSet ds = new DataSet();

        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM MemberInfo", sqlCon);
            sda.Fill(ds, "MemberInfo"); // DataSet에 SELECT 결과를 담는다.
        }

        // DataSet에 포함된 테이블 중에서 "MemberInfo"를 찾고
        DataTable dt = ds.Tables["MemberInfo"];

        // SELECT로 반환된 데이터 레코드를 열람한다.
        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", row["Name"], row["Birth"], row["Email"], row["Family"]);
        }
    }
}
