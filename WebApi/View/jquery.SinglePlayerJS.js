function generate() {
    var apiUrl = "../api/GenerateMaze/5";
    var maze = {
        Name: $("#mazeName").val(),
        Rows: $("#mazeRows").val(),
        Cols: $("#mazeCols").val()
    };
    $.getJSON(apiUrl + "/" + maze)
    //$.post(apiUrl, maze)
        .done(function (product) {
            $("#product").text(maze.Name + ": $" + maze.Rows + ": $" + maze.Cols)
        });
}$("#btnGenerateMaze").click(function () {
    var maze = {
        Name: $("#mazeName").val(),
        Rows: $("#mazeRows").val(),
        Cols: $("#mazeCols").val()
    };
    $.getJSON(apiUrl, maze)
        .done(function () {
            alert("Product added successfully");
        });
});