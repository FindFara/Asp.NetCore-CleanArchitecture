using Programer.Core.ViewModels.Users;
using Programer.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.Utilities.UserConvertor
{
    public static class UserConvertor
    {
        public static UserDetailVm ToDetailViewModel(this User user)
        {
            return new UserDetailVm
            {
                Email = user.Email,
                CreateDate = user.CreateDate,
                EmailCode = user.EmailCode,
                EmailConfirm = user.EmailConfirm,
                Name = user.FirstName,
                Family = user.LastName,
                Id = user.Id,
                IsActive = user.IsActive,
                Mobile = user.Mobile
            };
        }
        public static IQueryable<UserDetailVm> ToDetailViewModel(this IQueryable<User> users)
        {
            return users.Select(user => user.ToDetailViewModel());
        }


    }
}
