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
        Task<LoginResponseDTO> Register(RegisterDTO model);
        Task<bool> ResetPassword(ResetPasswordDTO model);
        Task<bool> GenerateForgotPasswordToken(string email);
        Task<bool> ResetPasswordWithToken(ResetPasswordDTO model);
        Task<bool> InvitationToJoinProject(string email);
       // Task<bool> stage1Post(SignUpstage1DTO model);
        void Stage2BusinessPost(SignUPStage2BusinessDTO model);
        Task Stage2PersonalPost(SignUPStage2PersonalDTO model);
        void Stage2PartnerPost(SignUPStage2PartnerDTO model);
        void Stage3Post(signUpstage3DTO model);
        void Stage4Post(signUpstage4DTO model);
        void Stage5BusinessPost(SignUPStage5BusinessDTO model);
        void Stage5PersonalPost(SignUPStage5PersonalDTO model);
        void Stage5PartnerPost(SignUPStage5PartnerDTO model);
    }
}
