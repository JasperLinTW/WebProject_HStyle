<template>
    <div class="container mt-5">
        <div class="row">
            <div class="col-lg-8">
                <div class="">
                    <video class="video" :src="video.filePath"></video>
                </div>
                <div class="content">
                    <div v-for="tag in video.tags">#{{tag}}</div>
                    <div class="videoLike">
                        <label >
                            <span>影片收藏  </span>
                            <span v-if="!video.isClicked" @click="postVideoLike(videoId)" ><i class="fa-regular fa-heart fz-18"></i></span>
                            <span v-else @click="video.isClicked = false"><i class="fa-solid fa-heart fz-18"></i></span></label>
                    </div>
                    <!-- <label for="" class=" tags" v-for="tag in video.tags">{{tag}}</label> -->
                    <label class="title">{{video.title}}</label>
                    <p class="description">{{video.description}}</p>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="row">
                    <div class="col-lg-12">
                        <form action="">
                            <div class="form-group" v-for="comment in videoComments">
                                <label >{{comment.memberId}}　說：</label>
                                <label >{{comment.comment}}</label>
                                <label >{{comment.createdTime.slice(0, 10)}}</label>
                                按讚留言
                                <label ><span v-if="!video.isClicked" @click="postCommentLike(videoId)"><i class="fa-regular fa-heart fz-18"></i></span>
                                <span v-else @click="video.isClicked = false"><i class="fa-solid fa-heart fz-18"></i></span>
                                </label> 
                            </div>
                            <div class="form-group">
                                <div class="d-flex justify-content-start">
                                    <span class="form-label">留言：</span>
                                </div>
                                <input type="text" class="form-control">
                                <div class="d-flex justify-content-end mt-2">
                                    <button type="submit" class="" @click="postComment(comment)">送出</button>
                                </div>
                            </div>
                        </form>
                    </div>
                    <br>
                    <div class="col-lg-12">
                        <div class="users">商品推薦
                            <div class="col-lg-6 ">
                                <div class="recoProducts" v-for="product in RecoProducts">
                                    <div>
                                        <img class="img-fluid" :src="product.imgs[0]" alt="推薦商品圖片">
                                    </div>
                                    <label>{{ product.product_Name }}</label>
                                </div>
                            </div>
                        </div>
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
const RecoProducts=ref([]);
const videoComments=ref([]);
const videoLike=ref([]);

// get
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
    .catch(error=>{console.log(error);});
}

const getRecommenations=async()=>{
    await axios.get(`https://localhost:7243/api/Video/Recommenations/${route.params.id}`)
    .then(response=>{
        RecoProducts.value=response.data;
        console.log(RecoProducts.value);
    })
    .catch(error=>{console.log(error);});
}

// post
const postVideoLike=(videoId)=>{
    axios.post(`https://localhost:7243/api/Video/Like/${videoId}`,{ withCredentials: true, })
    .then(response=>{
        console.log("VideoLike");
    })
    .catch(error=>{console.log(error);});
}

const postCommentLike=(videoId)=>{
    axios.post(`https://localhost:7243/api/Video/CommentLike/${videoId}`,{ withCredentials: true, })
    .then(response=>{
        console.log("commentLike");
    })
    .catch(error=>{console.log(error);});
}

const postView=()=>{
    axios.post(`https://localhost:7243/api/Video/View/${route.params.id}`)
    .then(response=>{
        console.log("view");
    })
    .catch(error=>{console.log(error);});
}

const postComment=(comment)=>{
    axios.post(`https://localhost:7243/api/Video/Comment?videoId=${route.params.id}`,{ withCredentials: true, })
    .then(response=>{
        console.log("Comment");
    })
    .catch(error=>{console.log(error);});
}

onMounted(() => {
    getVideo();
    getComments();
    getRecommenations();
    postView();
})
</script>

<style scoped>
.video{
    width:800px;
}

img{
    height: 140px;
}
</style>
