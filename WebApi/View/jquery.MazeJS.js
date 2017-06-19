var currentPosition;
var goalPosition, initPosition;
var maze, rows, cols;
var isDone = false;
(function ($) {
    $.fn.generateMaze = function (data) {
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
        goalPosition = data.End;
        initPosition = data.Start;
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
})(jQuery);

(function ($){
    $.fn.solveMaze = function (data) {
        currentPosition.Row = initPosition.Row;
        currentPosition.Col = initPosition.Col;
        var frameActivator = window.setInterval(frame, 600);
        var i = 0;
        function frame() {
            if (i < data.solution.length) {
                switch (data.solution.charAt(i)) {
                    //left
                    case '0':
                        moveLeft();
                        break;

                    //right
                    case '1':
                        moveRight();
                        break;

                    //up
                    case '2':
                        moveUp();
                        break;

                    //down
                    case '3':
                        moveDown();
                        break;
                }
                i++;
            }
            
            if (i == data.solution.length) {
                clearInterval(frameActivator);
                isDone = true;
            }       
        }
       
        return this;
    };
})(jQuery);

function move(e) {
    if (isDone == false) {
        var myCanvas = document.getElementById("mazeCanvas");
        var player = document.getElementById("prince");
        var dest = document.getElementById("cinderella");
        var context = mazeCanvas.getContext("2d");
        var cellWidth = myCanvas.width / cols;
        var cellHeight = myCanvas.height / rows;
        if (gameOnBool) {
            var keynum;
            if (window.event) { // IE                    
                keynum = e.keyCode;
                switch (keynum) {
                    //move left
                    case 37:
                        moveLeft();
                        break;
                    //move up
                    case 38:
                        moveUp();
                        break;
                    //move right
                    case 39:
                        moveRight();
                        break;
                    //move down
                    case 40:
                        moveDown();
                        break;

                    default:
                        break;
                }

                if ((goalPosition.Row === currentPosition.Row) && (goalPosition.Col === currentPosition.Col)) {
                    alert("wow you won!!!");
                    isDone = true;
                }
            }
        }
    }
}

function moveLeft() {
    var myCanvas = document.getElementById("mazeCanvas");
    var player = document.getElementById("prince");
    var dest = document.getElementById("cinderella");
    var context = mazeCanvas.getContext("2d");
    var cellWidth = myCanvas.width / cols;
    var cellHeight = myCanvas.height / rows;
    var i = maze[(currentPosition.Row * cols) + currentPosition.Col - 1];
    if (i == 0) {
        context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
            cellWidth, cellHeight);
        currentPosition.Col = currentPosition.Col - 1;
        context.drawImage(player, currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
            cellWidth, cellHeight);
    }
}

function moveUp() {
    var myCanvas = document.getElementById("mazeCanvas");
    var player = document.getElementById("prince");
    var dest = document.getElementById("cinderella");
    var context = mazeCanvas.getContext("2d");
    var cellWidth = myCanvas.width / cols;
    var cellHeight = myCanvas.height / rows;
    var i = maze[((currentPosition.Row - 1) * cols) + currentPosition.Col];
    if (i == 0) {
        context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
            cellWidth, cellHeight);
        currentPosition.Row = currentPosition.Row - 1;
        context.drawImage(player, currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
            cellWidth, cellHeight);
    }
}

function moveRight() {
    var myCanvas = document.getElementById("mazeCanvas");
    var player = document.getElementById("prince");
    var dest = document.getElementById("cinderella");
    var context = mazeCanvas.getContext("2d");
    var cellWidth = myCanvas.width / cols;
    var cellHeight = myCanvas.height / rows;
    var i = maze[(currentPosition.Row * cols) + currentPosition.Col + 1];
    if (i == 0) {
        context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
            cellWidth, cellHeight);
        currentPosition.Col = currentPosition.Col + 1;
        context.drawImage(player, currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
            cellWidth, cellHeight);
    }
}

function moveDown() {
    var myCanvas = document.getElementById("mazeCanvas");
    var player = document.getElementById("prince");
    var dest = document.getElementById("cinderella");
    var context = mazeCanvas.getContext("2d");
    var cellWidth = myCanvas.width / cols;
    var cellHeight = myCanvas.height / rows;
    var i = maze[((currentPosition.Row + 1) * cols) + currentPosition.Col];
    if (i == 0) {
        context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
            cellWidth, cellHeight);
        currentPosition.Row = currentPosition.Row + 1;
        context.drawImage(player, currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
            cellWidth, cellHeight);
    }
}
