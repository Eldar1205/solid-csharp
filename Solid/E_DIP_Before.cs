using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solid.E_DIP_Before
{
    public class Worker
    {
        public void Work()
        {
            // ....working	
        }
    }

    public class Manager
    {
        private readonly Worker _worker;

        public Manager()
        {
            _worker = new Worker();
        }

        public void Manage()
        {
            _worker.Work();
        }
    }

    // Later in the application's lifetime, a new requirement calls for a new class
    public class SuperWorker
    {
        public void Work()
        {
            //.... working much more	
        }
    }
}
