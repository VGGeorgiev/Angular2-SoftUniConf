"use strict";

// SignalR
var connection = new signalR.HubConnectionBuilder().withUrl("/streamingHub").build();

// SignalR
connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("stream-btn").addEventListener("click", function () {
    connection.stream("ShowMeTheWords", 750)
        .subscribe({
            next: (item) => {
                var li = document.createElement("li");
                li.textContent = item;
                document.getElementById("messagesList").appendChild(li);
            },
            complete: () => {
                var li = document.createElement("li");
                li.textContent = "Stream completed";
                document.getElementById("messagesList").appendChild(li);
            },
            error: (err) => {
                var li = document.createElement("li");
                li.textContent = err;
                document.getElementById("messagesList").appendChild(li);
            }
        });
});
