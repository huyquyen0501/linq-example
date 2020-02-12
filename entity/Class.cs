using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tesst
{
   public class Class : IComparable
    {
        public int ID { set; get; }
        public string Name { set; get; }

        public Class(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
