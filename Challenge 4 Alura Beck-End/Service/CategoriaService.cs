using AutoMapper;
using Challenge_4_Alura_Beck_End.Data;
using Challenge_4_Alura_Beck_End.Data.Dtos.Categorias;
using Challenge_4_Alura_Beck_End.Models;

namespace Challenge_4_Alura_Beck_End.Service {
    public class CategoriaService {

        private AppDbContext _context;
        private IMapper _mapper;

        public CategoriaService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public Categoria AdicionaCategoria(CreateCategoriaDto createDto) {
            Categoria categoria = _mapper.Map<Categoria>(createDto);
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }
    }
}
