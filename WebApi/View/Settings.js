function save() {
    sessionStorage.Name = $("#MazeName").val();
    sessionStorage.Rows = $("#MazeRows").val();
    sessionStorage.Cols = $("#MazeCols").val();
    sessionStorage.Algo = $("#algoSelect").val();
}