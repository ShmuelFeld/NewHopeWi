
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
            $("#mazeCanvas").MazeJS(maze);
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("error");
        });
}function drawMaze() {    
}