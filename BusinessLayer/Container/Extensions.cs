using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUow;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUow;
using BusinessLayer.ValidationRules;
using BusinessLayer.ValidationRules.ContactUs;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependency(this IServiceCollection services)
        {
            //Comment sınıfını Ef Core bağımlılığından kurtarma işlemi
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();
            //Destination sınıfını Ef Core bağımlılığından kurtarma işlemi
            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EfDestinationDal>();
            //AppUser sınıfını Ef Core bağımlılığından kurtarma işlemi
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();
            //Reservation sınıfını Ef Core bağımlılığından kurtarma işlemi
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();
            //Guide sınıfını Ef Core bağımlılığından kurtarma işlemi
            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();
            //Excel sınıfını Ef Core bağımlılığından kurtarma işlemi
            services.AddScoped<IExcelService, ExcelManager>();
            //Pdf sınıfını Ef Core bağımlılığından kurtarma işlemi
            services.AddScoped<IPdfService, PdfManager>();
            //ContactUs sınıfını Ef Core bağımlılığından kurtarma işlemi
            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();
            //Announcement sınıfını Ef Core bağımlılığından kurtarma işlemi
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            //Unit Of Work sınıfını Ef Core bağımlılığından kurtarma işlemi
            services.AddScoped<IUowDal, UowDal>();
            //Account(Unit Of Work) sınıfını Ef Core bağımlılığından kurtarma işlemi
            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EfAccountDal>();
        }

        public static void CustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementValidator>();
            services.AddTransient<IValidator<SendMessageDTO>, SendContactUsValidator>();
        }
    }
}
