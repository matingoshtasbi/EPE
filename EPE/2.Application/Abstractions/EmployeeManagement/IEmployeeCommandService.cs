﻿using EPE.Application.DTOs.EmployeeManagement;
using EPE.Application.DTOs.EmployeeManagement.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.Abstractions.EmployeeManagement
{
    public interface IEmployeeCommandService
    {
        #region employee
        Task<Guid> AddEmployee(EmployeeRequest request);
        Task UpdateEmployee(EmployeeRequest requst);
        Task RemoveEmployee(Guid employeeId);
        #endregion

        #region baseInfo
        Task<EmployeeBaseInfo> GetBaseInfo();
        #endregion
    }
}
