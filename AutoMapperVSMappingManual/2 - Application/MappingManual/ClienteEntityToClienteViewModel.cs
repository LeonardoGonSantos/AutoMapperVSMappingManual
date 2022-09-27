using AutoMapperVSMappingManual._2___Application.Interface;
using static AutoMapperVSMappingManual._2___Application.Entity.Clientes.Clientes;
using static AutoMapperVSMappingManual._2___Application.Entity.Clientes.ClientesViewModel;

namespace AutoMapperVSMappingManual._2___Application.MappingManual
{
    public class ClienteEntityToClienteViewModel : IClienteEntityToClienteView
    {
        private ClienteView _clienteView = new ClienteView();
        private ParallelOptions _parallelOptions = new()
        {
            MaxDegreeOfParallelism = 15
        };

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
        public async Task<ClienteView> CreateAsync(ClienteEntity clienteEntity)
        {
            _clienteView.Nome = clienteEntity.Nome;
            _clienteView.Idade = clienteEntity.Idade;
            _clienteView.Email = clienteEntity.Email;
            _clienteView.SiatuacaoCiviil = clienteEntity.SiatuacaoCiviil;

            await Task.WhenAll(CreateContatoDeEmergencia(clienteEntity), CreateTelefone(clienteEntity), CreateEndereco(clienteEntity)).ConfigureAwait(false);

            return _clienteView;
        }

        private async Task CreateContatoDeEmergencia(ClienteEntity clienteEntity)
        {
            _clienteView.ContatosDeEmergencia = new List<ContatosdeemergenciaView>();

            await Parallel.ForEachAsync(clienteEntity.ContatosDeEmergencia, _parallelOptions, async (source, token) =>
            {
                _clienteView.ContatosDeEmergencia.Add(new ContatosdeemergenciaView()
                {
                    DDD = source.DDD,
                    Nome = source.Nome,
                    Telefone = source.Telefone
                });
            });
        }        
        
        private async Task CreateTelefone(ClienteEntity clienteEntity)
        {
            _clienteView.Telefone = new List<TelefoneView>();

            await Parallel.ForEachAsync(clienteEntity.Telefone, _parallelOptions, async (source, token) =>
            {
                _clienteView.Telefone.Add(new TelefoneView()
                {
                    DDD = source.DDD,
                    Numero = source.Numero
                });
            });
        }        
        
        private async Task CreateEndereco(ClienteEntity clienteEntity)
        {
            _clienteView.Endereco = new List<EnderecoView>();

            await Parallel.ForEachAsync(clienteEntity.Endereco, _parallelOptions, async (source, token) =>
            {
                _clienteView.Endereco.Add(new EnderecoView()
                {
                    Bairro = source.Bairro,
                    NUmero = source.NUmero,
                    Cep = source.Cep,
                    Complemento = source.Complemento,
                    Estado = source.Estado,
                    Pais = source.Pais,
                    Rua = source.Rua
                });
            });
        }
    }
}
