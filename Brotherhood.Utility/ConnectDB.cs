using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Brotherhood.Utility
{
    public class ConnectDB
    {        
        private MongoClient _client = null;
        
        public void Connect()
        {
            var settings = new MongoClientSettings
            {
                ServerSelectionTimeout = new TimeSpan(0, 0, 30),
                Server = new MongoServerAddress("localhost", 27017),
                Credentials = new[]
                {
                    MongoCredential.CreateCredential("loja", "joel", "xyz123")
                }
            };
        }

        public MongoClient GetClient()
        {
            if (_client == null)
            {
                // TODO add try-catch
                // Connect to the server
                Console.WriteLine("Connecting to the server");
                _client = new MongoClient("mongodb://localhost:27017");

                // Connect to the database
                Console.WriteLine("Connecting to the database");
                var database = _client.GetDatabase("Voluntarios");

                // Collection to store - "contatos" will be created if it doesn't exist
                IMongoCollection<Pessoa> colecao = database.GetCollection<Pessoa>("contatos");

                //InserirPessoa(colecao);
                //AtualizarPessoa();
                //ExcluirPessoa(colecao);
                ListarPessoa(colecao);
            }
            return _client;
        }

        private static void InserirPessoa(IMongoCollection<Pessoa> colecao)
        {
            Servico serv1 = new Servico() { descricao = "pintura" };
            Servico serv2 = new Servico() { descricao = "massagem" };

            List<Servico> servicos = new List<Servico>();
            servicos.Add(serv1);
            servicos.Add(serv2);

            Pessoa p = new Pessoa() { CPF = "123456789", Nome = "Dalton", Endereco = "Rua 13", Ativo = false, Servicos = servicos };
            colecao.InsertOne(p);
        }

        private static void AtualizarPessoa(IMongoCollection<Pessoa> colecao)
        {
            // Filtro
            //var filtro = Builders<Pessoa>.Filter.Where(x => x.Nome == "xpto");
            var filtro = Builders<Pessoa>.Filter.Empty;

            // Alteracao
            var alteracao = Builders<Pessoa>.Update.Set(p => p.Ativo, true); // Set or Unset

            colecao.UpdateMany(filtro, alteracao);
        }

        private static void RemoverPessoa(IMongoCollection<Pessoa> colecao)
        {
            // Filtro
            //var filtro = Builders<Pessoa>.Filter.Where(x => x.Nome == "xpto");
            var filtro = Builders<Pessoa>.Filter.Empty;

            // Alteracao
            var alteracao = Builders<Pessoa>.Update.Unset(p => p.Ativo, true);

            colecao.UpdateMany(filtro, alteracao);
        }

        private static void RemoverPessoa(IMongoCollection<Pessoa> colecao)
        {
            // Filtro
            var filtro = Builders<Pessoa>.Filter.Where(x => x.Nome == "Fernanda");        

            colecao.DeleteMany(filtro);
        }

        private static void ListarPessoa(IMongoCollection<Pessoa> colecao)
        {
            // Filtro
            var filtro = Builders<Pessoa>.Filter.Where(x => x.Nome == "Fernanda");
            var pessoas = colecao.Find<Pessoa>(filtro).ToList();

            pessoas.ForEach(x =>
            {
                Console.WriteLine(x.Nome);
            });
        }

    }
}
