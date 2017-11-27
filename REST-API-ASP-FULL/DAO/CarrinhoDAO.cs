using Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.DAO
{
    public class CarrinhoDAO
    {
        private static Dictionary<long, Carrinho> banco = new Dictionary<long, Carrinho>();
        private static long contador = 1;

        static CarrinhoDAO()
        {
            Produto videogame = new Produto(6237, "Videogame 4", 4000, 1);
            Produto esporte = new Produto(3467, "Jogo de esporte", 60, 2);
            Carrinho carrinho = new Carrinho();
            carrinho.Adiciona(videogame);
            carrinho.Adiciona(esporte);
            carrinho.Endereco = "Rua Vergueiro 3185, 8 andar, Sao Paulo";
            carrinho.Id = 1;
            banco.Add(1, carrinho);
            banco.Add(2, carrinho);
        }

        public void Adiciona(Carrinho carrinho)
        {
            contador++;
            carrinho.Id = contador;
            banco.Add(contador, carrinho);
        }

        public Carrinho Busca(long id)
        {
            return banco[id];
        }

        public void Remove(long id)
        {
            banco.Remove(id);
        }

    }
}
