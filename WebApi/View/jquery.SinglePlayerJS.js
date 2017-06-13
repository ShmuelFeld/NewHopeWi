
function generate() {
    var apiUrl = "../api/GenerateMaze";
    var maze = {
        Name: $("#mazeName").val(),
        Rows: $("#mazeRows").val(),
        Cols: $("#mazeCols").val()
    };
    var request = apiUrl + "/" + maze.Name + "/" + maze.Rows + "/" + maze.Cols;
    $.getJSON(request)
        .done(function (maze) {
            var player = document.getElementById("prince");
            var dest = document.getElementById("cinderella");
            $("#mazeCanvas").MazeJS(maze, player, dest);
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("error");
        });
}function drawMaze() {    
}