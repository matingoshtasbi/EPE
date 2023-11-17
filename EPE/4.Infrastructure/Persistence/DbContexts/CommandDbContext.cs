using EPE.Domain.EmployeeManagement.Aggregates;
using EPE.Domain.EmployeeManagement.Enums;
using EPE.Domain.EmployeeManagement.ValueObjects.Education;
using EPE.Domain.EmployeeManagement.ValueObjects.Gender;
using EPE.Domain.EmployeeManagement.ValueObjects.MaritalStatus;
using EPE.Domain.EmployeeManagement.ValueObjects.MilitaryServiceStatus;
using EPE.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using EPE.Domain.MasterData.Aggregates;
using EPE.Domain.PerformanceEvaluate.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace EPE.Infrastructure.Persistence.DbContexts
{
    public class CommandDbContext : DbContext
    {
        #region constractor
        public CommandDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        #region properties

        #region MasterData
        public DbSet<EducationLevelMD> MDEducationLevels { get; set; } = default!;
        public DbSet<EducationMajorMD> MDEducationMajors { get; set; } = default!;
        public DbSet<PhysicalInfoMD> MDPhysicalInfos { get; set; } = default!;
        public DbSet<MaritalStatusMD> MDMaritalStatuses { get; set; } = default!;
        public DbSet<GenderMD> MDGenders { get; set; } = default!;
        public DbSet<JobMD> MDJobs { get; set; } = default!;
        public DbSet<MeritMD> MDMerits { get; set; } = default!;
        public DbSet<MeritItemMD> MDMeritItems { get; set; } = default!;
        public DbSet<EvaluationItemMD> MDEvaluationItems { get; set; } = default!;
        public DbSet<MilitaryServiceStatusMD> MDMilitaryServiceStatuses { get; set; } = default!;

        #endregion

        #region employee management 
        public DbSet<Employee> Employees { get; set; } = default!;
        //public DbSet<EducationLevelEM> EMEducationLevels { get; set; } = default!;
        //public DbSet<EducationMajorEM> EMEducationMajors { get; set; } = default!;
        //public DbSet<PhysicalInfoEM> EMPhysicalInfos { get; set; } = default!;
        //public DbSet<MaritalStatusEM> EMMaritalStatuses { get; set; } = default!;
        //public DbSet<GenderEM> EMGenders { get; set; } = default!;
        //public DbSet<MilitaryServiceStatusEM> EMMilitaryServiceStatuses { get; set; } = default!;
        #endregion

        #region performance evaluated
        public DbSet<EmployeePerformanceEvaluate> EmployeePerformanceEvaluates { get; set; } = default!;
        #endregion



        #endregion

        #region protected methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommandDbContext).Assembly);

            modelBuilder.Entity<GenderMD>().HasData(new GenderMD() { Id = 1, Title = "زن" });
            modelBuilder.Entity<GenderMD>().HasData(new GenderMD() { Id = 2, Title = "مرد" });

            modelBuilder.Entity<EducationLevelMD>().HasData(new EducationLevelMD() { Id = 1, Title = "بیسواد", Order = 1 });
            modelBuilder.Entity<EducationLevelMD>().HasData(new EducationLevelMD() { Id = 2, Title = "سیکل", Order = 2 });
            modelBuilder.Entity<EducationLevelMD>().HasData(new EducationLevelMD() { Id = 3, Title = "دیپلم", Order = 3 });
            modelBuilder.Entity<EducationLevelMD>().HasData(new EducationLevelMD() { Id = 4, Title = "کاردانی", Order = 4 });
            modelBuilder.Entity<EducationLevelMD>().HasData(new EducationLevelMD() { Id = 5, Title = "کارشناسی", Order = 5 });
            modelBuilder.Entity<EducationLevelMD>().HasData(new EducationLevelMD() { Id = 6, Title = "کارشناسی ارشد", Order = 6 });
            modelBuilder.Entity<EducationLevelMD>().HasData(new EducationLevelMD() { Id = 7, Title = "دکترا", Order = 7 });

            modelBuilder.Entity<EducationMajorMD>().HasData(new EducationMajorMD() { Id = 1, Title = "مهندسی کامپیوتر" });
            modelBuilder.Entity<EducationMajorMD>().HasData(new EducationMajorMD() { Id = 2, Title = "مهندسی صنایع" });
            modelBuilder.Entity<EducationMajorMD>().HasData(new EducationMajorMD() { Id = 3, Title = "علوم کامپیوتر" });


            modelBuilder.Entity<PhysicalInfoMD>().HasData(new PhysicalInfoMD() { Id = 1, Title = "قد" });
            modelBuilder.Entity<PhysicalInfoMD>().HasData(new PhysicalInfoMD() { Id = 2, Title = "وزن" });
            modelBuilder.Entity<PhysicalInfoMD>().HasData(new PhysicalInfoMD() { Id = 3, Title = "سایز لباس" });
            modelBuilder.Entity<PhysicalInfoMD>().HasData(new PhysicalInfoMD() { Id = 4, Title = "شلوار" });
            modelBuilder.Entity<PhysicalInfoMD>().HasData(new PhysicalInfoMD() { Id = 5, Title = "سایز کفش" });

            modelBuilder.Entity<MilitaryServiceStatusMD>().HasData(new MilitaryServiceStatusMD() { Id = 1, Title = "مشمول" });
            modelBuilder.Entity<MilitaryServiceStatusMD>().HasData(new MilitaryServiceStatusMD() { Id = 2, Title = "معافیت تحصیلی" });
            modelBuilder.Entity<MilitaryServiceStatusMD>().HasData(new MilitaryServiceStatusMD() { Id = 3, Title = "درحال خدمت" });
            modelBuilder.Entity<MilitaryServiceStatusMD>().HasData(new MilitaryServiceStatusMD() { Id = 4, Title = "معاف دائم" });
            modelBuilder.Entity<MilitaryServiceStatusMD>().HasData(new MilitaryServiceStatusMD() { Id = 5, Title = "اتمام خدمت" });

            modelBuilder.Entity<MaritalStatusMD>().HasData(new MaritalStatusMD() { Id = 1, Title = "مجرد" });
            modelBuilder.Entity<MaritalStatusMD>().HasData(new MaritalStatusMD() { Id = 2, Title = "متاهل" });

            modelBuilder.Entity<MeritMD>().HasData(new MeritMD() { Id = 1, Title = "تخصصی" });
            modelBuilder.Entity<MeritMD>().HasData(new MeritMD() { Id = 2, Title = "عمومی" });
            modelBuilder.Entity<MeritMD>().HasData(new MeritMD() { Id = 3, Title = "تجربی" });
            modelBuilder.Entity<MeritMD>().HasData(new MeritMD() { Id = 4, Title = "سلامت جسم" });
            modelBuilder.Entity<MeritMD>().HasData(new MeritMD() { Id = 5, Title = "نتایج آزمون ها" });

            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 1, Title = "مهارت", MeritId = 1 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 2, Title = "دانش", MeritId = 1 });

            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 3, Title = "برنامه ریزی و سازماندهی", MeritId = 2 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 4, Title = "حل مساله", MeritId = 2 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 5, Title = "مهارت های بین فردی", MeritId = 2 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 6, Title = "ارتباط موثر", MeritId = 2 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 7, Title = "تعهد سازمانی", MeritId = 2 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 8, Title = "ثبات هیجانی", MeritId = 2 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 9, Title = "سرمایه روانشناختی", MeritId = 2 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 10, Title = "ارتقا دانش", MeritId = 2 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 11, Title = "هدایت افراد", MeritId = 2 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 12, Title = "دانش و فناوری", MeritId = 2 });

            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 13, Title = "تحصیلات", MeritId = 3 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 14, Title = "سابقه کار مرتبط", MeritId = 3 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 15, Title = "سابقه کار نامرتبط", MeritId = 3 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 16, Title = "آموزش حرفه ای", MeritId = 3 });

            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 17, Title = "نظم و پیگیری", MeritId = 4 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 18, Title = "طب کار (ثبت در پرونده پرسنلی )", MeritId = 4 });

            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 19, Title = "نئو", MeritId = 5 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 20, Title = "لنگرگاه شغلی", MeritId = 5 });
            modelBuilder.Entity<MeritItemMD>().HasData(new MeritItemMD() { Id = 21, Title = "استرانگ", MeritId = 5 });

            modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 1,
                Title = "درک مطلب",
                MeritItemId = 1,
                Description = "درک جملات و پاراگراف های نوشته شده در اسناد مربوط به کار."
            });
            modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 2,
                Title = "گوش دادن فعال",
                MeritItemId = 1,
                Description = "توجه کامل به آنچه دیگران می گویند، وقت گذاشتن برای درک نکات گفته شده، پرسیدن سؤالات مناسب و عدم قطع صحبت در زمان های نامناسب."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 3,
                Title = "نوشتن",
                MeritItemId = 1,
                Description = "برقراری ارتباط مؤثر به صورت نوشتاری و متناسب با نیازهای مخاطب."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 4,
                Title = "تفکر انتقادی",
                MeritItemId = 1,
                Description = "استفاده از منطق و استدلال برای شناسایی نقاط قوت و ضعف راه حل ها، نتیجه گیری ها یا رویکردهای جایگزین برای مشکلات."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 5,
                Title = "صحبت كردن",
                MeritItemId = 1,
                Description = "صحبت کردن با دیگران برای انتقال موثر اطلاعات."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 6,
                Title = "حل مسائل پیچیده",
                MeritItemId = 1,
                Description = "شناسایی مشکلات پیچیده و بررسی اطلاعات مرتبط برای توسعه و ارزیابی گزینه ها و اجرای راه حل ها."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 7,
                Title = "علوم پایه",
                MeritItemId = 1,
                Description = "استفاده از قوانین و روش های علمی برای حل مسائل."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 8,
                Title = "ریاضیات",
                MeritItemId = 1,
                Description = "استفاده از ریاضیات برای حل مسائل"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 9,
                Title = "یادگیری فعال",
                MeritItemId = 1,
                Description = "درک پیامدهای اطلاعات جدید برای حل مسئله و تصمیم گیری فعلی و آینده."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 10,
                Title = "قضاوت و تصمیم گیری",
                MeritItemId = 1,
                Description = "در نظر گرفتن هزینه ها و منافع نسبی اقدامات بالقوه برای انتخاب مناسب ترین."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 12,
                Title = "راهکارهای آموختن",
                MeritItemId = 1,
                Description = "انتخاب و استفاده از روش‌ها و روش‌های آموزشی/آموزشی متناسب با موقعیت در هنگام یادگیری یا آموزش چیزهای جدید."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 13,
                Title = "تجزیه و تحلیل سیستم ها",
                MeritItemId = 1,
                Description = "تعیین اینکه یک سیستم چگونه باید کار کند و چگونه تغییرات در شرایط، عملیات و محیط بر نتایج تأثیر می گذارد."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 14,
                Title = "نظارت بر",
                MeritItemId = 1,
                Description = "نظارت/ارزیابی عملکرد خود، سایر افراد یا سازمان ها برای ایجاد بهبود یا انجام اقدامات اصلاحی."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 15,
                Title = "ادراک اجتماعی",
                MeritItemId = 1,
                Description = "آگاه بودن از واکنش دیگران و درک اینکه چرا آنها مانند خودشان واکنش نشان می دهند."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 16,
                Title = "هماهنگی",
                MeritItemId = 1,
                Description = "تنظیم اعمال در رابطه با اعمال دیگران."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 17,
                Title = "ارزیابی سیستم ها",
                MeritItemId = 1,
                Description = "شناسایی معیارها یا شاخص های عملکرد سیستم و اقدامات لازم برای بهبود یا اصلاح عملکرد، نسبت به اهداف سیستم."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 18,
                Title = "مدیریت زمان",
                MeritItemId = 1,
                Description = "مدیریت زمان خود و دیگران."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 19,
                Title = "دستور دادن",
                MeritItemId = 1,
                Description = "یاد دادن به دیگران که چگونه کاری را انجام دهند."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 20,
                Title = "برنامه نويسي",
                MeritItemId = 1,
                Description = "نوشتن برنامه های کامپیوتری برای اهداف مختلف."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 21,
                Title = "اقناع",
                MeritItemId = 1,
                Description = "متقاعد کردن دیگران برای تغییر عقیده یا رفتارشان."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 22,
                Title = "تجزیه و تحلیل کنترل کیفیت",
                MeritItemId = 1,
                Description = "انجام تست ها و بازرسی محصولات، خدمات یا فرآیندها برای ارزیابی کیفیت یا عملکرد."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 23,
                Title = "مذاکره",
                MeritItemId = 1,
                Description = "دور هم جمع کردن دیگران و تلاش برای آشتی دادن اختلافات."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 24,
                Title = "جهت گیری خدمات",
                MeritItemId = 1,
                Description = "فعالانه به دنبال راه هایی برای کمک به مردم است."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 25,
                Title = "تجزیه و تحلیل عملیات",
                MeritItemId = 1,
                Description = "تجزیه و تحلیل نیازها و الزامات محصول برای ایجاد یک طرح."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 26,
                Title = "مدیریت منابع مادی",
                MeritItemId = 1,
                Description = "به دست آوردن و مشاهده استفاده مناسب از تجهیزات، امکانات و مواد مورد نیاز برای انجام کارهای معین."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 27,
                Title = "طراحی فناوری",
                MeritItemId = 1,
                Description = "تولید یا تطبیق تجهیزات و فناوری برای پاسخگویی به نیازهای کاربر."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 28,
                Title = "عیب یابی",
                MeritItemId = 1,
                Description = "تعیین علل خطاهای عملیاتی و تصمیم گیری در مورد آن."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 29,
                Title = "مدیریت منابع مالی",
                MeritItemId = 1,
                Description = "تعیین چگونگی هزینه کردن پول برای انجام کار، و حسابداری برای این هزینه ها."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 30,
                Title = "عملیات و کنترل",
                MeritItemId = 1,
                Description = "کنترل عملیات تجهیزات یا سیستم ها."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 31,
                Title = "زبان انگلیسی",
                MeritItemId = 2,
                Description = "آشنایی با ساختار و محتوای زبان انگلیسی شامل معنی و املای کلمات، قواعد ترکیب و دستور زبان."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 32,
                Title = "کامپیوتر و الکترونیک",
                MeritItemId = 2,
                Description = "آشنایی با بردهای مدار، پردازنده ها، تراشه ها، تجهیزات الکترونیکی و سخت افزار و نرم افزار کامپیوتر از جمله برنامه های کاربردی و برنامه نویسی."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 33,
                Title = "اداری",
                MeritItemId = 2,
                Description = "آشنایی با رویه ها و سیستم های اداری  مانند واژه پردازی، مدیریت فایل ها و سوابق، تنگ نگاری و رونویسی، طراحی فرم ها و اصطلاحات محل کار."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 34,
                Title = "ریاضیات",
                MeritItemId = 2,
                Description = "دانش حساب، جبر، هندسه، حساب دیفرانسیل و انتگرال، آمار و کاربردهای آنها."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 35,
                Title = "خدمات مشتری و شخصی",
                MeritItemId = 2,
                Description = "آشنایی با اصول و فرآیندهای ارائه خدمات به مشتریان و شخصی. این شامل ارزیابی نیازهای مشتری، رعایت استانداردهای کیفیت برای خدمات و ارزیابی رضایت مشتری است."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 36,
                Title = "آموزش و پرورش",
                MeritItemId = 2,
                Description = "آشنایی با اصول و روشهای برنامه درسی و طراحی آموزشی، تدریس و آموزش برای افراد و گروهها و سنجش تأثیرات آموزشی."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 37,
                Title = "روانشناسی",
                MeritItemId = 2,
                Description = "آگاهی از رفتار و عملکرد انسان؛ تفاوت های فردی در توانایی، شخصیت و علایق؛ یادگیری و انگیزه؛ روش های تحقیق روانشناختی؛ و ارزیابی و درمان اختلالات رفتاری و عاطفی."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 38,
                Title = "مدیریت",
                MeritItemId = 2,
                Description = "آگاهی از اصول کسب و کار و مدیریت مربوط به برنامه ریزی استراتژیک، تخصیص منابع، مدل سازی منابع انسانی، تکنیک رهبری، روش های تولید و هماهنگی افراد و منابع."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 39,
                Title = "قانون و دولت",
                MeritItemId = 2,
                Description = "آگاهی از قوانین، قوانین حقوقی، رویه های دادگاه، سوابق، مقررات دولتی، دستورات اجرایی، قوانین آژانس و روند سیاسی دموکراتیک."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 40,
                Title = "ارتباطات و رسانه",
                MeritItemId = 2,
                Description = "آشنایی با تکنیک ها و روش های تولید رسانه، ارتباطات و انتشار. این شامل راه های جایگزین برای اطلاع رسانی و سرگرمی از طریق رسانه های نوشتاری، شفاهی و بصری است."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 41,
                Title = "فروش و بازاریابی",
                MeritItemId = 2,
                Description = "آشنایی با اصول و روش های نمایش، تبلیغ و فروش محصولات یا خدمات. این شامل استراتژی ها و تاکتیک های بازاریابی، نمایش محصول، تکنیک های فروش و سیستم های کنترل فروش است."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 43,
                Title = "جامعه شناسی و مردم شناسی",
                MeritItemId = 2,
                Description = "آگاهی از رفتار و پویایی گروه، روندها و تأثیرات اجتماعی، مهاجرت های انسانی، قومیت، فرهنگ ها و تاریخچه و خاستگاه آنها."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 44,
                Title = "پرسنل و منابع انسانی",
                MeritItemId = 2,
                Description = "آشنایی با اصول و رویه های جذب پرسنل، گزینش، آموزش، جبران خسارت و مزایا، روابط کار و مذاکره و سیستم های اطلاعات پرسنل."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 45,
                Title = "درمان و مشاوره",
                MeritItemId = 2,
                Description = "آگاهی از اصول، روش ها و روش های تشخیص، درمان و توانبخشی اختلالات جسمی و روانی و مشاوره و راهنمایی شغلی."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 46,
                Title = "فلسفه و الهیات",
                MeritItemId = 2,
                Description = "آشنایی با نظام ها و مذاهب مختلف فلسفی. این شامل اصول اساسی، ارزش‌ها، اخلاق، روش‌های تفکر، آداب و رسوم، اعمال و تأثیر آن‌ها بر فرهنگ انسانی است."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 47,
                Title = "زبان خارجی",
                MeritItemId = 2,
                Description = "آگاهی از ساختار و محتوای یک زبان خارجی (غیر انگلیسی) شامل معنی و املای کلمات، قواعد ترکیب و دستور زبان و تلفظ."
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 48,
                Title = "سازمان دهی وظایف",
                MeritItemId = 3,
                Description = "نئو  c2"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 49,
                Title = "اولویت بندی وظایف",
                MeritItemId = 3,
                Description = "نئو  c2"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 50,
                Title = "مدیریت بحران",
                MeritItemId = 3,
                Description = "نئو  c5&6"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 51,
                Title = "برنامه ریزی وظایف",
                MeritItemId = 3,
                Description = "نئو  c2"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 52,
                Title = "تعیین هدف",
                MeritItemId = 3,
                Description = "نئو  c4"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 53,
                Title = "تحلیل و ارزیابی",
                MeritItemId = 4,
                Description = "طرح مسئله فرضی یا پرسش درباره تجربیات"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 54,
                Title = "استدلال منطقی",
                MeritItemId = 4,
                Description = "طرح مسئله فرضی یا پرسش درباره تجربیات"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 55,
                Title = "تصمیم گیری",
                MeritItemId = 4,
                Description = "نئو e4"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 56,
                Title = "مشاهده دقیق",
                MeritItemId = 4,
                Description = "طرح مسئله فرضی یا پرسش درباره تجربیات"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 57,
                Title = "طوفان فکری",
                MeritItemId = 4,
                Description = "طرح مسئله فرضی یا پرسش درباره تجربیات"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 58,
                Title = "همدلی و همدردی",
                MeritItemId = 5,
                Description = "نئو e1"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 59,
                Title = "تیم سازی",
                MeritItemId = 5,
                Description = "نئو e2"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 60,
                Title = "شبکه سازی",
                MeritItemId = 5,
                Description = "روابط و ساختار ارتباط وی در حوزه تخصصی اش چقدر وسعت دارد؟"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 61,
                Title = "درک افراد",
                MeritItemId = 5,
                Description = "عملکرد وی در تحلیل و فهم صحبت دیگران چه گونه است؟"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 62,
                Title = "ارتباط کلامی",
                MeritItemId = 6,
                Description = "برداشت کلی مصاحبه گر"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 63,
                Title = "ارتباط نوشتاری",
                MeritItemId = 6,
                Description = "نحوه نوشتن رزومه، ویراستاری، نوع پرزنت خود در رزومه"
            }); ; modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 64,
                Title = "اغازگر ارتباط",
                MeritItemId = 6,
                Description = "برداشت کلی مصاحبه گر"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 65,
                Title = "بازخورد موثر",
                MeritItemId = 6,
                Description = "برداشت کلی مصاحبه گر"
            }); ; modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 66,
                Title = "گوش دادن فعال",
                MeritItemId = 6,
                Description = "برداشت کلی مصاحبه گر"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 67,
                Title = "اخلاق کاری",
                MeritItemId = 7,
                Description = "چقدر بر قوانین و ملاحظات تخصصی شغل خود آگاه است + اخلاق عمومی"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 68,
                Title = "صداقت",
                MeritItemId = 7,
                Description = "برداشت کلی مصاحبه گر"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 69,
                Title = "اشتیاق (تعهد عاطفی)",
                MeritItemId = 7,
                Description = "سوال در خصوص منابع مالی فرد، دیدگاه فرد نسبت به آینده ی موقعیت شغلی"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 70,
                Title = "نیاز (تعهد مستمر)",
                MeritItemId = 7,
                Description = "سوال در خصوص منابع مالی فرد، دیدگاه فرد نسبت به آینده ی موقعیت شغلی"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 71,
                Title = "تعهد (تداوم هنجاری)",
                MeritItemId = 7,
                Description = "سوال در خصوص منابع مالی فرد، دیدگاه فرد نسبت به آینده ی موقعیت شغلی"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 72,
                Title = "هوش درون فردی",
                MeritItemId = 8,
                Description = "چقدر بر هیجانات خود اگاه است؟"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 73,
                Title = "هوش بین فردی",
                MeritItemId = 8,
                Description = "چقدر در بروز و ظهور هیجانات موفق است؟"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 74,
                Title = "توان سازگاری",
                MeritItemId = 8,
                Description = "چقدر در پذیرش هیجانات موفق است؟"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 75,
                Title = "کنترل استرس",
                MeritItemId = 8,
                Description = "چقدر در کنترل و مدیریت هیجانات موفق است؟"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 76,
                Title = "خلق عمومی",
                MeritItemId = 8,
                Description = "خلق عمومی او به چه شکل است؟"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 77,
                Title = "تاب آوری",
                MeritItemId = 9,
                Description = "عملکرد ولی در برخورد با چالش های مصاحبه"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 78,
                Title = "خودکار آمدی",
                MeritItemId = 9,
                Description = "میزان اعتماد به نفس فرد در مصاحبه"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 79,
                Title = "امیدواری",
                MeritItemId = 9,
                Description = "میزان امیدواری فرد نسبت به آینده"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 80,
                Title = "خوش بینی",
                MeritItemId = 9,
                Description = "میزان خوش بینی فرد نسبت به رخداد های آینده"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 81,
                Title = "تواضع و پذیرش",
                MeritItemId = 10,
                Description = "مستندات علمی فرد+پذیرا بودن نظرات در مصاحبه"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 82,
                Title = "روحیه یادگیری",
                MeritItemId = 10,
                Description = "مستندات علمی فرد+پذیرا بودن نظرات در مصاحبه"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 83,
                Title = "بلند پرواز",
                MeritItemId = 10,
                Description = "مسیر شغلی فرد تا کنون چه بوده است/ تصورش از مسیر شغلی اش در آینده چیست؟"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 84,
                Title = "نظارت بر اثربخشی",
                MeritItemId = 11,
                Description = "پرسش در مورد تجربیات گذشته"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 85,
                Title = "برنامه ریزی، سازماندهی",
                MeritItemId = 11,
                Description = "پرسش در مورد تجربیات گذشته"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 86,
                Title = "تفویض و تقسیم مسئولیت",
                MeritItemId = 11,
                Description = "پرسش در مورد تجربیات گذشته"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 87,
                Title = "حمایت و تشویق ",
                MeritItemId = 11,
                Description = "پرسش در مورد تجربیات گذشته"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 88,
                Title = "آشنایی با فریمورک های برنامه نویسی",
                MeritItemId = 12,
                Description = "برداشت کلی مصاحبه گر"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 89,
                Title = "آشنایی با ویندوز",
                MeritItemId = 12,
                Description = "برداشت کلی مصاحبه گر"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 90,
                Title = "آشنایی با  تلفن همراه",
                MeritItemId = 12,
                Description = "برداشت کلی مصاحبه گر"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 91,
                Title = "سطح تحصیلات",
                MeritItemId = 13,
                Description = "میزان تحصیلات مورد نیاز برای احراز در این موقعیت شغلی"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 92,
                Title = "میزان سابقه ی مهندسی",
                MeritItemId = 14,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 93,
                Title = "میزان سابقه ی غیر مهندسی",
                MeritItemId = 15,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 94,
                Title = "دوره حضوری یا غیر حضوری",
                MeritItemId = 16,
                Description = "دوره ها و یا آموزش های حرفه ای که فرد برای این شغل فراگرفته"
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 95,
                Title = "نظم شرکت در کلاس ها و برنامه های ورزشی",
                MeritItemId = 17,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 96,
                Title = "رعایت رژیم غذایی طبق توصیه پزشک یا مربی",
                MeritItemId = 17,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 97,
                Title = "معاینات و ارزیابی اندام‌ها",
                MeritItemId = 18,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 98,
                Title = "آزمایش خون",
                MeritItemId = 18,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 99,
                Title = "آزمایش ادرار (که شامل تست اعتیاد هم می‌شود)",
                MeritItemId = 18,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 100,
                Title = "نوار قلب",
                MeritItemId = 18,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 101,
                Title = "معاینات بینایی‌سنجی (اپتومتری)",
                MeritItemId = 18,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 102,
                Title = "بررسی شنوایی‌سنجی (آدیومتر)",
                MeritItemId = 18,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 103,
                Title = "سلامت تنفس (اسپیرومتری)",
                MeritItemId = 18,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 104,
                Title = "فشارخون",
                MeritItemId = 18,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 105,
                Title = "چکاپ ادواری",
                MeritItemId = 18,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 106,
                Title = "روان رنجوری",
                MeritItemId = 19,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 107,
                Title = "برون گرایی",
                MeritItemId = 19,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 108,
                Title = "گشودگی به تجربه",
                MeritItemId = 19,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 109,
                Title = "سازگاری",
                MeritItemId = 19,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 110,
                Title = "مسئولیت پذیری",
                MeritItemId = 19,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 111,
                Title = "لنگرگاه فنی",
                MeritItemId = 20,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 112,
                Title = "لنگرگاه خدمت",
                MeritItemId = 20,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 113,
                Title = "لنگرگاه استقلال",
                MeritItemId = 20,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 114,
                Title = "لنگرگاه تنوع",
                MeritItemId = 20,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 115,
                Title = "لنگرگاه مدیریت",
                MeritItemId = 20,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 116,
                Title = "لنگرگاه هویت",
                MeritItemId = 20,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 117,
                Title = "لنگرگاه امنیت",
                MeritItemId = 20,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 118,
                Title = "لنگرگاه خلاقیت",
                MeritItemId = 20,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 119,
                Title = "هنری",
                MeritItemId = 21,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 120,
                Title = "جستجوگر",
                MeritItemId = 21,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 121,
                Title = "اجتماعی",
                MeritItemId = 21,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 122,
                Title = "متهور",
                MeritItemId = 21,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 123,
                Title = "واقع گرا",
                MeritItemId = 21,
                Description = ""
            }); modelBuilder.Entity<EvaluationItemMD>().HasData(new EvaluationItemMD()
            {
                Id = 124,
                Title = "قرارداری",
                MeritItemId = 21,
                Description = ""
            });


            modelBuilder.Entity<JobMD>().HasData(new JobMD() { Id = 1, Title = "کارشناس برنامه نویسی" });



            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)1,
                EvaluationItemId = 1,
                ImportanceFactor = 10,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)2,
                EvaluationItemId = 8,
                ImportanceFactor = 20,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)3,
                EvaluationItemId = 12,
                ImportanceFactor = 20,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)4,
                EvaluationItemId = 20,
                ImportanceFactor = 15,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)5,
                EvaluationItemId = 27,
                ImportanceFactor = 30,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)6,
                EvaluationItemId = 28,
                ImportanceFactor = 30,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)7,
                EvaluationItemId = 31,
                ImportanceFactor = 40,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)8,
                EvaluationItemId = 32,
                ImportanceFactor = 20,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)9,
                EvaluationItemId = 34,
                ImportanceFactor = 10,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)10,
                EvaluationItemId = 49,
                ImportanceFactor = 15,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)11,
                EvaluationItemId = 53,
                ImportanceFactor = 15,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)12,
                EvaluationItemId = 54,
                ImportanceFactor = 10,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)13,
                EvaluationItemId = 55,
                ImportanceFactor = 40,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)14,
                EvaluationItemId = 67,
                ImportanceFactor = 10,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)15,
                EvaluationItemId = 77,
                ImportanceFactor = 30,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)16,
                EvaluationItemId = 88,
                ImportanceFactor = 20,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)17,
                EvaluationItemId = 89,
                ImportanceFactor = 30,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)18,
                EvaluationItemId = 91,
                ImportanceFactor = 25,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)19,
                EvaluationItemId = 92,
                ImportanceFactor = 20,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)20,
                EvaluationItemId = 109,
                ImportanceFactor = 20,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)21,
                EvaluationItemId = 110,
                ImportanceFactor = 25,
                CriterionScore = 60,
                JobMDId = 1
            });

            modelBuilder.Entity<JobEvaluatedItemMD>().HasData(new 
            {
                Id = (long)22,
                EvaluationItemId = 124,
                ImportanceFactor = 15,
                CriterionScore = 60,
                JobMDId = 1
            });

            var employeeId = Guid.NewGuid();
            modelBuilder.Entity<Employee>(emp =>
            {
                emp.HasData(new Employee()
                {
                    Id = employeeId,
                    Code = "1",
                    FirstName = "متین",
                    IdNo = "0022",
                    LastName = "گشتاسبی",
                    Birthdate = new DateTime(2000, 1, 12),
                    Birthplace = "تهران",
                    FatherName = "مسعود",
                    EmploymentDate = new DateTime(2023, 1, 1),
                    GenderId = 2,
                    ReleaseDate = new DateTime(2024, 1, 1),
                    JobId = 1,
                    NumberOfDependents = 1,
                    MaritalStatusId = 2,
                    MilitaryServiceStatusId = 1,
                    Nationality = "ایرانی",
                    Description = "توسعه دهنده ی پروژه ارزیابی عملکرد کارکنان"
                });

                //emp.OwnsMany(c => c.Contacts).HasData(new
                //{
                //    Id = 1,
                //    Title = "شماره شخصی",
                //    Type = ContactTypeEnum.Mobile,
                //    Value = "0930",
                //    EmployeeId = employeeId
                //});
            });

            modelBuilder.Entity<EmployeeContact>().HasData(new
            {
                Id = 1,
                Title = "شماره شخصی",
                Type = ContactTypeEnum.Mobile,
                Value = "0930",
                EmployeeId = employeeId
            });

            modelBuilder.Entity<EmployeeEducation>().HasData(new
            {
                Id = 1,
                LevelId = 5,
                MajorId = 1,
                Average = 16.5,
                Minor = "",
                EmployeeId = employeeId
            });

            modelBuilder.Entity<EmployeePhysicalInfo>().HasData(new
            {
                Id = 1,
                PhysicalInfoId = 1,
                Value = "186 cm",
                EmployeeId = employeeId
            });

            modelBuilder.Entity<EmployeeResume>().HasData(new
            {
                Id = 1,
                Title = "توسعه دهنده ی دات نت",
                FromDate = new DateTime(2019, 1, 1),
                ToDate = new DateTime(2023, 1, 1),
                EmployeeId = employeeId,
                Description = "شاغل در شرکت های : \n" +
                        " سازمان بنادر و کشتیرانی (آسپیان) \n" +
                        "شرکت بابکو \n" +
                        "بیمه ی مرکزی ایران (راهبرد نگار آمیتیس)"
            });


        }
        #endregion
    }
}
