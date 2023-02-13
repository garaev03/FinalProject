var dropCarBtn = document.querySelectorAll(".drop-car")

dropCarBtn.forEach(btn => {
    btn.addEventListener("click", () => {
        if (btn.parentElement.parentElement.children[1].style.display === "none") {
            btn.parentElement.parentElement.children[1].style.display = "block"
        } else {
            btn.parentElement.parentElement.children[1].style.display = "none"
        }
    })
})