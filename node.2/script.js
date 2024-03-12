const mysql2 = require('mysql2');
const express = require('express');
const path = require('path');



const connnection = mysql2.createConnection(
    {
        host:'127.0.0.1',
        user: 'root',
        password: 'root',
        port: '3306',
        database:'moje_db'
    }
);

connnection.connect((error) =>{
    if (error) {
        console.log(error);
    }else{
        console.log("Úspěšně připojeno");
    }
})

const app = express();
app.use(express.static(__dirname));
app.use(express.urlencoded({extended: true}));
app.use(express.json());

app.get("/", (req,res) =>{
    res.sendFile(path.join(__dirname,'index.html'));
})
app.post("/uloz-uzivatele", (req,res) =>{
        connnection.query(
            `INSERT INTO uzivatele(jmeno,prijimeni) VAlUES('${req.body.jmeno}', '${req.body.prijimeni}');`
            , (error, data) =>{
                if(error) console.log(error);
            }
        );
    res.redirect("/");
});

app.listen(7000);