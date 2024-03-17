using AutoMapper;
using BackendshareSale.Repo.Models;
using BackendshareSale.Repo.ViewModel;
using System.Security.Claims;

namespace BackendTimeshareSale.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Property
            CreateMap<Property, PropertyVM>();
            #endregion
        }
    }
}
