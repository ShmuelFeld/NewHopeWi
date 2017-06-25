//initilaize the local storage with default values.
function init() {
    if (localStorage.getItem("MazeName") == 0) {
        localStorage.setItem("MazeName", "Cinderella");
        localStorage.setItem("MazeRows", "12");
        localStorage.setItem("MazeCols", "12");
        localStorage.setItem("MazeAlgo", "0");
    }
}