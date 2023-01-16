using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoCreate
    {
        [Required(ErrorMessage = "CEP é um campo obrigatório!")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Logradouro é um campo obrigatório!")]
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        [Required(ErrorMessage = "Municipio é um campo obrigatório!")]
        public Guid MunicipioId { get; set; }
    }
}