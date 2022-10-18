
/* ================= 예제 6.50: 칼럼 정보를 포함하는 DataTable 정의 ================= */

using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        DataColumn nameCol = new DataColumn("Name", typeof(string));
        DataColumn birthCol = new DataColumn("Birth", typeof(DateTime));
        DataColumn emailCol = new DataColumn("Email", typeof(string));
        DataColumn familyCol = new DataColumn("Family", typeof(byte));

        DataTable table = new DataTable("MemberInfo");

        table.Columns.Add(nameCol);
        table.Columns.Add(birthCol);
        table.Columns.Add(emailCol);
        table.Columns.Add(familyCol);

        // INSERT: 4개의 레코드를 생성
        table.Rows.Add("Anderson", new DateTime(1950, 5, 20), "anderson@gmail.com", 2);
        table.Rows.Add("Jason", new DateTime(1967, 12, 3), "jason@gmail.com", 0);
        table.Rows.Add("Mark", new DateTime(1998, 3, 2), "mark@naver.com", 1);
        table.Rows.Add("Jennifer", new DateTime(1985, 5, 6), "jennifer@jennifersoft.com", 0);

        // SELECT: 가족 구성원이 1명 이상인 레코드를 선택
        DataRow[] members = table.Select("Family >= 1");

        foreach (DataRow row in members)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", row["Name"], row["Birth"], row["Email"], row["Family"]);
        }
        
        // UPDATE: 4번째 레코드의 Name 칼럼의 값을 "Jennifer"에서 "Jenny"로 변경
        table.Rows[3]["Name"] = "Jenny";
        
        // DELETE: 4번째 레코드를 삭제
        table.Rows.Remove(table.Rows[3]);

        DataSet ds = new DataSet();
        ds.Tables.Add(table);
    }
}
