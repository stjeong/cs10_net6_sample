
/* ================= 예제 6.54: Typed DataSet을 이용한 데이터베이스 연동 ================= */

using System;
using System.Data;
using ConsoleApplication1;
using ConsoleApplication1.TestDBDataSetTableAdapters;

class Program
{
    static void Main(string[] args)
    {
        TestDBDataSet ds = new TestDBDataSet();
        MemberInfoTableAdapter da = new MemberInfoTableAdapter();

        // 새로운 레코드를 삽입: INSERT
        da.Insert("Julie", new DateTime(1985, 5, 6), "julie@naver.com", 1);

        // 테이블의 모든 레코드를 조회: SELECT
        da.Fill(ds.MemberInfo);

        foreach (TestDBDataSet.MemberInfoRow row in ds.MemberInfo)
        {
            Console.WriteLine(string.Format("{0}, {1}, {2}, {3}",
            row.Name, row.Birth, row.Email, row.Family));
        }

        // 테이블의 특정 레코드의 값을 변경: UPDATE
        TestDBDataSet.MemberInfoRow[] rows = ds.MemberInfo.Select("Name = 'Julie'") as TestDBDataSet.MemberInfoRow[];

        rows[0].Name = "July";
        da.Update(rows[0]);

        // 테이블의 특정 레코드를 삭제: DELETE
        da.Delete(rows[0].Name, rows[0].Birth, rows[0].Email, rows[0].Family);
    }
}

