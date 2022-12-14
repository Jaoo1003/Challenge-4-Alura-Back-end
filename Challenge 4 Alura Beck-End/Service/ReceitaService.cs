using AutoMapper;
using Challenge_4_Alura_Beck_End.Data;
using Challenge_4_Alura_Beck_End.Data.Dtos.Receitas;
using Challenge_4_Alura_Beck_End.Models;
using FluentResults;
using System.Linq;

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
                _context.Receitas.Add(receita);
                _context.SaveChanges();
                return _mapper.Map<ReadReceitaDto>(receita);
            }
            return null;
        }

        public List<ReadReceitaDto> BuscaReceita(string? descricao) {
            List<Receita> receitas;
            if (descricao == null) {
                receitas = _context.Receitas.ToList();
            }
            else {
                receitas = _context.Receitas.Where(receita => receita.Descricao == descricao).ToList();
            }

            if (receitas != null) {
                List<ReadReceitaDto> readDto = _mapper.Map<List<ReadReceitaDto>>(receitas);
                return readDto;
            }
            return null;
        }

        public ReadReceitaDto BuscaReceitaPorId(int id) {
            Receita receita = _context.Receitas.FirstOrDefault(receita => receita.Id == id);
            if (receita == null) {
                return null;
            }
            else {
                ReadReceitaDto readDto = _mapper.Map<ReadReceitaDto>(receita);
                return readDto;
            }
        }

        public List<ReadReceitaDto> BuscaReceitaPorMes(int? ano, int? mes) {
            List<Receita> receitas;
            if (ano == null || mes == null) {
                return null;
            }
            else {
                receitas = _context.Receitas.Where(receita => receita.Data.Year == ano && receita.Data.Month == mes).ToList();
            }
            if (receitas != null) {
                List<ReadReceitaDto> readDto = _mapper.Map<List<ReadReceitaDto>>(receitas);
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
