var dropCarBtn = document.querySelectorAll(".drop-car")

dropCarBtn.forEach(btn => {
    btn.addEventListener("click", () => {
        if (btn.parentElement.children[1].style.display === "none") {
            btn.parentElement.children[1].style.display = "block"
        } else {
            btn.parentElement.children[1].style.display = "none"
        }
    })
})