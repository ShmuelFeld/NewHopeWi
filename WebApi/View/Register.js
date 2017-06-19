function register() {
    var str1 =$("#password").val();
    var str2 = $("#passwordVeri").val();
    if (validPassword(str1, str2)) {
        document.getElementById("demo").innerHTML = "";
        var userName = $("#userName").val();
        var password = SHA1($("#password").val());
        var Email = $("#Email").val();
        var UserObject = {
            UserName: userName,
            Password: password,
            EMail: Email,
            numberOfWins: 0,
            numberOfLoses: 0
            //todo inset date
        };
        var apiUrl = "../api/Users/";
        var request = UserObject;
        $.post(apiUrl, UserObject)
            .done(function (data) {
                alert("success");
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
