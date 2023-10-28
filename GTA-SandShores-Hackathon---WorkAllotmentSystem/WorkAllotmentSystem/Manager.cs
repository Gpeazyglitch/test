using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkAllotmentSystem
{
    internal class Manager
    {
        public int skillFactor;
        public List<Employee> employeeList = new List<Employee>(5);
        public List<Work> workList = new List<Work>(5);
        public float minValue = 0f;
        public float maxValue = 100f;
        public Work currentWork;

        public void workAssigner()
        {
            foreach(Work i in workList)
            {
                if (i.isAssigned == false)
                {
                    currentWork = i;
                    i.isAssigned = true;
                    break;
                }
            }
        }

        public void eligibilityCalculator()
        {

            foreach(Employee j in employeeList)
            {
                var skillfactor = j.skillset.Distinct().Intersect(currentWork.requiredSkills.Distinct());
                skillFactor = skillfactor.Count();
                j.workEligibilty = (skillFactor) * j.experience / j.workCompletionTime * j.workLoad;
                

            }
        }
        public void scheduler()
        {
            foreach (Employee j in employeeList)
            {
                if(j.workEligibilty > minValue&& j.workLoad < maxValue)
                {
                    j.assignedWork.Add(currentWork);

                }
            }
        }
        


    }
}
