console.log("started");

const sql = require('mssql');

const config = {
    user: 'dbuser',
    password: 'Julian1999',
    server: 'localhost',
    database: 'SessionRatingDB',
    options: {
        instanceName: 'SQLEXPRESS',
    }
};

sql.connect(config, err => {
    // ... error checks
    if (err) {
        console.log(err);
    } else {
        console.log("connected");

        // execute (very) simple query    
        new sql.Request().query('select * from dbo.Session;', (err, result) => {
            if (err) {
                console.log(err);
            } else {
                console.dir(result);
            }
        });
    }
});

sql.on('error', err => {
    console.log(error);
});

console.log("ended");