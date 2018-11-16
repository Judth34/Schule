module.exports = (function (message,name) {
    this.message = message;

    if (name) {
        if (typeof name == "string")
            this.name = name;
    }else
            this.name = "Default Session Exception";

    this.toString = function () {
        return this.name + " : " + this.message;
    }
});
