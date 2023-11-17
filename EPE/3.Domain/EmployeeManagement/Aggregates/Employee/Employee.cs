using EPE.Application.Core.Domain;
using EPE.Domain.EmployeeManagement.Aggregates;
using EPE.Domain.EmployeeManagement.Enums;
using EPE.Domain.EmployeeManagement.ParameterObjects;
using EPE.Domain.EmployeeManagement.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPE.Domain.EmployeeManagement.Aggregates
{
    public class Employee : Entity<Guid>
    {
        #region members
        string? _idNo = default!;
        string _code = default!;
        string _firstName = default!;
        string _lastName = default!;
        string? _fatherName = default!;
        DateTime _employmentDate = default!;
        DateTime? _releaseDate = default!;
        DateTime? _birthdate = default!;
        string? _birthplace = default!;
        int? _gender = default!;
        string? _nationality = default!;
        int? _maritalStatusId = default!;
        int? _militaryServiceStatusId = default!;
        int? _numberOfDependents = default!;
        int? _jobId = default!;
        string? _description = default!;
        List<EmployeeContact> _contacts = new ();
        List<EmployeeEducation> _educations = new ();
        List<EmployeePhysicalInfo> _physicalInfo = new ();
        List<EmployeeResume> _resume = new();
        #endregion members

        #region constractors
        public Employee()
        {

        }
        public Employee(EmployeePO po, IEmployeeService employeeService)
        {
            EmployeeService = employeeService;

            validate(po);
            IdNo = po.IdNo;
            Code = po.Code;
            FirstName = po.FirstName;
            LastName = po.LastName;
            MaritalStatusId = po.MaritalStatusId;
            FatherName = po.FatherName;
            EmploymentDate = po.EmploymentDate;
            ReleaseDate = po.ReleaseDate;
            Birthdate = po.Birthdate;
            Birthplace = po.Birthplace;
            GenderId = po.GenderId;
            Nationality = po.Nationality;
            NumberOfDependents = po.NumberOfDependents;
            MilitaryServiceStatusId = po.MilitaryServiceStatusId;
            JobId = po.JobId;
            Description = po.Description;
        }


        #endregion

        #region private methodes
        private void validate(EmployeePO po)
        {
            if (string.IsNullOrWhiteSpace(po.IdNo))
                throw new Exception("کد ملی اجباریست");
            if (string.IsNullOrWhiteSpace(po.Code))
                throw new Exception("کد پرسنلی اجباریست");
            if (string.IsNullOrWhiteSpace(po.FirstName))
                throw new Exception("نام اجباریست");
            if (string.IsNullOrWhiteSpace(po.LastName))
                throw new Exception("نام خانوادگی اجباریست");
            if (EmployeeService.IsEmployeeIdNoExist(po.IdNo , Id))
                throw new Exception("کد ملی تکراریست");
            if (EmployeeService.IsEmployeeCodeExist(po.Code , Id))
                throw new Exception("کد پرسنلی اجباریست");
            if (po.GenderId != 0 && !EmployeeService.IsGenderInvalid(po.GenderId))
                throw new Exception("جنسیت نامعتبر است");
            if (po.MaritalStatusId != 0 && !EmployeeService.IsMaritalStatusInvalid(po.MaritalStatusId))
                throw new Exception("وضعیت تاهل نامعتبر است");
            if (po.MilitaryServiceStatusId != 0 && !EmployeeService.IsMilitaryServiceStatusInvalid(po.MilitaryServiceStatusId))
                throw new Exception("وضعیت خدمت نامعتبر است");
            if (po.EmploymentDate < po.Birthdate)
                throw new Exception("تاریخ استخدام باید از تاریخ تولد بزرگتر باشد");
            if (po.ReleaseDate < po.EmploymentDate)
                throw new Exception("تاریخ اتمام همکاری باید از تاریخ استخدام بزرگتر باشد");
         
        }
        private EmployeeContact? findContact(int contactId)
        {
            var employeeContact = Contacts.FirstOrDefault(c => c.Id == contactId);
            if (employeeContact == null)
                throw new Exception("اطلاعات تماس یافت نشد");

            return employeeContact;
        }
        private EmployeeEducation findEducation(int educationId)
        {
            var employeeEducation = Educations.FirstOrDefault(c => c.Id == educationId);
            if (employeeEducation == null)
                throw new Exception("اطلاعات تحصیلی یافت نشد");

            return employeeEducation;
        }
        private EmployeePhysicalInfo findPhysicalInfo(int physicalInfoId)
        {
            var employeePhysicalInfo = PhysicalInfo.FirstOrDefault(c => c.Id == physicalInfoId);
            if (employeePhysicalInfo == null)
                throw new Exception("اطلاعات فیزیکی یافت نشد");

            return employeePhysicalInfo;
        }

        private EmployeeResume findResume(int resumeId)
        {
            var employeeResume = Resume.FirstOrDefault(c => c.Id == resumeId);
            if (employeeResume == null)
                throw new Exception("سابقه کاری یافت نشد");

            return employeeResume;
        }

        #endregion

        #region properties
        public string? IdNo { get => _idNo; set => _idNo = value; }
        public string Code { get => _code; set => _code = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string? FatherName { get => _fatherName; set => _fatherName = value; }
        public DateTime EmploymentDate { get => _employmentDate; set => _employmentDate = value; }

        public DateTime? ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public DateTime? Birthdate { get => _birthdate; set => _birthdate = value; }
        public string? Birthplace { get => _birthplace; set => _birthplace = value; }
        public int? GenderId { get => _gender; set => _gender = value; }
        public string? Nationality { get => _nationality; set => _nationality = value; }
        public int? MaritalStatusId { get => _maritalStatusId; set => _maritalStatusId = value; }


        public int? MilitaryServiceStatusId { get => _militaryServiceStatusId; set => _militaryServiceStatusId = value; }
        public int? NumberOfDependents { get => _numberOfDependents; set => _numberOfDependents = value; }
        public int? JobId { get => _jobId; set => _jobId = value; }
        public string? Description { get => _description; set => _description = value; }

        public virtual List<EmployeeContact> Contacts { get => _contacts; set => _contacts = value; }

        public virtual List<EmployeeEducation> Educations { get => _educations; set => _educations = value; }

        public virtual List<EmployeePhysicalInfo> PhysicalInfo { get => _physicalInfo; set => _physicalInfo = value; }
        public virtual List<EmployeeResume> Resume { get => _resume; set => _resume = value; }


        public IEmployeeService EmployeeService = default!; 
        #endregion

        #region public methodes

        #region employee PO
        public void UpdateProperties(EmployeePO po)
        {
            validate(po);
            IdNo = po.IdNo;
            Code = po.Code;
            FirstName = po.FirstName;
            LastName = po.LastName;
            MaritalStatusId = po.MaritalStatusId;
            MilitaryServiceStatusId = po.MilitaryServiceStatusId;
            FatherName = po.FatherName;
            EmploymentDate = po.EmploymentDate;
            ReleaseDate = po.ReleaseDate;
            Birthdate = po.Birthdate;
            Birthplace = po.Birthplace;
            GenderId = po.GenderId;
            Nationality = po.Nationality;
            NumberOfDependents = po.NumberOfDependents;
            JobId = po.JobId;
            Description = po.Description;
        }
        #endregion

        #region contact
        public EmployeeContact AddContact(string title, ContactTypeEnum type, string value)
        {
            var employeeContact = EmployeeFactory.CreateContact(title, type, value);
            Contacts.Add(employeeContact);

            if (Contacts.GroupBy(c => new { c.Title, c.Value, c.Type })
              .Where(p => p.Count() > 1).Any())
                throw new Exception("اطلاعات تماس تکراریست");
            return employeeContact;
        }

        public void UpdateContact(int contactId, string title, ContactTypeEnum type, string value)
        {
            var employeeContact = findContact(contactId);
            employeeContact!.UpdateProperties(title, type, value);
            if (Contacts.GroupBy(c => new { c.Title, c.Value, c.Type })
              .Where(p => p.Count() > 1).Any())
                throw new Exception("اطلاعات تماس تکراریست");
        }
        public void RemoveContact(int contactId)
        {
            var employeeContact = findContact(contactId);
            Contacts.Remove(employeeContact!);
        }
        #endregion

        #region Education
        public EmployeeEducation AddEducation(int levelId, int majorId, string minor, double? average)
        {
            if (!EmployeeService.IsEducationLevelValid(levelId))
                throw new Exception("مقطع تحصیل نامعتبر است");
            
            if (!EmployeeService.IsEducationMajorValid(majorId))
                throw new Exception("رشته تحصیل نامعتبر است");
            
            var employeeEducation = EmployeeFactory.CreateEducation(levelId, majorId, minor, average);
            Educations.Add(employeeEducation);
            if (Educations.GroupBy(e => new { e.LevelId, e.MajorId, e.Minor })
                .Where(e => e.Count() > 1).Any())
                throw new Exception("اطلاعات تحصیلی تکراریست");
            return employeeEducation;
        }
        public void UpdateEducation(int educationId, int levelId, int majorId, string minor, double? average)
        {
            if (!EmployeeService.IsEducationLevelValid(levelId))
                throw new Exception("مقطع تحصیل نامعتبر است");
            if (!EmployeeService.IsEducationMajorValid(majorId))
                throw new Exception("رشته تحصیل نامعتبر است");
            var employeeEducation = findEducation(educationId);
            employeeEducation.UpdateProperties(levelId, majorId, minor, average);
            if (Educations.GroupBy(e => new { e.LevelId, e.MajorId, e.Minor })
               .Where(e => e.Count() > 1).Any())
                throw new Exception("اطلاعات تحصیلی تکراریست");
        }
        public void RemoveEducation(int educationId)
        {
            var employeeEducation = findEducation(educationId);
            Educations.Remove(employeeEducation);
        }
        #endregion

        #region physicalInfo
        public EmployeePhysicalInfo AddPhysicalInfo(int physicalInfoId, string value)
        {
            if (!EmployeeService.IsPhysicalInfoValid(physicalInfoId))
                throw new Exception("اطلاعات فیزیکی نامعتبر است");
            var employeePhysicalInfo = EmployeeFactory.CreatePhysicalInfo(physicalInfoId, value);
            PhysicalInfo.Add(employeePhysicalInfo);
            if (PhysicalInfo.GroupBy(p => new { p.PhysicalInfoId })
               .Where(p => p.Count() > 1).Any())
                throw new Exception("اطلاعات فیزیکی تکراریست");
            return employeePhysicalInfo;
        }
        public void UpdatePhysicalInfo(int id , int physicalInfoId, string value)
        {
            if (!EmployeeService.IsPhysicalInfoValid(physicalInfoId))
                throw new Exception("اطلاعات فیزیکی نامعتبر است");
            var employeePhysicalInfo = findPhysicalInfo(id);
            employeePhysicalInfo.UpdateProperties(physicalInfoId, value);
            if (PhysicalInfo.GroupBy(p => new { p.PhysicalInfoId })
               .Where(p => p.Count() > 1).Any())
                throw new Exception("اطلاعات فیزیکی تکراریست");
        }
        public void RemovePhysicalInfo(int physicalInfoId)
        {
            var employeePhysicalInfo = findPhysicalInfo(physicalInfoId);
            PhysicalInfo.Remove(employeePhysicalInfo);
        }
        #endregion

        #region resume
        public EmployeeResume AddResume(string title, DateTime fromDate, DateTime toDate, string description)
        {
            var employeeResume = EmployeeFactory.CreateResume(title , fromDate , toDate , description);
            Resume.Add(employeeResume);
            if (Resume.GroupBy(c => new { c.Title, c.FromDate, c.ToDate , Description })
              .Where(p => p.Count() > 1).Any())
                throw new Exception("سابقه کاری تکراریست");
            return employeeResume;
        }

        public void UpdateResume(int resumeId, string title, DateTime fromDate, DateTime toDate, string description)
        {
            var employeeResume = findResume(resumeId);
            employeeResume.UpdateProperties(title , fromDate , toDate , description);
            if (Resume.GroupBy(c => new { c.Title, c.FromDate, c.ToDate, Description })
                  .Where(p => p.Count() > 1).Any())
                throw new Exception("سابقه کاری تکراریست");
        }

        public void RemoveResume(int resumeId)
        {
            var employeeResume = findResume(resumeId);
            Resume.Remove(employeeResume);
        }

   
        #endregion

        #endregion
    }
}
