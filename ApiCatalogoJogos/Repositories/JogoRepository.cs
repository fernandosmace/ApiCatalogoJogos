using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("2f9ff41f-59a0-4b8f-ac34-2d010da38cd9"), new Jogo{Id = Guid.Parse("2f9ff41f-59a0-4b8f-ac34-2d010da38cd9"), Nome = "The Last of Us 1", Produtora = "Naughty Dog", Preco = 100}},
            {Guid.Parse("a88f6ead-d170-4322-a2d2-64e417648fba"), new Jogo{Id = Guid.Parse("a88f6ead-d170-4322-a2d2-64e417648fba"), Nome = "The Last of Us 2", Produtora = "Naughty Dog", Preco = 110}},
            {Guid.Parse("6c47687a-7386-4565-94fb-f35230ab3680"), new Jogo{Id = Guid.Parse("6c47687a-7386-4565-94fb-f35230ab3680"), Nome = "The Last of Us 3", Produtora = "Naughty Dog", Preco = 120}},
            {Guid.Parse("af05a492-af1d-4e87-80e0-688954dc609b"), new Jogo{Id = Guid.Parse("af05a492-af1d-4e87-80e0-688954dc609b"), Nome = "The Last of Us 4", Produtora = "Naughty Dog", Preco = 130}},
            {Guid.Parse("d558702b-26c7-4036-ad66-85176617754c"), new Jogo{Id = Guid.Parse("d558702b-26c7-4036-ad66-85176617754c"), Nome = "The Last of Us 5", Produtora = "Naughty Dog", Preco = 140}},
            {Guid.Parse("f74ad4c8-62fc-495b-9d81-1e6dae4027a8"), new Jogo{Id = Guid.Parse("f74ad4c8-62fc-495b-9d81-1e6dae4027a8"), Nome = "The Last of Us 6", Produtora = "Naughty Dog", Preco = 150}},
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }
        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
        }
    }
}
