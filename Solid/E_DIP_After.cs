using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solid.E_IDP_After
{
    public interface IWorker
    {
        void Work();
    }

    public class Worker : IWorker
    {
        public void Work()
        {
            // ....working	
        }
    }

    class SuperWorker : IWorker
    {
        public void Work()
        {
            //.... working much more	
        }
    }

    class Manager
    {
        private readonly IWorker _worker;

        public Manager(IWorker worker)
        {
            _worker = worker;
        }

        public void Manage()
        {
            _worker.Work();
        }
    }
}
