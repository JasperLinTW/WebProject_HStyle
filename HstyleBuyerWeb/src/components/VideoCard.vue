<template>
    <div class="col-lg-3" v-for="video in videos">
        <div class="card ">
            <router-link :to="'/VideoBlog/' +video.id">
                <img src="{{video.imageId}}" alt="">
                <div class="card-body">
                    <p class="card-title">{{video.title}}</p>
                    <div class="me-2 mb-2">
                        <i class="fa-solid fa-heart"></i>
                    </div>
                </div>
            </router-link>
        </div>
    </div>
</template>

<script setup>
import axios from 'axios';
import {ref,onMounted} from 'vue';

const videos=ref([]);

const getVideos=async()=>{
    await axios.get("https://localhost:7243/api/Video")
        .then(response=>{
            videos.value=response.data;
            console.log(videos.value);
        })
        .catch(error=>{console.log(error);});
}

onMounted(()=>{
    getVideos();
})
</script>

<style scoped>

</style>
