using OutsourcingSystem.DTOs;

namespace OutsourcingSystem.Services
{
    public interface IDeveloperServices
    {
        void RegisterDeveloper(UserDeveloperInputDto input);
    }
}