using EPE.Application.Core.Domain;
using EPE.Domain.EmployeeManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.Aggregates
{
    public class EmployeeContact : Entity<int>
    {
        #region constractors

        public EmployeeContact()
        {
        }

        public EmployeeContact(string title, ContactTypeEnum type, string value)
        {
            validate(title , type , value);
            Title = title;
            Type = type;
            Value = value;
        }

        #endregion

        #region properties

        //public Guid  EmployeeId{ get; set; } = default!;
        public string Title { get; set; } = default!;
        public ContactTypeEnum Type { get; set; } = default!;
        public string Value { get; set; } = default!;
        #endregion

        #region public methodes
        internal void UpdateProperties(string title, ContactTypeEnum type, string value)
        {
            validate(title, type , value);
            Title = title;
            Type = type;
            Value = value;
        }
        #endregion

        #region private methods
        private void validate(string title, ContactTypeEnum type, string value)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("عنوان اطلاعات تماس اجباریست");
            if (!Enum.IsDefined(typeof(ContactTypeEnum), type))
                throw new Exception("نوع اطلاعات تماس نامعتبر است");
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("مقدار اطلاعات تماس اجباریست");

        }
        #endregion
    }
}
