window.onload = function () {
    var TopMask = document.querySelector('.TopMask');
    var BottomMask = document.querySelector('.BottomMask');
    var DoorBackground = document.querySelector('.DoorBackground');

    var logos = [
        document.querySelector('.BadmintonLogo'),
        document.querySelector('.BasketballLogo'),
        document.querySelector('.VolleyballLogo')
    ];

    var ChooseText = document.getElementById('ChooseText');

    // 1: 圖片1下拉
    setTimeout(function () {
        BottomMask.style.transform = "translate(0, 30vh)";
    }, 100);


    // 2: 圖片1上拉同時圖片2下拉
    setTimeout(function () {
        TopMask.style.transform = "translate(0, -150vh)";
        BottomMask.style.transform = "translate(0, 250vh)";
        TopMask.style.transition = "transform 0.5s ease-in-out";
        BottomMask.style.transition = "transform 0.5s ease-in-out";
    }, 2000);

    // 3: 圖片1、2隱藏 圖片3模糊
    setTimeout(function () {
        TopMask.style.display =
            BottomMask.style.display =
            "none";
        DoorBackground.style.filter = "blur(10px)";
    }, 2500);

    // 4: 圖片4、5、6顯示
    for (let i = 0; i < logos.length; i++) {
        setTimeout(function () {
            logos[i].style.clipPath = "inset(0 0 0 0)";
        }, 4000 + (i * 300));
    }

    // 5: 顯示文字
    setTimeout(function () {
        ChooseText.style.visibility = "visible";
    }, 5500);
};
