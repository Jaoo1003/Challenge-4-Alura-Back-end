using AutoMapper;
using Challenge_4_Alura_Beck_End.Data.Dtos.Receita;
using Challenge_4_Alura_Beck_End.Models;

namespace Challenge_4_Alura_Beck_End.Profiles {
    public class ReceitaProfile : Profile{

        public ReceitaProfile() {
            CreateMap<CreateReceitaDto, Receita>();
            CreateMap<Receita, ReadReceitaDto>();
            CreateMap<UpdateReceitaDto, Receita>();
        }
    }
}
