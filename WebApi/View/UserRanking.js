/*
this function calls when the page is loaded, send the request to the server
and display the user rankings order by (numberOfWins - numberOfLoses)
in descending order.
*/
function displayRank() {
    document.title = "UserRanking";
    //here I want to request the users. and then to show the complete table
    $("#myDiv").hide();
    var apiUrl = "../api/Users";
    $.getJSON(apiUrl, function () {
    })
        //prints the table
        .done(function (data) {
            var counter = 0;
            var obj;
            var i;
            for (i = 0; i < data.length; i++) {
                obj = data[i];
                counter++;
                $("#rankTable").append("<tr><td>" + counter + "</td><td><h>" + data[i].UserName + "</h><p>player since:" + data[i].Date + "</p></td><td>" + data[i].NumberOfWins + "</td> <td>" + data[i].NumberOfLoses + "</td></tr> ");
            }
            $("#myDiv").show();
            $("#loader").remove();
        })
        .fail(function () {
            alert("error");
        });
}