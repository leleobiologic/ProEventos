using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dto
{
    public class EventoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(4, ErrorMessage = "{0} dever ter no minimo 4 caracteres")]
        [MaxLength(50, ErrorMessage = "{0} dever ter no maximo 50  caracteres")]
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Tema { get; set; }
        [Range(1, 120000, ErrorMessage = "{0} Não pode ser menor que 1 ou maior que 120.000")]
        public int QtdPessoas { get; set; }
        [Display(Name = "Imagem")]
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",
                           ErrorMessage = "Insira uma {0} em um formato válido")]
        public string ImagemURL { get; set; }
        [MinLength(4, ErrorMessage = "{0} dever ter no minimo 4 caracteres")]
        [MaxLength(18, ErrorMessage = "{0} dever ter no maximo 18  caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Phone(ErrorMessage = "O campo {0}, está em um formato invalido.")]
        public string Telefone { get; set; }
        [EmailAddress(ErrorMessage = "Insira E-mail válido")]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> PalestrantesEventos { get; set; }
    }
}