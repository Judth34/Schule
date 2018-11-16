function duckCount() {
    

    return duckCountRec(0, 0, arguments)
    
    function duckCountRec(idx, calls, arg) {
        if (idx > arg.length - 2) {
            console.log(arg[idx]);
            if (Object.hasOwnProperty.call(arg[idx], 'quack') && arg[idx]['quack'] == true) return calls + 1;
        }
        else {
            if (Object.hasOwnProperty.call(arg[idx], 'quack') && arg[idx]['quack'] == true) calls++;
            return duckCountRec(idx + 1, calls, arg);
        }
        
    }
}


console.log(duckCount({ quack: false }, { quack: true }, { quack: true }, { quack: true }));
console.log("asdf");