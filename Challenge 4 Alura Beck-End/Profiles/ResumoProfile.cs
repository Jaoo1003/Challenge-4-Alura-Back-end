using AutoMapper;
using Challenge_4_Alura_Beck_End.Data.Dtos.Resumos;
using Challenge_4_Alura_Beck_End.Models;

namespace Challenge_4_Alura_Beck_End.Profiles {
    public class ResumoProfile : Profile{

        public ResumoProfile() {
            CreateMap<Despesa, ResumoDto>();
            CreateMap<Receita, ResumoDto>();
        }
    }
}
