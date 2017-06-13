var currentPosition;
var maze, rows, cols;
(function ($) {
    $.fn.MazeJS = function (data) {
        maze = data.Maze;
        var myCanvas = document.getElementById("mazeCanvas");  
        var player = document.getElementById("prince");
        var dest = document.getElementById("cinderella");
        var context = mazeCanvas.getContext("2d");
        context.clearRect(0, 0, myCanvas.width, myCanvas.height);
        rows = data.Rows;
        cols = data.Cols;
        var cellWidth = mazeCanvas.width / cols;
        var cellHeight = mazeCanvas.height / rows;
        currentPosition = data.Start;
        var counter = 0;
        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                if (maze[counter] === '1') {
                    context.fillRect(cellWidth * j, cellHeight * i,
                        cellWidth, cellHeight);
                }
                counter++;
            }
        }
        context.drawImage(player, data.Start.Col * cellWidth, data.Start.Row * cellHeight,
            cellWidth, cellHeight);
        context.drawImage(dest, data.End.Col * cellWidth, data.End.Row * cellHeight,
            cellWidth, cellHeight);
        return this;
};
})(jQuery);function move(e) {    var myCanvas = document.getElementById("mazeCanvas");
    var player = document.getElementById("prince");
    var dest = document.getElementById("cinderella");
    var context = mazeCanvas.getContext("2d");    var cellWidth = myCanvas.width / cols;
    var cellHeight = myCanvas.height / rows;    if (gameOnBool) {        var keynum;
        if (window.event) { // IE                    
            keynum = e.keyCode;
            switch (keynum) {
                //move left
                case 37:
                    var i = maze[(currentPosition.Row * cols) + currentPosition.Col - 1]; 
                    if (i == 0) {
                        context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                            cellWidth, cellHeight);
                        currentPosition.Col = currentPosition.Col - 1;
                        context.drawImage(player, currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                            cellWidth, cellHeight);
                        //alert("possible move");
                    }
                    break;
                //move up
                case 38:
                    var i = maze[((currentPosition.Row - 1) * cols) + currentPosition.Col];
                    if (i == 0) {
                        context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                            cellWidth, cellHeight);
                        currentPosition.Row = currentPosition.Row - 1;
                        context.drawImage(player, currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                            cellWidth, cellHeight);
                        //alert("possible move");
                    }
                    break;
                //move right
                case 39:
                    var i = maze[(currentPosition.Row * cols) + currentPosition.Col + 1];
                    if (i == 0) {
                        context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                            cellWidth, cellHeight);
                        currentPosition.Col = currentPosition.Col + 1;
                        context.drawImage(player, currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                            cellWidth, cellHeight);
                        //alert("possible move");
                    }
                    break;
                //move down
                case 40:
                    var i = maze[((currentPosition.Row + 1) * cols) + currentPosition.Col]; 
                    if (i == 0) {
                        context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                            cellWidth, cellHeight);
                        currentPosition.Row = currentPosition.Row + 1;
                        context.drawImage(player, currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                            cellWidth, cellHeight);
                        //alert("possible move");
                    }
                    break;

                default:
                    break;
            }
            //here we need see if we won
        }    }}