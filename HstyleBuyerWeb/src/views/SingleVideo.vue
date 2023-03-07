<template>
    <div>
        <div class="video">
            <video :src="video.filePath"></video>
        </div>
        <div class=" tags" v-for="tag in video.tags">{{tag}}</div>
        <div class="title">{{video.title}}</div>
        <div class="description">{{video.description}}</div>
        <div class="recoProducts">{{}}</div>
        <div class="comment" v-for="comment in videoComments.comment">{{comment}}</div>
        <form action="">
            <div class="form-group" v-for="comment in videoComments">
                <label >留言者{{comment}}</label>
                <label class="">留言{{comment.memberId}}</label>
            </div>
            <div class="form-group">
                <label class="form-label">留言：</label>
                <input type="text" class="form-control">
                <button type="submit">送出</button>
            </div>
        </form>
    </div>
</template>

<script setup>
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
import axios from 'axios';

const video=ref([]);
const route = useRoute();
const getRecoProducts=ref([]);
const videoComments=ref([]);

const getVideo=async()=>{
    await axios.get(`https://localhost:7243/api/Video/${route.params.id}`)
    .then(response=>{
        video.value=response.data;
        console.log(video.value);
    })
    .catch(error=>{console.log(error);});
}

const getComments=async()=>{
    await axios.get(`https://localhost:7243/api/Video/Comments/${route.params.id}`)
    .then(response=>{
        videoComments.value=response.data;
        console.log(videoComments.value);
    })
}
// const getRecoProducts=async()=>{
//     await axios.get(`thhps://localhost:7243/api/Video/${route.params.id}/Recommenations`)
//     .then(response=>{
//         getRecoProducts.value=response.data;
//     })
//     .catch(error=>{console.log(error);});
// }

onMounted(() => {
    getVideo();
    getComments();
})
</script>

<style scoped>

</style>
