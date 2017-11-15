using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Leaf.Web.Models.Users;

namespace Leaf.Web.Validators
{
    public class UserValidator:AbstractValidator<UserModel>
    {
        //private readonly xxx xx
        public UserValidator()//可以依赖注入
        {
            RuleFor(c => c.Account).NotEmpty().WithMessage("用户名称不能为空");
            //RuleFor(customer => customer.Email)
            //   .NotEmpty().WithMessage("邮箱不能为空")
            //   .EmailAddress().WithMessage("邮箱格式不正确");
            //RuleFor(customer => customer.Discount)
            //    .NotEqual(0)
            //    .When(customer => customer.HasDiscount);
            //RuleFor(customer => customer.Address)
            //    .NotEmpty()
            //    .WithMessage("地址不能为空")
            //    .Length(20, 50)
            //    .WithMessage("地址长度范围为20-50字节");

            //用法

            //UserValidator validator = new UserValidator();
            //var result = validator.Validate(new UserModel);

            //if (!result.IsValid)
            //{
            //    result.Errors.ToList().ForEach(error =>
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    });
            //}
            //     if (ModelState.IsValid)

        }
    }
}
