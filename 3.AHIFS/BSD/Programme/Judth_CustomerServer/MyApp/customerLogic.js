module.exports = function () {
    var allCustomers = [];
    var id = 0;
    return {
        register: _register,
        login: _login,
        customerIsOnline: _customerIsOnline,
        logout: _logout,
        remove: _removeCustomer,
        userToString: _userToString
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
            throw "1";
        }
        if (allCustomers.some(function (e) {
            return (e.userName == userName) && (e.online == true);
        }))throw "2";
        
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
            lastName: lastname,
            userName: userName,
            password: password,
            id : null,
            online : false
        }
        if (userNameIsNotUnique(userName))
            throw "3";
        
        allCustomers.push(newCustomer);
        return _login(userName, password);
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

    function _removeCustomer(userName){
        allCustomers.length;
        var user = _getUserWithUserName(userName);
        if (user == undefined)
            throw "1";
        _deleteCustomerFromAllCustomers(user);
        var id = user.id;
        user = undefined;
        return id;
    }

    function _userToString(id){
        var user = _getUserWithId(id);
        if (user == undefined) throw "user does not exsist";
        return user.firstName + " " + user.lastName + " " + id;
    }

    function _deleteCustomerFromAllCustomers(customer){
        var idx = 0;
        var result = false;
        while (!result && idx < allCustomers.length) {
            result = allCustomers[idx] == customer;
            idx++;
        }

        if (result) {
            while (idx < allCustomers.length) {
                allCustomers[idx - 1] = allCustomers[idx];
                idx++;
            }
            allCustomers.length=  allCustomers.length - 1;
        }
    }
}();