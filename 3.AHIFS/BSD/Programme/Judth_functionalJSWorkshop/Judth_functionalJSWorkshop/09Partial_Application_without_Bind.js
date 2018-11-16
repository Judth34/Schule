var slice = Array.prototype.slice

function logger(namespace) {
      // SOLUTION GOES HERE
    var result = function (message) { 
        console.log(namespace + " " + message);
    };

    return result;
}

//var info = logger('INFO:');
//info('this is an info message');
//// INFO: this is an info message

//var warn = logger('WARN:');
//warn('this is a warning message', 'with more info');
//// WARN: this is a warning message with more info
module.exports = logger