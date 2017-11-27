using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Loja.Models
{
    public class Carrinho
    {
        public List<Produto> Produtos { get; set; }
        public string Endereco { get; set; }
        public long Id { get; set; }

        public Carrinho()
        {
            this.Produtos = new List<Produto>();
        }

        public void Adiciona(Produto produto)
        {
            this.Produtos.Add(produto);
        }

        public void Remove(long id)
        {
            Produto produto = Produtos.FirstOrDefault(p => p.Id == id);

            Produtos.Remove(produto);
        }

        public void Troca(Produto produto)
        {
            Remove(produto.Id);
            Adiciona(produto);
        }

        public void TrocaEndereco(string endereco)
        {
            this.Endereco = endereco;
        }
		
		public void TrocaQuantidade(Produto produto)
        {
            Produto produtoCarregado = Produtos.FirstOrDefault(p => p.Id == produto.Id);

            produtoCarregado.Quantidade = produto.Quantidade;
        }

        public string ToXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Carrinho));
            StringWriter stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(writer, this);
                return stringWriter.ToString();
            }
        }
    }
}
