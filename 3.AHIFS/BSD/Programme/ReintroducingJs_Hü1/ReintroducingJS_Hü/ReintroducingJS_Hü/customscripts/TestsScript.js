function test() {
    function f01(paramx) {
        console.log("Here is f01:" + paramx);
    }

    var a = f01;

    a({ r: [0, 1, 2, 3] });

}

function hallo() {
    console.log("hallo aus der TstsScripts");
}