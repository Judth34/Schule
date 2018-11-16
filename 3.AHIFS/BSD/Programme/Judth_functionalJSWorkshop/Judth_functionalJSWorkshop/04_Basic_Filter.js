function getShortMessages(messages) {
    messages = messages.filter(function (e) { return (e.message.length < 50) });
    
    
    var result = messages.map(function (item) { return item.message});
    return result;
}
module.exports = getShortMessages