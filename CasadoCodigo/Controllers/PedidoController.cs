using CasadoCodigo.Models;
using CasadoCodigo.Models.ViewModel;
using CasadoCodigo.Repositories;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasadoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Carrossel()
        {
            return View(produtoRepository.GetProdutos());
        }

        public IActionResult Cadastro()
        {
            var pedido = pedidoRepository.GetPedido();

            if (pedido == null)
            {
                return RedirectToAction("Carrossel");
            }

            return View(pedido.Cadastro);
        }

        public IActionResult Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                pedidoRepository.AddItem(codigo);
            }

            List<ItemPedido> pedido = pedidoRepository.GetPedido().Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(pedido);
            return View(carrinhoViewModel);
        }

        [HttpPost]
        public IActionResult Resumo(Cadastro cadastro)
        {
            var pedido = pedidoRepository.GetPedido();
            return View(pedido);
        }

        [HttpPost]
        public UpdateQuantidadeResponse UpdateQuantidade([FromBody] ItemPedido itemPedido)
        {
            return pedidoRepository.UpdateQuantidade(itemPedido);
        }
    }
}
