using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDTO>
    {
        public SendContactUsValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Bu alana 5 - 100 karakter arasında giriş yapmalısınız!");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Bu alana 5 - 100 karakter arasında giriş yapmalısınız!"); 
            RuleFor(x => x.Mail).MinimumLength(5).WithMessage("Bu alana 5 - 100 karakter arasında giriş yapmalısınız!");
            RuleFor(x => x.Mail).MaximumLength(100).WithMessage("Bu alana 5 - 100 karakter arasında giriş yapmalısınız!");
        }
    }
}
