﻿
module.exports = function () {
    var customer = require('./customerLogic.js');
    var items = require('./itemLogic.js');
    var customer = require('./customerLogic.js');
    var onlineCustomers = [];
    return {
        registerCustomer: _registerCustomer,
        login: _login,
        addItem: _addItem,
        getItems: _getItems,
        logout: _logout,
        removeCustomer: _removeCustomer,
        userToString: _UserToString
    }
    
    function _logout(id){
        customer.logout(id);
    }    

    function _getItems(id) {
        if (!customer.customerIsOnline(id))
            throw "This customer does not excist!";
        return items.getItems(id);
    }
    
    function _addItem(item, quantity, id) {
        if (customer.customerIsOnline(id))
            items.addItem(item, quantity, id);
        else
            throw "This customer does not excist!";
    }
    function _login(userName, password) {
        var id = customer.login(userName, password);
        return id;
    }
    function _registerCustomer(firstName, lastname, userName, password) {
        return customer.register(firstName, lastname, userName, password);
    }

    function _removeCustomer(userName){
        var id = customer.remove(userName);
        items.deleteAll(id);
    }

    function _UserToString(id){
        return customer.userToString(id);
    }

}();