using AutoMapper;
using Challenge_4_Alura_Beck_End.Data;
using Challenge_4_Alura_Beck_End.Data.Dtos.Despesa;
using Challenge_4_Alura_Beck_End.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_4_Alura_Beck_End.Service {
    public class DespesaService {

        private AppDbContext _context;
        private IMapper _mapper;

        public DespesaService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public ReadDespesaDto CadastraDespesa(CreateDespesaDto createDto) {
            Despesa verificaDespesa = _context.Despesas.FirstOrDefault(d => d.Descricao == createDto.Descricao && d.Data.Month = createDto.Data);    
            if (verificaDespesa == null) {
                Despesa despesa = _mapper.Map<Despesa>(createDto);
                _context.Despesas.Add(despesa);
                _context.SaveChanges();
                return _mapper.Map<ReadDespesaDto>(despesa);
            }
            return null;
        }

        public List<ReadDespesaDto> BuscaDespesa(string? descricao) {
            List<Despesa> despesas;
            if (descricao == null) {
                despesas = _context.Despesas.ToList();
            }
            else {
                despesas = _context.Despesas.Where(despesa => despesa.Descricao == descricao).ToList();
            }
            if (despesas != null) {
                List<ReadDespesaDto> readDto = _mapper.Map<List<ReadDespesaDto>>(despesas);
                return readDto;
            }
            return null;
            
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
