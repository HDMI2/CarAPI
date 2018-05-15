using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDemo
{
    public class DemoManager
    {

        Predicate<Demo> demoFinder = (Demo d) => { return d.Name == "My Name 2"; };
        public delegate void DemoInfoDelegate(Demo demo);

        public void DemoListInfoGerade(DemoInfoDelegate demoInfoDelegate,List<Demo> demos)
        {
            var list = demos.FindAll(d => d.Id > 3);
            foreach (var item in demos)
            {
                demoInfoDelegate(item);
            }
        }


        public void DemoListInfo(List<Demo> demos)
        {

            DemoInfoDelegate demoInfoDelegate = DemoInfo;

            foreach (var item in demos)
            {
                demoInfoDelegate(item);
            }
        }



        void DemoInfo(Demo demo)
        {
            Console.WriteLine($"Demo: id:{demo.Id}, Name:{demo.Name} ");
        }

        public void DemosPred()
        {
            List<Demo> demos = new List<Demo>();
            demos.Find(demoFinder);
        }

        public List<Demo> CreateList(int count = 10)
        {
            List<Demo> demos = new List<Demo>();
            for (int i = 0; i < count; i++)
            {
                demos.Add(new Demo { Id = i, Name = "My Name " + i });
            }

            return demos;
        }

        public string GetAllNames(List<Demo> demos)
        {
            Func<Demo, string> func = GetName;
            string ret = "";
            foreach (var item in demos)
            {
                ret += func(item) + Environment.NewLine;
            }
            return ret;
        }

        private string GetName(Demo demo)
        {
            return demo.Name;
        }



    }
}
