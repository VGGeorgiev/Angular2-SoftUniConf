"use strict";

// SignalR
var connection = new signalR.HubConnectionBuilder().withUrl("/stronglyTypedHub").build();

// SignalR
connection.on("receiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

// SignalR
connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    // SignalR
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});