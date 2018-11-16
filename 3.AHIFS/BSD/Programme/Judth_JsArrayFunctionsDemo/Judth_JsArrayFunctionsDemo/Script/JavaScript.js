var a = [4, 6, 1, 5, 0];

Array.prototype.myMap = function (callbackFnc) {
    var result = [];

    for (var idx = 0; idx < this.length; idx++) {
        var y = callbackFnc(this[idx]);
        result.push(y);
    }

    return result;
};

Array.prototype.myEvery = function (callbackFnc) {
    var result = true;
    var idx = 0;

    while(idx < this.length && result){
        result = callbackFnc(this[idx]);
        idx++;
    }
    
    return result;
};



Array.prototype.myFilter = function (callbackFnc) {
    var result = [];

    for (var idx = 0; idx < this.length; idx++) {
        if (callbackFnc(this[idx])) result.push(this[idx]);
    }
    return result;
};


Array.prototype.myForEach = function (callbackFnc) {
    for (var idx = 0; idx < this.length; idx++) {
        callbackFnc(this[idx], idx, this);
    }
}

Array.prototype.mySum = function () {
    var result = 0;

    for (var idx = 0; idx < this.length; idx++) {
        result += this[idx];
    }
    return result;
}

Array.prototype.myReduce = function (callbackFnc) {
    var result = 0;
    var idx = 0;

    while (idx < this.length - 1) {
        result += callbackFnc(this[idx], this[idx + 1]);
        idx = idx + 2;
    }

    return result;
};

Array.prototype.mySort = function (compareFn) {
    var help;
    var sorted = true;
    while (sorted) {
        sorted = false;
        for (var idx = 0; idx < this.length; idx++) {
            if (compareFn(this[idx], this[idx + 1]) > 0) {
                help = this[idx];
                this[idx] = this[idx + 1];
                this[idx + 1] = help;
                sorted = true;
            }

        }
    }
}




//var b = a.myMap(function (e) { return e * -1; });

//var rtnWert = a.myEvery(function (e) { return e >= 0; });


//var d = a.myFilter(function (value) { return value > 4 });

//d.myForEach(function (element, index, array) { alert("Element: " + element + " Index: " + index + " Array: " + array) });

//alert(a.mySum());

//alert(a.myReduce(function (a, b) { return a + b; }));


//a.mySort(function (a, b) { return a - b; });
//alert(a);


var alleSchueler = [];

for (var idx = 0; idx < 5; idx++) {
    alleSchueler.push(new schueler("Schueler" + idx));
}

alert(alleSchueler.myEvery(function (e) { return (e.noten.length < 7 && e.noten.length < 3) }));



function schueler(name) {
    this.name = name;
    this.noten = [];

    for (var idx = 0; idx < rand(1, 7); idx++) {
        this.noten.push(rand(1, 5));
    }
    

    function rand(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
    }