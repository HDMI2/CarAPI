// Bind DOM elements
var sendForm = document.getElementById("send-form");
var sendButton = document.getElementById("send-button");
var messagesList = document.getElementById("messages-list");
var messageTextBox = document.getElementById("message-textbox");

function appendMessage(content) {
    var li = document.createElement("li");
    li.innerText = content;
    messagesList.appendChild(li);
}

var connection = new signalR.HubConnection("/hubs/chat");

sendForm.addEventListener("submit", function () {
    var message = messageTextBox.value;
    messageTextBox.value = "";
    connection.send("Send", message);
});

connection.on("SendMessage", function (sender, message) {
    appendMessage(sender + ': ' + message);
});

connection.on("SendAction", function (sender, action) {
    appendMessage(sender + ' ' + action);
});

connection.start().then(function () {
    messageTextBox.disabled = false;
    sendButton.disabled = false;
});