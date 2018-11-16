function reduce(arr, fn, initial) {    
    return (function reduceRec(idx, elem) { 
        if (idx > arr.length - 1)
            return elem;
        else
            return reduceRec(idx + 1, fn(elem, arr[idx], idx, arr));
    })(0, initial);
}
module.exports = reduce