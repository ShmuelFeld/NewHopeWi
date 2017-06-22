var currentPosition;
var goalPosition, initPosition, otherPosition;
var maze, rows, cols;
var isDone = false;
(function ($) {
    $.fn.generateMaze = function (data) {
        maze = data.Maze;
        var myCanvas = document.getElementById("mazeCanvas");
        
        function draw(mazeCanvas, data) {
            var player = document.getElementById("prince");
            var dest = document.getElementById("cinderella");
            var context = mazeCanvas.getContext("2d");
            context.clearRect(0, 0, myCanvas.width, myCanvas.height);
            rows = data.Rows;
            cols = data.Cols;
            var cellWidth = mazeCanvas.width / cols;
            var cellHeight = mazeCanvas.height / rows;
            currentPosition = data.Start;
            otherPosition = jQuery.extend(true, {}, data.Start);
            goalPosition = data.End;
            initPosition = jQuery.extend(true, {}, data.Start);
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
        }
        if (myCanvas == null) {
            myCanvas = document.getElementById("myMazeCanvas");
            draw(myCanvas, data);
            myCanvas = document.getElementById("otherMazeCanvas");
            draw(myCanvas, data);
        }
        else { draw(myCanvas, data); }
        return this;
    };
})(jQuery);

(function ($) {
    $.fn.solveMaze = function (data) {
        alert("hey");
    };
})(jQuery);

(function ($){
    $.fn.solveMaze = function (data) {
        var myCanvas = document.getElementById("mazeCanvas");
        var player = document.getElementById("prince");
        var dest = document.getElementById("cinderella");
        var context = myCanvas.getContext("2d");
        var cellWidth = myCanvas.width / cols;
        var cellHeight = myCanvas.height / rows;
        
        var frameActivator = window.setInterval(frame, 600);
        var i = 0;

        context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
            cellWidth, cellHeight);
        currentPosition.Row = initPosition.Row;
        currentPosition.Col = initPosition.Col;

        function frame() {
            if (i < data.solution.length) {
                switch (data.solution.charAt(i)) {
                    //left
                    case '0':
                        moveLeft(myCanvas, player, dest, context, cellWidth, cellHeight);
                        break;
                    //right
                    case '1':
                        moveRight(myCanvas, player, dest, context, cellWidth, cellHeight);
                        break;

                    //up
                    case '2':
                        moveUp(myCanvas, player, dest, context, cellWidth, cellHeight);
                        break;

                    //down
                    case '3':
                        moveDown(myCanvas, player, dest, context, cellWidth, cellHeight);
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

(function ($) {
    $.fn.move = function (keynum, canvasId) {
        if (isDone == false) {
            var myCanvas = document.getElementById(canvasId);
            var player = document.getElementById("prince");
            var dest = document.getElementById("cinderella");
            var context = myCanvas.getContext("2d");
            var cellWidth = myCanvas.width / cols;
            var cellHeight = myCanvas.height / rows;
            if (gameOnBool) {
                var keynum;
                if (window.event) { // IE                    
                    //keynum = e.keyCode;
                    switch (keynum) {
                        //move left
                        case 37:
                            moveLeft(myCanvas, player, dest, context, cellWidth, cellHeight);
                            break;
                        //move up
                        case 38:
                            moveUp(myCanvas, player, dest, context, cellWidth, cellHeight);
                            break;
                        //move right
                        case 39:
                            moveRight(myCanvas, player, dest, context, cellWidth, cellHeight);
                            break;
                        //move down
                        case 40:
                            moveDown(myCanvas, player, dest, context, cellWidth, cellHeight);
                            break;

                        default:
                            break;
                    }
                    if ((goalPosition.Row === currentPosition.Row) && (goalPosition.Col === currentPosition.Col)) {
                        alert("wow you won!!!");
                        isDone = true;
                    } else if ((goalPosition.Row === otherPosition.Row) && (goalPosition.Col === otherPosition.Col)) {
                        alert("you lost :(");
                        isDone = true;
                    }
                }
            }
        }
        return this;
    };
})(jQuery);

function moveLeft(myCanvas, player, dest, context, cellWidth, cellHeight) {
    if (myCanvas.id == "otherMazeCanvas") {
        var i = maze[(otherPosition.Row * cols) + otherPosition.Col - 1];
        if (i == 0) {
            context.clearRect(otherPosition.Col * cellWidth, otherPosition.Row * cellHeight,
                cellWidth, cellHeight);
            otherPosition.Col = otherPosition.Col - 1;
            context.drawImage(player, otherPosition.Col * cellWidth, otherPosition.Row * cellHeight,
                cellWidth, cellHeight);
        }
     }
    else {
        var i = maze[(currentPosition.Row * cols) + currentPosition.Col - 1];
        if (i == 0) {
            context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                cellWidth, cellHeight);
            currentPosition.Col = currentPosition.Col - 1;
            context.drawImage(player, currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                cellWidth, cellHeight);
        }
    }
}

function moveUp(myCanvas, player, dest, context, cellWidth, cellHeight) {
    if (myCanvas.id == "otherMazeCanvas") {
        var i = maze[((otherPosition.Row - 1) * cols) + otherPosition.Col];
        if (i == 0) {
            context.clearRect(otherPosition.Col * cellWidth, otherPosition.Row * cellHeight,
                cellWidth, cellHeight);
            otherPosition.Row = otherPosition.Row - 1;
            context.drawImage(player, otherPosition.Col * cellWidth, otherPosition.Row * cellHeight,
                cellWidth, cellHeight);
        }
    }
    else {
        var i = maze[((currentPosition.Row - 1) * cols) + currentPosition.Col];
        if (i == 0) {
            context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                cellWidth, cellHeight);
            currentPosition.Row = currentPosition.Row - 1;
            context.drawImage(player, currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                cellWidth, cellHeight);
        }
    }
    
}

function moveRight(myCanvas, player, dest, context, cellWidth, cellHeight) {
    if (myCanvas.id == "otherMazeCanvas") {
        var i = maze[(otherPosition.Row * cols) + otherPosition.Col + 1];
        if (i == 0) {
            context.clearRect(otherPosition.Col * cellWidth, otherPosition.Row * cellHeight,
                cellWidth, cellHeight);
            otherPosition.Col = otherPosition.Col + 1;
            context.drawImage(player, otherPosition.Col * cellWidth, otherPosition.Row * cellHeight,
                cellWidth, cellHeight);
        }
    }
    else {
        var i = maze[(currentPosition.Row * cols) + currentPosition.Col + 1];
        if (i == 0) {
            context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                cellWidth, cellHeight);
            currentPosition.Col = currentPosition.Col + 1;
            context.drawImage(player, currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                cellWidth, cellHeight);
        }
    }    
}

function moveDown(myCanvas, player, dest, context, cellWidth, cellHeight) {
    if (myCanvas.id == "otherMazeCanvas") {
        var i = maze[((otherPosition.Row + 1) * cols) + otherPosition.Col];
        if (i == 0) {
            context.clearRect(otherPosition.Col * cellWidth, otherPosition.Row * cellHeight,
                cellWidth, cellHeight);
            otherPosition.Row = otherPosition.Row + 1;
            context.drawImage(player, otherPosition.Col * cellWidth, otherPosition.Row * cellHeight,
                cellWidth, cellHeight);
        }
    }
    else {
        var i = maze[((currentPosition.Row + 1) * cols) + currentPosition.Col];
        if (i == 0) {
            context.clearRect(currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                cellWidth, cellHeight);
            currentPosition.Row = currentPosition.Row + 1;
            context.drawImage(player, currentPosition.Col * cellWidth, currentPosition.Row * cellHeight,
                cellWidth, cellHeight);
        }
    }    
}