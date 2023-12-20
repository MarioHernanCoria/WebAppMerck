document.addEventListener('DOMContentLoaded', function () {
    const burger = document.getElementById('burger');
    const navList = document.getElementById('navList');

    burger.addEventListener('click', function () {
        navList.classList.toggle('show');
    });
});