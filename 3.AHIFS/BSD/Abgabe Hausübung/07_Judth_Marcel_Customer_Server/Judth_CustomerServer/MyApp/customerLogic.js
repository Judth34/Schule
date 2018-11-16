module.exports = function () {
    var allCustomers = [];
    var id = 0;
    return {
        register: _register,
        login: _login,
        customerIsOnline: _customerIsOnline,
        logout: _logout
    }
    function _customerIsOnline(id) {
        return allCustomers.some(function (e) {
            return (e.id == id) && (e.online == true);
        });
    }
    
    function _logout(id){
        var user = _getUserWithId(id);
        user.online = false;
    }

    function _login(userName, password) {
        if (!allCustomers.some(function (e) {return ((userName == e.userName) && (password == e.password));})){
            throw userName + " is not registered!";
        }
        if (allCustomers.some(function (e) {
            return (e.userName == userName) && (e.online == true);
        }))throw "Customer is already online!";
        
        var customer = _customerAlreadyGotId(userName, password);
        var newId;
        if (customer != undefined) {
            newId = customer.id;
            customer.online = true;
        }
        else {
            newId = ++id;
            var user = _getUserWithUserName(userName);
            user.online = true;
            user.id = newId;
            
        }
        return newId;
    }
    
    function _customerAlreadyGotId(userName, password){
        return (allCustomers.filter(function (e) {
            return ((userName == e.userName) && (password == e.password) && (e.id != null));
        }))[0];
    }

    function _register(firstName, lastname, userName, password) {
        var newCustomer = {
            firstName: firstName,
            lastname: lastname,
            userName: userName,
            password: password,
            id : null,
            online : false
        }
        if (userNameIsNotUnique(userName))
            throw "Username already registered!";
        
        if (customerAlreadyRegistered(newCustomer))
            throw "Customer already registered!";
        
        allCustomers.push(newCustomer);
    }
    
    function customerAlreadyRegistered(customer) {
        return allCustomers.some(function (e) {
            return (e == customer);
        })
    }
    
    function userNameIsNotUnique(username) {
        return allCustomers.some(function (e) {
            return (e.userName == username);
        })
    }

    function _getUserWithId(id){
        return allCustomers.filter(function (e) {
            return (e.id == id);
        })[0];
    }

    function _getUserWithUserName(username) {
        return allCustomers.filter(function (e) {
            return (e.userName == username);
        })[0];
    }
}();