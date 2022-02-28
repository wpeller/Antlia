using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.Authorization.Users.Dto;
using Fgv.Ide.Corporativohotsite.Authorization.Users.Profile.Dto;
using Fgv.Ide.Corporativohotsite.Dto;

namespace Fgv.Ide.Corporativohotsite.Authorization.Users.Profile
{
    public interface IProfileAppService : IApplicationService
    {
        Task<CurrentUserProfileEditDto> GetCurrentUserProfileForEdit();

        Task UpdateCurrentUserProfile(CurrentUserProfileEditDto input);
        
        Task ChangePassword(ChangePasswordInput input);

        Task UpdateProfilePicture(UpdateProfilePictureInput input);

        Task<GetPasswordComplexitySettingOutput> GetPasswordComplexitySetting();

        Task<GetProfilePictureOutput> GetProfilePicture();

        Task<GetProfilePictureOutput> GetProfilePictureById(Guid profilePictureId);

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<UpdateGoogleAuthenticatorKeyOutput> UpdateGoogleAuthenticatorKey();

        Task SendVerificationSms();

        Task VerifySmsCode(VerifySmsCodeInputDto input);

        Task PrepareCollectedData();
    }
}
