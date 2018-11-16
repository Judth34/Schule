
var idx = 0;
var centerX;
var centerY;
var word = ["H", "A", "N", "G", "M", "A", "N"];
var guessedWord = new Array("__", "__", "__", "__", "__", "__", "__");

function check(letter) {
    var result = false;
    var i = 0;
    word.forEach(function (currendValue, array, index) {
        if (currendValue == letter) {
            result = true;
            guessedWord[i] = letter;
            showWord();
            proveWin();
        }
        i++;
    })
    document.getElementById(letter).style.display = "none";


    if (!result) drawLine();
}

function showWord() {
    var value = "";
    guessedWord.forEach(function (currendValue, array, index) {
        value += currendValue;
    })

    document.getElementById("guessedWord").firstChild.nodeValue = value;
}

function proveWin() {
    var result = true;
    for (var idx = 0; idx < word.length && result; idx++) {
        if (word[idx] != guessedWord[idx]) result = false;
    }

    if (result) alert("You won - Congratulations");
}


function drawLine() {
    var canvas = document.getElementById("myCanvas");
    var context = canvas.getContext("2d");
    
    idx++;
    switch (idx) {
        case 1: {
            //1. Fehler
            centerX = 0;
            centerY = canvas.height;
            context.moveTo(centerX, centerY);
            context.lineTo(40, canvas.height - 40);
            context.lineTo(80, canvas.height);
            context.stroke();
            break;
        }
        case 2: {
            //2.Fehler
            centerX = 40;
            centerY = canvas.height - 40;
            context.moveTo(centerX, centerY);
            centerY = centerY - 200;
            context.lineTo(centerX, centerY);
            context.stroke();
            break;
        }
        case 3: {
            //3.Fehler
            context.moveTo(centerX, centerY);
            centerX = canvas.width / 2;
            context.lineTo(centerX, centerY);
            context.stroke();
            break;
        }
        case 4: {
            //4.Fehler
            context.moveTo(centerX, centerY);
            centerY = canvas.height / 2 - 20;
            context.lineTo(centerX, centerY);
            context.stroke();
            break;
        }
        case 5: {
            //5.Fehler
            centerX = canvas.width / 2;
            centerY = canvas.height / 2;
            var radius = 20;
            context.beginPath();
            context.arc(centerX, centerY, radius, 0, 2 * Math.PI, false);
            context.lineWidth = 5;
            context.stroke();

            centerY = centerY + 20;
            context.moveTo(centerX, centerY);
            centerY = centerY + 25;
            context.lineTo(centerX, centerY);
            context.stroke();

            context.lineTo(centerX + 30, centerY);
            context.moveTo(centerX, centerY);
            context.lineTo(centerX - 30, centerY);
            context.moveTo(centerX, centerY);
            centerY += 25;
            context.lineTo(centerX, centerY);


            context.moveTo(centerX, centerY);
            context.lineTo(centerX + 40, centerY + 40);
            context.moveTo(centerX, centerY);
            context.lineTo(centerX - 40, centerY + 40);
            context.stroke();
            alert("Sorry but the game is over!!!");
            break;
        }
        default: {

            break;

        }

    }
       
}