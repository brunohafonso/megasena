using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace megasena.Models
{
    public class JogoDomain
    {
        [Required(ErrorMessage="Essa informação é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage="Por favor digite um número válido.")]
        public int QuantidadeJogos { get; set; }

        [Required(ErrorMessage="Essa informação é obrigatória")]
        [Range(6, 15, ErrorMessage="Por favor digite um número entre 6 e 15.")]
        public int QuantidadeNumeros { get; set; }

        public List<string> Jogos { get; set; }
    }
}