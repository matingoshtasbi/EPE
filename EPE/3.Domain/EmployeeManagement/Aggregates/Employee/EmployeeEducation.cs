using EPE.Application.Core.Domain;
using EPE.Domain.EmployeeManagement.Aggregates;
using EPE.Domain.EmployeeManagement.ValueObjects;
using EPE.Domain.EmployeeManagement.ValueObjects.Education;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.Aggregates
{
    public class EmployeeEducation: Entity<int>
    {
        #region constractors
        public EmployeeEducation()
        {

        }
        public EmployeeEducation(int levelId, int majorId, string minor, double? average)
        {
            validate(minor , average);
            LevelId = levelId;
            MajorId = majorId;
            Minor = minor;
            Average = average;
        }
        #endregion

        #region properties

        public int LevelId { get; set; }
        public int MajorId { get; set; }
        public string? Minor { get; set; }
        public double? Average { get; set; }
        #endregion

        #region public methods
        internal void UpdateProperties(int levelId, int majorId, string minor, double? average)
        {
            validate(minor, average);
            LevelId = levelId;
            MajorId = majorId;
            Minor = minor;
            Average = average;
        }
        #endregion

        #region private methods
        private void validate(string minor, double? average)
        {
            if (string.IsNullOrWhiteSpace(minor))
                throw new Exception("عنوان گرایش تحصیلی خالیست");
            if (average <= 0)
                throw new Exception("مقدار معدل نامعتبر است");
        }
        #endregion
    }
}
