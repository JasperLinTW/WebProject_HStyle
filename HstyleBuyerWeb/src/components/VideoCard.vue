<template>
     <div class="col-lg-3">
        <div class="card ">
            <router-link :to="'/VideoBlog/' +data.id">
                <div class="card-body">
                    <img class="img img-fluid" :src="data.image" :alt="VideoImage">
                    <p class="card-title title">{{data.title}}</p>
                    <div class="me-auto">
                        <div class="tags" v-for="tag in data.tags">
                            <span class="tag">#{{tag}}</span>
                        </div>
                        <div @click.stop="" class="likeIcon d-flex flex-row-reverse">
                            
                            <span v-if="!data.isClicked" @click="postVideoLike(data.id)"><i class="fa-regular fa-heart fz-18"></i></span>
                            <span v-else @click="data.isClicked = false"><i class="fa-solid fa-heart fz-18"></i></span>
                            <div class="influence">
                                <label onclick="event.stopPropagation()"><i class="fa-solid fa-eye"></i>{{data.views}}</label>
                                <label ><i class="fa-solid fa-thumbs-up"></i>{{data.likes}}</label>
                            </div>
                        </div>
                    </div>
                </div>
            </router-link>
        </div>
    </div>
<!-- 
    收藏影片
    <div class="col-lg-3" v-for="likeVideo in Likesvideos">
        <div class="card ">
            <router-link :to="'/VideoBlog/' +likeVideo.id">
                <div class="card-body">
                    <img class="img img-fluid" :src="likeVideo.image" :alt="VideoImage">
                    <p class="card-title title">{{likeVideo.title}}</p>
                    <div class="me-auto">
                        <div class="tags" v-for="tag in likeVideo.tags">
                            <span class="tag">#{{tag}}</span>
                        </div>
                        <div class="likeIcon d-flex flex-row-reverse">
                            
                            <span v-if="!likeVideo.isClicked" @click="likeVideo.isClicked==true"><i class="fa-regular fa-heart fz-18"></i></span>
                            <span v-else @click="likeVideo.isClicked = false"><i class="fa-solid fa-heart fz-18"></i></span>
                            <div class="influence">
                                <label ><i class="fa-solid fa-eye"></i>{{likeVideo.views}}</label>
                                <label ><i class="fa-solid fa-thumbs-up"></i>{{likeVideo.likes}}</label>
                            </div>
                        </div>
                    </div>
                </div>
            </router-link>
        </div>
    </div> -->
</template>

<script setup>
import axios from 'axios';
import {ref,onMounted} from 'vue';

// const videos=ref([])
// const Likesvideos=ref([])
// const likes=ref([])
const props = defineProps({
  data: Object,
});

// const likesVideos = async () => {
//     await axios.post("https://localhost:7243/api/likes")
//         .then(response => {
//             if (response.data.length > 0) {
//                 likes.value = response.data;
//                 likeProductsId.value = likes.value.map(p => {
//                     return p.productId
//                 });
//             }

//         })
//         .catch(error => { console.log(error); });
// }

// const getVideos=async()=>{
//     await axios.get(`https://localhost:7243/api/Video`)
//     .then(response=>{
//         videos.value=response.data;
//         console.log(videos.value);
//     })
//     .catch(error=>{console.log(error);});
// }

// const getLikesVideos=async()=>{
//     await axios.get(`https://localhost:7243/api/Video/MyLike`,{ withCredentials: true, })
//     .then(response=>{
//         Likesvideos.value=response.data;
//         console.log(Likesvideos.value);
//     })
// }

// const postVideoLike=(videoId)=>{
//     // console.log(videoId);
//     axios.post(`https://localhost:7243/api/Video/Like/${videoId}`,{},{ withCredentials: true, })
//     .then(response=>{
//         console.log("VideoLike");
//     })
//     .catch(error=>
//         {console.log(error.response.status);
//             if (error.response.status === 401) {
//                 router.push("/login");
//         }});
// }

onMounted(() => {
    // getVideos();
    //getLikesVideos();
    //postLike();
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

a {
    text-decoration: none;
}

.tags{
    color: black;
    text-decoration:none;
    text-align:left;
}

.influence{
    color:darkgrey;
    /* color: black; */
    font-size: 70%;
    text-decoration:none;
    text-align:left;
}
</style>
