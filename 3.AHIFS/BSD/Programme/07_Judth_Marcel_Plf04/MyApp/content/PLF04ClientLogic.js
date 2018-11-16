

var clientLogic = (function () {
    function _load(){
        document.getElementById("btnGenerateTable").addEventListener("click", _postZeilenSpalten);
    }
    
    function  _reqListener() {
        var allZeilen = this.responseText.split("\n");
        var innerHtml = "";
        var data = [];
        var tableBody = document.getElementById("tableBody")

        allZeilen.forEach(function (e) {
            innerHtml += "<tr>";
            data = e.split(";");
            data.forEach(function (el) {
                innerHtml += "<td>" + el + "</td>";
            });
            innerHtml + "</tr>";
        });

        tableBody.innerHTML = innerHtml;
    }
    
    function _postZeilenSpalten(){        
        var zeilen = document.getElementById("Zeilen").value;
        var spalten = document.getElementById("Spalten").value;
        
        if (zeilen < 1 || spalten < 1) {
            alert("Sorry your input values are not valid try again!");
        }
        else {
            var XHR = new XMLHttpRequest();
            
            var body = zeilen + ";" + spalten + "\n";
            
            XHR.addEventListener("load", function (event) {
                var callingObject = {};
                callingObject.responseText = event.target.responseText;
                _reqListener.call(callingObject);
            });
            
            XHR.open("POST", "http://localhost:1337/generateTableData");
            XHR.setRequestHeader("Content-Type", "Judth_CSVPT");
            XHR.send(body);
        }        
    }

    return {
        load: _load
    }
})();

window.onload = function (){
    clientLogic.load();
}