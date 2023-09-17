using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu alan boş bırakılamaz!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Bu alan boş bırakılamaz!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen 5-20 karakter arası veri girişi yapınız!");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Lütfen 5-20 karakter arası veri girişi yapınız!");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("Lütfen 5-500 karakter arası veri girişi yapınız!");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen 5-500 karakter arası veri girişi yapınız!");
        }
    }
}
