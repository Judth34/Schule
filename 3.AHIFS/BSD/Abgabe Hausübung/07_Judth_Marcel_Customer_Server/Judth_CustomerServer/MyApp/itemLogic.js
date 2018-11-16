module.exports = function () {
    var allItems = [];
    return {
        addItem: _addItem,
        getItems: _getItems
    }
    
    function _addItem(item, quantity, id) {
        if (isNaN(quantity))
            throw "quantity is not a number!";
        if (allItems[id] == undefined)
            allItems[id] = [];
        var objItem = _itemAlreadyAdded(allItems[id], item);
        if (objItem.length > 0)
            objItem[0].quantity = parseInt(objItem[0].quantity) + parseInt(quantity);
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