function CartDetailViewModel(model) {
    var self = this;
    self.sending = ko.observable(false);
    self.cart = model;

    for (var i = 0; i < self.cart.cartItems.length; i++) {
        self.cart.cartItems[i].quantity = ko.observable(self.cart.cartItems[i].quantity)
            .extend({ subTotal: self.cart.cartItems[i].book.salePrice });
    }

    self.cart.cartItems = ko.observableArray(self.cart.cartItems);

    self.cart.total = self.cart.cartItems.total();

    self.cartItemBeingChanged = null;

    self.deleteCartItem = function () {
        self.sending(true);
        self.cartItemBeingChanged = cartItem;
        $.ajax({
            url: "http://localhost:64962/api/cartitem/delete",
            type: 'delete',
            contentType: 'application/json',
            data: ko.toJSON(cartItem),
            success: self.successfulDelete,
            error: self.errorSave,
            complete: function () {
                self.sending(false);
            }
        });
    };

    self.successfulDelete = function (data) {
        var msg = '<div class="alert alert-success"><strong>Success!</strong> The item has been';
        $('.body-content').prepend(msg + 'deleted from your cart.</div>');
        self.cart.cartItem.remove(self.cartItemBeginChanged);
        cartSummaryViewModel.deleteCartItem(ko.toJS(self.cartItemBeginChanged));
        self.cartItemBeginChanged = null;
    };

    self.errorSave = function () {
        var msg = '<div class="alert alert-danger"><strong>Error!</strong> There was an error updating the item to your cart.';
        $('.body-content').prepend(msg + '</div>');
    };

    self.fadeOut = function (element) {
        $(element).fadeOut(1000, function () {
            $(element).remove();
        });
    };
}