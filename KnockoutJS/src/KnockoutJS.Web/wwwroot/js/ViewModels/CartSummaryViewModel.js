function CartSummaryViewModel(model) {
    var self = this;

    self.cart = model;

    for (var i = 0; i < self.cart.cartItems.length; i++) {
        var cartItem = self.cart.cartItems[i];
        cartItem.quantity = ko.observable(cartItem.quantity).extend({ subTotal: cartItem.book.salePrice });
    }

    self.cart.cartItems = ko.observableArray(self.cart.cartItems);

    self.cart.total = self.cart.cartItems.total();

    self.updateCartItem = function (cartItem) {
        var isNewItem = true;

        for (var i = 0; i < self.cart.cartItems().length; i++) {
            if (self.cart.cartItems()[i].id === cartItem.id) {
                self.cart.cartItems()[i].quantity(cartItem.quantity);
                isNewItem = false;
                break;
            }
        }

        if (isNewItem) {
            cartItem.quantity = ko.observable(cartItem.quantity)
                .extend({ subTotal: cartItem.book.salePrice });
            self.cart.cartItems.push(cartItem);
        }
    };

    self.deleteCartItem = function (cartItem) {
        for (var i = 0; i < self.cart.cartItems().length; i++) {
            if (self.cart.cartItems()[i].id === cartItem.id) {
                self.cart.cartItems.remove(self.cart.cartItems()[i]);
                break;
            }
        }
    };

    self.showCart = function () {
        displayCartItems();
    };

    self.fadeIn = function (element) {
        setTimeout(function () {
            displayCartItems();
            $(element).slideDown(function () {
                setTimeout(function () {
                    //$("cart").popover("hide");
                }, 2000);
            });
        }, 100);
    };

    function displayCartItems() {
        alert($("#cart-summary").html());
    }
}

if (cartSummaryData !== undefined) {
    var cartSummaryViewModel = new CartSummaryViewModel(cartSummaryData);
    ko.applyBindings(cartSummaryViewModel, document.getElementById("cart-details"));
}
else {
    $(".body-content").prepend('<div class="alert alert-danger"><strong>错误！</strong>没有找到购物车');
}