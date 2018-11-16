

var clientLogic = (function () {

    function  _reqListener() {
        var myArticleList = document.getElementById('ItemsavailableArticles');
        console.log(myArticleList);
        var allArticles = JSON.parse(this.responseText);
        var myNode = document.getElementById("ItemsavailableArticles");
        while (myNode.firstChild) {
            myNode.removeChild(myNode.firstChild);
        }
        for (var idx = 0; idx < allArticles.length; idx++) {
            var article = allArticles[idx];
            _appendItem(myNode, article);
        }
        if (allArticles.length == 0) {
            var noItmems = document.createElement("li");
            noItmems.appendChild(document.createTextNode("No articles available at the moment"));
            myNode.appendChild(noItmems);
        }
    }
    
    function _appendItem(parentElement, article) {
        var image = document.createElement('img');
        image.setAttribute('src', './images/logo.png');
        image.src = article.imgUrl; // Alternative!   
        
        var li = document.createElement("li");
        li.classList.add('availableItem');
        li.appendChild(image);
        var txt = document.createElement('lable');
        var lableName = document.createElement('lable');
        var lablePrice = document.createElement('lable');
        var lableQuantity = document.createElement('lable');
        lableName.classList.add('availableItemText');
        
        lableName.appendChild(document.createTextNode(article.articleName));
        lablePrice.appendChild(document.createTextNode(article.price + "€"));
        lableQuantity.appendChild(document.createTextNode(" " + article.quantity + " pices in stock"));
        lableName.setAttribute("id", "nameAvailableArticle");
        lablePrice.setAttribute("id", "priceAvailableArticle");
        lableQuantity.setAttribute("id", "quantityAvailableArticle");
        
        
        txt.appendChild(lableName);
        txt.appendChild(lablePrice);
        txt.appendChild(lableQuantity);
        
        txt.classList.add('availableItemText');
        li.appendChild(txt);
        parentElement.appendChild(li);
    }
    
    function _postArticleWWWUrlEncoded() {
        var oReq = new XMLHttpRequest();
        //oReq.addEventListener("load", reqListener);
        var name = document.getElementById("articleName").value;
        var price = document.getElementById("articlePrice").value;
        var quantity = document.getElementById("articleQuantity").value;
        var url = document.getElementById("articleImgUrl").value;
        
        var item = "articleName=" + name + "&price=" + price + "&quantity=" + quantity + "&imgUrl=" + url;
        oReq.open("POST", "http://localhost:1337/addNewAvailableArticle");
        oReq.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
        oReq.send(item);
        
        oReq.onreadystatechange = function () {
            _reqListener.call(oReq);
        }
    }
    
    function Article(articleName, price, quantity, imgUrl) {
        this.articleName = articleName;
        this.price = price;
        this.quantity = quantity;
        this.imgUrl = imgUrl;
    }
    
    function _postArticleJson() {
        var oReq = new XMLHttpRequest();
        //oReq.addEventListener("load", reqListener);
        var name = document.getElementById("articleName").value;
        var price = document.getElementById("articlePrice").value;
        var quantity = document.getElementById("articleQuantity").value;
        var url = document.getElementById("articleImgUrl").value;
        
        var item = new Article(name, price, quantity, url);
        oReq.open("POST", "http://localhost:1337/addNewAvailableArticle");
        oReq.setRequestHeader("Content-Type", "application/json");
        oReq.send(JSON.stringify(item));
        
        oReq.onreadystatechange = function () {
            _reqListener.call(oReq);
        }
    }
    
    function _postArticleMultiPartFormat(event) {
        var XHR = new XMLHttpRequest();
        
        var form = document.getElementById("myForm");
        
        console.log(form);
        //Bindd the FormData object and the form element
        var FD = new FormData(form);
        
        //Define what happens on successful data submission
        XHR.addEventListener("load", function (event) {
            var callingObject = {};
            callingObject.responseText = event.target.responseText;
            _reqListener.call(callingObject);
        });
        
        //Define what happens in case of error
        XHR.addEventListener("error", function (event) {

        });
        
        //Set up our request 
        XHR.open("POST", "addNewAvailableArticle");
        
        //The data sent is what the user provided in the form
        XHR.send(FD);
    }
    
    function _makeHTTPCall() {
        var oReq = new XMLHttpRequest();
        oReq.addEventListener("load", _reqListener);
        oReq.open("GET", "http://localhost:1337/getAllArticles");
        oReq.send();
    }
    function _load(){
        document.getElementById("btnAddAvailArticleMultiPart").addEventListener("click", _postArticleMultiPartFormat);
        document.getElementById("btnAddAvailArticleJson").addEventListener("click", _postArticleJson);
        document.getElementById("btnAddAvailArticleUrl").addEventListener("click", _postArticleWWWUrlEncoded); 
    }

    return {
        reqListener: _reqListener,
        appendItem: _appendItem,
        makeHTTPCall: _makeHTTPCall,
        postArticleJson: _postArticleJson,
        postArticleMultiPartFormat: _postArticleMultiPartFormat,
        postArticleWWWUrlEncoded: _postArticleWWWUrlEncoded,
        load: _load
    }
})();

window.onload = function () {
    clientLogic.makeHTTPCall();
    clientLogic.load();
}