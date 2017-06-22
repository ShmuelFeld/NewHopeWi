$(document).ready(function () {
    $("#login").click(function () {
        if (localStorage.Name) {
            localStorage.Name = "";
            window.location.replace("HomePage.html");
        }
    });
    if (localStorage.Name) {
        var hello = "Hello " + localStorage.Name;
        $("#register").text(hello);
        $("#register").attr("href", "#");
        $("#login").text("Logout");
        $("#login").attr("href", "#");
    }
});