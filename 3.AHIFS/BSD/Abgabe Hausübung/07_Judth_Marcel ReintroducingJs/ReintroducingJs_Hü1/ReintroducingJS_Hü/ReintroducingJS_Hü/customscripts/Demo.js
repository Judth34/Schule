function test01() {
    //var name = "kittens";
    //if (name == "puppies") {
    //    name += "!";
    //} else if (name == "kittens") {
    //    name += "!!";
    //} else {
    //    name = "!" + name;
    //}
    //alert(name);

    //var name = otherName || "default";
    //alert(name);

    //var obj = {
    //    name: "Marcel Judth",
    //    "for": "Max",
    //    details: {
    //        color: "orange",
    //        size: 12
    //    }
    //}

    //function Person(name, age) {
    //    this.name = name;
    //    this.age = age;
    //}

    //var person = new Person("Marcel", "12");

    //alert(person.name);
    //person.name = "Judth";
    //alert("ah");
    //alert(person.name);
    //person["age"] = "47";
    //alert(person.age);

    //var a = ["1", "2", "3"]
    //a.forEach(function(currentValue, index, array) {
    //alert(currentValue);
    //});

    //["dog", "cat", "hen"].forEach(function (currentValue, index, array) {
    //    alert(array[index]);
    //});

    //alert(avg(2, 3, 4, 5));

    //alert(avgArray([2, 3, 4, 5]));

    //var Variable1 = 1;
    //var Variable2 = 2;
    (function counter(x) {
        var Variable1 = 12;
        Variable2 = 3;
        alert(x);
        if (x < 10) counter(x + 1);
    })(2)
    alert("Variable1: " + Variable1 + ", Variable: " + Variable2);

    alert("hallo");
    alert(countChars(document.getElementById("ul1")));
}

function countChars(elm) {
    if (elm.nodeType == 3) { // TEXT_NODE
        return elm.nodeValue.length;
    }
    var count = 0;
    for (var i = 0, child; child = elm.childNodes[i]; i++) {
        count += countChars(child);
    }
    return count;
}

function avg() {
    var sum = 0;
    for (var i = 0, j = arguments.length; i < j; i++) {
        sum += arguments[i];
    }
    return sum / arguments.length;
}

function avgArray(arr) {
    var sum = 0;
    for (var i = 0, j = arr.length; i < j; i++) {
        sum += arr[i];
    }
    return sum / arr.length;
}