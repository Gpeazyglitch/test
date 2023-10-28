using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkAllotmentSystem
{
    public enum skills
    {
        TimeManagement,
        AIExperience,
        DatabaseKnowledge,
        Leadership,
        Communication
    };
    public class Employee
    {
        public string employeeName;
        public List<skills> skillset = new List<skills>();
        public float workEligibilty;
        public int experience;
        public float workCompletionTime;
        public float workLoad;
        public List<Work> assignedWork = new List<Work>();
    }
}
