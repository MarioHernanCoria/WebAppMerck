namespace WebAppMerck.Servicios.Interfaces
{
    public interface IEmailSender
    {
        public Task EnviarEmailAsync(string to, string subject, string body, string message);
    }
}
                                                                                                                                                                       