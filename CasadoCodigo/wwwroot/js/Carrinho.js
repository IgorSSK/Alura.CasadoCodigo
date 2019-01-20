class Carrinho {

    clickIncremento(btn) {

        let data = this.getData(btn);
        data.Quantidade++;
        this.postQuantidade(data);
   
    }

    clickDecremento(btn) {

        let data = this.getData(btn);
        data.Quantidade--;
        this.postQuantidade(data);

    }

    updateQuantidade(input) {

        let data = this.getData(input);
        this.postQuantidade(data);

    }

    getData(elemento) {
        var linhaDoItem = $(elemento).parents('[item-id]');
        var itemId = $(linhaDoItem).attr('item-id');
        var novaQtde = $(linhaDoItem).find('input').val();

        return {
            Id: itemId,
            Quantidade: novaQtde
        };
    }
    
    postQuantidade(data) {

        let token = $('[name=__RequestVerificationToken]').val();
        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/pedido/updatequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function(response){
            var itemPedido = response.itemPedido;
            var linhaItem = $('[item-id=' + itemPedido.id + ']');
            linhaItem.find('input').val(itemPedido.quantidade);
            linhaItem.find('[subtotal]').html((itemPedido.subtotal).duasCasas());
            let carrinhoViewModel = response.carrinhoViewModel;
            $('[numero-itens]').html('Total:' + carrinhoViewModel.item.length + ' itens');
            $('[total]').html((carrinhoViewModel.total).duasCasas());

            if (itemPedido.quantidade === 0) {
                linhaItem.remove();
            }
           

        });
    }

}
Number.prototype.duasCasas = function () { return this.toFixed(2).replace('.', ','); } 
var carrinho = new Carrinho();