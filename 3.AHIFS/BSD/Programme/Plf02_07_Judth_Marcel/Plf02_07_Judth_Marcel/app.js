function cars() {
    this.car = null;
    this.Create = function (name, tankCapacity) {
        this.car = new car(name, tankCapacity);
    };
    this.CurrentCar = function () {
        return this.car;
    };
}

function car(name, tankCapacity) {
    this.tankCapacity = tankCapacity;
    this.name = name;
    this.isMoving = false;
    this.engineRuns = false;
    
    this.GetState = function () {
        var stateMoving = "moving";
        var stateRunning = "";

        if (!this.isMoving) stateMoving = "not moving";
        if (this.engineRuns) stateRunning = "on";
        else stateRunning = "off";
        
        return "Car " + "'" + this.name + "'" + " is " + stateMoving + ". Engine is " + stateRunning + ". Fuel left: " + this.tankCapacity;
    };
    this.StartEngine = function () {
        var result = true;
        if (this.tankCapacity >= 3 && this.engineRuns == false) {
            this.engineRuns = true;
            this.tankCapacity = this.tankCapacity - 3;
        }
        else {
            result = false;
        }
        return result;
    };
    
    this.StopEngine = function () {
        var result = true;
        if (this.engineRuns && this.isMoving == false) this.engineRuns = false;
        else result = false;
        return result;
    };
}


var Cars = new cars();
console.log("\n\n   >>>>CAR TEST Program >>> \n\n");
Cars.Create("Bmw", 10);


var curCar = Cars.CurrentCar();


console.log(curCar.GetState());


console.log("Try to start car. Succeess: " + curCar.StartEngine());
console.log(curCar.GetState());


console.log("Try to start car again. Success has to be false: " + curCar.StartEngine());
console.log(curCar.GetState());


curCar.StopEngine();
console.log(curCar.GetState());


curCar.StartEngine();
console.log(curCar.GetState());
