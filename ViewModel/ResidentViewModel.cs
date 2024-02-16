using System.ComponentModel.DataAnnotations;

namespace API_Condominio.ViewModel
{
    public class ResidentViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do morador é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O e-mail do morador é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O telefone do morador é obrigatório")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "A unidade do morador é obrigatório")]
        public int UnitId { get; set; }
        public string? Image { get; set; }
        public short SexId { get; set; }
        public bool Responsible { get; set; } = false;

        public bool DisabledPerson { get; set; } = false;
        public bool Excluded { get; set; } = false;
        public DateTime ExclusionDate { get; set; } = DateTime.Now;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string Observation { get; set; }
        public bool Defaulter { get; set; } = false;




    }
}



