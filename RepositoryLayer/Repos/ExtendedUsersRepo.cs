
using CommonLayer;
using CommonLayer.DTOs;
using CommonLayer.Helpers;
using CommonLayer.Services.EmailService;
using EntityLayer;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static CommonLayer.Constants;

namespace RepositoryLayer.Repos
{
    public class ExtendedUsersRepo : RepositoryBase<ExtendedUser>, IExtendedUsersRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IProfile_BankingDetailsRepo _BankingDetailsRepo;
        private readonly IProfile_BusinessInforRepo _BusinessInforRepo;
        private readonly IProfile_CardDetailsRepo _CardDetailsRepo;
        private readonly IProfile_LegalRepo _LegalRepo;
        public ExtendedUsersRepo(IServiceProvider serviceProvider,
            IProfile_BusinessInforRepo businessInforRepo,
            IProfile_LegalRepo legalRepo,
            IProfile_CardDetailsRepo cardDetailsRepo,
            IProfile_BankingDetailsRepo bankingDetailsRepo, RechargeDbContext
            context) : base(context)
        {
            _BankingDetailsRepo = bankingDetailsRepo;
            _BusinessInforRepo = businessInforRepo;
            _CardDetailsRepo = cardDetailsRepo;
            _LegalRepo = legalRepo;

            _serviceProvider = serviceProvider;
            //  _mapper = _serviceProvider.GetRequiredService<IMapper>();
            ///  _blobUploader = _serviceProvider.GetRequiredService<IBlobUploader>();
        }

        public async Task<LoginResponseDTO> ProcessLogin(LoginDTO model)
        {
            var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
            var _roleManager = _serviceProvider.GetRequiredService<RoleManager<ExtendedRole>>();
            // var companyRepo = _serviceProvider.GetRequiredService<IUserCompanyRepo>();

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                if (!user.EmailConfirmed)
                {
                    OtherConstants.messageType = MessageType.Error;
                    OtherConstants.isSuccessful = false;
                    OtherConstants.responseMsg = "Email not verified";
                    return null;
                }

                if (!user.MemberStatus)
                {
                    OtherConstants.messageType = MessageType.Error;
                    OtherConstants.isSuccessful = false;
                    OtherConstants.responseMsg = "User status is not active";
                    return null;
                }
                var userRoles = await _userManager.GetRolesAsync(user);
                var signIn = await _serviceProvider.GetRequiredService<SignInManager<ExtendedUser>>().PasswordSignInAsync(user, model.Password, true, true);
                if (signIn.Succeeded)
                {
                    var _tokenService = _serviceProvider.GetRequiredService<ITokenService>();
                    var _loginRepo = _serviceProvider.GetRequiredService<ILoginsRepo>();

                    var claims = new List<Claim>()
                    {
                        new Claim("UserId", user.Id),
                        new Claim("UserName",user.UserName),
                      //  new Claim("TenantId", user.TenantId.ToString()),
                        new Claim("Role", userRoles.FirstOrDefault())
                    };
                    var role = await _roleManager.FindByNameAsync(userRoles.FirstOrDefault());
                    var claimsList = await _roleManager.GetClaimsAsync(role);
                    claims.AddRange(claimsList.ToList());

                    foreach (var item in userRoles)
                        claims.Add(new Claim(ClaimTypes.Role, item));

                    var accessToken = _tokenService.GenerateAccessToken(claims);
                    var refreshToken = _tokenService.GenerateRefreshToken();

                    await _loginRepo.Post(new Login()
                    {
                        RefreshToken = refreshToken,
                        RefreshTokenExpiryTime = DateTime.Now.AddDays(10),
                        UserId = user.Id,
                        CreatedBy = user.Id,
                        TenantId = user.TenantId
                    }, true);
                    int daysLeft = 0;


                    UserDTO userModel;

                    if (daysLeft >= 0)
                    {
                        userModel = CreateUserModel(user, role.Name);
                        OtherConstants.isSuccessful = true;
                    }
                    else
                    {
                        userModel = CreateUserModel(user, role.Name);
                        OtherConstants.messageType = MessageType.Error;
                        OtherConstants.isSuccessful = true;
                        OtherConstants.responseMsg = "Free trial time period expired!";
                    }

                    return new LoginResponseDTO()
                    {
                        AccessToken = accessToken,
                        RefreshToken = refreshToken,
                        AccountDetails = userModel
                    };
                }
                else if (signIn.IsLockedOut)
                {
                    OtherConstants.messageType = MessageType.Error;
                    OtherConstants.isSuccessful = false;
                    OtherConstants.responseMsg = "Too many invalid attempts! Account locked out for 5 minutes";
                    return null;
                }
                else
                {
                    OtherConstants.messageType = MessageType.Error;
                    OtherConstants.isSuccessful = false;
                    OtherConstants.responseMsg = "Invalid username or password!";
                    return null;
                }
            }
            else
            {
                OtherConstants.messageType = MessageType.Error;
                OtherConstants.isSuccessful = false;
                OtherConstants.responseMsg = "Invalid username or password!";
                return null;
            }
        }

        public bool Logout()
        {
            var context = _serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
            var _loginRepo = _serviceProvider.GetRequiredService<ILoginsRepo>();
            var loginDetail = _loginRepo.Get().IgnoreQueryFilters().Where(p => p.RefreshToken == context.Request.Headers["RefreshToken"].ToString()).FirstOrDefault();
            loginDetail.IsDeleted = true;
            loginDetail.ModifiedBy = Utils.GetUserId(_serviceProvider);
            _loginRepo.Put(loginDetail);
            OtherConstants.isSuccessful = true;
            return OtherConstants.isSuccessful;
        }

        public async Task<ResponseDTO<UserDTO>> GetUserDetails()
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
            var user = await userManager.FindByIdAsync(Utils.GetUserId(_serviceProvider));

            var role = Utils.GetRole(_serviceProvider);


            var model = CreateUserModel(user, role);

            OtherConstants.isSuccessful = true;
            return new ResponseDTO<UserDTO>() { dynamicResult = model };
        }

        public List<ExtendedUser> GetUsers()
        {
            return _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>().Users.ToList();
        }
        public async Task<bool> Register(RegisterDTO model)
        {
            var usersList = _BankingDetailsRepo.Get().ToList();

            var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
            var usr = await _userManager.FindByEmailAsync(model.Email);
            ExtendedUser newUser = new ExtendedUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                MemberStatus = true,
                TenantId = "1",
                EmailConfirmed = true ////////////// to be removed if Email confirmation required in future
            };
            newUser.PasswordHash = _userManager.PasswordHasher.HashPassword(newUser, model.Password);

            var resonser = await _userManager.CreateAsync(newUser);

            // var role = await _userManager.GetRolesAsync(user);
            // await _userManager.RemoveFromRolesAsync(user, role);
            await _userManager.AddToRoleAsync(newUser, model.role);

            if (resonser.Succeeded)
            {
                OtherConstants.isSuccessful = true;
                var currentUser = newUser;

                var entity = new RC_Profile_BankingDetails()
                {
                    BnakName = "",
                    BranchCode = "",
                    IsDeleted = false,
                    AccountNumber = "",
                    AccountHolderName = "",
                    UserID = currentUser.Id,
                    CreatedBy = currentUser.Id,
                    CreatedDate = DateTime.Now,
                };
                await _BankingDetailsRepo.PostInitial(entity);

                var Legal_entity = new RC_Profile_Legal()
                {
                    Country = 0,
                    PhotoId = "",
                    Answer1 = "",
                    Answer2 = "",
                    ImageURL = "",
                    PhotIDNumber = "",
                    IsDeleted = false,
                    User = currentUser,
                    SecurityQuestion1 = "",
                    SecurityQuestion2 = "",
                    CreatedDate = DateTime.Now,
                    CreatedBy = currentUser.Id
                };

                await _LegalRepo.PostInitial(Legal_entity);

                var BusinessInfo_entity = new RC_Profile_BusinessInfor()
                {
                    Description = "",
                    CreatedDate = DateTime.Now,
                    CreatedBy = currentUser.Id,
                    IsDeleted = false,
                    UserID = currentUser.Id,
                    GSTNo = "",
                    BusinessName = "",
                    BusinessRegCertificateImg = "",
                    Logo = "",
                    Category = 1,
                    SubCategory = 1,
                    Website = "",
                    LoyaltyMembership = "",
                };
                await _BusinessInforRepo.PostInitial(BusinessInfo_entity);



            }
            else
            {
                OtherConstants.isSuccessful = false;
            }
            return OtherConstants.isSuccessful;
        }

        public async Task<bool> RegisterOld(RegisterDTO model)
        {

            var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
            var usr = await _userManager.FindByEmailAsync(model.Email);
            ExtendedUser newUser = new ExtendedUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                MemberStatus = true,
                TenantId = "1",
                EmailConfirmed = true ////////////// to be removed if Email confirmation required in future
            };
            newUser.PasswordHash = _userManager.PasswordHasher.HashPassword(newUser, model.Password);

            var resonser = await _userManager.CreateAsync(newUser);
            // var role = await _userManager.GetRolesAsync(user);
            // await _userManager.RemoveFromRolesAsync(user, role);
            await _userManager.AddToRoleAsync(newUser, model.role);
            if (resonser.Succeeded)
            {
                OtherConstants.isSuccessful = true;

            }
            else
            {
                OtherConstants.isSuccessful = false;
            }
            return OtherConstants.isSuccessful;
        }

        private UserDTO CreateUserModel(ExtendedUser user, string role)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = $"{user.FirstName}",
                LastName = $"{user.LastName}",
                Role = role,
                ProfileCompletion = user.ProfileCompletion,
                ImageURL = user.BlobURI
            };
        }

        public List<ExtendedRole> GetRoles()
        {
            return _serviceProvider.GetRequiredService<RoleManager<ExtendedRole>>().Roles.ToList();
        }

        public async Task<bool> ResetPasswordWithToken(ResetPasswordDTO model)
        {
            var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null && !string.IsNullOrWhiteSpace(model.Token))
            {
                model.Token = model.Token.Replace(" ", "+");
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    OtherConstants.responseMsg = "Password Updated Successfully.";
                    OtherConstants.isSuccessful = true;
                }
                else
                {
                    OtherConstants.responseMsg = "Password Reset token expired.";
                    OtherConstants.isSuccessful = false;
                }
            }
            else
            {
                OtherConstants.responseMsg = "Email not found.";
                OtherConstants.isSuccessful = false;
            }

            return OtherConstants.isSuccessful;
        }



        public async Task<bool> ResetPassword(ResetPasswordDTO model)
        {
            var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();

            var user = await _userManager.FindByIdAsync(Utils.GetUserId(_serviceProvider));

            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    //if (model.EnableTwoStepVerification)
                    //{
                    //    user.TwoFactorEnabled = model.EnableTwoStepVerification;
                    //    var res = await _userManager.UpdateAsync(user);
                    //    if (res.Succeeded)
                    //        OtherConstants.isSuccessful = true;
                    //    else
                    //        OtherConstants.isSuccessful = false;
                    //}
                    //else
                    //{
                    OtherConstants.isSuccessful = true;
                    //}
                }
                else
                {
                    OtherConstants.responseMsg = result.Errors.FirstOrDefault().Description;
                    OtherConstants.isSuccessful = false;
                }
            }
            else
            {
                OtherConstants.isSuccessful = false;
            }
            return OtherConstants.isSuccessful;
        }
        public async Task<bool> GenerateForgotPasswordToken(string email)
        {
            var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var url = (currentRoles.Contains("Admin") ? DomainConfiguration.SuperAdminAppDomain : DomainConfiguration.PortalAppDomain) + $"#/auth/new-password?userid={user.Id}&token={token}";
                var body = CreateEmailTemplate(url, EmailTemplateConfiguration.ResetEmailDescription, EmailTemplateConfiguration.ResetEmailButtonTitle, EmailTemplateConfiguration.ResetEmailMessage, EmailTemplateConfiguration.ResetEmailAddress);

                var isEmailSent = _serviceProvider.GetRequiredService<IEmailService>().SendEmailWithoutTemplate(user.Email, "Reset Password", body, true);
                if (isEmailSent)
                    OtherConstants.isSuccessful = true;
                else
                    OtherConstants.isSuccessful = false;
            }
            else
                OtherConstants.isSuccessful = false;

            return OtherConstants.isSuccessful;
        }

        public async Task<bool> InvitationToJoinProject(string email)
        {
            var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                var url = DomainConfiguration.PortalAppDomain + $"#/auth/registration";
                var body = CreateEmailTemplateForInivitationToApply(url, EmailTemplateConfiguration.ResetEmailDescription, EmailTemplateConfiguration.ResetEmailButtonTitle, EmailTemplateConfiguration.ResetEmailMessage, EmailTemplateConfiguration.ResetEmailAddress);

                var isEmailSent = _serviceProvider.GetRequiredService<IEmailService>().SendEmailWithoutTemplate(email, "Invitation to Apply", body, true);
                if (isEmailSent)
                    OtherConstants.isSuccessful = true;
                else
                    OtherConstants.isSuccessful = false;
            }
            else
                OtherConstants.isSuccessful = false;

            return OtherConstants.isSuccessful;
        }


        #region stages

        public async Task<bool> Stage2BusinessPost(SignUPStage2BusinessDTO model)
        {


            return false;
        }
        public async Task<bool> Stage2PersonalPost(SignUPStage2PersonalDTO model)
        {
            return false;
        }
        public async Task<bool> Stage2PartnerPost(SignUPStage2PartnerDTO model)
        {
            return false;
        }
        public async Task<bool> Stage3Post(signUpstage3DTO model)
        {
            return false;
        }
        public async Task<bool> Stage4Post(signUpstage4DTO model)
        {
            return false;
        }

        public async Task<bool> Stage5BusinessPost(SignUPStage5BusinessDTO model)
        {
            return false;
        }
        public async Task<bool> Stage5PersonalPost(SignUPStage5PersonalDTO model)
        {
            return false;
        }
        public async Task<bool> Stage5PartnerPost(SignUPStage5PartnerDTO model)
        {
            return false;
        }
        #endregion



        //public async Task<List<TeamMemberDTO>> GetUsersForCurrentTenant()
        //{
        //    var _roleManager = _serviceProvider.GetRequiredService<RoleManager<ExtendedRole>>();
        //    var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //    var _loginRepo = _serviceProvider.GetRequiredService<ILoginsRepo>();
        //    var users = _userManager.Users.Where(x => x.TenantId == Utils.GetTenantId(_serviceProvider)).Include(x => x.Citites.State.Country).ToList();
        //    var mappedTeamMember = _mapper.Map<List<TeamMemberDTO>>(users);
        //    var loginDetails = _loginRepo.Get().IgnoreQueryFilters().OrderByDescending(p => p.CreatedDate);
        //    foreach (var item in users.Select((value, i) => new { i, value }))
        //    {
        //        var lastloginDetail = loginDetails.Where(p => p.UserId == item.value.Id);
        //        var userRoles = await _userManager.GetRolesAsync(item.value);
        //        var role = userRoles.FirstOrDefault();
        //        mappedTeamMember[item.i].Role = role;
        //        if (lastloginDetail.Any())
        //            mappedTeamMember[item.i].LastLoggedIn = lastloginDetail.FirstOrDefault().CreatedDate;
        //    }
        //    return mappedTeamMember;
        //}

        //    public async Task<bool> UpdateUser(UpdateUserDTO model)
        //    {
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var user = await _userManager.FindByIdAsync(Utils.GetUserId(_serviceProvider));
        //        if (user != null)
        //        {
        //            user.Email = model.Email;
        //            user.FirstName = model.FirstName;
        //            user.LastName = model.LastName;

        //            if (model.File != null)
        //            {
        //                BlobUploadDTO blobRes = new BlobUploadDTO();
        //                var uniqueFileName = Utils.GetUniqueFileName(model.File.FileName);
        //                using (var ms = new MemoryStream())
        //                {
        //                    model.File.CopyTo(ms);
        //                    var fileBytes = ms.ToArray();
        //                    blobRes = await _blobUploader.UploadFileToBlobAsync(uniqueFileName, fileBytes, Blob.ImagesContainerName);
        //                }
        //                user.ImageName = blobRes.BlobFileName;
        //                user.BlobURI = blobRes.BlobURI;
        //            }

        //            var result = await _userManager.UpdateAsync(user);
        //            if (result.Succeeded)
        //                OtherConstants.isSuccessful = true;
        //            else
        //                OtherConstants.isSuccessful = false;
        //        }
        //        else
        //        {
        //            OtherConstants.isSuccessful = false;
        //        }

        //        return OtherConstants.isSuccessful;
        //    }

        //public async Task<bool> Register(RegisterDTO model)
        //{
        //    var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //    var usr = await _userManager.FindByEmailAsync(model.Email);
        //    if (usr != null)
        //    {
        //        var result = await _userManager.AddPasswordAsync(usr, model.Password);
        //    if (result.Succeeded)
        //    {
        //        var guid = Guid.NewGuid().ToString();

        //        ///////////// project ETC         
        //        OtherConstants.isSuccessful = true;
        //    }
        //    else {
        //        OtherConstants.isSuccessful = false;
        //    }
        //}
        //else
        //{
        //    OtherConstants.isSuccessful = false;
        //}
        //    return OtherConstants.isSuccessful;
        // }


        //    public async Task<bool> CheckIsEmailExist(string Email, bool isFromAdmin = false)
        //    {
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var user = await _userManager.FindByEmailAsync(Email);
        //        if (user == null)
        //            OtherConstants.isSuccessful = true;
        //        else
        //        {
        //            var roles = await _userManager.GetRolesAsync(user);
        //            if (roles.Contains(Roles.Admin))
        //            {
        //                if (user.Email.ToLower() == Email.ToLower() && isFromAdmin)
        //                    OtherConstants.isSuccessful = true;
        //                else
        //                    OtherConstants.isSuccessful = false;
        //            }
        //            else
        //                OtherConstants.isSuccessful = false;
        //        }

        //        return OtherConstants.isSuccessful;
        //    }

        //    public async Task<bool> CheckIsUserEligibleForNewPswd(string userId)
        //    {
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var user = await _userManager.FindByIdAsync(userId);
        //        if (user != null)
        //        {
        //            if (user.MemberStatus)
        //            {
        //                if (user.EmailConfirmed == false && user.IsSignUpCompleted == false)
        //                {
        //                    OtherConstants.isSuccessful = true;
        //                }
        //                else
        //                {
        //                    OtherConstants.isSuccessful = false;
        //                    OtherConstants.responseMsg = "Password is already created.";
        //                }
        //            }
        //            else
        //            {
        //                OtherConstants.isSuccessful = false;
        //                OtherConstants.responseMsg = "User status is not active";
        //            }
        //        }
        //        else
        //        {
        //            OtherConstants.isSuccessful = false;
        //            OtherConstants.responseMsg = "User not found.";
        //        }
        //        return OtherConstants.isSuccessful;
        //    }

        //    public async Task<RegisterDTO> VerifyEmail(string userId, string token, string planId)
        //    {
        //        var model = new RegisterDTO();
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var user = await _userManager.FindByIdAsync(userId);
        //        if (user != null && !string.IsNullOrWhiteSpace(token))
        //        {
        //            if (user.EmailConfirmed)
        //            {
        //                if (user.IsSignUpCompleted)
        //                    model.IsSignupCompleted = true;
        //                model.IsEmailVerified = true;
        //                model.Email = user.Email;
        //                OtherConstants.responseMsg = "Email verified successfully.";
        //                OtherConstants.isSuccessful = true;
        //            }
        //            else if (user.IsSignUpCompleted)
        //            {
        //                model.IsEmailVerified = true;
        //                model.IsSignupCompleted = true;
        //                OtherConstants.isSuccessful = false;
        //            }
        //            else
        //            {
        //                token = token.Replace(" ", "+");
        //                var result = await _userManager.ConfirmEmailAsync(user, token);
        //                if (result.Succeeded)
        //                {
        //                    model.IsEmailVerified = true;
        //                    model.IsSignupCompleted = false;
        //                    model.PlanId = planId;
        //                    model.UserId = userId;
        //                    model.Email = user.Email;
        //                    OtherConstants.responseMsg = "Email verified successfully.";
        //                    OtherConstants.isSuccessful = true;
        //                }
        //                else
        //                {
        //                    OtherConstants.responseMsg = "Error while verification of email";
        //                    OtherConstants.isSuccessful = false;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            OtherConstants.responseMsg = "Error while verification of email";
        //            OtherConstants.isSuccessful = false;
        //        }

        //        return model;
        //    }




        //    public async Task<bool> CreateNewPassword(ResetPasswordDTO model)
        //    {
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var user = await _userManager.FindByIdAsync(model.UserId);
        //        if (user != null)
        //        {
        //            if (user.IsSignUpCompleted == false && user.EmailConfirmed == false && user.MemberStatus)
        //            {
        //                var result = await _userManager.AddPasswordAsync(user, model.NewPassword);
        //                if (result.Succeeded)
        //                {
        //                    user.IsSignUpCompleted = true;
        //                    user.EmailConfirmed = true;
        //                    var res = await _userManager.UpdateAsync(user);
        //                    if (res.Succeeded)
        //                    {
        //                        OtherConstants.responseMsg = "Password Created Successfully.";
        //                        OtherConstants.isSuccessful = true;
        //                    }
        //                    else
        //                    {
        //                        OtherConstants.responseMsg = "Password Creation Failed.";
        //                        OtherConstants.isSuccessful = false;
        //                    }
        //                }
        //                else
        //                {
        //                    OtherConstants.responseMsg = "Password Creation Failed.";
        //                    OtherConstants.isSuccessful = false;
        //                }
        //            }
        //            else
        //            {
        //                OtherConstants.responseMsg = "Password is already created.";
        //                if (!user.MemberStatus)
        //                {
        //                    OtherConstants.responseMsg = "User status is not active.";
        //                }
        //                OtherConstants.isSuccessful = false;
        //            }
        //        }
        //        else
        //        {
        //            OtherConstants.responseMsg = "User not found.";
        //            OtherConstants.isSuccessful = false;
        //        }

        //        return OtherConstants.isSuccessful;
        //    }

        //    public async Task<bool> ResendEmailConfirmationTokenMail(RegisterDTO model)
        //    {
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var user = await _userManager.FindByIdAsync(model.UserId);
        //        if (user != null)
        //        {
        //            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //            var url = $"{DomainConfiguration.PortalAppDomain}#/signup/create-account?userid={user.Id}&token={token}&planid={model.PlanId}";
        //            var body = CreateEmailTemplate(url, EmailTemplateConfiguration.VerifyEmailDescription, EmailTemplateConfiguration.VerifyEmailButtonTitle, EmailTemplateConfiguration.VerifyEmailMessage, EmailTemplateConfiguration.VerifyEmailAddress);
        //            if (!string.IsNullOrWhiteSpace(body))
        //            {
        //                var isEmailSent = _serviceProvider.GetRequiredService<IEmailService>().SendEmailWithoutTemplate(user.Email, "Verify Email", body, true);
        //                if (isEmailSent)
        //                    OtherConstants.isSuccessful = true;
        //                else
        //                    OtherConstants.isSuccessful = false;
        //            }
        //            else
        //                OtherConstants.isSuccessful = false;
        //        }
        //        return OtherConstants.isSuccessful;
        //    }

        //    public async Task<RegisterDTO> RegisterUsingEmail(RegisterDTO model)
        //    {
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var user = new ExtendedUser()
        //        {
        //            Email = model.Email,
        //            UserName = model.Email,
        //            FirstName = "",
        //            LastName = "",
        //            EmailConfirmed = false,
        //            MemberStatus = true
        //        };

        //        var result = await _userManager.CreateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            user = await _userManager.FindByEmailAsync(model.Email);
        //            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //            var url = $"{DomainConfiguration.PortalAppDomain}#/signup/create-account?userid={user.Id}&token={token}&planid={model.PlanId}";
        //            var body = CreateEmailTemplate(url, EmailTemplateConfiguration.VerifyEmailDescription, EmailTemplateConfiguration.VerifyEmailButtonTitle, EmailTemplateConfiguration.VerifyEmailMessage, EmailTemplateConfiguration.VerifyEmailAddress);
        //            if (!string.IsNullOrWhiteSpace(body))
        //            {
        //                var isEmailSent = _serviceProvider.GetRequiredService<IEmailService>().SendEmailWithoutTemplate(user.Email, "Verify Email", body, true);
        //                if (isEmailSent)
        //                    OtherConstants.isSuccessful = true;
        //                else
        //                    OtherConstants.isSuccessful = false;
        //            }
        //            else
        //                OtherConstants.isSuccessful = false;
        //        }
        //        else
        //            OtherConstants.isSuccessful = false;

        //        return new RegisterDTO()
        //        {
        //            PlanId = model.PlanId,
        //            UserId = user.Id
        //        };
        //    }

        //    public bool VerifyUserAndPlan(string userId, string planId)
        //    {
        //        var isPlanAvailable = _serviceProvider.GetRequiredService<ISubscriptionPlansRepo>().GetWithCondition(p => p.SubscriptionPlanKey == planId).Count() > 0;
        //        var isUserAvailable = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>().FindByIdAsync(userId).Result != null;
        //        if (isPlanAvailable && isUserAvailable)
        //            OtherConstants.isSuccessful = true;
        //        else
        //            OtherConstants.isSuccessful = false;

        //        return OtherConstants.isSuccessful;
        //    }

        //    public async Task<bool> UpgradePlan(UpgradePlanDTO model)
        //    {
        //        var stripeRepo = _serviceProvider.GetRequiredService<IStripeConfigurationRepo>();
        //        var _stripeService = _serviceProvider.GetRequiredService<IStripeService>();
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var orderRepo = _serviceProvider.GetRequiredService<IOrdersRepo>();
        //        var company = await _serviceProvider.GetRequiredService<ICompanyRepo>().Get()
        //            .Include(p => p.SubscriptionPlan.BillingPlan).FirstOrDefaultAsync(p => p.CompanyGUID == Utils.GetTenantId(_serviceProvider));
        //        SubscriptionPlans plan;
        //        if (model.PlanId == company.SubscriptionPlan.Id)
        //            plan = company.SubscriptionPlan;
        //        else
        //            plan = await _serviceProvider.GetRequiredService<ISubscriptionPlansRepo>().Get().Include(p => p.BillingPlan).FirstOrDefaultAsync(p => p.Id == model.PlanId);
        //        var user = await _userManager.FindByIdAsync(Utils.GetUserId(_serviceProvider));
        //        var stripeSecretKey = stripeRepo.GetStripeSecretKey();
        //        string customerId = null;

        //        if (string.IsNullOrWhiteSpace(user.StripeCustomerId))
        //            customerId = CreateStripeCustomer(model, _stripeService, user, stripeSecretKey);
        //        else
        //            customerId = user.StripeCustomerId;

        //        if (!string.IsNullOrWhiteSpace(customerId))
        //        {
        //            var subscription = CreateSubscription(model, plan, _stripeService, stripeSecretKey, customerId);
        //            if (subscription != null)
        //            {
        //                var invoice = _stripeService.GetInvoice(subscription.LatestInvoiceId, stripeSecretKey);
        //                var oldOrders = orderRepo.Get().Where(p => p.CompanyId == company.Id).ToList();
        //                foreach (var item in oldOrders)
        //                    item.IsDeleted = true;
        //                orderRepo.UpdateRange(oldOrders);
        //                DateTime? recurringDate = null;
        //                if (plan.IsRecurring)
        //                    recurringDate = subscription.CurrentPeriodEnd;
        //                user.StripeCustomerId = customerId;
        //                await _userManager.UpdateAsync(user);
        //                await PostOrder(model, orderRepo, company, plan, subscription, recurringDate);
        //                await PostPaymentHistory(model, company, plan, _stripeService, stripeSecretKey, subscription, invoice, recurringDate);
        //                OtherConstants.isSuccessful = true;
        //            }
        //        }
        //        return OtherConstants.isSuccessful;
        //    }

        //    public bool CancelSubscription(int id)
        //    {
        //        var _stripeService = _serviceProvider.GetRequiredService<IStripeService>();
        //        var orderRepo = _serviceProvider.GetRequiredService<IOrdersRepo>();
        //        var order = orderRepo.Get().Where(p => p.CompanyGUID == Utils.GetTenantId(_serviceProvider) && p.SubscriptionPlanId == id).FirstOrDefault();

        //        if (_stripeService.CancelSubscription(order.StripeSubscriptionId, _serviceProvider.GetRequiredService<IStripeConfigurationRepo>().GetStripeSecretKey()))
        //        {
        //            order.IsDeleted = true;
        //            orderRepo.Put(order, true);
        //            OtherConstants.isSuccessful = true;
        //        }

        //        return OtherConstants.isSuccessful;
        //    }

        //    public async Task<bool> CreateTeamMember(TeamMemberDTO model)
        //    {
        //        BlobUploadDTO blobRes = new BlobUploadDTO();
        //        if (model.File != null)
        //        {
        //            var uniqueFileName = Utils.GetUniqueFileName(model.File.FileName);
        //            using (var ms = new MemoryStream())
        //            {
        //                model.File.CopyTo(ms);
        //                var fileBytes = ms.ToArray();
        //                blobRes = await _blobUploader.UploadFileToBlobAsync(uniqueFileName, fileBytes, Blob.ImagesContainerName);
        //            }
        //            model.ImageName = blobRes.BlobFileName;
        //            model.BlobURI = blobRes.BlobURI;
        //        }
        //        if (model.Id != "" && model.Id != null)
        //        {
        //            await Update(model);
        //        }
        //        else
        //        {
        //            await Post(model);
        //        }
        //        return OtherConstants.isSuccessful;
        //    }

        //    public async Task Update(TeamMemberDTO model)
        //    {
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var user = await _userManager.FindByIdAsync(model.Id);
        //        user.FirstName = model.FirstName;
        //        user.LastName = model.LastName;
        //        user.Email = model.Email;
        //        user.UserName = model.Email;
        //        user.TenantId = Utils.GetTenantId(_serviceProvider);
        //        if (model.BlobURI != null)
        //        {
        //            user.ImageName = model.ImageName;
        //            user.BlobURI = model.BlobURI;
        //        }
        //        user.TimeZone = model.TimeZone;
        //        user.JobTitleId = model.JobTitleId;
        //        user.CompensationTypeId = model.CompensationTypeId;
        //        user.CurrencyTypeId = model.CurrencyTypeId;
        //        user.CompensationAmountId = model.CompensationAmountId;
        //        user.CityId = model.CityId;
        //        user.PhoneNumber = model.PhoneNumber;
        //        user.SecondaryPhoneNumber = model.SecondaryPhoneNumber;
        //        user.Address = model.Address;
        //        user.MemberStatus = model.MemberStatus;
        //        var result = await _userManager.UpdateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            var role = await _userManager.GetRolesAsync(user);
        //            await _userManager.RemoveFromRolesAsync(user, role);
        //            await _userManager.AddToRoleAsync(user, model.Role);
        //            user = await _userManager.FindByEmailAsync(model.Email);
        //            var url = $"{DomainConfiguration.PortalAppDomain}#/auth/new-password?userid={user.Id}";
        //            var body = CreateEmailTemplate(url, EmailTemplateConfiguration.VerifyEmailDescription, EmailTemplateConfiguration.VerifyEmailButtonTitle, EmailTemplateConfiguration.VerifyEmailMessage, EmailTemplateConfiguration.VerifyEmailAddress);
        //            if (!string.IsNullOrWhiteSpace(body))
        //            {
        //                if (user.MemberStatus && !user.EmailConfirmed && !user.IsSignUpCompleted)
        //                {
        //                    var isEmailSent = _serviceProvider.GetRequiredService<IEmailService>().SendEmailWithoutTemplate(user.Email, "Verify Email", body, true);
        //                    if (isEmailSent)
        //                        OtherConstants.isSuccessful = true;
        //                    else
        //                        OtherConstants.isSuccessful = false;
        //                }
        //                else
        //                    OtherConstants.isSuccessful = true;
        //            }
        //            else
        //                OtherConstants.isSuccessful = false;
        //        }
        //        else
        //            OtherConstants.isSuccessful = false;
        //    }

        //    public async Task Post(TeamMemberDTO model)
        //    {
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var user = new ExtendedUser();
        //        user.FirstName = model.FirstName;
        //        user.LastName = model.LastName;
        //        user.Email = model.Email;
        //        user.UserName = model.Email;
        //        user.TenantId = Utils.GetTenantId(_serviceProvider);
        //        user.ImageName = model.ImageName;
        //        user.BlobURI = model.BlobURI;
        //        user.TimeZone = model.TimeZone;
        //        user.JobTitleId = model.JobTitleId;
        //        user.CompensationTypeId = model.CompensationTypeId;
        //        user.CurrencyTypeId = model.CurrencyTypeId;
        //        user.CompensationAmountId = model.CompensationAmountId;
        //        user.CityId = model.CityId;
        //        user.PhoneNumber = model.PhoneNumber;
        //        user.SecondaryPhoneNumber = model.SecondaryPhoneNumber;
        //        user.Address = model.Address;
        //        user.MemberStatus = model.MemberStatus;
        //        user.ProfileCompletion = 20;
        //        var result = await _userManager.CreateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            await _userManager.AddToRoleAsync(user, model.Role);
        //            user = await _userManager.FindByEmailAsync(model.Email);
        //            var url = $"{DomainConfiguration.PortalAppDomain}#/auth/new-password?userid={user.Id}";
        //            var body = CreateEmailTemplate(url, EmailTemplateConfiguration.VerifyEmailDescription, EmailTemplateConfiguration.VerifyEmailButtonTitle, EmailTemplateConfiguration.VerifyEmailMessage, EmailTemplateConfiguration.VerifyEmailAddress);
        //            if (!string.IsNullOrWhiteSpace(body))
        //            {
        //                if (user.MemberStatus)
        //                {
        //                    var isEmailSent = _serviceProvider.GetRequiredService<IEmailService>().SendEmailWithoutTemplate(user.Email, "Verify Email", body, true);
        //                    if (isEmailSent)
        //                        OtherConstants.isSuccessful = true;
        //                    else
        //                        OtherConstants.isSuccessful = false;
        //                }
        //                else
        //                    OtherConstants.isSuccessful = true;
        //            }
        //            else
        //                OtherConstants.isSuccessful = false;
        //        }
        //        else
        //            OtherConstants.isSuccessful = false;
        //    }

        //    public async Task<bool> SoftDelete(string id)
        //    {
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var user = await _userManager.FindByIdAsync(id);
        //        user.IsDeleted = true;
        //        await _userManager.UpdateAsync(user);
        //        OtherConstants.isSuccessful = true;
        //        return true;
        //    }

        //    public async Task<UserPersonalSettingsDTO> GetUserPersonalSettings()
        //    {
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var user = await _userManager.FindByIdAsync(Utils.GetUserId(_serviceProvider));
        //        return _mapper.Map<UserPersonalSettingsDTO>(user);
        //    }

        //    public async Task<bool> UpdateUserPersonalSettings(UserPersonalSettingsDTO model)
        //    {
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var user = await _userManager.FindByIdAsync(Utils.GetUserId(_serviceProvider));
        //        BlobUploadDTO blobRes = new BlobUploadDTO();
        //        if (model.File != null)
        //        {
        //            var uniqueFileName = Utils.GetUniqueFileName(model.File.FileName);
        //            using (var ms = new MemoryStream())
        //            {
        //                model.File.CopyTo(ms);
        //                var fileBytes = ms.ToArray();
        //                blobRes = await _blobUploader.UploadFileToBlobAsync(uniqueFileName, fileBytes, Blob.ImagesContainerName);
        //            }
        //            user.ImageName = blobRes.BlobFileName;
        //            user.BlobURI = blobRes.BlobURI;
        //        }

        //        user.FirstName = model.FirstName.Trim();
        //        user.LastName = model.LastName.Trim();
        //        user.RecieveNotifications = model.RecieveNotifications;
        //        user.RecieveProductEmails = model.RecieveProductEmails;
        //        user.Email = model.Email;
        //        user.UserName = model.Email;
        //        user.JobTitleId = model.JobTitleId == 0 ? null : model.JobTitleId;
        //        user.PhoneNumber = model.PhoneNo;
        //        user.TimeZone = model.TimeZone;
        //        user.ProfileCompletion = user.IsPersonalSettingsCompleted ? user.ProfileCompletion : user.ProfileCompletion + 20;
        //        user.IsPersonalSettingsCompleted = true;
        //        var result = await _userManager.UpdateAsync(user);
        //        if (result.Succeeded)
        //            OtherConstants.isSuccessful = true;
        //        else
        //            OtherConstants.isSuccessful = false;

        //        return OtherConstants.isSuccessful;
        //    }

        //    public async Task<bool> UpdateBillingDetails(string newSource)
        //    {
        //        var stripeRepo = _serviceProvider.GetRequiredService<IStripeConfigurationRepo>();
        //        var _stripeService = _serviceProvider.GetRequiredService<IStripeService>();
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var company = await _serviceProvider.GetRequiredService<ICompanyRepo>().Get()
        //            .Include(p => p.SubscriptionPlan.BillingPlan).FirstOrDefaultAsync(p => p.CompanyGUID == Utils.GetTenantId(_serviceProvider));
        //        var user = await _userManager.FindByIdAsync(Utils.GetUserId(_serviceProvider));
        //        var stripeSecretKey = stripeRepo.GetStripeSecretKey();
        //        string customerId = null;
        //        if (string.IsNullOrWhiteSpace(user.StripeCustomerId))
        //        {
        //            customerId = _stripeService.CreateCustomer(new CreateCustomerDTO()
        //            {
        //                StripeSecretKey = stripeSecretKey,
        //                FirstName = user.FirstName,
        //                LastName = user.LastName,
        //                Email = user.Email,
        //                Phone = user.PhoneNumber,
        //                StripePaymentToken = newSource
        //            });
        //            user.StripeCustomerId = customerId;
        //            await _userManager.UpdateAsync(user);
        //            OtherConstants.isSuccessful = true;
        //        }
        //        else
        //        {
        //            var response = _stripeService.UpdateBillingDetailOfCustomer(new UpdateCustomerDTO()
        //            {
        //                CustomerId = user.StripeCustomerId,
        //                StripeSecretKey = stripeSecretKey,
        //                FirstName = user.FirstName,
        //                LastName = user.LastName,
        //                Email = user.Email,
        //                Phone = user.PhoneNumber,
        //                StripePaymentToken = newSource
        //            });
        //            OtherConstants.isSuccessful = response;
        //        }

        //        return OtherConstants.isSuccessful;
        //    }

        //    public async Task<Stripe.Card> GetUserCardDetails()
        //    {
        //        var _userManager = _serviceProvider.GetRequiredService<UserManager<ExtendedUser>>();
        //        var _stripeService = _serviceProvider.GetRequiredService<IStripeService>();
        //        var user = await _userManager.FindByIdAsync(Utils.GetUserId(_serviceProvider));
        //        if (!string.IsNullOrWhiteSpace(user.StripeCustomerId))
        //        {
        //            var secretKey = _serviceProvider.GetRequiredService<IStripeConfigurationRepo>().GetStripeSecretKey();
        //            var customer = _stripeService.GetCustomer(secretKey, user.StripeCustomerId);
        //            return _stripeService.GetCard(customer.Id, customer.DefaultSourceId, secretKey);
        //        }

        //        return null;
        //    }





        //    private static Stripe.Subscription CreateSubscription(UpgradePlanDTO model, SubscriptionPlans plan, IStripeService _stripeService, string stripeSecretKey, string customerId)
        //    {
        //        model.NumberOfUsers = (model.NumberOfUsers - plan.FreeUsersAllowed) + 1;

        //        return _stripeService.CreateSubscription(new CreateSubscriptionDTO()
        //        {
        //            CustomerId = customerId,
        //            PlanId = plan.StripePlanId,
        //            StripeSecretKey = stripeSecretKey,
        //            Quantity = model.NumberOfUsers
        //        });
        //    }

        //    private static string CreateStripeCustomer(UpgradePlanDTO model, IStripeService _stripeService, ExtendedUser user, string stripeSecretKey)
        //    {
        //        return _stripeService.CreateCustomer(new CreateCustomerDTO()
        //        {
        //            StripeSecretKey = stripeSecretKey,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            Email = user.Email,
        //            Phone = user.PhoneNumber,
        //            StripePaymentToken = model.StripeToken
        //        });
        //    }



        //    private async Task PostPaymentHistory(UpgradePlanDTO model, Company company, SubscriptionPlans plan, IStripeService _stripeService, string stripeSecretKey, Stripe.Subscription subscription, Stripe.Invoice invoice, DateTime? recurringDate)
        //    {
        //        await _serviceProvider.GetRequiredService<IPaymentHistoryRepo>().Post(new PaymentHistory()
        //        {
        //            CreatedBy = Utils.GetUserId(_serviceProvider),
        //            InvoiceURL = invoice.HostedInvoiceUrl,
        //            IsDeleted = false,
        //            Payment = Convert.ToDecimal(subscription.Items.Data[0].Price.UnitAmount * subscription.Items.Data[0].Quantity / 100),
        //            PaymentDate = DateTime.UtcNow,
        //            StripeRecieptURL = _stripeService.GetCharge(invoice.ChargeId, stripeSecretKey).ReceiptUrl,
        //            SubscriptionPlanId = plan.Id,
        //            TenantId = company.CompanyGUID,
        //            EndDate = subscription.CurrentPeriodEnd,
        //            RecurringDate = recurringDate,
        //            CreatedDate = DateTime.UtcNow,
        //            NumberOfUsers = model.NumberOfUsers,
        //            Currency = model.Currency
        //        }, true);
        //    }

        //    private static async Task PostOrder(UpgradePlanDTO model, IOrdersRepo orderRepo, Company company, SubscriptionPlans plan, Stripe.Subscription subscription, DateTime? recurringDate)
        //    {
        //        await orderRepo.Post(new Order()
        //        {
        //            CompanyId = company.Id,
        //            CreatedDate = DateTime.UtcNow,
        //            IsFree = false,
        //            IsDeleted = false,
        //            Payment = Convert.ToDecimal(subscription.Items.Data[0].Price.UnitAmount * subscription.Items.Data[0].Quantity / 100),
        //            SubscriptionPlanId = plan.Id,
        //            EndDate = subscription.CurrentPeriodEnd,
        //            RecurringDate = recurringDate,
        //            CompanyGUID = company.CompanyGUID,
        //            NumberOfUsers = model.NumberOfUsers,
        //            StripeSubscriptionId = subscription.Id
        //        });
        //    }

        private string CreateEmailTemplate(string link, string description, string buttonTitle, string message, string address)
        {
            var _env = _serviceProvider.GetRequiredService<IHostingEnvironment>();
            string path = Path.Combine(_env.ContentRootPath, "EmailTemplates\\EmailTemplateForVerifyAndReset.html");
            if (System.IO.File.Exists(path))
            {
                string html = System.IO.File.ReadAllText(path);
                html = html.Replace("{logoLink}", LogoConfigurations.PortalFrontEndLogo);
                html = html.Replace("{description}", description);
                html = html.Replace("{link}", link);
                html = html.Replace("{buttonTitle}", buttonTitle);
                html = html.Replace("{message}", message);
                html = html.Replace("{address}", address);
                return html;
            }
            return null;
        }
        private string CreateEmailTemplateForInivitationToApply(string link, string description, string buttonTitle, string message, string address)
        {
            var _env = _serviceProvider.GetRequiredService<IHostingEnvironment>();
            string path = Path.Combine(_env.ContentRootPath, "EmailTemplates\\EmailTemplateForInvitation.html");
            if (System.IO.File.Exists(path))
            {
                string html = System.IO.File.ReadAllText(path);
                html = html.Replace("{logoLink}", LogoConfigurations.PortalFrontEndLogo);
                html = html.Replace("{description}", description);
                html = html.Replace("{link}", link);
                html = html.Replace("{buttonTitle}", buttonTitle);
                html = html.Replace("{message}", message);
                html = html.Replace("{address}", address);
                return html;
            }
            return null;
        }
    }
}