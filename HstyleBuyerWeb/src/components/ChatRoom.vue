<template>
   <div class="container" id="app">
      <div class="row">
         <input class="col-3 m-1" v-model="userName" placeholder="User name" />
         <input class="col-6 m-1" v-model="message" placeholder="Message" />
         <button class="col-2 m-1 btn btn-light" @click="sendMessage">Send</button>
      </div>
      <div class="p-2 chat">
         <ul>
            <li v-for="(item, index) in chatHistory" :key="index">{{ item.userName }} 說: {{ item.message }}</li>
         </ul>
      </div>
   </div>
</template>

<script>
import { ref, onMounted } from "vue";
import axios from "axios";

export default {
   setup() {
      const userName = ref("");
      const message = ref("");
      const chatHistory = ref([]);

      let socket;

      async function connect() {
         try {
            const { data } = await axios.get("https://localhost:7243/api/WebSocket");
            socket = new WebSocket("wss://localhost:7243/api/WebSocket");
            socket.onmessage = function (e) {
               processMessage(e.data);
            };
         } catch (error) {
            console.error(error);
         }
      }

      function processMessage(data) {
         const content = JSON.parse(data);
         chatHistory.value.push(content);
      }

      function sendMessage() {
         if (socket && socket.readyState === WebSocket.OPEN) {
            const data = {
               userName: userName.value,
               message: message.value,
            };
            socket.send(JSON.stringify(data));
            message.value = "";
         }
      }

      onMounted(() => {
         connect();
      });

      function handleKeyPress(event) {
         if (event.keyCode === 13) {
            sendMessage();
         }
      }

      return {
         userName,
         message,
         chatHistory,
         sendMessage,
         handleKeyPress,
      };
   },
};
</script>
