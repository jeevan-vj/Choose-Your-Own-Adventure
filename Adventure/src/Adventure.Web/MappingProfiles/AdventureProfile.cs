using Adventure.Core.Models;
using Adventure.Web.ApiModels;
using AutoMapper;

namespace Adventure.Web.MappingProfiles;

public class AdventureProfile : Profile
{
  public AdventureProfile()
  {
    CreateMap<AdventureItem, AdventureDto>();
    CreateMap<AdventureDto, AdventureItem>();
    CreateMap<AdventureDto, UserAdventureItem>();
    CreateMap<UserAdventureItem, UserAdventureDto>();
    CreateMap<UserAdventureDto, UserAdventureItem>();
    CreateMap<CreateAdventureDto, AdventureItem>();
    CreateMap<CreateChoiceDto, Choice>();
    CreateMap<CreateOptionDto, Option>();
  }
}
