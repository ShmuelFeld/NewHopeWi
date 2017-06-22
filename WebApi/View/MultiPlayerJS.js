$("#navigationBar").load("MenuBar.html");
var multiplayer = $.connection.multiplayerHub;
var gameOnBool = false;

multiplayer.client.drawMaze = function (data) {
    gameOnBool = true;
    var myCanvas = document.getElementById("myMazeCanvas");
    $("#myMazeCanvas").generateMaze(data, myCanvas);
    var otherCanvas = document.getElementById("otherMazeCanvas"); 
    $("#otherMazeCanvas").generateMaze(data, otherCanvas);
};

multiplayer.client.moveOther = function (move) {
    $("#otherMazeCanvas").move(move, 'otherMazeCanvas');
};

$.connection.hub.start().done(function () {
    $("#btnStartGame").click(function () {
        var name = $("#mazeName").val();
        rows = $("#mazeRows").val();
        cols = $("#mazeCols").val();
        multiplayer.server.start(name, rows, cols);
    });
    $("#btnJoinGame").click(function () {
        var algo = document.getElementById('listDrpdwn');
        var select = algo.options[algo.selectedIndex].value;
        multiplayer.server.join(select);
    });
});

$("#body").keydown(function (e) {    multiplayer.server.play(e.keyCode);        $("#myMazeCanvas").move(e.keyCode, 'myMazeCanvas');});

function getListOfGames() {
    //$('#listDrpdwn').empty();
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

