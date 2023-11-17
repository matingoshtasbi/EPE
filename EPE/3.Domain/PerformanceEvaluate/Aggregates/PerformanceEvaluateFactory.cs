using EPE.Application.DTOs.PerformanceEvaluate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.PerformanceEvaluate.Aggregates
{
    public static class PerformanceEvaluateFactory
    {

        internal static EmployeePerformanceEvaluate CreateEmployeePerformanceEvaluate(
            string employeePersonalCode, string employeeFirstName, string employeeLastName)
        {
            var employeePE = new EmployeePerformanceEvaluate(employeePersonalCode , employeeFirstName , employeeLastName , DateTime.Now);
            return employeePE;
        }

        internal static PerformanceEvaluateItem CreatePerformanceEvaluateItem(ParameterObjects.PerformanceEvaluateItemPO po)
        {
            var pE = new PerformanceEvaluateItem(po);
            return pE;
        }

        internal static MeritAverage CreateMeritAverage(IGrouping<string, PerformanceEvaluateItemRequest> meritsGroup)
        {
            var meritAverage = new MeritAverage(meritsGroup);
            return meritAverage;
        }

        internal static MeritItemAverage CreateMeritItemAverage(IGrouping<string, PerformanceEvaluateItemRequest> meritItemsGroup)
        {
            var meritItemAverage = new MeritItemAverage(meritItemsGroup);
            return meritItemAverage;
        }
    }
}
