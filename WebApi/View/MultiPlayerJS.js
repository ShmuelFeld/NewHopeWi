var multiplayer = $.connection.multiplayerHub;
var gameOnBool = false;

multiplayer.client.drawMaze = function (data) {
    gameOnBool = true;
    $("#myMazeCanvas").generateMaze(data);
    $("#myMazeCanvas").show();
    $("#otherMazeCanvas").show();
    $("l").show();
    $("l1").show();
    $("#loader").hide();
};

multiplayer.client.moveOther = function (move) {
    $("#otherMazeCanvas").move(move, 'otherMazeCanvas');
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

$("#body").keydown(function (e) {    multiplayer.server.play(e.keyCode);        $("#myMazeCanvas").move(e.keyCode, 'myMazeCanvas');});

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

