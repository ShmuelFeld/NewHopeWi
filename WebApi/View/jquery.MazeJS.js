(function ($) {
    $.fn.MazeJS = function (data) {
        maze = data.Maze;
        var myCanvas = document.getElementById("mazeCanvas");  
        var player = document.getElementById("prince");
        var dest = document.getElementById("cinderella");
        var context = mazeCanvas.getContext("2d");
        context.clearRect(0, 0, myCanvas.width, myCanvas.height);
        var rows = data.Rows;
        var cols = data.Cols;
        var cellWidth = mazeCanvas.width / cols;
        var cellHeight = mazeCanvas.height / rows;
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
})(jQuery);function move(e) {    if (gameOnBool) {        var keynum;
        if (window.event) { // IE                    
            keynum = e.keyCode;
            switch (keynum) {
                //move left
                case 37:
                    break;
                //move up
                case 38:

                    break;
                //move right
                case 39:

                    break;
                //move down
                case 40:

                    break;

                default:
                    break;
            }
            alert(String.fromCharCode(keynum));
        }    }}