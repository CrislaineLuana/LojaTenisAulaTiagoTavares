using System.ComponentModel.DataAnnotations;

namespace LojaTenisAula12.Models
{
    public class TenisModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite a Marca!")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "Insira uma foto!")]
        public string Foto { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite um valor!")]
        public double Valor { get; set; }
    }
}
