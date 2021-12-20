using Microsoft.EntityFrameworkCore;
using Programer.Core.Utilities.Security;
using Programer.Core.Utilities.UserConvertor;
using Programer.Core.ViewModels.Users;
using Programer.DataEF.ProgramersContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.Services
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(AccountRegisterVm vm);
        Task<bool> CheckEmailAndPasswordAsync(AccountLoginVm vm);
        Task<bool> IsDuplicatedEmail(string email);
        Task<UserDetailVm> GetUserByEmailAsync(string email);
        Task<UserDetailVm> GetUserByIdAsync(int userId);

    }
    public class AccountService : IAccountService
    {
        private readonly ProgramerContext _context;
        private readonly ISecurityService _securityService;

        public AccountService(ProgramerContext context, ISecurityService securityService)
        {
            _context = context;
            _securityService = securityService;
        }

        public async Task<bool> CheckEmailAndPasswordAsync(AccountLoginVm vm)
        {
            var user = await _context.Users.SingleOrDefaultAsync(c => c.Email.Trim().ToLower() == vm.Email.Trim().ToLower());
            if (user != null)
            {
                return _securityService.VerifyHashedPassword(user.Password, vm.Password);
            }
            return false;
        }

        public async Task<UserDetailVm> GetUserByEmailAsync(string email)
        {
            email = email.Trim().ToLower();
            var user = await _context.Users
                .SingleOrDefaultAsync(c => c.Email == email);

            return user.ToDetailViewModel();
        }

        public async Task<UserDetailVm> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users
               .SingleOrDefaultAsync(c => c.Id == userId);
            return user.ToDetailViewModel();
        }

        public async Task<bool> IsDuplicatedEmail(string email)
        {
            return await _context.Users.AnyAsync(c => c.Email.Trim().ToLower() == email.Trim().ToLower());
        }

        public async Task<bool> RegisterAsync(AccountRegisterVm vm)
        {
            try
            {
                var hassPassword = _securityService.HashPassword(vm.Password);
                var emailCode = Guid.NewGuid();
                await _context.Users.AddAsync(new Domain.Entities.Users.User
                {
                    Password = hassPassword,
                    CreateDate = DateTime.Now,
                    Email = vm.Email,
                    EmailCode = emailCode,
                    EmailConfirm = true, // Todo : Confirm by sending email (false as a default)
                    IsActive = true,
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                var m = ex.Message;
                return false;
            }
        }
    }


}