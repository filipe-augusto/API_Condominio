using System.ComponentModel.DataAnnotations;

namespace API_Condominio.ViewModel
{
    public class BlockViewModel
    {
        [Required(ErrorMessage = "O nome do bloco é obrigatorio")]
        public string NameBlock { get; set; }
        [Required(ErrorMessage = "Quantidade de unidades é obrigatorio informar")]
        [MinLength(1, ErrorMessage = "Quantidade minima é 1")]
        public int QuantityeUnit { get; set; }
        [Required(ErrorMessage = "Quantidade de andares é obrigatorio informar")]
        [MinLength(1, ErrorMessage ="Quantidade minima é 1")]
        [MaxLength(1, ErrorMessage = "Quantidade maxima é 100")]
        public int QuantityFloor { get; set; }

    }
}



