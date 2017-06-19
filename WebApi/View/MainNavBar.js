$(document).ready(function () {
    $("#login").click(function () {
        if (sessionStorage.Name) {
            sessionStorage.Name = "";
            window.location.replace("HomePage.html");
        }
    });
    if (sessionStorage.Name) {
        var hello = "Hello " + sessionStorage.Name;
        $("#register").text(hello);
        $("#register").attr("href", "#");
        $("#login").text("Logout");
        $("#login").attr("href", "#");
    }
});