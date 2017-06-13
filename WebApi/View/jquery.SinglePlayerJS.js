var gameOnBool = false;
function generate() {
    var apiUrl = "../api/GenerateMaze";
    var maze = {
        Name: $("#mazeName").val(),
        Rows: $("#mazeRows").val(),
        Cols: $("#mazeCols").val()
    };
    //var title = document.getElementsByTagName("title");
    //title.textStatus = maze.Name;
    var request = apiUrl + "/" + maze.Name + "/" + maze.Rows + "/" + maze.Cols;
    $.getJSON(request)
        .done(function (maze) {
            gameOnBool = true
            $("#mazeCanvas").MazeJS(maze);
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("error");
        });
}


