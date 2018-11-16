try {
    var CL = require('./cartLogic.js');
    var CI = CL.registerCustomer("Marcel", "Judth", "judthm", "hallo");
    CL.addItem("Fish", 1, CI);
    CL.addItem("Kartoffel", 3, CI);
    CL.addItem("Kartoffel", 2, CI);
    console.log(CL.getItems(CI));
} catch (ex) {
    console.log(ex);
}