using AutoMapper;
using EPE.Application.Abstractions.PerformanceEvaluate;
using EPE.Application.DTOs.PerformanceEvaluate;
using EPE.Domain.PerformanceEvaluate.Aggregates;
using EPE.Domain.PerformanceEvaluate.Enums;
using EPE.Domain.PerformanceEvaluate.ParameterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.Services.PerformanceEvaluate
{
    public class PerformanceEvaluateCommandService : IPerformanceEvaluateCommandService
    {
        #region members
        private readonly IMapper _mapper;
        private readonly IEmployeePerformanceEvaluateRepository _employeePerformanceEvaluateRepository;
        #endregion

        public PerformanceEvaluateCommandService(IMapper mapper,
            IEmployeePerformanceEvaluateRepository employeePerformanceEvaluateRepository)
        {
            _mapper = mapper;
            _employeePerformanceEvaluateRepository = employeePerformanceEvaluateRepository;
        }

        public async Task<EmployeePerformanceEvaluate> Calculate(EmployeePerformanceEvaluateRequest result)
        {
            var employeePE = PerformanceEvaluateFactory.CreateEmployeePerformanceEvaluate(
                result.EmployeePersonalCode, result.EmployeeFirstName, result.EmployeeLastName);

            foreach (var item in result.PerformanceEvaluateItems)
            {
                var po = _mapper.Map<PerformanceEvaluateItemPO>(item);
                employeePE.AddPerformanceEvaluateItem(po);
            }

            // Calculate Merit Item Average
            foreach (var meritsGroup in result.PerformanceEvaluateItems.GroupBy(c => c.MeritTitle))
            {
                employeePE.CalculateAndAddMeritAverage(meritsGroup);
            }
            // CalculateScales
            CalculateScales(employeePE.MeritAverages);


            // Calculate Merit Item Average
            foreach (var meritItemsGroup in result.PerformanceEvaluateItems.GroupBy(c => c.MeritItemTitle))
            {
                employeePE.CalculateAndAddMeritItemAverage(meritItemsGroup);
            }
            // Calculate Scales
            CalculateScales(employeePE.MeritItemAverages , (int)ScaleEnum.Total);
            foreach (var item in employeePE.MeritItemAverages.GroupBy(c => c.MeritTitle))
            {
                CalculateScales(item.ToList(), (int)ScaleEnum.Merit);
            }

            // Calculate MeritFactor
            employeePE.CalculateMeritFactor();

            _employeePerformanceEvaluateRepository.Add(employeePE);
            await _employeePerformanceEvaluateRepository.UnitOfWork.SaveChangesAsync();

            return employeePE;
        }

        public async Task RemoveEPE(long epeId)
        {
            var epe = _employeePerformanceEvaluateRepository.Get(epeId);
            if (epe == null)
                throw new Exception("نتیجه ی ارزیابی یافت نشد");

            _employeePerformanceEvaluateRepository.Remove(epeId);
            await _employeePerformanceEvaluateRepository.UnitOfWork.SaveChangesAsync();
        }


        #region private methods
        private void CalculateScales(List<MeritAverage> meritAverages)
        {
            // Get Sum Of Factors
            var totalMeritImportanceFactor = meritAverages.Select(c => c.ImportanceFactor).Sum();

            if (totalMeritImportanceFactor > 0)
            {
                // Calculate All Scales
                foreach (var item in meritAverages)
                {
                    item.TotalScale = ((double)item.ImportanceFactor / (double)totalMeritImportanceFactor) * 100;
                }

                double[] originalValues = meritAverages.Select(c => c.TotalScale).ToArray();
                List<(double orginal, int round)> valuePairs = new List<(double orginal, int round)>();

                double totalSum = originalValues.Sum();
                int currentSum = 0;

                for (int i = 0; i < originalValues.Length; i++)
                {
                    double ratio = originalValues[i] / totalSum;
                    int roundedValue = (int)Math.Round(ratio * 100);
                    valuePairs.Add((originalValues[i], roundedValue));
                    currentSum += roundedValue;
                }

                // Calculate the rounding error
                int roundingError = 100 - currentSum;

                // Distribute the rounding error by adding or subtracting from the rounded values
                for (int i = 0; i < Math.Abs(roundingError); i++)
                {
                    int indexToAdjust = roundingError > 0 ? i : i % originalValues.Length;
                    var pair = valuePairs[indexToAdjust];
                    valuePairs[indexToAdjust] = (pair.orginal, pair.round + Math.Sign(roundingError));
                }
                // Now, roundedIntValues should contain integer values that sum up to 100.     

                foreach (var item in meritAverages)
                {
                    var temp = valuePairs.FirstOrDefault(c => c.orginal == item.TotalScale)!.round;
                    valuePairs.Remove(valuePairs.FirstOrDefault(c => c.orginal == item.TotalScale));
                    item.TotalScale = temp;
                }
            }
        }

        private void CalculateScales(List<MeritItemAverage> meritItemAverages, int scaleType)
        {
            // Get Sum Of Factors
            var totalMeritItemImportanceFactor = meritItemAverages.Select(c => c.ImportanceFactor).Sum();

            if (totalMeritItemImportanceFactor > 0)
            {
                // Calculate All Scales
                foreach (var item in meritItemAverages)
                {
                    item.MeritScale = ((double)item.ImportanceFactor / (double)totalMeritItemImportanceFactor) * 100;
                }

                double[] originalValues = meritItemAverages.Select(c => c.MeritScale).ToArray();
                List<(double orginal, int round)> valuePairs = new List<(double orginal, int round)>();

                double totalSum = originalValues.Sum();
                int currentSum = 0;

                for (int i = 0; i < originalValues.Length; i++)
                {
                    double ratio = originalValues[i] / totalSum;
                    int roundedValue = (int)Math.Round(ratio * 100);
                    valuePairs.Add((originalValues[i], roundedValue));
                    currentSum += roundedValue;
                }

                // Calculate the rounding error
                int roundingError = 100 - currentSum;

                // Distribute the rounding error by adding or subtracting from the rounded values
                for (int i = 0; i < Math.Abs(roundingError); i++)
                {
                    int indexToAdjust = roundingError > 0 ? i : i % originalValues.Length;
                    var pair = valuePairs[indexToAdjust];
                    valuePairs[indexToAdjust] = (pair.orginal, pair.round + Math.Sign(roundingError));
                }
                // Now, roundedIntValues should contain integer values that sum up to 100.     

                foreach (var item in meritItemAverages)
                {
                    var temp = valuePairs.FirstOrDefault(c => c.orginal == item.MeritScale)!.round;
                    valuePairs.Remove(valuePairs.FirstOrDefault(c => c.orginal == item.MeritScale));
                    if (scaleType == (int)ScaleEnum.Merit)
                        item.MeritScale = temp;
                    else if (scaleType == (int)ScaleEnum.Total)
                        item.TotalScale = temp;
                }
            }
        }
        #endregion
    }
}
