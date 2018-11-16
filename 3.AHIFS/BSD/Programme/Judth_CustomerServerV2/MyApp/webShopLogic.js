
module.exports = function () {
    var customer = require('./customerLogic.js');
    var items = require('./itemLogic.js');
    var customer = require('./customerLogic.js');
    var onlineCustomers = [];
    var filepathArticles = ".\\allArticles.txt";
    var fs = require("fs");
    var availableArticles = [];
    var lastFileRead = null;
    
    
    return {
        registerCustomer: _registerCustomer,
        login: _login,
        addItem: _addItem,
        getItems: _getItems,
        logout: _logout,
        removeCustomer: _removeCustomer,
        userToString: _UserToString,
        getArticles: _getAllArticles,
        addAvailableArticle: _addAvailableArticle
    }
    
    function _logout(id) {
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
    
    function _removeCustomer(userName) {
        var id = customer.remove(userName);
        items.deleteAll(id);
    }
    
    function _UserToString(id) {
        return customer.userToString(id);
    }
    
    function _addAvailableArticle(newArticle) {
        availableArticles.push(newArticle);
        var allArticleCsv = _parseAllArticleToCsv();
        fs.writeFileSync(filepathArticles, allArticleCsv);
    }
    
    function Article(articleName, price, quantity, imgUrl) {
        this.articleName = articleName;
        this.price = price;
        this.quantity = quantity;
        this.imgUrl = imgUrl;
    }
    
    function _getAllArticles() {
        try {
                var stats = fs.statSync(filepathArticles);

                if (lastFileRead < stats.mtime || lastFileRead == null) {
                    var allFileData = fs.readFileSync(filepathArticles, "utf-8");
                    var allavailableArticles = _getAllArticlesFromString(allFileData);
                    availableArticles = allavailableArticles;
                    lastFileRead = new Date();
                }
        } catch (ex) {
            console.log("Error:" + ex);
            return "not items available";
        }
        
        return availableArticles;
    }

    function _getAllArticlesFromString(allDataString){
        var allArticleStrings = allDataString.split(";");
        var allArticle = [];
        
        allArticleStrings.forEach(function (e) {
            var properties = e.split(',');
            if (properties[0] != undefined && properties[1] != undefined && properties[2] != undefined && properties[3] != undefined) {
                if (properties[0] != "" && properties[1] != "" && properties[2] != "" && properties[3] != "") {
                    var newArticle = new Article(properties[0], properties[1], properties[2], properties[3]);
                    allArticle.push(newArticle);
                }
            }
                
        });

        return allArticle;
    }

    function _parseAllArticleToCsv(){
        var allArticleCsv = ""; 
        availableArticles.forEach(function (e, index) {
            allArticleCsv += e.articleName + "," + e.price + "," + e.quantity + "," + e.imgUrl + ";" + "\n";
        });
        return allArticleCsv;
    }
}();