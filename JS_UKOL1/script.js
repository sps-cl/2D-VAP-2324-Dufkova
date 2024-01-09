let pocetRadku = document.getElementById("pocet-radku");
let pocetSloupcu = document.getElementById("pocet-sloupcu");
let tabulka = document.createElement("table");
function vytvoritTabulku(){
    let radky = Number(pocetRadku.value);
    let sloupce = Number(pocetSloupcu.value);

   for (let index = 0; index < radky ; index++) {
        let radek = tabulka.insertRow(index);
    for (let i = 0; i < sloupce; i++) {
        let bunka = radek.insertCell();
        bunka.innerText = (index * sloupce) + i + 1;
    }
   }
   document.body.appendChild(tabulka);
}