function show() {
    var pswrd = document.getElementById('pswrd');
    var icon = document.querySelector('.fa');
    if (pswrd.type === "password") {
        pswrd.type = "text";
        pswrd.style.marginTop = "20px";
        icon.style.color = "#7f2092";
    } else {
        pswrd.type = "password";
        icon.style.color = "gray";
    }
}

