using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Philosophers
{
    public class Fork
    {
        private Mutex m = new Mutex();
        public bool TakeFork()
        {
            return m.WaitOne();
        }
        public void PutFork()
        {
            m.ReleaseMutex();
        }
    }
}
