let searchedValue = document.querySelectorAll(".vehicle-makes-models")
let searchBtn = document.querySelectorAll(".search-button")
let ownerNumbers = document.querySelectorAll(".owner-numbers")

searchBtn.forEach(btn => {
    btn.addEventListener("click", () => {
        let value = btn.parentElement.children[0].children[0].children[1].value
        let value2 = btn.parentElement.children[1].children[0].children[1].value
        console.log(value2);
        searchedValue.forEach(vehicle => {
            if (vehicle.innerHTML.toLowerCase().includes(value.toLowerCase())) {
                if (vehicle.parentElement.parentElement.parentElement.children[1].children[0].children[1].children[1].children[0].children[0].children[3].children[5].children[0].innerHTML.includes(value2)) {
                    vehicle.parentElement.parentElement.parentElement.style.display = "block"
                } else {
                    vehicle.parentElement.parentElement.parentElement.style.display = "none"
                }
            } else {
                vehicle.parentElement.parentElement.parentElement.style.display = "none"
            }
        });
    })
})


