function test() {
    var testvar;

    //numbers
    testvar = 12345;
    output(testvar);

    //Strings
    testvar = "hallo"
    output(testvar);

    //booleans
    testvar = true;
    output(testvar);

    //object
    testvar = new Array(1, 2, 3, 4, 5);
    output(testvar);

    //leeres object
    testvar = {};
    output(testvar);

    testvar = f001;
    output(testvar);
}

function output(ausgabe) {
    console.log(ausgabe + ", Datentyp: " + typeof (ausgabe));
}

function f001() {
    console.log()
}