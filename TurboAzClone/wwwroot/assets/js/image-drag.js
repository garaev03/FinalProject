function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("src", ev.target.src);
    ev.dataTransfer.setData("id", ev.target.getAttribute("data-id"))
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("src");
    var id = ev.dataTransfer.getData("id");
    ev.target.src = data
    ev.target.parentElement.children[1].setAttribute("value", id)
}