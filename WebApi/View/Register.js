function register() {
    var str1 = document.getElementById("password").value;
    var str2 = document.getElementById("passwordVeri").value;
    if (validPassword(str1, str2)) {
        document.getElementById("demo").innerHTML = "";
        var userName = document.getElementById("userName").value;
        var password = str1;
        var Email = document.getElementById("Email").value;
        //send a request to Server.
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
