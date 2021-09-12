function getRandomInt(max) {
    return Math.floor(Math.random() * max);
}

help.onclick = function () {
    if (localStorage.getItem("help") != 1 ) {
        IsLie = document.getElementsByClassName("false");
        rnd = getRandomInt(3);
        IsLie[rnd].style.visibility = 'hidden';
        rnd2 = getRandomInt(3)
        if (rnd == rnd2) {
            while (rnd2 == rnd) {
                rnd2 = getRandomInt(3)
            };
        };
        IsLie[rnd2].style.visibility = 'hidden';
        localStorage.setItem("help", 1);
    };
    help.className = "hidden";
};