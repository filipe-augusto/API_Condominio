using System.ComponentModel.DataAnnotations;

namespace API_Condominio.ViewModel
{
    public class BlockViewModel
    {
        [Required(ErrorMessage = "O nome do bloco é obrigatorio")]
        public string NameBlock { get; set; }
        [Required(ErrorMessage = "Quantidade de unidades é obrigatorio informar")]
 
        public int QuantityeUnit { get; set; }
        [Required(ErrorMessage = "Quantidade de andares é obrigatorio informar")]
  
        public int QuantityFloor { get; set; }

    }
}



