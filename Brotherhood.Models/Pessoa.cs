using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Brotherhood.Models
{
    public class Pessoa
    {
        //[DbColumn(IsIdentity = true, IsPrimary = true)]
        public ObjectId Id { get; set; }
        public string CPF { get; set; }
        //[DbColumn]
        //public string RG { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public bool Ativo { get; set; }
        public List<Servico> Servicos { get; set; }
        
            // TODO add the following fields
        //RG, RGEmissor, Nome, Endereco, TelefoneFixo, TelefoneCelular, DiasDisponiveis, InicioDasAtividades, Observacoes, ServicoID, Email
    }
}
