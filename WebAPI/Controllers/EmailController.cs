using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] // Define a rota para o controlador, neste caso, "api/email"
    [ApiController] // Indica que este controlador é uma API Controller, habilitando recursos específicos para APIs, como validação automática de modelos e formatação de respostas
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService; // Injeção de Dependência para acessar o serviço de email

        // Construtor para receber o serviço de email injetado pelo contêiner de dependências, permitindo que o controlador utilize os métodos do serviço de email para enviar emails
        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")] // Define a rota para o método de envio de email, neste caso, "api/email/send", e indica que este método responde a requisições HTTP POST]
        public async Task<IActionResult> Send(string dest, string assunto, string mensagem)
        {
            await _emailService.SendEmailAsync(dest, assunto, mensagem); // Chama o método SendEmailAsync do serviço de email para enviar o email utilizando os parâmetros recebidos na requisição

            return Ok(new { Message = "Email enviado com sucesso!" }); // Retorna uma resposta HTTP 200 OK com uma mensagem indicando que o email foi enviado com sucesso
        }

    }
}
