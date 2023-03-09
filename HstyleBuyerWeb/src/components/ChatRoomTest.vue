<template>
   <div class="container" id="app">
      <div class="row">
         <input class="col-4 m-1" id="userName" placeholder="User name" />
         <input class="col-6 m-1" id="message" placeholder="Message" />
         <button class="col-1 m-1" id="send">Send</button>
      </div>
      <div class="p-2 chat">
         <ul id="list"></ul>
      </div>
   </div>
</template>

<script>
var socket;
var wsUrl = `${document.location.href.replace("http", "ws")}/ws`;
//alert(wsUrl);
function connect() {
   socket = new WebSocket(wsUrl);
   socket.onmessage = function (e) {
      processMessage(e.data);
   };
}
var list = document.getElementById("list");
function processMessage(data) {
   let li = document.createElement("li");
   var content = JSON.parse(data);
   li.textContent = `${content["userName"]}說:${content["message"]}`;
   list.appendChild(li);
}
function sendMessage(msg) {
   if (socket && socket.readyState == WebSocket.OPEN) socket.send(msg);
}
connect();
var message = document.getElementById("message");
var send = document.getElementById("send");
message.addEventListener("keydown", function (e) {
   if (e.keyCode === 13) send.click();
});
send.addEventListener("click", function () {
   var data = {
      userName: $("#userName").val(),
      message: $("#message").val(),
   };
   sendMessage(JSON.stringify(data));
});
</script>