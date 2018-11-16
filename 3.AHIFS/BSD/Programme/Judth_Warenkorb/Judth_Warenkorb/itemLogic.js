module.exports = function () {
    var allItems = [];
    return {
        addItem: _addItem,
        getItems: _getItems
    }

    function _addItem(item, quantity, id){
        if (allItems[id] == undefined)
            allItems[id] = [];
        var objItem = _itemAlreadyAdded(allItems[id], item);
        if (objItem.length > 0)
            objItem[0].quantity = objItem[0].quantity + quantity;
        else
            allItems[id].push({
                "item": item,
                "quantity": quantity
            });
    }

    function _getItems(id) {
        return allItems[id];
    }

    function _itemAlreadyAdded(allCustomerItems, item) {
        return allCustomerItems.filter(function (e) {
            return (e.item == item);
        });
    }
}();