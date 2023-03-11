<template>
   <div>
      <h1>Chat Room</h1>
      <ul>
         <li v-for="(message, index) in messages" :key="index">{{ message }}</li>
      </ul>
      <form @submit.prevent="handleSubmit">
         <input v-model="message" type="text" placeholder="Type your message" />
         <button type="submit">Send</button>
      </form>
   </div>
</template>

<script>
import { ref, onUnmounted  } from "vue";
// 引入 socket.io-client 模組
import io from "socket.io-client";

export default {
   name: "ChatRoom",
   setup() {
      const message = ref("");
      const messages = ref([]);
      const chatSocket = io("https://localhost:7243/ws");

      function handleSubmit() {
         messages.value.push(message.value);
         chatSocket.emit("message", message.value);
         message.value = "";
      }

      chatSocket.on("message", (message) => {
         messages.value.push(message);
      });

      onUnmounted(() => {
         chatSocket.disconnect();
      });

      return {
         message,
         messages,
         handleSubmit,
      };
   },
};
</script>
