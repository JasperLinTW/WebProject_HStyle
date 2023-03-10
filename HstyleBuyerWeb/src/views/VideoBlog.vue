<template>
    <div class="container">
        <div class="row">
                <VideoCard  v-for="video in videos" :data="video"/>
        </div>
    </div>    
</template>

<script setup>
import VideoCard from '../components/VideoCard.vue';
import axios from 'axios';
import {ref,onMounted} from 'vue';

const videos=ref([])
const Likesvideos=ref([])
const likes=ref([])

const getVideos=async()=>{
    await axios.get(`https://localhost:7243/api/Video`)
    .then(response=>{
        videos.value=response.data;
        console.log(videos.value);
    })
    .catch(error=>{console.log(error);});
}

// const getLikesVideos=async()=>{
//     await axios.get(`https://localhost:7243/api/Video/MyLike`,{ withCredentials: true, })
//     .then(response=>{
//         Likesvideos.value=response.data;
//         console.log(Likesvideos.value);
//     })
// }

const postVideoLike=(videoId)=>{
    // console.log(videoId);
    axios.post(`https://localhost:7243/api/Video/Like/${videoId}`,{},{ withCredentials: true, })
    .then(response=>{
        console.log("VideoLike");
    })
    .catch(error=>
        {console.log(error.response.status);
            if (error.response.status === 401) {
                router.push("/login");
        }});
}

onMounted(() => {
    getVideos();
    //getLikesVideos();
    //postLike();
});
</script>

<style scoped>

</style>
