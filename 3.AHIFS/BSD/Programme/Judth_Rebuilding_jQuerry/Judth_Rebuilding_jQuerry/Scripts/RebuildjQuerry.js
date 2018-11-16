function $(selector) {
    var result = {
        hide: hideInternal,         //keine Klammern!!! da sonst hide der Return-Wert von hideInternal wird
        show: showInternal,
        last: lastInternal,
        append: appendInternal,
    };

    function hideInternal() {
        //da es ein normales statement ist und nur eine funktion ist
        document.getElementById(selector).style.display = "none";

        //implement hide
    };

    function showInternal() {
        document.getElementById(selector).style.display = "block";
    };
    
    function lastInternal(){
        var lastElement = document.getElementsByTagName(selector)[0];
        while (lastElement.nextSibling != null) {
            lastElement = lastElement.nextSibling;
        }
        alert(lastElement);
    }

    function appendInternal(htmlTags) {
        var doc = new DOMParser();
        doc.parseFromString(htmlTags, "text/html");
        document.getElementById(selector).nextSibling = doc.body.childNodes;
    }

    return result;
}