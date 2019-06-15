ko.bindingHandlers.appendToHref = {
    init: function (element, valueAccessor) {
        var currentHref = $(element).attr('href');
        $(element).attr('href', currentHref + '/' + valueAccessor());
    }
};

ko.bindingHandlers.isDirty = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContent) {
        var originalValue = ko.unwrap(valueAccessor());

        var interceptor = ko.pureComputed(function () {
            return (bindingContent.$data.showButton !== undefined && bindingContent.$data.showButton) || originalValue !== valueAccessor()();
        });

        ko.applyBindingsToNode(element, {
            visible: interceptor
        });
    }
};

//ko扩展方法
ko.extenders.subTotal = function (target, multiplier) {
    target.subTotal = ko.observable();

    function calculateTotal(newValue) {
        target.subTotal((newValue * multiplier).toFixed(2));
    }

    calculateTotal(target());

    target.subscribe(calculateTotal);

    return target;
};

ko.observableArray.fn.total = function () {
    return ko.pureComputed(function () {
        var runningTotal = 0;

        for (var i = 0; i < this().length; i++) {
            runningTotal += parseFloat(this()[i].quantity.subTotal());
        }

        return runningTotal.toFixed(2);
    }, this);
};