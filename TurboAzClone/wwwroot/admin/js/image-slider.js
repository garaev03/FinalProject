var modal = document.getElementById("myModal");
let img = document.querySelectorAll(".myImg")
var modalImg = document.getElementById("modal-img");


img.forEach(btn => {
    btn.addEventListener("click", (e) => {
        const elem = e.target;
        modal.style.display = "block";
        modalImg.src = elem.dataset.biggerSrc || elem.src;
        var span = document.getElementsByClassName("close")[0];
        span.onclick = function () {
            modal.style.display = "none";
        }
        modal.onclick = function () {
            modal.style.display = "none";
        }
    })
})

