/*
* this function initilaize the settings values;
*/
$(document).ready(function () {
    document.title = "Settings";
    var a = localStorage.getItem("MazeName");
    var b = localStorage.getItem("MazeRows");
    var c = localStorage.getItem("MazeCols");
    var d = localStorage.getItem("MazeAlgo");
    document.getElementById("mazeName").value = a;
    document.getElementById("mazeRows").value = b;
    document.getElementById("mazeCols").value = c;
    document.getElementById("algoSelect").value = d;
});
/*
* this function saves the settings values;
*/
function save() {
    localStorage.MazeName = $("#mazeName").val();
    localStorage.MazeRows = $("#mazeRows").val();
    localStorage.MazeCols = $("#mazeCols").val();
    localStorage.MazeAlgo = $("#algoSelect").val();
    alert("Settings saved");
}