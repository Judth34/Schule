
module.exports = (function () {   
    
    return {
        generateTableDataInCsv: _generateTableDataInCsv
    }

    function _generateTableDataInCsv(zeilen, spalten) {
        var data = "";
        var cnt = 1;
        for (var idx = 0; idx < zeilen; idx++) {
            
            for (var i = 0; i < spalten - 1; i++) {
                data += cnt + ";";
                cnt++;
            }
            if (zeilen - idx == 1)                  //weil sonst immer eine leere zeile entsteht
                data += cnt;
            else
                data += cnt + "\n";
            cnt++;
        }
        
        return data;
    }
})();