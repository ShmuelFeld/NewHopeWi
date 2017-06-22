﻿function displayRank() {
    //here I want to request the users. and then to show the complete table
    var apiUrl = "../api/Users";
    $.getJSON(apiUrl, function () {
        alert("success");
    })
        .done(function (data) {
            alert("second success");
            var counter = 0;
            var obj;
            var i;
            for (i = 0; i < data.length; i++) {
                obj = data[i];
                counter++;
                $("#rankTable").append("<tr><td>" + counter + "</td><td><h>" + data[i].UserName + "</h><p>player since:" + data[i].Date + "</p></td><td>" + data[i].NumberOfWins + "</td> <td>" + data[i].NumberOfLoses + "</td></tr> ");
                //<ul><li>" + data[i].UserName + "</li><li>player since:" + data[i].Date + "</li></ul>
            }
        })
        .fail(function () {
            alert("error");
        });
}