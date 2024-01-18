let platno = document.getElementById("platno");
let context = platno.getContext("2d")
let stredKruhuX = 100;
let stredKruhuY = 100;

platno.addEventListener("mousemove", (event)=> {
    let rect = platno.getBoundingClientRect();
    stredKruhuX = event.clientX - rect.x;
    stredKruhuY = event.clientY - rect.y;
});

function nakresli(){
    context.clearRect(0,0,platno.width, platno.height);
    context.beginPath();
    context.arc(stredKruhuX, stredKruhuY, 50, 0, 2*Math.PI)
    context.fill();
    context.fillStyle ="pink"
    context.fillRect(50,50,100,100);
    requestAnimationFrame(nakresli);
}
nakresli();