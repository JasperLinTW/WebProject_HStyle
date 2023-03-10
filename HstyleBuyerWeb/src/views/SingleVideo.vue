<template>
   <div class="container mt-5">
      <div v-if="isLoaded" class="row">
         <div class="col-lg-8">
            <!-- plyr影片串接 -->
            <div>
               <video ref="player" class="plyr__video-embed" playsinline controls autoplay>
                  <source :src="video.filePath" type="video/mp4" autoplay />
               </video>
            </div>
            <!-- <div class="">
                    <video class="video" :src="video.filePath"></video>
                </div> -->
            <div class="content">
               <div v-for="tag in video.tags" :key="tag">#{{ tag }}</div>
               <div class="videoLike">
                  <label>
                     <span>影片收藏 </span>
                     <span v-if="!isClicked" @click="postVideoLike(video.id)"><i class="fa-regular fa-heart icon-hover fz-18"></i></span>
                     <span v-else @click="postVideoLike(video.id)"><i class="fa-solid fa-heart fz-18"></i></span>
                  </label>
               </div>
               <label class="title">{{ video.title }}</label>
               <p class="description">{{ video.description }}</p>
            </div>
         </div>
         <div class="col-lg-4">
            <div class="row">
               <div class="col-lg-12">
                  <form action="">
                     <div class="form-group" v-for="comment in videoComments" :key="comment.id">
                        <div class="d-flex justify-content-start">
                           <label>{{ comment.memberName }}　說：</label>
                           <div>
                              <label>{{ comment.comment }}</label>
                           </div>
                        </div>
                        <div class="videoLike">
                           <label>
                              <span>留言按讚 </span>
                              <span v-if="!commentIsClicked" @click="postCommentLike(comment.id)"
                                 ><i class="fa-regular fa-heart icon-hover fz-18"></i
                              ></span>
                              <span v-else @click="postCommentLike(comment.id)"><i class="fa-solid fa-heart fz-18"></i></span>
                           </label>
                        </div>
                        <div class="d-flex justify-content-end">
                           <label>{{ comment.createdTime.slice(0, 10) }}</label>
                           <!-- 按讚留言 -->
                        </div>
                     </div>
                  </form>
                  <form>
                     <!-- 留言板 -->
                     <div class="form-group">
                        <div class="d-flex justify-content-start">
                           <span class="form-label">留言：</span>
                        </div>
                        <input type="text" v-model="comment" class="form-control" />
                        <div class="d-flex justify-content-end mt-2">
                           <!-- <button type="submit" class="" @click="postComment(videoComments.comment,videoComments.videoId)">送出</button> -->
                           <button type="submit" @click.prevent="postComment()" class="btn btn-light">
                              <!-- <button type="submit" class="" @click="postComment(comment,videoId)"> -->
                              送出
                           </button>
                        </div>
                     </div>
                  </form>
               </div>
               <br />
               <!-- 商品推薦 -->
               <div class="col-lg-12">
                  <div class="users">
                     商品推薦
                     <div class="col-lg-6">
                        <div class="recoProducts" v-for="product in RecoProducts" :key="product.product_Id">
                           <a :href="`http://localhost:5173/product/${product.product_Id}`">
                              <div>
                                 <img class="img-fluid" :src="product.imgs[0]" alt="推薦商品圖片" />
                              </div>
                              <label>{{ product.product_Name }}</label>
                           </a>
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
import { onMounted, ref } from "vue";
import { useRoute, useRouter } from "vue-router";
import axios from "axios";
import Plyr from "plyr";
import { slotFlagsText } from "@vue/shared";

// export default {
//   data() {
//     return {
//       videoUrl: 'path/to/video.mp4'
//     };
//   },
//   mounted() {
//     const player = new Plyr(this.$refs.player);
//   }
// };

const video = ref([]);
const route = useRoute();
const RecoProducts = ref([]);
const videoComments = ref([]);

const router = useRouter();
const isLoaded = ref(false);
const isClicked = ref(false);
// likeCommentId會員所有喜歡的評論
let likesComments = ref([]);
const likeCommentId = ref([]);

// get
const getVideo = async () => {
   await axios
      .get(`https://localhost:7243/api/Video/${route.params.id}`)
      .then((response) => {
         video.value = response.data;
         console.log(video.value);
         isClicked.value = likevideoId.value.includes(parseInt(route.params.id));
      })
      .catch((error) => {
         console.log(error);
      });
};

const getComments = async () => {
   await axios
      .get(`https://localhost:7243/api/Video/Comments/${route.params.id}`)
      .then((response) => {
         videoComments.value = response.data;
         console.log("commentGet");
      })
      .catch((error) => {
         console.log(error);
      });
};

const getRecommenations = async () => {
   await axios
      .get(`https://localhost:7243/api/Video/Recommenations/${route.params.id}`)
      .then((response) => {
         RecoProducts.value = response.data;
         console.log(RecoProducts.value);
         isLoaded.value = true;
      })
      .catch((error) => {
         console.log(error);
      });
};

// 喜歡的評論
const getCommentLikes = async () => {
   await axios.get(`https://localhost:7243/api/Video/comment/Likes`, { withCredentials: true }).then((response) => {
      if (response.data.length > 0) {
         likesComments.value = response.data;
         likeCommentId.value = likesComments.value.map((likes) => {
            return likes.commentId;
         });
      }
   });
};

// 喜歡的video
let likes = ref([]);
const likevideoId = ref([]);
const getLikesVideos = async () => {
   await axios.get(`https://localhost:7243/api/Video/MyLike`, { withCredentials: true }).then((response) => {
      if (response.data.length > 0) {
         likes.value = response.data;
         likevideoId.value = likes.value.map((v) => {
            return v.videoId;
         });
         console.log("likes");
      }
   });
};

// post
const postVideoLike = (videoId) => {
   // console.log(videoId);
   axios
      .post(`https://localhost:7243/api/Video/Like/${videoId}`, {}, { withCredentials: true })
      .then((response) => {
         isClicked.value = !isClicked.value;
         console.log(isClicked.value);
      })
      .catch((error) => {
         console.log(error.response.status);
         if (error.response.status === 401) {
            router.push("/login");
         }
      });
};

// 點擊喜歡的留言
const commentIsClicked = ref(false);
const postCommentLike = (commentId) => {
   axios
      .post(`https://localhost:7243/api/Video/CommentLike/${commentId}`, {}, { withCredentials: true })
      .then((response) => {
         commentIsClicked.value = !commentIsClicked.value;
         console.log("commentLike");
      })
      .catch((error) => {
         console.log(error.response.status);
         if (error.response.status === 401) {
            window.location = "http://localhost:5173/login";
         }
      });
};

const postView = () => {
   axios
      .post(`https://localhost:7243/api/Video/View/${route.params.id}`)
      .then((response) => {
         console.log("view");
      })
      .catch((error) => {
         console.log(error);
      });
};

// 送出留言
const comment = ref("");
const postComment = async () => {
   //console.log(comment);
   //const data = { comment: comment.value };
   //const jsonString = JSON.stringify(data);
   await axios
      .post(`https://localhost:7243/api/Video/Comment/${route.params.id}`, { comment: comment.value }, { withCredentials: true })
      .then((response) => {
         console.log("Comment");
         console.log(response.data);
         getComments();
         comment.value = "";
      })
      .catch((error) => {
         console.log(error.response.status);
         if (error.response.status === 401) {
            window.location = "http://localhost:5173/login";
         }
      });
};

onMounted(async () => {
   await getLikesVideos();
   await getVideo();
   await getComments();
   await getRecommenations();
   // postView();
   // const player = new Plyr(this.$refs.player);
   // player.on("ready", () => {
   //   console.log(player.duration);
   // });
});
</script>

<style scoped>
@import "plyr/dist/plyr.css";
/* @import '~plyr/dist/plyr.css'; */
.video {
   width: 800px;
}

img {
   height: 140px;
}

video {
   width: 800px;
}
</style>
