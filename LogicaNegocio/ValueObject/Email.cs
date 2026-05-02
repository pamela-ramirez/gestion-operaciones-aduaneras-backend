using LogicaNegocio.Excepciones.Usuarios;
using System.Net.Mail;

namespace LogicaNegocio.ValueObject
{
    //[ComplexType]
    public record Email
    {
        public string Valor { get; init; }

        public Email(string valor)
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Valor))
            {
                throw new UsuarioEmailVacioException();
            }

            try
            {
                var mailAddress = new MailAddress(Valor);

                if (!mailAddress.Host.Contains("."))
                {
                    throw new UsuarioEmailFormatoInvalidoException();
                }
            }
            catch (FormatException)
            {
                throw new UsuarioEmailFormatoInvalidoException();
            }
        }
    }
}

