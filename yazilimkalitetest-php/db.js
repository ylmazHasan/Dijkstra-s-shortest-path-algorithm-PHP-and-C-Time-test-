
var mysql = require('mysql');
var baglanti = mysql.createConnection({
    host : 'localhost',
    user : 'root',
    password : '12345678',
    database : 'yazilimkalitetest'
    });
 
connection.connect(function(err) {
  if (err) {
    console.error('Veri tabanına bağlanırken hata : ' + err.stack);
    return;
  }