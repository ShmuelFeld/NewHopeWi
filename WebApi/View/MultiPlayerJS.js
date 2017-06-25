$("#navigationBar").load("MenuBar.html");
var multiplayer = $.connection.multiplayerHub;
var gameOnBool = false;
document.title = "Multiplayer";
$(document).ready(function () {
    if (sessionStorage.Name) {
        $("#mazeName").val(localStorage.getItem("MazeName"));
        $("#mazeRows").val(localStorage.getItem("MazeRows"));
        $("#mazeCols").val(localStorage.getItem("MazeCols"));
    } else {
        alert("Please login first");
        window.location.replace("LoginPage.html");
    }
});
multiplayer.client.drawMaze = function (data) {
    gameOnBool = true;
    var myCanvas = document.getElementById("myMazeCanvas");
    $("#myMazeCanvas").generateMaze(data, myCanvas);
    var otherCanvas = document.getElementById("otherMazeCanvas"); 
    $("#otherMazeCanvas").generateMaze(data, otherCanvas);
    $("#myMazeCanvas").show();
    $("#otherMazeCanvas").show();
    $("#l").show();
    $("#l1").show();
    $("#loader").hide();
};

multiplayer.client.moveOther = function (move) {
    var a = $("#otherMazeCanvas").move(move, 'otherMazeCanvas');
    if (a == 3) {
        alert("you lost :(");
        var apiUrl = "../api/Users/Lost/";
        var str1 = sessionStorage.Name;
        var request = apiUrl + str1;
        $.getJSON(request)
            .done(function (data) {
                window.location.replace("HomePage.html");
            })
            .fail(function (jqXHR, textStatus, err) {
                alert("couldn't update data");
            });
    }
};

$.connection.hub.start().done(function () {
    $("#btnStartGame").click(function () {
        $("#myMazeCanvas").hide();
        $("#otherMazeCanvas").hide();
        $("#loader").show();
        var name = $("#mazeName").val();
        rows = $("#mazeRows").val();
        cols = $("#mazeCols").val();
        multiplayer.server.start(name, rows, cols);
    });
    $("#btnJoinGame").click(function () {
        multiplayer.server.join($("#listDrpdwn").val());
        $("#myMazeCanvas").hide();
        $("#otherMazeCanvas").hide();
        $("#loader").show();
    });
});

$("#body").keydown(function (e) {
    multiplayer.server.play(e.keyCode);    
    var a = $("#myMazeCanvas").move(e.keyCode, 'myMazeCanvas');
    if (a == 2) {
        alert("wow you won!!!");
        var apiUrl = "../api/Users/Win/";
        var str1 = sessionStorage.Name;
        var request = apiUrl + str1;
        $.getJSON(request)
        .done(function (data) {
            window.location.replace("HomePage.html");
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("couldn't update data");
        });
    }
});

function getListOfGames() {
    var dropdowns = document.getElementsByClassName("dropdown-content");
    multiplayer.server.list().done(function (result) {
        if (result) {
            var list = document.getElementById("listDrpdwn");
            for (var i = 0; i < result.length; i++) {
                if (!isContains(list, result[i])) {
                    var op = document.createElement('option');
                    op.value = result[i];
                    op.text = result[i];
                    list.appendChild(op);
                }
            }
        }
    });
}

function isContains(list, item) {
    for (var i = 0; i < list.length; i++){
        if (list[i].text == item) {
            return true;
        }
    }
    return false;
}

