var express = require('express');
var app = express();
var path = require('path');

app.use(express.static(__dirname));

app.get('/*', function (req, res) {
    res.sendFile(path.join(__dirname + '/index.html'));
});


var port = process.env.port || 1337;
app.listen(port, function () {
    console.log('Applistening on port: ', port);
});

