function pupil(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
    fullname: "Seas";
    var result = true;

    this.getFullName = function () { return firstName + " " + lastName;};
}

var man = new pupil("Hans", "Peter");
console.log(man.getFullName());
man.firstName = "Hansi";
man.getFullName = "Name geändert";


var Pupil = (function (firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.fu = function () { };
     return firstName + " " + lastName;
})("Pupil", "12345")


Pupil("Pupil", "54321");

var result = true;
