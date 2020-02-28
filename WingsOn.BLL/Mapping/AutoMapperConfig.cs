using AutoMapper;
using WingsOn.BLL.DTOs;
using WingsOn.Domain;
using Unity;
using WingsOn.Api.Models;

namespace WingsOn.BLL.Mapping
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersonDTO, Person>()
                .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
                .ReverseMap();

                 cfg.CreateMap<UpdateAddressDTO, UpdateAddressModel>()
                .ForMember(dst => dst.PersonId, src => src.MapFrom(e => e.PersonId))
                .ReverseMap();

                cfg.CreateMap<PersonDTO, PersonViewModel>().ReverseMap();

                cfg.CreateMap<FlightDTO, Flight>().ReverseMap();

              cfg.CreateMap<BookingDTO, Booking>()
                 .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
                .ReverseMap();

            });
            Mapper = config.CreateMapper();
        }

        public static void RegisterInstance(UnityContainer container)
        {
            container.RegisterInstance(Mapper);
        }
    }
}
