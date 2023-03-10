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
import { ref, onMounted } from "vue";
// 引入 socket.io-client 模組
import io from "socket.io-client";

export default {
  name: "ChatRoom",
  setup() {
    const message = ref("");
    const messages = ref([]);

    function handleSubmit() {
      messages.value.push(message.value);
      message.value = "";
    }

    onMounted(() => {
      const socket = io("https://localhost:7243/ws");
      socket.on("message", (message) => {
        messages.value.push(message);
      });
    });

    return {
      message,
      messages,
      handleSubmit,
    };
  },
};
</script>