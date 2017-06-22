﻿$("#navigationBar").load("MenuBar.html");

function register() {
    var str1 =$("#password").val();
    var str2 = $("#passwordVeri").val();
    if (validPassword(str1, str2)) {
        document.getElementById("demo").innerHTML = "";
        var userName = $("#userName").val();
        var password = SHA1($("#password").val());
        var Email = $("#Email").val();
        var dateObj = new Date();
        var month = dateObj.getUTCMonth() + 1; //months from 1-12
        var day = dateObj.getUTCDate();
        var year = dateObj.getUTCFullYear();
        var newdate = day + "/" + month + "/" + year;
        var UserObject = {
            UserName: userName,
            Password: password,
            EMail: Email,
            NumberOfWins: 0,
            NumberOfLoses: 0,
            Date: newdate 
        };
        var apiUrl = "../api/Users/";
        var request = UserObject;
        $.post(apiUrl, UserObject)
            .done(function (data) {
                alert("Register succeeded");
                sessionStorage.Name = userName;
                var helloUser = "Hello " + userName;
                $("#register").text(helloUser);
                $("#register").attr("href", "#");
                $("#login").text("Logout");
                $("#login").attr("href", "#");
                window.location.replace("HomePage.html");
            })
            .fail(function (jqXHR, textStatus, err) {
                alert("UserName is already exists. Please choose different name");
            });
    } else {
        document.getElementById("demo").innerHTML = "there is a conflict between passwords";
        document.getElementById("password").value = "";
        document.getElementById("passwordVeri").value = "";
    }
}

function validPassword(str1, str2) {
    var ret = str1.localeCompare(str2);
    if (ret == 0) {
        return true;
    } else {
        return false;
    }
}
