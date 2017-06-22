$("#navigationBar").load("MenuBar.html");
document.title = "Login";
function login() {
    $("#loader").show();
    var str1 = $("#userName").val();
    var str2 = $("#password").val();
    var password = SHA1(str2);
    var apiUrl = "../api/Users/";
    var obj = {
        name: str1
    }
    var request = apiUrl + str1;
    $.getJSON(request)//
        .done(function (data) {
            if (data.Password.localeCompare(password) == 0) {
                sessionStorage.setItem("Name", str1);
                var hello = "Hello " + str1;
                $("#register").text(hello);
                $("#register").attr("href", "#");
                $("#login").text("Logout");
                $("#login").attr("href", "#");
                window.location.replace("HomePage.html");
            } else {
                alert("Not the Same Passwords");
            }
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("userName not found");
        });
}