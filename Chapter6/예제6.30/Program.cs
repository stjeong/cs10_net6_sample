
/* ================= 예제 6.30: 비동기 방식의 파일 읽기 ================= */

using System;
using System.IO;
using System.Text;

class FileState
{
    public byte[] Buffer;
    public FileStream File;
}
class Program
{
    static void Main(string[] args)
    {
        FileStream fs = new FileStream(@"C:\windows\system32\drivers\etc\HOSTS", FileMode.Open, FileAccess.Read, FileShare.ReadWrite,
            4096, true);

        FileState state = new FileState();
        state.Buffer = new byte[fs.Length];
        state.File = fs;

        fs.BeginRead(state.Buffer, 0, state.Buffer.Length, readCompleted, state);
        // BeginRead 비동기 메서드 호출은 스레드로 곧바로 제어를 반환하기 때문에
        // 이곳에서 자유롭게 다른 연산을 동시에 진행할 수 있다.

        Console.ReadLine();

        fs.Close();
    }

    // 읽기 작업이 완료되면 메서드가 호출된다.
    static void readCompleted(IAsyncResult ar)
    {
        FileState state = ar.AsyncState as FileState;
        state.File.EndRead(ar);
        string txt = Encoding.UTF8.GetString(state.Buffer);
        Console.WriteLine(txt);
    }
}

