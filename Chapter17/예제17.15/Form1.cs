
#define USE_FUNCTION_POINTER

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

#if USE_FUNCTION_POINTER
        [DllImport("user32.dll", ExactSpelling = true)]
        unsafe static extern IntPtr SetTimer(IntPtr hWnd, IntPtr nIDEvent, uint uElapse, delegate* unmanaged[Stdcall]<IntPtr, uint, IntPtr, uint, void> lpTimerFunc);
#else
        [DllImport("user32.dll", ExactSpelling = true)]
        static extern IntPtr SetTimer(IntPtr hWnd, IntPtr nIDEvent, uint uElapse, TimerProc lpTimerFunc);

        delegate void TimerProc(IntPtr hWnd, uint uMsg, IntPtr nIDEvent, uint dwTime);

        // TimerProc _timerProc = new TimerProc(timerCallback);
#endif

        public Form1()
        {
            InitializeComponent();
        }

#if USE_FUNCTION_POINTER
        [UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvStdcall) })]
#endif

        static void timerCallback(IntPtr hWnd, uint uMsg, IntPtr nIDEvent, uint dwTime)
        {
            System.Diagnostics.Trace.WriteLine($"timerCallback - {dwTime}");
        }

        private unsafe void Form1_Load(object sender, EventArgs e)
        {
#if USE_FUNCTION_POINTER
            SetTimer(this.Handle, IntPtr.Zero, 1000, &timerCallback);
#else
            SetTimer(this.Handle, IntPtr.Zero, 1000, timerCallback);

            // SetTimer(this.Handle, IntPtr.Zero, 1000, _timerProc);

            // 위의 코드는 결국 이렇게 호출한 것과 동일            
            // TimerProc timerProc = new TimerProc(timerCallback);
            // SetTimer(this.Handle, IntPtr.Zero, 1000, timerProc);
#endif
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            GC.Collect(2, GCCollectionMode.Forced);
        }

    }
}
