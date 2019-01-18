using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasadoCodigo.Models.ViewModel
{
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel(List<ItemPedido> Item)
        {
            this.Item = Item;
        }

        public List<ItemPedido> Item { get; }
        
        public decimal Total => Item.Sum(p => p.PrecoUnitario * p.Quantidade);

    }
}
