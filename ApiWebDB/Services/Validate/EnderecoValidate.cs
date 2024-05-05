using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;

namespace ApiWebDB.Services.Validate
{
    public class EnderecoValidate
    {
        public static bool Execute(EnderecoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Cep.ToString()))
                throw new InvalidEntityException("Campo CEP é obrigatório");

            if (dto.Cep.ToString().Length != 8)
                throw new InvalidEntityException("Campo CEP deve ter 8 dígitos");

            if (string.IsNullOrEmpty(dto.Logradouro))
                throw new InvalidEntityException("Campo Logradouro é obrigatório");

            if (string.IsNullOrEmpty(dto.Numero))
                throw new InvalidEntityException("Campo Numero é obrigatório");

            if (string.IsNullOrEmpty(dto.Bairro))
                throw new InvalidEntityException("Campo Bairro é obrigatório");

            if (string.IsNullOrEmpty(dto.Cidade))
                throw new InvalidEntityException("Campo Cidade é obrigatório");

            if (string.IsNullOrEmpty(dto.Uf))
                throw new InvalidEntityException("Campo UF é obrigatório");

            if (dto.Status != 0 && dto.Status != 1)
                throw new InvalidEntityException("Campo Status deve ser 0 (inativo) ou 1 (ativo)");

            return true;
        }
    }
}
