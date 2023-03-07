<template>
    <div v-for="item in video">
        <div class="video">
            <video :src="video.filePath" ></video>
        </div>
        <div class=" tags" v-for="tag in item.tags">

        </div>
        <div class="description">

        </div>
        <div class="r ecoProducts">

        </div>
    </div>
    123456
</template>

<script setup>
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
import axios from 'axios';

const route = useRoute();
onMounted(() => {
    getProduct();
})
</script>

<style scoped>

</style>
