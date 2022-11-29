using AutoMapper;
using Challenge_4_Alura_Beck_End.Data;
using Challenge_4_Alura_Beck_End.Data.Dtos.Despesa;
using Challenge_4_Alura_Beck_End.Models;
using FluentResults;

namespace Challenge_4_Alura_Beck_End.Service {
    public class DespesaService {

        private AppDbContext _context;
        private IMapper _mapper;

        public DespesaService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public ReadDespesaDto CadastraDespesa(CreateDespesaDto createDto) {
            Despesa verificaDespesa = _context.Despesas.FirstOrDefault(d => d.Descricao == createDto.Descricao && d.Data.Month == createDto.Data.Month);
            if (verificaDespesa == null) {
                Despesa despesa = _mapper.Map<Despesa>(createDto);
                _context.Add(despesa);
                _context.SaveChanges();
                return _mapper.Map<ReadDespesaDto>(despesa);
            }
            return null;
        }

        public List<ReadDespesaDto> BuscaDespesa() {
            List<Despesa> despesa = _context.Despesas.ToList();
            if (despesa == null) {
                return null;
            }
            return _mapper.Map<List<ReadDespesaDto>>(despesa);
        }

        public ReadDespesaDto BuscaDespesaPorId(int id) {
            Despesa despesa = _context.Despesas.FirstOrDefault(despesa => despesa.Id == id);
            if (despesa != null) {
                ReadDespesaDto readDto = _mapper.Map<ReadDespesaDto>(despesa);
                return readDto;
            }
            return null;
        }

        public Result AtualizaDespesa(int id, UpdateDespesaDto updateDto) {
            Despesa despesa = _context.Despesas.FirstOrDefault(r => r.Id == id);
            if (despesa == null) {
                return Result.Fail("Despesa não encontrada");
            }
            _mapper.Map(despesa, updateDto);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaDespesa(int id) {
            Despesa despesa = _context.Despesas.FirstOrDefault(r => r.Id == id);
            if (despesa == null) {
                return Result.Fail("Despesa não encontrada");
            }
            _context.Remove(despesa);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
