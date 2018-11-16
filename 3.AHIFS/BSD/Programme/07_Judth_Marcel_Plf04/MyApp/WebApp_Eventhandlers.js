
module.exports = function () {
    var backendLogic = require('./ServerBackendLogic.js');

    return {
        generateTableData: _generateTableData
    }

    function _generateTableData(req, res){
        var reqbody = "";
        req.on('data', function (data) {
            reqbody += data;
            if (reqbody.length > 1e7)
                responseEnd(res, "", 'text/html' , 413);
        });
        
        req.on('end', function () {
            res.setHeader("Content-Type", "Judth_CSVPT");
            var arr = reqbody.split("\n");
            var data = arr[0].split(";");
            var text = backendLogic.generateTableDataInCsv(data[0], data[1]);
            res.write(text);
            res.end();
        });

    }
}();


