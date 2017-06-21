var gameOnBool = false;
function generate() {
    var apiUrl = "../api/GenerateMaze";
    var maze = {
        Name: $("#mazeName").val(),
        Rows: $("#mazeRows").val(),
        Cols: $("#mazeCols").val()
    };
    var request = apiUrl + "/" + maze.Name + "/" + maze.Rows + "/" + maze.Cols;
    $.getJSON(request)
        .done(function (mazeAns) {
            gameOnBool = true;
            $("#mazeCanvas").generateMaze(mazeAns);
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("error");
        });
}

function solve() {
    var apiUrl = "../api/SolveMaze";
    var algo = $("#algoSelect").val();
    var request = apiUrl + "/" + $("#mazeName").val() + "/" + algo;
    var i;
    $.getJSON(request)
        .done(function (solution) {
            $("#mazeCanvas").solveMaze(solution);
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("error");
        });
}

$("#body").keydown(function (e) {    $("#mazeCanvas").move(e, 'mazeCanvas');});


