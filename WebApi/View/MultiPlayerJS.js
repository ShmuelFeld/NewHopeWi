﻿var multiplayer = $.connection.multiplayerHub;
var gameOnBool = false;

multiplayer.client.drawMaze = function (data) {
    gameOnBool = true;
    $("#myMazeCanvas").generateMaze(data);
};

$.connection.hub.start().done(function () {
    $("#btnStartGame").click(function () {
        var name = $("#mazeName").val();
        rows = $("#mazeRows").val();
        cols = $("#mazeCols").val();
        multiplayer.server.start(name, rows, cols);
    });
    $("#btnJoinGame").click(function () {
        multiplayer.server.join($("#listDrpdwn").val());
    });
});

$("#body").keydown(function (e) {    multiplayer.server.play(e.key);    $("#myMazeCanvas").move(e, 'myMazeCanvas');});

function getListOfGames() {
    var dropdowns = document.getElementsByClassName("dropdown-content");
    multiplayer.server.list().done(function (result) {
        if (result) {
            $.each(result, function (i, item) {
                $('#listDrpdwn').empty();
                $('#listDrpdwn').append($('<option>', {
                    value: item,
                    text: item
                }));
            });
        }
    });
}

