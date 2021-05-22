using CommonLayer.DTOs;
using EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrastructures
{
    public interface IExtendedUsersRepo : IRepositoryBase<ExtendedUser>
    {
        Task<LoginResponseDTO> ProcessLogin(LoginDTO model);
        List<ExtendedUser> GetUsers();
        bool Logout();
        Task<bool> Register(RegisterDTO model);
        Task<bool> ResetPassword(ResetPasswordDTO model);
        Task<bool> GenerateForgotPasswordToken(string email);
        Task<bool> ResetPasswordWithToken(ResetPasswordDTO model);
        Task<bool> InvitationToJoinProject(string email);
       // Task<bool> stage1Post(SignUpstage1DTO model);
        Task<bool> Stage2BusinessPost(SignUPStage2BusinessDTO model);
        Task<bool> Stage2PersonalPost(SignUPStage2PersonalDTO model);
        Task<bool> Stage2PartnerPost(SignUPStage2PartnerDTO model);
        Task<bool> Stage3Post(signUpstage3DTO model);
        Task<bool> Stage4Post(signUpstage4DTO model);

        Task<bool> Stage5BusinessPost(SignUPStage5BusinessDTO model);
        Task<bool> Stage5PersonalPost(SignUPStage5PersonalDTO model);

        Task<bool> Stage5PartnerPost(SignUPStage5PartnerDTO model);

 
        //Task<UserDTO> GetUserDetails();
        //Task<bool> UpdateUser(UpdateUserDTO model);
        //Task<bool> CheckIsEmailExist(string Email, bool isFromAdmin = false);
        //Task<bool> CheckIsUserEligibleForNewPswd(string UserId);
        //Task<RegisterDTO> VerifyEmail(string userId, string token, string planId);
        //Task<bool> CreateNewPassword(ResetPasswordDTO model);
        //Task<RegisterDTO> RegisterUsingEmail(RegisterDTO model);
        //Task<bool> ResendEmailConfirmationTokenMail(RegisterDTO model);
        //bool VerifyUserAndPlan(string userId, string planId);
        //Task<bool> SoftDelete(string id);
    }
}
