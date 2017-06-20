var multiplayer = $.connection.multiplayerHub;

multiplayer.client.drawMaze = function (data) {
    //var maze = FromJSON(data);
    $("#myMazeCanvas").generateMaze(data);
    $("#otherMazeCanvas").generateMaze(data);
};

$.connection.hub.start().done(function () {
    $("#btnStartGame").click(function () {
        var name = $("#mazeName").val();
        rows = $("#mazeRows").val();
        cols = $("#mazeCols").val();
        multiplayer.server.start(name, rows, cols);
    });
    $("#btnJoinGame").click(function () {
        multiplayer.server.join();
    });
});



function getListOfGames() {
    var dropdowns = document.getElementsByClassName("dropdown-content");
    var apiUrl = "../api/GetList";
    $.getJSON(apiUrl)
        .done(function (mazeAns) {
            alert("hay");
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("error1");
        });
    var i;
    for (i = 0; i < dropdowns.length; i++) {
        var openDropdown = dropdowns[i];
        if (openDropdown.classList.contains('show')) {
            openDropdown.classList.remove('show');
        }
    }
}

function joinGame() {

}

