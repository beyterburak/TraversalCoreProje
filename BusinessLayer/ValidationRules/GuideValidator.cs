using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Soyad kısmını boş geçemezsiniz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Görsel kısmını boş geçemezsiniz!");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("30 karakterden daha kısa bir isim giriniz!");
            RuleFor(x => x.Name).MinimumLength(8).WithMessage("8 karakterden daha uzun bir isim giriniz!");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("100 karakterden daha kısa bir açıklama giriniz!");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("10 karakterden daha uzun bir açıklama giriniz!");
        }
    }
}
