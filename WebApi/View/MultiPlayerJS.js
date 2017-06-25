
/*
loads the nav bar's script.
*/$("#navigationBar").load("MenuBar.html");
var multiplayer = $.connection.multiplayerHub;
var gameOnBool = false;
document.title = "Multiplayer";

/*
loads the default settings into the input.
*/
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

/*
draws  the maze
*/
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

/*
moves the other player according to what other player moved.
*/
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

/*
start when connection is done
*/
$.connection.hub.start().done(function () {
    /*
    start a multiplayer.
    */
    $("#btnStartGame").click(function () {
        $("#myMazeCanvas").hide();
        $("#otherMazeCanvas").hide();
        $("#loader").show();
        var name = $("#mazeName").val();
        rows = $("#mazeRows").val();
        cols = $("#mazeCols").val();
        multiplayer.server.start(name, rows, cols);
    });
    /*
    joins an existing game.
    */
    $("#btnJoinGame").click(function () {
        multiplayer.server.join($("#listDrpdwn").val());
        $("#myMazeCanvas").hide();
        $("#otherMazeCanvas").hide();
        $("#loader").show();
    });
});

/*
moves the player accoding to the event (e), and send to other player to move his
"other board".
*/
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

/*
gets list of joinable games from the server and puts them on the dropdown's list.
*/
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

/*
runs over the list and checks if item is in it.
*/
function isContains(list, item) {
    for (var i = 0; i < list.length; i++){
        if (list[i].text == item) {
            return true;
        }
    }
    return false;
}

