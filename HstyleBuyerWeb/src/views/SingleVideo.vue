<template>
    <div class="container mt-5">
        <div class="row">
            <div class="col-lg-8">
                <div class="">
                    <video class="video" :src="video.filePath"></video>
                </div>
                <div class="content">
                    <label for="" class=" tags" v-for="tag in video.tags">{{tag}}</label>
                    <label class="title">{{video.title}}</label>
                    <p class="description">{{video.description}}</p>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="row">
                    <div class="col-lg-12">
                        <form action="">
                            <div class="form-group" v-for="comment in videoComments">
                                <label >留言者{{comment}}</label>
                                <label class="">留言{{comment.memberId}}</label>
                            </div>
                            <div class="form-group">
                                <div class="d-flex justify-content-start">
                                    <span class="form-label">留言：</span>
                                </div>
                                <input type="text" class="form-control">
                                <div class="d-flex justify-content-end mt-2">
                                    <button type="submit" class="">送出</button>
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class="col-lg-12">
                        <div class="recoProducts">{{}}</div>
                    </div>
                </div>
            </div>
        </div>
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
.video{
    width:800px;
}
</style>
