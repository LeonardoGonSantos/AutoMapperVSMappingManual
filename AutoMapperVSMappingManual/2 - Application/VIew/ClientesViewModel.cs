namespace AutoMapperVSMappingManual._2___Application.Entity.Clientes
{
    public class ClientesViewModel
    {
        public List<ClienteView> ClientesView { get; set; }

        public class ClienteView
        {
            public string Nome { get; set; }
            public string Idade { get; set; }
            public string SiatuacaoCiviil { get; set; }
            public List<EnderecoView> Endereco { get; set; }
            public List<TelefoneView> Telefone { get; set; }
            public List<ContatosdeemergenciaView> ContatosDeEmergencia { get; set; }
            public string Email { get; set; }
        }

        public class EnderecoView
        {
            public string Rua { get; set; }
            public string NUmero { get; set; }
            public string Estado { get; set; }
            public string Pais { get; set; }
            public string Cep { get; set; }
            public string Bairro { get; set; }
            public string Complemento { get; set; }
        }

        public class TelefoneView
        {
            public string DDD { get; set; }
            public string Numero { get; set; }
        }

        public class ContatosdeemergenciaView
        {
            public string DDD { get; set; }
            public string Telefone { get; set; }
            public string Nome { get; set; }
        }
    }
}
