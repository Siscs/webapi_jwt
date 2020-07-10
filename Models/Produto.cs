using System.ComponentModel.DataAnnotations;

namespace lxwebapi.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo é obrigatório")]
        [MaxLength(60, ErrorMessage="Deve conter até 60 caracteres")]
        [MinLength(3,ErrorMessage="Deve conter no mínimo 3 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage="Campo é obrigatório")]
        [MaxLength(1024, ErrorMessage="Deve conter até 1024 caracteres")]
        public string Descricao { get; set; }   
        
        
        [Required(ErrorMessage="Campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage=("o preço deve ser maior que zero"))]
        public decimal Preco { get; set; }

        [Required(ErrorMessage="Campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage=("Categoria inválida"))]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}