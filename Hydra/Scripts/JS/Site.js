﻿$("input[data-autocomplete-source]").each(function () {
    $.widget("custom.catcomplete", $.ui.autocomplete, {
        _create: function () {
            this._super();
            this.widget().menu("option", "items", "> :not(.ui-autocomplete-category)");
        },
        _renderMenu: function (ul, items) {
            var that = this,
                currentCategory = "";
            $.each(items, function (index, item) {
                var li;
                if (item.category !== currentCategory) {
                    ul.append("<li class='ui-autocomplete-category'>" + item.category + "</li>");
                    currentCategory = item.category;
                }
                li = that._renderItemData(ul, item);

                if (item.category) {
                    li.attr("aria-label", item.category + " : " + item.label);
                }
            });
        }
    });
    var target = $(this);
    target.catcomplete({
        delay: 0,
        source: target.attr("data-autocomplete-source")
    });
});

$("#productSearch").submit(function (event) {
    event.preventDefault();
    var form = $(this);
    $("#productSearch").load(form.attr("action"), form.serialize());
});