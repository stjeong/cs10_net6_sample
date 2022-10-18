
/*
// 상속을 하지 않은 경우 
public class Notebook
{
    bool powerOn;
    public void Boot() { }
    public void Shutdown() { }
    public void Reset() { }
    bool fingerScan; // Notebook에 특화된 멤버 필드 추가

    public bool HasFingerScanDevice() // Notebook에 특화된 멤버 메서드 추가
    {
        return fingerScan;
    }
}

public class Desktop
{
    bool powerOn;
    public void Boot() { }
    public void Shutdown() { }
    public void Reset() { }
}

public class Netbook
{
    bool powerOn;
    public void Boot() { }
    public void Shutdown() { }
    public void Reset() { }
}
*/

/* ================= 예제 4.9: 상속을 이용한 클래스 정의 ================= */

public class Computer
{
    bool powerOn;
    public void Boot() { }
    public void Shutdown() { }
    public void Reset() { }
}

public class Notebook : Computer
{
    bool fingerScan; // Notebook 타입에 해당하는 멤버만 추가
    public bool HasFingerScanDevice() { return fingerScan; }
}

public class Desktop : Computer
{
}

public class Netbook : Computer
{
}

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer();
            Notebook notebook = new Notebook();
            Desktop desktop = new Desktop();
            Netbook netbook = new Netbook();
        }
    }
}
