﻿using FN.Store.UI.Models;
using System.Collections.Generic;
using System.Data.Entity;
using FN.Store.UI.Infra.Helpers;

namespace FN.Store.UI.Data
{
    internal class DbInitializer : CreateDatabaseIfNotExists<FNStoreDataContext>
    {
        protected override void Seed(FNStoreDataContext context)
        {
            var alimento = new TipoDeProduto { Nome = "Alimento" };
            var higiene = new TipoDeProduto { Nome = "Higiene" };
            var eletronico = new TipoDeProduto { Nome = "Eletronico" };
            var limpeza = new TipoDeProduto { Nome = "Limpeza" };

            var produtos = new List<Produto> {
                new Produto {  Nome= "Picanha", Preco = 70.5M, Qtde = 150, TipoDeProduto = alimento },
                new Produto {  Nome= "Iogurte", Preco = 10.5M, Qtde = 250, TipoDeProduto = alimento },
                new Produto {  Nome= "Pasta de dente", Preco = 9.5M, Qtde = 250, TipoDeProduto = higiene},
                new Produto {  Nome= "Sabonete", Preco = 5.5M, Qtde = 1250, TipoDeProduto = higiene},
                new Produto {  Nome= "Desinfetante", Preco = 8.99M, Qtde = 520, TipoDeProduto = limpeza },
                new Produto {  Nome= "Detergente", Preco = 4.49M,  Qtde = 1520, TipoDeProduto = limpeza },
                new Produto {  Nome= "Telefone sem fio", Preco = 125.15M, Qtde = 85, TipoDeProduto = eletronico }
            };

            context.Produtos.AddRange(produtos);

            context.Usuarios.AddRange(new List<Usuario>{
                new Usuario
                {
                    Nome = "Kleberton Camargo",
                    Email = "kleberton6@gmail.com",
                    Senha = "123456".Encrypt()
                },
                new Usuario
                {
                    Nome = "Eliane B. Camargo",
                    Email = "eliane@gmail.com",
                    Senha = "123456@qwr#".Encrypt()
                }

            });

            context.SaveChanges();
        }
    }
}