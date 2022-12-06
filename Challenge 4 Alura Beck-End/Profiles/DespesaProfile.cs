using AutoMapper;
using Challenge_4_Alura_Beck_End.Data.Dtos.Despesas;
using Challenge_4_Alura_Beck_End.Models;

namespace Challenge_4_Alura_Beck_End.Profiles {
    public class DespesaProfile : Profile{

        public DespesaProfile() {
            CreateMap<CreateDespesaDto, Despesa>();
            CreateMap<Despesa, ReadDespesaDto>();
            CreateMap<UpdateDespesaDto, Despesa>();
        }
    }
}
