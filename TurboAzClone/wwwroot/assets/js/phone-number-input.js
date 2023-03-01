document.getElementById("phone").addEventListener("keydown", function (e) {
    const txt = this.value;
    // prevent more than 12 characters, ignore the spacebar, allow the backspace
    if ((txt.length == 12 || e.which == 32) & e.which !== 8) e.preventDefault();
    // add spaces after 3 & 7 characters, allow the backspace
    if ((txt.length == 2 || txt.length == 6 || txt.length == 9) && e.which !== 8)
        this.value = this.value + " ";
});