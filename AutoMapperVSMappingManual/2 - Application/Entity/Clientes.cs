namespace AutoMapperVSMappingManual._2___Application.Entity.Clientes
{
    public class Clientes
    {
        public List<ClienteEntity> ClientesEntity { get; set; }

        public class ClienteEntity
        {
            public string Nome { get; set; }
            public string Idade { get; set; }
            public string SiatuacaoCiviil { get; set; }
            public List<EnderecoEntity> Endereco { get; set; }
            public List<TelefoneEntity> Telefone { get; set; }
            public List<ContatosdeemergenciaEntity> ContatosDeEmergencia { get; set; }
            public string Email { get; set; }
        }

        public class EnderecoEntity
        {
            public string Rua { get; set; }
            public string NUmero { get; set; }
            public string Estado { get; set; }
            public string Pais { get; set; }
            public string Cep { get; set; }
            public string Bairro { get; set; }
            public string Complemento { get; set; }
        }

        public class TelefoneEntity
        {
            public string DDD { get; set; }
            public string Numero { get; set; }
        }

        public class ContatosdeemergenciaEntity
        {
            public string DDD { get; set; }
            public string Telefone { get; set; }
            public string Nome { get; set; }
        }
    }
}
