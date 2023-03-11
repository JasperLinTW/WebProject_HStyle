<template>
<div >
    <div class="container">
        <div class="row">
            <div class="col-lg-4 d-flex">
                    <input type="text" class="form-control "  v-model="keyword" placeholder="請輸入影片關鍵字">
                    <button type="submit" class="btn btn-light" @click="searchVideosByIndex(keyword)">搜尋</button>
            </div>
        </div>
    </div>
    <div class="container" >
        <div class="row">
            <VideoCard v-for="video in videos" :data="video"/>
        </div>
    </div>    
</div>
    
</template>

<script setup>
import VideoCard from '../components/VideoCard.vue';
import axios from 'axios';
import {ref,onMounted} from 'vue';
import { eventBus } from "../mybus";

//const isLoaded=ref(false);
const videos=ref([])
const Likesvideos=ref([])
//const likeVideosId=ref([]);
//影片收藏
let likes = ref([]);
const likevideoId = ref([]);
const getLikesVideos = async () => {
   await axios.get(`https://localhost:7243/api/Video/MyLike`, { withCredentials: true })
   .then((response) => {
      if (response.data.length > 0) {
         likes.value = response.data;
         likevideoId.value = likes.value.map((v) => {
            return v.videoId;
         });
         getVideos();
        }
   })
   .catch((error) => {
      console.log(error);
    });
};

const getVideos=async()=>{
    await axios.get(`https://localhost:7243/api/Video`, {
      withCredentials: true,
    })//為什麼需要身分驗證?
    .then(response=>{
        response.data.map((v)=>{
            v.isClicked=likevideoId.value.includes(v.id);
        })
        videos.value=response.data;
        //isLoaded.value=true;
    })
    .catch(error=>{console.log(error);});
}

// 搜尋
const keyword = ref('');
const updateSelectVideos=ref([]);
const selectedVideos=ref({});
const searchVideosByIndex=(keyword)=>{
    if(keyword===""){
        getVideos();
    }else{
        selectedVideos.value=videos.value.filter(v=>v.title.includes(keyword)||v.tags.includes(keyword));
        videos.value=selectedVideos.value;
    }
};

const postVideoLike = (data) => {
   axios
      .post(`https://localhost:7243/api/Video/Like/${props.data.id}`, {}, { withCredentials: true })
      .then((response) => {
         data.isClicked= !data.isClicked;
         eventBus.emit("postVideoLike");
         getVideos();
      })
      .catch((error) => {
         console.log(error);
         if (error.response.status === 401) {
            router.push("/login");
         }
      });
};

onMounted(() => {
    getVideos();
    getLikesVideos();
    searchVideosByIndex();
});

eventBus.on("postVideoLike", () => {
    getLikesVideos();
});
</script>

<style scoped>

</style>
