
﻿$("#navigationBar").load("MenuBar.html");
document.title = "Singleplayer";
var gameOnBool = false;
function generate() {
    $("#mazeCanvas").hide();
    $("#loader").show();
    var apiUrl = "../api/GenerateMaze";
    mazeName = $("#mazeName").val()
    var maze = {
        Name: mazeName,
        Rows: $("#mazeRows").val(),
        Cols: $("#mazeCols").val()
    };
    var request = apiUrl + "/" + maze.Name + "/" + maze.Rows + "/" + maze.Cols;
    $.getJSON(request)
        .done(function (mazeAns) {
            gameOnBool = true;
            var myCanvas = document.getElementById("mazeCanvas");
            $("#mazeCanvas").generateMaze(mazeAns, myCanvas);
            $("#mazeCanvas").show();
            $("#loader").hide();
            document.title = $("#mazeName").val();
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("error");
            $("#loader").hide();
        });
}

function solve() {
    var apiUrl = "../api/SolveMaze";
    var algo = $("#algoSelect").val();
    var request = apiUrl + "/" + mazeName + "/" + algo;
    var i;
    $.getJSON(request)
        .done(function (solution) {
            $("#mazeCanvas").solveMaze(solution);
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("error");
            $("#mazeName").val(localStorage.getItem("MazeName"));
            $("#mazeRows").val(localStorage.getItem("MazeRows"));
            $("#mazeCols").val(localStorage.getItem("MazeCols"));
            $("#algoSelect").val(localStorage.getItem("MazeAlgo"));
        });
}
$("#body").keydown(function (e) {
    var a = $("#mazeCanvas").move(e.keyCode, 'mazeCanvas');
    switch (a) {
        case 1:
            break;
        case 2:
            alert("wow you won!!!");
            break;
        case 3:
            alert("you lost :(");
            break;
    }
});
$(document).ready(function () {
    $("#mazeName").val(localStorage.getItem("MazeName"));
    $("#mazeRows").val(localStorage.getItem("MazeRows"));
    $("#mazeCols").val(localStorage.getItem("MazeCols"));
    $("#algoSelect").val(localStorage.getItem("MazeAlgo"));
});


