
function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
    document.getElementById("haken").style.display = "none";
    document.getElementById("x").style.display = "none";
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    ev.target.appendChild(document.getElementById(data));
}

function checkPuzzle() {
    var result = true;
    var x = 0;


    for (var i = 0; i < 3 && result; i++) {
        if (document.getElementById("" + i + "-"+ 0).firstChild == null || document.getElementById("" + i + "-"+ 0).firstChild.id != "" + x) result = false;
        x++;
        if (result) {
            if (document.getElementById("" + i + "-" + 1).firstChild == null || document.getElementById("" + i + "-" + 1).firstChild.id != "" + x) result = false;
            x++;
            if (result) {
                if (document.getElementById("" + i + "-" + 2).firstChild == nul || document.getElementById("" + i + "-" + 2).firstChild.id != "" + x) result = false;
                x++;
            }
        }

    }

    if(result)
    {
        document.getElementById("haken").style.display = "inline";
    }
    else
    {
        document.getElementById("x").style.display = "inline";
    }
}
