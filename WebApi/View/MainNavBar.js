/*
starts every time page is changed.
*/
$(document).ready(function () {
    //turns on the option to log out.
    $("#login").click(function () {
        if (sessionStorage.Name) {
            sessionStorage.Name = "";
            window.location.replace("HomePage.html");
        }
    });
    //writes "hello user.name" and cancels the option to log in.
    if (sessionStorage.Name) {
        var hello = "Hello " + sessionStorage.Name;
        $("#register").text(hello);
        $("#register").attr("href", "#");
        $("#login").text("Logout");
        $("#login").attr("href", "#");
    }
});