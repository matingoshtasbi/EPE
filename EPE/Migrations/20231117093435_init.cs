using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPE.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationMajors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationMajors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePerformanceEvaluates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeePersonalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalWeightedCriterionScore = table.Column<double>(type: "float", nullable: false),
                    TotalWeightedScore = table.Column<double>(type: "float", nullable: false),
                    MeritFactor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePerformanceEvaluates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Birthplace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: true),
                    MilitaryServiceStatusId = table.Column<int>(type: "int", nullable: true),
                    NumberOfDependents = table.Column<int>(type: "int", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeritItemId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeritItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeritId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeritItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryServiceStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryServiceStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeritAverages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeritTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriterionScore = table.Column<double>(type: "float", nullable: false),
                    TotalScale = table.Column<double>(type: "float", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    EmployeePerformanceEvaluateId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeritAverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeritAverages_EmployeePerformanceEvaluates_EmployeePerformanceEvaluateId",
                        column: x => x.EmployeePerformanceEvaluateId,
                        principalTable: "EmployeePerformanceEvaluates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeritItemAverages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeritTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeritItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriterionScore = table.Column<double>(type: "float", nullable: false),
                    MeritScale = table.Column<double>(type: "float", nullable: false),
                    TotalScale = table.Column<double>(type: "float", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    EmployeePerformanceEvaluateId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeritItemAverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeritItemAverages_EmployeePerformanceEvaluates_EmployeePerformanceEvaluateId",
                        column: x => x.EmployeePerformanceEvaluateId,
                        principalTable: "EmployeePerformanceEvaluates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceEvaluateItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeritTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeritItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluationItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluationItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImportanceFactor = table.Column<int>(type: "int", nullable: false),
                    CriterionScore = table.Column<int>(type: "int", nullable: false),
                    TotalScale = table.Column<double>(type: "float", nullable: false),
                    MeritScale = table.Column<double>(type: "float", nullable: false),
                    MeritItemScale = table.Column<double>(type: "float", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    EmployeePerformanceEvaluateId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceEvaluateItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceEvaluateItems_EmployeePerformanceEvaluates_EmployeePerformanceEvaluateId",
                        column: x => x.EmployeePerformanceEvaluateId,
                        principalTable: "EmployeePerformanceEvaluates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeContacts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false),
                    Minor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Average = table.Column<double>(type: "float", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEducations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePhysicalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhysicalInfoId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePhysicalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePhysicalInfos_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeResume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeResume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeResume_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobEvaluatedItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationItemId = table.Column<int>(type: "int", nullable: false),
                    ImportanceFactor = table.Column<int>(type: "int", nullable: false),
                    CriterionScore = table.Column<int>(type: "int", nullable: false),
                    JobMDId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobEvaluatedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobEvaluatedItems_Jobs_JobMDId",
                        column: x => x.JobMDId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "Order", "Title" },
                values: new object[,]
                {
                    { 1, 1, "بیسواد" },
                    { 2, 2, "سیکل" },
                    { 3, 3, "دیپلم" },
                    { 4, 4, "کاردانی" },
                    { 5, 5, "کارشناسی" },
                    { 6, 6, "کارشناسی ارشد" },
                    { 7, 7, "دکترا" }
                });

            migrationBuilder.InsertData(
                table: "EducationMajors",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "مهندسی کامپیوتر" },
                    { 2, "مهندسی صنایع" },
                    { 3, "علوم کامپیوتر" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Birthdate", "Birthplace", "Code", "Description", "EmploymentDate", "FatherName", "FirstName", "GenderId", "IdNo", "JobId", "LastName", "MaritalStatusId", "MilitaryServiceStatusId", "Nationality", "NumberOfDependents", "ReleaseDate" },
                values: new object[] { new Guid("31bbac2a-2a14-445f-9e37-08b81c1f192f"), new DateTime(2000, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "تهران", "1", "توسعه دهنده ی پروژه ارزیابی عملکرد کارکنان", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مسعود", "متین", 2, "0022", 1, "گشتاسبی", 2, 1, "ایرانی", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "EvaluationItems",
                columns: new[] { "Id", "Description", "MeritItemId", "Title" },
                values: new object[,]
                {
                    { 1, "درک جملات و پاراگراف های نوشته شده در اسناد مربوط به کار.", 1, "درک مطلب" },
                    { 2, "توجه کامل به آنچه دیگران می گویند، وقت گذاشتن برای درک نکات گفته شده، پرسیدن سؤالات مناسب و عدم قطع صحبت در زمان های نامناسب.", 1, "گوش دادن فعال" },
                    { 3, "برقراری ارتباط مؤثر به صورت نوشتاری و متناسب با نیازهای مخاطب.", 1, "نوشتن" },
                    { 4, "استفاده از منطق و استدلال برای شناسایی نقاط قوت و ضعف راه حل ها، نتیجه گیری ها یا رویکردهای جایگزین برای مشکلات.", 1, "تفکر انتقادی" },
                    { 5, "صحبت کردن با دیگران برای انتقال موثر اطلاعات.", 1, "صحبت كردن" },
                    { 6, "شناسایی مشکلات پیچیده و بررسی اطلاعات مرتبط برای توسعه و ارزیابی گزینه ها و اجرای راه حل ها.", 1, "حل مسائل پیچیده" },
                    { 7, "استفاده از قوانین و روش های علمی برای حل مسائل.", 1, "علوم پایه" },
                    { 8, "استفاده از ریاضیات برای حل مسائل", 1, "ریاضیات" },
                    { 9, "درک پیامدهای اطلاعات جدید برای حل مسئله و تصمیم گیری فعلی و آینده.", 1, "یادگیری فعال" },
                    { 10, "در نظر گرفتن هزینه ها و منافع نسبی اقدامات بالقوه برای انتخاب مناسب ترین.", 1, "قضاوت و تصمیم گیری" },
                    { 12, "انتخاب و استفاده از روش‌ها و روش‌های آموزشی/آموزشی متناسب با موقعیت در هنگام یادگیری یا آموزش چیزهای جدید.", 1, "راهکارهای آموختن" },
                    { 13, "تعیین اینکه یک سیستم چگونه باید کار کند و چگونه تغییرات در شرایط، عملیات و محیط بر نتایج تأثیر می گذارد.", 1, "تجزیه و تحلیل سیستم ها" },
                    { 14, "نظارت/ارزیابی عملکرد خود، سایر افراد یا سازمان ها برای ایجاد بهبود یا انجام اقدامات اصلاحی.", 1, "نظارت بر" },
                    { 15, "آگاه بودن از واکنش دیگران و درک اینکه چرا آنها مانند خودشان واکنش نشان می دهند.", 1, "ادراک اجتماعی" },
                    { 16, "تنظیم اعمال در رابطه با اعمال دیگران.", 1, "هماهنگی" },
                    { 17, "شناسایی معیارها یا شاخص های عملکرد سیستم و اقدامات لازم برای بهبود یا اصلاح عملکرد، نسبت به اهداف سیستم.", 1, "ارزیابی سیستم ها" },
                    { 18, "مدیریت زمان خود و دیگران.", 1, "مدیریت زمان" },
                    { 19, "یاد دادن به دیگران که چگونه کاری را انجام دهند.", 1, "دستور دادن" },
                    { 20, "نوشتن برنامه های کامپیوتری برای اهداف مختلف.", 1, "برنامه نويسي" },
                    { 21, "متقاعد کردن دیگران برای تغییر عقیده یا رفتارشان.", 1, "اقناع" },
                    { 22, "انجام تست ها و بازرسی محصولات، خدمات یا فرآیندها برای ارزیابی کیفیت یا عملکرد.", 1, "تجزیه و تحلیل کنترل کیفیت" },
                    { 23, "دور هم جمع کردن دیگران و تلاش برای آشتی دادن اختلافات.", 1, "مذاکره" },
                    { 24, "فعالانه به دنبال راه هایی برای کمک به مردم است.", 1, "جهت گیری خدمات" },
                    { 25, "تجزیه و تحلیل نیازها و الزامات محصول برای ایجاد یک طرح.", 1, "تجزیه و تحلیل عملیات" },
                    { 26, "به دست آوردن و مشاهده استفاده مناسب از تجهیزات، امکانات و مواد مورد نیاز برای انجام کارهای معین.", 1, "مدیریت منابع مادی" },
                    { 27, "تولید یا تطبیق تجهیزات و فناوری برای پاسخگویی به نیازهای کاربر.", 1, "طراحی فناوری" },
                    { 28, "تعیین علل خطاهای عملیاتی و تصمیم گیری در مورد آن.", 1, "عیب یابی" },
                    { 29, "تعیین چگونگی هزینه کردن پول برای انجام کار، و حسابداری برای این هزینه ها.", 1, "مدیریت منابع مالی" },
                    { 30, "کنترل عملیات تجهیزات یا سیستم ها.", 1, "عملیات و کنترل" },
                    { 31, "آشنایی با ساختار و محتوای زبان انگلیسی شامل معنی و املای کلمات، قواعد ترکیب و دستور زبان.", 2, "زبان انگلیسی" },
                    { 32, "آشنایی با بردهای مدار، پردازنده ها، تراشه ها، تجهیزات الکترونیکی و سخت افزار و نرم افزار کامپیوتر از جمله برنامه های کاربردی و برنامه نویسی.", 2, "کامپیوتر و الکترونیک" }
                });

            migrationBuilder.InsertData(
                table: "EvaluationItems",
                columns: new[] { "Id", "Description", "MeritItemId", "Title" },
                values: new object[,]
                {
                    { 33, "آشنایی با رویه ها و سیستم های اداری  مانند واژه پردازی، مدیریت فایل ها و سوابق، تنگ نگاری و رونویسی، طراحی فرم ها و اصطلاحات محل کار.", 2, "اداری" },
                    { 34, "دانش حساب، جبر، هندسه، حساب دیفرانسیل و انتگرال، آمار و کاربردهای آنها.", 2, "ریاضیات" },
                    { 35, "آشنایی با اصول و فرآیندهای ارائه خدمات به مشتریان و شخصی. این شامل ارزیابی نیازهای مشتری، رعایت استانداردهای کیفیت برای خدمات و ارزیابی رضایت مشتری است.", 2, "خدمات مشتری و شخصی" },
                    { 36, "آشنایی با اصول و روشهای برنامه درسی و طراحی آموزشی، تدریس و آموزش برای افراد و گروهها و سنجش تأثیرات آموزشی.", 2, "آموزش و پرورش" },
                    { 37, "آگاهی از رفتار و عملکرد انسان؛ تفاوت های فردی در توانایی، شخصیت و علایق؛ یادگیری و انگیزه؛ روش های تحقیق روانشناختی؛ و ارزیابی و درمان اختلالات رفتاری و عاطفی.", 2, "روانشناسی" },
                    { 38, "آگاهی از اصول کسب و کار و مدیریت مربوط به برنامه ریزی استراتژیک، تخصیص منابع، مدل سازی منابع انسانی، تکنیک رهبری، روش های تولید و هماهنگی افراد و منابع.", 2, "مدیریت" },
                    { 39, "آگاهی از قوانین، قوانین حقوقی، رویه های دادگاه، سوابق، مقررات دولتی، دستورات اجرایی، قوانین آژانس و روند سیاسی دموکراتیک.", 2, "قانون و دولت" },
                    { 40, "آشنایی با تکنیک ها و روش های تولید رسانه، ارتباطات و انتشار. این شامل راه های جایگزین برای اطلاع رسانی و سرگرمی از طریق رسانه های نوشتاری، شفاهی و بصری است.", 2, "ارتباطات و رسانه" },
                    { 41, "آشنایی با اصول و روش های نمایش، تبلیغ و فروش محصولات یا خدمات. این شامل استراتژی ها و تاکتیک های بازاریابی، نمایش محصول، تکنیک های فروش و سیستم های کنترل فروش است.", 2, "فروش و بازاریابی" },
                    { 43, "آگاهی از رفتار و پویایی گروه، روندها و تأثیرات اجتماعی، مهاجرت های انسانی، قومیت، فرهنگ ها و تاریخچه و خاستگاه آنها.", 2, "جامعه شناسی و مردم شناسی" },
                    { 44, "آشنایی با اصول و رویه های جذب پرسنل، گزینش، آموزش، جبران خسارت و مزایا، روابط کار و مذاکره و سیستم های اطلاعات پرسنل.", 2, "پرسنل و منابع انسانی" },
                    { 45, "آگاهی از اصول، روش ها و روش های تشخیص، درمان و توانبخشی اختلالات جسمی و روانی و مشاوره و راهنمایی شغلی.", 2, "درمان و مشاوره" },
                    { 46, "آشنایی با نظام ها و مذاهب مختلف فلسفی. این شامل اصول اساسی، ارزش‌ها، اخلاق، روش‌های تفکر، آداب و رسوم، اعمال و تأثیر آن‌ها بر فرهنگ انسانی است.", 2, "فلسفه و الهیات" },
                    { 47, "آگاهی از ساختار و محتوای یک زبان خارجی (غیر انگلیسی) شامل معنی و املای کلمات، قواعد ترکیب و دستور زبان و تلفظ.", 2, "زبان خارجی" },
                    { 48, "نئو  c2", 3, "سازمان دهی وظایف" },
                    { 49, "نئو  c2", 3, "اولویت بندی وظایف" },
                    { 50, "نئو  c5&6", 3, "مدیریت بحران" },
                    { 51, "نئو  c2", 3, "برنامه ریزی وظایف" },
                    { 52, "نئو  c4", 3, "تعیین هدف" },
                    { 53, "طرح مسئله فرضی یا پرسش درباره تجربیات", 4, "تحلیل و ارزیابی" },
                    { 54, "طرح مسئله فرضی یا پرسش درباره تجربیات", 4, "استدلال منطقی" },
                    { 55, "نئو e4", 4, "تصمیم گیری" },
                    { 56, "طرح مسئله فرضی یا پرسش درباره تجربیات", 4, "مشاهده دقیق" },
                    { 57, "طرح مسئله فرضی یا پرسش درباره تجربیات", 4, "طوفان فکری" },
                    { 58, "نئو e1", 5, "همدلی و همدردی" },
                    { 59, "نئو e2", 5, "تیم سازی" },
                    { 60, "روابط و ساختار ارتباط وی در حوزه تخصصی اش چقدر وسعت دارد؟", 5, "شبکه سازی" },
                    { 61, "عملکرد وی در تحلیل و فهم صحبت دیگران چه گونه است؟", 5, "درک افراد" },
                    { 62, "برداشت کلی مصاحبه گر", 6, "ارتباط کلامی" },
                    { 63, "نحوه نوشتن رزومه، ویراستاری، نوع پرزنت خود در رزومه", 6, "ارتباط نوشتاری" },
                    { 64, "برداشت کلی مصاحبه گر", 6, "اغازگر ارتباط" },
                    { 65, "برداشت کلی مصاحبه گر", 6, "بازخورد موثر" },
                    { 66, "برداشت کلی مصاحبه گر", 6, "گوش دادن فعال" },
                    { 67, "چقدر بر قوانین و ملاحظات تخصصی شغل خود آگاه است + اخلاق عمومی", 7, "اخلاق کاری" },
                    { 68, "برداشت کلی مصاحبه گر", 7, "صداقت" },
                    { 69, "سوال در خصوص منابع مالی فرد، دیدگاه فرد نسبت به آینده ی موقعیت شغلی", 7, "اشتیاق (تعهد عاطفی)" },
                    { 70, "سوال در خصوص منابع مالی فرد، دیدگاه فرد نسبت به آینده ی موقعیت شغلی", 7, "نیاز (تعهد مستمر)" },
                    { 71, "سوال در خصوص منابع مالی فرد، دیدگاه فرد نسبت به آینده ی موقعیت شغلی", 7, "تعهد (تداوم هنجاری)" },
                    { 72, "چقدر بر هیجانات خود اگاه است؟", 8, "هوش درون فردی" },
                    { 73, "چقدر در بروز و ظهور هیجانات موفق است؟", 8, "هوش بین فردی" },
                    { 74, "چقدر در پذیرش هیجانات موفق است؟", 8, "توان سازگاری" },
                    { 75, "چقدر در کنترل و مدیریت هیجانات موفق است؟", 8, "کنترل استرس" }
                });

            migrationBuilder.InsertData(
                table: "EvaluationItems",
                columns: new[] { "Id", "Description", "MeritItemId", "Title" },
                values: new object[,]
                {
                    { 76, "خلق عمومی او به چه شکل است؟", 8, "خلق عمومی" },
                    { 77, "عملکرد ولی در برخورد با چالش های مصاحبه", 9, "تاب آوری" },
                    { 78, "میزان اعتماد به نفس فرد در مصاحبه", 9, "خودکار آمدی" },
                    { 79, "میزان امیدواری فرد نسبت به آینده", 9, "امیدواری" },
                    { 80, "میزان خوش بینی فرد نسبت به رخداد های آینده", 9, "خوش بینی" },
                    { 81, "مستندات علمی فرد+پذیرا بودن نظرات در مصاحبه", 10, "تواضع و پذیرش" },
                    { 82, "مستندات علمی فرد+پذیرا بودن نظرات در مصاحبه", 10, "روحیه یادگیری" },
                    { 83, "مسیر شغلی فرد تا کنون چه بوده است/ تصورش از مسیر شغلی اش در آینده چیست؟", 10, "بلند پرواز" },
                    { 84, "پرسش در مورد تجربیات گذشته", 11, "نظارت بر اثربخشی" },
                    { 85, "پرسش در مورد تجربیات گذشته", 11, "برنامه ریزی، سازماندهی" },
                    { 86, "پرسش در مورد تجربیات گذشته", 11, "تفویض و تقسیم مسئولیت" },
                    { 87, "پرسش در مورد تجربیات گذشته", 11, "حمایت و تشویق " },
                    { 88, "برداشت کلی مصاحبه گر", 12, "آشنایی با فریمورک های برنامه نویسی" },
                    { 89, "برداشت کلی مصاحبه گر", 12, "آشنایی با ویندوز" },
                    { 90, "برداشت کلی مصاحبه گر", 12, "آشنایی با  تلفن همراه" },
                    { 91, "میزان تحصیلات مورد نیاز برای احراز در این موقعیت شغلی", 13, "سطح تحصیلات" },
                    { 92, "", 14, "میزان سابقه ی مهندسی" },
                    { 93, "", 15, "میزان سابقه ی غیر مهندسی" },
                    { 94, "دوره ها و یا آموزش های حرفه ای که فرد برای این شغل فراگرفته", 16, "دوره حضوری یا غیر حضوری" },
                    { 95, "", 17, "نظم شرکت در کلاس ها و برنامه های ورزشی" },
                    { 96, "", 17, "رعایت رژیم غذایی طبق توصیه پزشک یا مربی" },
                    { 97, "", 18, "معاینات و ارزیابی اندام‌ها" },
                    { 98, "", 18, "آزمایش خون" },
                    { 99, "", 18, "آزمایش ادرار (که شامل تست اعتیاد هم می‌شود)" },
                    { 100, "", 18, "نوار قلب" },
                    { 101, "", 18, "معاینات بینایی‌سنجی (اپتومتری)" },
                    { 102, "", 18, "بررسی شنوایی‌سنجی (آدیومتر)" },
                    { 103, "", 18, "سلامت تنفس (اسپیرومتری)" },
                    { 104, "", 18, "فشارخون" },
                    { 105, "", 18, "چکاپ ادواری" },
                    { 106, "", 19, "روان رنجوری" },
                    { 107, "", 19, "برون گرایی" },
                    { 108, "", 19, "گشودگی به تجربه" },
                    { 109, "", 19, "سازگاری" },
                    { 110, "", 19, "مسئولیت پذیری" },
                    { 111, "", 20, "لنگرگاه فنی" },
                    { 112, "", 20, "لنگرگاه خدمت" },
                    { 113, "", 20, "لنگرگاه استقلال" },
                    { 114, "", 20, "لنگرگاه تنوع" },
                    { 115, "", 20, "لنگرگاه مدیریت" },
                    { 116, "", 20, "لنگرگاه هویت" },
                    { 117, "", 20, "لنگرگاه امنیت" }
                });

            migrationBuilder.InsertData(
                table: "EvaluationItems",
                columns: new[] { "Id", "Description", "MeritItemId", "Title" },
                values: new object[,]
                {
                    { 118, "", 20, "لنگرگاه خلاقیت" },
                    { 119, "", 21, "هنری" },
                    { 120, "", 21, "جستجوگر" },
                    { 121, "", 21, "اجتماعی" },
                    { 122, "", 21, "متهور" },
                    { 123, "", 21, "واقع گرا" },
                    { 124, "", 21, "قرارداری" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "زن" },
                    { 2, "مرد" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "کارشناس برنامه نویسی" });

            migrationBuilder.InsertData(
                table: "MaritalStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "مجرد" },
                    { 2, "متاهل" }
                });

            migrationBuilder.InsertData(
                table: "MeritItems",
                columns: new[] { "Id", "MeritId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "مهارت" },
                    { 2, 1, "دانش" },
                    { 3, 2, "برنامه ریزی و سازماندهی" },
                    { 4, 2, "حل مساله" },
                    { 5, 2, "مهارت های بین فردی" },
                    { 6, 2, "ارتباط موثر" },
                    { 7, 2, "تعهد سازمانی" },
                    { 8, 2, "ثبات هیجانی" },
                    { 9, 2, "سرمایه روانشناختی" },
                    { 10, 2, "ارتقا دانش" },
                    { 11, 2, "هدایت افراد" },
                    { 12, 2, "دانش و فناوری" },
                    { 13, 3, "تحصیلات" },
                    { 14, 3, "سابقه کار مرتبط" },
                    { 15, 3, "سابقه کار نامرتبط" },
                    { 16, 3, "آموزش حرفه ای" },
                    { 17, 4, "نظم و پیگیری" },
                    { 18, 4, "طب کار (ثبت در پرونده پرسنلی )" },
                    { 19, 5, "نئو" },
                    { 20, 5, "لنگرگاه شغلی" },
                    { 21, 5, "استرانگ" }
                });

            migrationBuilder.InsertData(
                table: "Merits",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "تخصصی" },
                    { 2, "عمومی" },
                    { 3, "تجربی" },
                    { 4, "سلامت جسم" },
                    { 5, "نتایج آزمون ها" }
                });

            migrationBuilder.InsertData(
                table: "MilitaryServiceStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "مشمول" },
                    { 2, "معافیت تحصیلی" },
                    { 3, "درحال خدمت" },
                    { 4, "معاف دائم" }
                });

            migrationBuilder.InsertData(
                table: "MilitaryServiceStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[] { 5, "اتمام خدمت" });

            migrationBuilder.InsertData(
                table: "PhysicalInfos",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "قد" },
                    { 2, "وزن" },
                    { 3, "سایز لباس" },
                    { 4, "شلوار" },
                    { 5, "سایز کفش" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeContacts",
                columns: new[] { "Id", "EmployeeId", "Title", "Type", "Value" },
                values: new object[] { 1, new Guid("31bbac2a-2a14-445f-9e37-08b81c1f192f"), "شماره شخصی", 1, "0930" });

            migrationBuilder.InsertData(
                table: "EmployeeEducations",
                columns: new[] { "Id", "Average", "EmployeeId", "LevelId", "MajorId", "Minor" },
                values: new object[] { 1, 16.5, new Guid("31bbac2a-2a14-445f-9e37-08b81c1f192f"), 5, 1, "" });

            migrationBuilder.InsertData(
                table: "EmployeePhysicalInfos",
                columns: new[] { "Id", "EmployeeId", "PhysicalInfoId", "Value" },
                values: new object[] { 1, new Guid("31bbac2a-2a14-445f-9e37-08b81c1f192f"), 1, "186 cm" });

            migrationBuilder.InsertData(
                table: "EmployeeResume",
                columns: new[] { "Id", "Description", "EmployeeId", "FromDate", "Title", "ToDate" },
                values: new object[] { 1, "شاغل در شرکت های : \n سازمان بنادر و کشتیرانی (آسپیان) \nشرکت بابکو \nبیمه ی مرکزی ایران (راهبرد نگار آمیتیس)", new Guid("31bbac2a-2a14-445f-9e37-08b81c1f192f"), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "توسعه دهنده ی دات نت", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "JobEvaluatedItems",
                columns: new[] { "Id", "CriterionScore", "EvaluationItemId", "ImportanceFactor", "JobMDId" },
                values: new object[,]
                {
                    { 1L, 60, 1, 10, 1 },
                    { 2L, 60, 8, 20, 1 },
                    { 3L, 60, 12, 20, 1 },
                    { 4L, 60, 20, 15, 1 },
                    { 5L, 60, 27, 30, 1 },
                    { 6L, 60, 28, 30, 1 },
                    { 7L, 60, 31, 40, 1 },
                    { 8L, 60, 32, 20, 1 },
                    { 9L, 60, 34, 10, 1 },
                    { 10L, 60, 49, 15, 1 },
                    { 11L, 60, 53, 15, 1 },
                    { 12L, 60, 54, 10, 1 },
                    { 13L, 60, 55, 40, 1 },
                    { 14L, 60, 67, 10, 1 },
                    { 15L, 60, 77, 30, 1 },
                    { 16L, 60, 88, 20, 1 },
                    { 17L, 60, 89, 30, 1 },
                    { 18L, 60, 91, 25, 1 },
                    { 19L, 60, 92, 20, 1 },
                    { 20L, 60, 109, 20, 1 },
                    { 21L, 60, 110, 25, 1 },
                    { 22L, 60, 124, 15, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContacts_EmployeeId",
                table: "EmployeeContacts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducations_EmployeeId",
                table: "EmployeeEducations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhysicalInfos_EmployeeId",
                table: "EmployeePhysicalInfos",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeResume_EmployeeId",
                table: "EmployeeResume",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobEvaluatedItems_JobMDId",
                table: "JobEvaluatedItems",
                column: "JobMDId");

            migrationBuilder.CreateIndex(
                name: "IX_MeritAverages_EmployeePerformanceEvaluateId",
                table: "MeritAverages",
                column: "EmployeePerformanceEvaluateId");

            migrationBuilder.CreateIndex(
                name: "IX_MeritItemAverages_EmployeePerformanceEvaluateId",
                table: "MeritItemAverages",
                column: "EmployeePerformanceEvaluateId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceEvaluateItems_EmployeePerformanceEvaluateId",
                table: "PerformanceEvaluateItems",
                column: "EmployeePerformanceEvaluateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "EducationMajors");

            migrationBuilder.DropTable(
                name: "EmployeeContacts");

            migrationBuilder.DropTable(
                name: "EmployeeEducations");

            migrationBuilder.DropTable(
                name: "EmployeePhysicalInfos");

            migrationBuilder.DropTable(
                name: "EmployeeResume");

            migrationBuilder.DropTable(
                name: "EvaluationItems");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "JobEvaluatedItems");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropTable(
                name: "MeritAverages");

            migrationBuilder.DropTable(
                name: "MeritItemAverages");

            migrationBuilder.DropTable(
                name: "MeritItems");

            migrationBuilder.DropTable(
                name: "Merits");

            migrationBuilder.DropTable(
                name: "MilitaryServiceStatuses");

            migrationBuilder.DropTable(
                name: "PerformanceEvaluateItems");

            migrationBuilder.DropTable(
                name: "PhysicalInfos");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "EmployeePerformanceEvaluates");
        }
    }
}
