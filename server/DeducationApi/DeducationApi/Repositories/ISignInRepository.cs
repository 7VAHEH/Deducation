using DeducationApi.Models.RequestModels;

namespace DeducationApi.Repositories
{
    public interface ISignInRepository
    {
        public Task<string> SignIn(SignInRequestModel signInModel);
        public Task<string> StudentRegistration(StudentRegistrationRequestModel registrationInModel);
    }
}
