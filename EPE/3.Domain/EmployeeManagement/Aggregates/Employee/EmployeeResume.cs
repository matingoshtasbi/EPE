using EPE.Application.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.Aggregates
{
    public class EmployeeResume : Entity<int>
    {
        #region constractors
        public EmployeeResume()
        {

        }

        public EmployeeResume(string title , DateTime fromDate , DateTime toDate , string description)
        {
            validate(title, fromDate, toDate);
            Title = title;
            FromDate = fromDate;
            ToDate = toDate;
            Description = description;
        }
        #endregion

        #region properties
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Description { get; set; }
        #endregion

        #region public methods
        public void UpdateProperties(string title, DateTime fromDate, DateTime toDate, string description)
        {
            validate(title, fromDate, toDate);
            Title = title;
            FromDate = fromDate;
            ToDate = toDate;
            Description = description;
        }
        #endregion

        #region private methods
        private void validate(string title, DateTime fromDate, DateTime toDate)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان سابقه کاری اجباریست");
            if (fromDate > toDate)
                throw new Exception("تاریخ شروع نمیتواند از تاریخ پایان بزرگتر باشد");
            if (fromDate > DateTime.Now)
                throw new Exception("تاریخ ها نمیتوانند بزرگتر از حال باشند");
        }
        #endregion
    }
}
