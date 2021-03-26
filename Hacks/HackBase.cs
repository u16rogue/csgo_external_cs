
using System.Collections.Generic;
using System.Threading;

namespace csgo_external_cs.Hacks
{
    public class HackBase
    {
        public delegate void Run();

        public HackBase()
        {
            Instances.Add(this);
        }

        public virtual bool Initialize()
        {
            return false;
        }
        
        public void SetRunner(Run RunnerThread)
        {
            ThreadHandle = new Thread(new ThreadStart(RunnerThread));
        }

        public string Name;
        public Thread ThreadHandle = null;

        public static List<HackBase> Instances = new List<HackBase>() { };
    }
}
