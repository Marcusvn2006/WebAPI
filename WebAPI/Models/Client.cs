

using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Client
    {

        public Guid ClientId { get; set; } // Propriedade para armazenar o identificador único do cliente, do tipo Guid (Globally Unique Identifier) -> Deve ser nomeada como "Nome-da-Classe" + "Id" (ClienteId) para ser reconhecida automaticamente pelo Entity Framework Core como chave primária da entidade Cliente

        [Required(ErrorMessage = "O Nome é Obrigatório")] // Atributo de validação para indicar que a propriedade Nome é obrigatória (não pode ser nula ou vazia)
        public string? Nome { get; set; } // Propriedade para armazenar o nome do cliente, do tipo string

        [Required(ErrorMessage = "O E-mail é Obrigatório")]
        [EmailAddress(ErrorMessage = "O Formato do E-mail deve ser válido")] // Atributo de validação para indicar que a propriedade Email é obrigatória e deve ser um endereço de email válido
        public string? Email { get; set; } // Propriedade para armazenar o email do cliente, do tipo string
    }
}

