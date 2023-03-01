var models = document.getElementById("models")

document.getElementById("selected-make").addEventListener("click", () => {
    models.innerHTML = "<option value='0'>Seçin</option>"
    fetch("/vehicle/getmodels?makeId=" + GetSelectedMake())
        .then(resp => resp.json())
        .then(data => {
            if (data != null) {
                data.forEach(element => {
                    models.innerHTML += "<option value=" + element.id + ">" + element.name + "</option"
                })
            }
        })
})

function GetSelectedMake() {
    return document.getElementById("selected-make").value
}