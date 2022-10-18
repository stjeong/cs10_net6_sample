
/* ================= 예제 6.49: 개별 칼럼 정보를 구성 ================= */

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
    }
}
