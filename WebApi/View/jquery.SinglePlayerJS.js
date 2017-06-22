
﻿$("#navigationBar").load("MenuBar.html");
var gameOnBool = false;
function generate() {
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
            $("#mazeCanvas").generateMaze(mazeAns);
            $("#mazeName").val("");
            $("#mazeRows").val("");
            $("#mazeCols").val("");
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("error");
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
        });
}

$("#body").keydown(function (e) {
    $("#mazeCanvas").move(e.keyCode, 'mazeCanvas');
});



