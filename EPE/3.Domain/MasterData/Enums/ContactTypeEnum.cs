using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Domain.EmployeeManagement.Enums
{
    public enum ContactTypeEnum
    {
        [Display(Name = "تلفن همراه")]
        Mobile = 1,
        [Display(Name = "تلفن ثابت")]
        Telephone = 2,
        [Display(Name = "آدرس")]
        Address = 3,
        [Display(Name = "ایمیل")]
        Email = 4,
        [Display(Name = "شماره اضطراری")]
        Emergency = 5,
    }
}
