<template>
     <div class="col-lg-3" v-for="video in videos">
        <div class="card ">
            <router-link :to="'/VideoBlog/' +video.id">
                <div class="card-body">
                    <img class="img img-fluid" :src="video.image" :alt="VideoImage">
                    <p class="card-title title">{{video.title}}</p>
                    <div class="me-auto">
                        <div class="tags" v-for="tag in video.tags">
                            <span class="tag">#{{tag}}</span>
                        </div>
                        <div class="likeIcon d-flex flex-row-reverse">
                            <!-- <span v-if="!video.isClicked" @click="video.isClicked = true"><i class="fa-regular fa-heart fz-18"></i></span> -->
                            <span v-if="!video.isClicked" @click="video.isClicked = true"><i class="fa-regular fa-heart fz-18"></i></span>
                        <span v-else @click="video.isClicked = false"><i class="fa-solid fa-heart fz-18"></i></span>
                        </div>
                    </div>
                </div>
            </router-link>
        </div>
    </div>
</template>

<script setup>
import axios from 'axios';
import {ref,onMounted} from 'vue';

const videos=ref([])
const likeVideosId=ref([])
const likes=ref([])

const getVideos=async()=>{
    await axios.get(`https://localhost:7243/api/Video`)
        .then(response=> {
            response.data.map(v=> {
            v.isClicked=likeVideosId.value.includes(v.id);
        })
            videos.value=response.data;
            console.log(videos.value);
        })
        .catch(error=> {console.log(error);});
}

// const postLike=()=>{
//     axios.post("https://localhost:7243/api/Video/Like",video.id)
//     .then(response=>{
//         if(response.data.length>0){
//             likes.value=response.data;
//         }
//     }).catch(error=>{console.log(error);});
// }


onMounted(() => {
    getVideos();
});
</script>

<style scoped>
.likeIcon{
    color:darkgrey;
    /* border: 1px; */
    font-size: 150%;
}

.img{
    width: 100%;
    height:100%;
}
.title {
    color: black;
    text-decoration:none;
    text-align:left;
}

a{
    text-decoration: none;
}

.tags{
    color: black;
    text-decoration:none;
    text-align:left;
}
</style>
