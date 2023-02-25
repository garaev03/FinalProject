var modal = document.getElementById("myModal");
var modalImg = document.getElementById("modal-img");
let img = document.querySelectorAll(".myImg")
var plusDivs = document.querySelectorAll(".plusDiv")
var minusDivs = document.querySelectorAll(".minusDiv")

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

plusDivs.forEach(btn => {
    btn.addEventListener("click", () => {
        for (let i = 0; i < btn.parentElement.parentElement.children.length; i++) {
            if (btn.parentElement.parentElement.children[i].classList.contains("imgDivs") && btn.parentElement.parentElement.children[i].style.display === "block") {
                if (btn.parentElement.parentElement.children[i + 1].classList.contains("imgDivs")) {
                    btn.parentElement.parentElement.children[i].style.display = "none"
                    btn.parentElement.parentElement.children[i + 1].style.display = "block"
                }
                return;
            }
        }
    })
})

minusDivs.forEach(btn => {
    btn.addEventListener("click", () => {
        for (let i = 0; i < btn.parentElement.parentElement.children.length; i++) {
            if (btn.parentElement.parentElement.children[i].classList.contains("imgDivs") && btn.parentElement.parentElement.children[i].style.display === "block") {
                if (btn.parentElement.parentElement.children[i - 1].classList.contains("imgDivs")) {
                    btn.parentElement.parentElement.children[i].style.display = "none"
                    btn.parentElement.parentElement.children[i - 1].style.display = "block"
                }
            }
        }
    })
})