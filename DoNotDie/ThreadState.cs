using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoNotDie
{

    public static class ThreadState
    {
        [DllImport("kernel32.dll")]
        static extern uint SetThreadExecutionState(uint esFlags);
        const uint ES_CONTINOUS = 0x80000000;
        const uint ES_SYSTEM_REQUIRED = 0x000000001;
        const uint ES_DISPLAY_REQUIRED = 0x00000002;

        public static bool StayingAlive { get; set; }

        public static void KeepAlive()
        {
            SetThreadExecutionState(ES_CONTINOUS | ES_DISPLAY_REQUIRED | ES_SYSTEM_REQUIRED);
            StayingAlive = true;
        }
        public static void LetDie()
        {
            SetThreadExecutionState(ES_CONTINOUS);
            StayingAlive = false;
        }

    }
}
