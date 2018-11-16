module.exports = function () {
    var allCustomers = [];
    var onlineCustomers = [];
    return {
        register: _register,
        login: _login,
        customerIsOnline: _customerIsOnline
    }
    function _customerIsOnline(id) {
        return onlineCustomers.some(function (e) {
            return (e.id == id);
        })
    }

    function _login(id, userName){
        if (onlineCustomers.some(function (e) {
        return (e.userName == userName);
        }))throw "Customer is already online!";
        onlineCustomers.push({
            userName: userName,
            id: id
        });
    }    

    function _register(firstName, lastname, userName, password) {
        var newCustomer = {
            firstName: firstName,
            lastname: lastname,
            userName: userName,
            password: password,
        }
        if (userNameIsNotUnique(userName))
            throw "Username already registered!";
        
        if (customerAlreadyRegistered(newCustomer))
            throw "Customer already registered!";

        allCustomers.push(newCustomer);
    }

    function customerAlreadyRegistered(customer){
        return allCustomers.some(function (e){
            return (e == customer);
        })
    }

    function userNameIsNotUnique(username){
        return allCustomers.some(function (e){
            return (e.userName == username);
        })
    }
}();