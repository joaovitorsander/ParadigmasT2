using APIWebDB.BaseDados.Models;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using ApiWebDB.Services.Parser;
using ApiWebDB.Services.Validate;
using System.Collections.Generic;
using System.Linq;

namespace ApiWebDB.Services
{
    public class EnderecoService
    {
        private readonly ApidbContext _dbContext;

        public EnderecoService(ApidbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public TbEndereco Insert(EnderecoDTO dto)
        {
            if (!EnderecoValidate.Execute(dto))
                return null;

            var entity = EnderecoParser.ToEntity(dto);

            _dbContext.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public TbEndereco Update(EnderecoDTO dto, int id)
        {
            if (!EnderecoValidate.Execute(dto))
                return null;


            var existingEntity = GetById(id);
            if (existingEntity == null)
            {
                throw new NotFoundException("Registro não existe");
            }

            var entity = EnderecoParser.ToEntity(dto);

            var EnderecoById = GetById(id);

            EnderecoById.Uf = entity.Uf;
            EnderecoById.Cep = entity.Cep;
            EnderecoById.Logradouro = entity.Logradouro;
            EnderecoById.Numero = entity.Numero;
            EnderecoById.Complemento = entity.Complemento;
            EnderecoById.Bairro = entity.Bairro;
            EnderecoById.Cidade = entity.Cidade;
            EnderecoById.Clienteid = entity.Clienteid;
            EnderecoById.Status = entity.Status;


            _dbContext.Update(EnderecoById);
            _dbContext.SaveChanges();

            return entity;
        }

        public TbEndereco GetById(int id)
        {
            var existingEntity = _dbContext.TbEnderecos.FirstOrDefault(c => c.Id == id);
            if (existingEntity == null)
            {
                throw new NotFoundException("Registro não existe");
            }
            return existingEntity;
        }

        public void Delete(int id)
        {
            var existingEntity = GetById(id);

            if (existingEntity == null)
            {
                throw new NotFoundException("Registro não existe");
            }
            _dbContext.Remove(existingEntity);
            _dbContext.SaveChanges();

        }

        public IEnumerable<TbEndereco> GetEnderecoById(int id)
        {
            var existingEntity = _dbContext.TbEnderecos.Where(c => c.Clienteid == id).ToList();
            if (existingEntity == null)
            {
                throw new NotFoundException("Registro não existe");
            }
            return existingEntity;
        }

        public IEnumerable<TbEndereco> Get()
        {
            var existingEntity = _dbContext.TbEnderecos.ToList();

            if (existingEntity == null || existingEntity.Count == 0)
            {
                throw new NotFoundException("Nenhum registro foi encontrado");
            }
            return existingEntity;
        }
    }
}
