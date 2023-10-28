using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkAllotmentSystem
{
    public class Work
    {
        public string WorkName;
        public bool isAssigned = false;
        public List<skills> requiredSkills = new List<skills>();
    }
}
