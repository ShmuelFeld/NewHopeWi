var multiplayer = $.connection.MultiPlayerHab;

multiplayer.client.broadcastMessage = function (name, message) {
    // Add the message to the page
    alert("msg");
};
$.connection.hub.start().done(function () {
    $("#btnStartGame").click(function () {
        multiplayer.server.hello();
    });
});
