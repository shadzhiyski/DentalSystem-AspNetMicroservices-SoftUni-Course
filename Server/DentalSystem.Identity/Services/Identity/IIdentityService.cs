﻿namespace DentalSystem.Identity.Services.Identity
{
    using System.Threading.Tasks;
    using DentalSystem.Services;
    using Data.Models;
    using Models.Identity;

    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput, string roleName = Constants.PatientRoleName);

        Task<Result<UserOutputModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);
    }
}
