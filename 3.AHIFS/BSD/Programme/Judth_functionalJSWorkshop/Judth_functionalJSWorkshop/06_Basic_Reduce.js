function countWords(inputWords) {
    var result = {};
    var callbackFu = function (previosValue, currentValue, currentIndex, array) {          
            if (result[currentValue] != null)
                result[currentValue]++;
            else
                result[currentValue] = 1;
    }
    
    inputWords.reduce(callbackFu, result);
    return result;
}

module.exports = countWords


function countWords(arr) {
    return arr.reduce(function (countMap, word) {
        countMap[word] = ++countMap[word] || 1 // increment or initialize to 1
        return countMap
    }, {}) // second argument to reduce initialises countMap to {}
}

module.exports = countWords