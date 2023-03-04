<template>
    <h1>這裡是編號{{ orderId }}商品頁面</h1>
</template>

<script setup>
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute();

const orderId = ref(0)
onMounted(() => {
    orderId.value = route.params.id;
})
</script>

<style></style>