ko.bindingHandlers.slideVisible = {
    init: function (element, valueAccessor) {
        var value = ko.unwrap(valueAccessor());
        $(element).toggle(value);
    },
    update: function (element, valueAccessor, allBindings) {
        // 获取属性值
        var value = valueAccessor();

        // 获取当前属性值
        var valueUnwrapped = ko.unwrap(value);

        // 从当前绑定上下文的其它上下文获取属性值
        var duration = allBindings.get('slideDuration') || 400; // 400ms is default duration unless otherwise specified

        // 操控DOM元素
        if (valueUnwrapped == true)
            $(element).slideDown(duration); // Make the element visible
        else
            $(element).slideUp(duration);   // Make the element invisible
    }
};

ko.bindingHandlers.hasFocus = {
    init: function (element, valueAccessor) {
        $(element).focus(function () {
            var value = valueAccessor();
            value(true);
        });
        $(element).blur(function () {
            var value = valueAccessor();
            value(false);
        });
    },
    update: function (element, valueAccessor) {
        var value = valueAccessor();
        if (ko.unwrap(value))
            element.focus();
        else
            element.blur();
    }
};