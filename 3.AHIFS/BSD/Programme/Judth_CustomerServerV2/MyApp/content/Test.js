function doSth(){
    var element = document.getElementById("hallo");
    var li = document.createElement("li");
    li.appendChild(document.createTextNode("hallo"));
    element.appendChild(li);
}