function duckCount() {
    
    return (Array.prototype.slice.call(arguments).filter(function (element) { return Object.prototype.hasOwnProperty.call(element, 'quack') })).length;
}

module.exports = duckCount