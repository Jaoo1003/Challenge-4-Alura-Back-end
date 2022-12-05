using AutoMapper;
using Challenge_4_Alura_Beck_End.Data.Dtos.Categorias;
using Challenge_4_Alura_Beck_End.Models;

namespace Challenge_4_Alura_Beck_End.Profiles {
    public class CategoriaProfile : Profile{

        public CategoriaProfile() {
            CreateMap<CreateCategoriaDto, Categoria>();
        }
    }
}
