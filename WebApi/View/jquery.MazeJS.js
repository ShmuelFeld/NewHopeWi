(function ($) {
    $.fn.MazeJS = function (data) {
        maze = data.Maze;
    var myCanvas = document.getElementById("mazeCanvas");
    var context = mazeCanvas.getContext("2d");
    var rows = data.Rows;
    var cols = data.Cols;
    var cellWidth = mazeCanvas.width / cols;
    var cellHeight = mazeCanvas.height / rows;
    var counter = 0;
    for (var i = 0; i < rows; i++) {
        for (var j = 0; j < cols; j++) {
            if (maze[counter] == 1) {
                context.fillRect(cellWidth * j, cellHeight * i,
                    cellWidth, cellHeight);
            }
            counter++;
        }
    }
    return this;
};
})(jQuery);