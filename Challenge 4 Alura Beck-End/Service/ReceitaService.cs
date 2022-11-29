using AutoMapper;
using Challenge_4_Alura_Beck_End.Data;
using Challenge_4_Alura_Beck_End.Data.Dtos.Receita;
using Challenge_4_Alura_Beck_End.Models;
using FluentResults;

namespace Challenge_4_Alura_Beck_End.Service {
    public class ReceitaService {

        private AppDbContext _context;
        private IMapper _mapper;

        public ReceitaService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public ReadReceitaDto CadastroReceita(CreateReceitaDto createDto) {
            Receita verificaReceita = _context.Receitas.FirstOrDefault(r => r.Descricao == createDto.Descricao && r.Data.Month == createDto.Data.Month);
            if (verificaReceita == null) {
                Receita receita = _mapper.Map<Receita>(createDto);
                _context.Add(receita);
                _context.SaveChanges();
                return _mapper.Map<ReadReceitaDto>(receita);
            }
            return null;
        }

        public List<ReadReceitaDto> BuscaReceita() {
            List<Receita> receitas = _context.Receitas.ToList();
            if (receitas == null) {
                return null;
            }
            else {
                List<ReadReceitaDto> readDto = _mapper.Map<List<ReadReceitaDto>>(receitas);
                return readDto;
            }
        }

        public ReadReceitaDto BuscaReceitaPorId(int id) {
            Receita receita = _context.Receitas.FirstOrDefault(receita => receita.Id == id);
            if (receita != null) {
                ReadReceitaDto readDto = _mapper.Map<ReadReceitaDto>(receita);
                return readDto;
            }
            return null;
        }

        public Result AtualizaReceita(int id, UpdateReceitaDto updateDto) {
            Receita receita = _context.Receitas.FirstOrDefault(r => r.Id == id);
            if (receita == null) {
                return Result.Fail("Receita não encontrada");
            }
            _mapper.Map(receita, updateDto);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaReceita(int id) {
            Receita receita = _context.Receitas.FirstOrDefault(r => r.Id == id);
            if (receita == null) {
                return Result.Fail("Receita não encontrada");
            }
            _context.Remove(receita);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
