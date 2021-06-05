using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLayer.Migrations
{
    public partial class StateCityAndEverything : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts_LedgerGroup",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UnderGroup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts_LedgerGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Accounts_Transacation",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GUIDID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts_Transacation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    IsSignUpCompleted = table.Column<bool>(nullable: false),
                    SecondaryPhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MemberStatus = table.Column<bool>(nullable: false),
                    TimeZone = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    BlobURI = table.Column<string>(nullable: true),
                    JobTitleId = table.Column<int>(nullable: true),
                    CompensationTypeId = table.Column<int>(nullable: true),
                    CurrencyTypeId = table.Column<int>(nullable: true),
                    CompensationAmountId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    ContactId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RecieveProductEmails = table.Column<bool>(nullable: false),
                    RecieveNotifications = table.Column<bool>(nullable: false),
                    IsPersonalSettingsCompleted = table.Column<bool>(nullable: false),
                    ProfileCompletion = table.Column<int>(nullable: false),
                    StripeCustomerId = table.Column<string>(nullable: true),
                    PeronalGreeting = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Address2 = table.Column<string>(nullable: true),
                    StateProvinceID = table.Column<int>(nullable: false),
                    ZiPcode = table.Column<string>(nullable: true),
                    PhysicalAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_Country",
                columns: table => new
                {
                    CountryID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_Security_Questions",
                columns: table => new
                {
                    Question_ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Question_Title = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_Security_Questions", x => x.Question_ID);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_Type_Of_Govt_IDs",
                columns: table => new
                {
                    Type_Govt_ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Govt_Id_Type = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_Type_Of_Govt_IDs", x => x.Type_Govt_ID);
                });

            migrationBuilder.CreateTable(
                name: "rc_profile_category",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    OrderBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rc_profile_category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SBI_Features",
                columns: table => new
                {
                    SBI_Features_Key = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SBI_Features_Title = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    SBI_Features_Descriptions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_Features", x => x.SBI_Features_Key);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts_Ledger",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    ChildTransacationID = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    openingBalance = table.Column<double>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ParentLedgerGroupID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts_Ledger", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_Ledger_Accounts_LedgerGroup_ParentLedgerGroupID",
                        column: x => x.ParentLedgerGroupID,
                        principalTable: "Accounts_LedgerGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RC_Profile_BankingDetails",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    BnakName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    BranchCode = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    AccountHolderName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RC_Profile_BankingDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RC_Profile_BankingDetails_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RC_Profile_CardDetails",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    CardHoldername = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<string>(nullable: true),
                    CVVCode = table.Column<string>(nullable: true),
                    BillingAddress = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RC_Profile_CardDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RC_Profile_CardDetails_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RC_Profile_Legal",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PhotoId = table.Column<string>(nullable: true),
                    Country = table.Column<int>(nullable: false),
                    PhotIDNumber = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    SecurityQuestion1 = table.Column<int>(nullable: false),
                    SecurityQuestion2 = table.Column<int>(nullable: false),
                    Answer1 = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Answer2 = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RC_Profile_Legal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RC_Profile_Legal_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SBI_Project",
                columns: table => new
                {
                    SBI_Project_Key = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SBI_Project_ProjectName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    SBI_Project_Description = table.Column<string>(type: "nvarchar(5000)", nullable: true),
                    SBI_Project_owner = table.Column<string>(nullable: true),
                    SBI_Group_Key = table.Column<int>(nullable: false),
                    SBI_Project_CanInviteMoreId = table.Column<int>(nullable: false),
                    SBI_Project_StarDate = table.Column<DateTime>(nullable: false),
                    SBI_Project_EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBI_Project", x => x.SBI_Project_Key);
                    table.ForeignKey(
                        name: "FK_SBI_Project_AspNetUsers_SBI_Project_owner",
                        column: x => x.SBI_Project_owner,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_State",
                columns: table => new
                {
                    StateID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CountryID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_State", x => x.StateID);
                    table.ForeignKey(
                        name: "FK_LookUp_State_LookUp_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "LookUp_Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rc_profile_subcategory",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    OrderBy = table.Column<int>(nullable: false),
                    ParentID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rc_profile_subcategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_rc_profile_subcategory_rc_profile_category_ParentID",
                        column: x => x.ParentID,
                        principalTable: "rc_profile_category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts_childTransaction",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Rate = table.Column<double>(nullable: false),
                    Qty = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    BillID = table.Column<string>(nullable: true),
                    ProviderRefNo = table.Column<string>(nullable: true),
                    ParentTransacatoinID = table.Column<long>(nullable: false),
                    DrLedgerID = table.Column<long>(nullable: false),
                    CrLedgerID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts_childTransaction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_childTransaction_Accounts_Ledger_CrLedgerID",
                        column: x => x.CrLedgerID,
                        principalTable: "Accounts_Ledger",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_childTransaction_Accounts_Ledger_DrLedgerID",
                        column: x => x.DrLedgerID,
                        principalTable: "Accounts_Ledger",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_childTransaction_Accounts_Transacation_ParentTransa~",
                        column: x => x.ParentTransacatoinID,
                        principalTable: "Accounts_Transacation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LookUp_City",
                columns: table => new
                {
                    CityID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    StateID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_LookUp_City_LookUp_State_StateID",
                        column: x => x.StateID,
                        principalTable: "LookUp_State",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RC_Profile_BusinessInfor",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Category = table.Column<long>(nullable: false),
                    SubCategory = table.Column<long>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    LoyaltyMembership = table.Column<string>(nullable: true),
                    GSTNo = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "nvarchar(5000)", nullable: true),
                    BusinessRegCertificateImg = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RC_Profile_BusinessInfor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RC_Profile_BusinessInfor_rc_profile_subcategory_SubCategory",
                        column: x => x.SubCategory,
                        principalTable: "rc_profile_subcategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RC_Profile_BusinessInfor_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_childTransaction_CrLedgerID",
                table: "Accounts_childTransaction",
                column: "CrLedgerID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_childTransaction_DrLedgerID",
                table: "Accounts_childTransaction",
                column: "DrLedgerID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_childTransaction_ParentTransacatoinID",
                table: "Accounts_childTransaction",
                column: "ParentTransacatoinID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Ledger_ParentLedgerGroupID",
                table: "Accounts_Ledger",
                column: "ParentLedgerGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LookUp_City_StateID",
                table: "LookUp_City",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_LookUp_State_CountryID",
                table: "LookUp_State",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_RC_Profile_BankingDetails_UserID",
                table: "RC_Profile_BankingDetails",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RC_Profile_BusinessInfor_SubCategory",
                table: "RC_Profile_BusinessInfor",
                column: "SubCategory");

            migrationBuilder.CreateIndex(
                name: "IX_RC_Profile_BusinessInfor_UserID",
                table: "RC_Profile_BusinessInfor",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RC_Profile_CardDetails_UserID",
                table: "RC_Profile_CardDetails",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RC_Profile_Legal_UserId",
                table: "RC_Profile_Legal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_rc_profile_subcategory_ParentID",
                table: "rc_profile_subcategory",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_SBI_Project_SBI_Project_owner",
                table: "SBI_Project",
                column: "SBI_Project_owner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts_childTransaction");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "LookUp_City");

            migrationBuilder.DropTable(
                name: "LookUp_Security_Questions");

            migrationBuilder.DropTable(
                name: "LookUp_Type_Of_Govt_IDs");

            migrationBuilder.DropTable(
                name: "RC_Profile_BankingDetails");

            migrationBuilder.DropTable(
                name: "RC_Profile_BusinessInfor");

            migrationBuilder.DropTable(
                name: "RC_Profile_CardDetails");

            migrationBuilder.DropTable(
                name: "RC_Profile_Legal");

            migrationBuilder.DropTable(
                name: "SBI_Features");

            migrationBuilder.DropTable(
                name: "SBI_Project");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts_Ledger");

            migrationBuilder.DropTable(
                name: "Accounts_Transacation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "LookUp_State");

            migrationBuilder.DropTable(
                name: "rc_profile_subcategory");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Accounts_LedgerGroup");

            migrationBuilder.DropTable(
                name: "LookUp_Country");

            migrationBuilder.DropTable(
                name: "rc_profile_category");
        }
    }
}
