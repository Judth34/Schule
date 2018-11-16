var guessedWord = new Array("__", "__", "__", "__", "__", "__", "__");
var idx = 0;
var startX;
var starY;
var gameOver = false;

function check1(letter) {
    var word = ["H", "A", "N", "G", "M", "A", "N"];
    var canvas = document.getElementById("myCanvas");
    var context = canvas.getContext("2d");

    var checkLetter = {
        checkFu: check,
    }

    function check() {
        var result = false;
        var i = 0;
        if (!gameOver) {
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


            if (!result) drawLineError();
        }
    };

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
    };


    function drawLineError() {
        idx++;
        switch (idx) {
            case 1: {
                //1. Fehler
                startX = 0;
                starY = canvas.height;
                
                drawLine(40, canvas.height - 40);
                startX = 80;
                drawLine(40, canvas.height - 40);
                break;
            }
            case 2: {
                //2.Fehler
                startX = 40;
                starY -= 40;
                
                drawLine(startX, starY - 200);
                break;
            }
            case 3: {
                //3.Fehler
                starY -= 200;
                drawLine(canvas.width / 2, starY);
                break;
            }
            case 4: {
                //4.Fehler
                startX = canvas.width / 2;
                drawLine(startX, canvas.height / 2 - 20);
                break;
            }
            case 5: {
                //5.Fehler
                startX = canvas.width / 2;
                starY = canvas.height / 2;
                var radius = 20;
                context.beginPath();
                context.arc(startX, starY, radius, 0, 2 * Math.PI, false);
                context.lineWidth = 5;
                context.stroke();

                starY = starY + 20;
                drawLine(startX, starY + 25);
                starY = starY + 25;

                drawLine(startX + 30, starY);
                drawLine(startX - 30, starY)
                drawLine(startX, starY + 25);
                starY += 25;

                drawLine(startX + 40, starY + 40);
                drawLine(startX - 40, starY + 40);

                alert("Sorry but the game is over!!!");
                gameOver = true;
                break;
            }
            default: {
                gameOver = true;
                break;

            }

        }

    };

    function drawLine(endX, endY) {
        context.moveTo(startX, starY);
        context.lineTo(endX, endY);
        context.stroke();
    }

    return checkLetter;
}