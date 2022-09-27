using AutoMapperVSMappingManual._2___Application.Interface;
using static AutoMapperVSMappingManual._2___Application.Entity.Clientes.Clientes;
using static AutoMapperVSMappingManual._2___Application.Entity.Clientes.ClientesViewModel;

namespace AutoMapperVSMappingManual._2___Application.MappingManual
{
    public class ClienteEntityToClienteViewModel : IClienteEntityToClienteView
    {
        public ClienteView Create(ClienteEntity clienteEntity)
        {
            ClienteView clienteView = new ClienteView();

            clienteView.Nome = clienteEntity.Nome;
            clienteView.Idade = clienteEntity.Idade;
            clienteView.Email = clienteEntity.Email;
            clienteView.SiatuacaoCiviil = clienteEntity.SiatuacaoCiviil;

            clienteView.ContatosDeEmergencia = new List<ContatosdeemergenciaView>();

            foreach (var contato in clienteEntity.ContatosDeEmergencia)
            {
                clienteView.ContatosDeEmergencia.Add(new ContatosdeemergenciaView()
                {
                    DDD = contato.DDD,
                    Nome = contato.Nome,
                    Telefone = contato.Telefone
                });
            }

            clienteView.Telefone = new List<TelefoneView>();

            foreach (var telefone in clienteEntity.Telefone)
            {
                clienteView.Telefone.Add(new TelefoneView()
                {
                    DDD = telefone.DDD,
                    Numero = telefone.Numero
                });
            }

            clienteView.Endereco = new List<EnderecoView>();

            foreach (var endereco in clienteEntity.Endereco)
            {
                clienteView.Endereco.Add(new EnderecoView()
                {
                    Bairro = endereco.Bairro,
                    NUmero = endereco.NUmero,
                    Cep = endereco.Cep,
                    Complemento = endereco.Complemento,
                    Estado = endereco.Estado,
                    Pais = endereco.Pais, 
                    Rua = endereco.Rua
                });
            }

            return clienteView;
        }
    }
}
