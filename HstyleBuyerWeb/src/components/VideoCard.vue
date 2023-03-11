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
                            <!-- 愛心 -->
                            <span v-if="!data.isClicked" @click.prevent @click="postVideoLike(data)"><i class="fa-regular fa-heart fz-18"></i></span>
                            <span v-else @click.prevent @click="postVideoLike(data)"><i class="fa-solid fa-heart fz-18"></i></span>
                            <!-- 宣傳 -->
                            <div class="influence">
                                <label ><i class="fa-solid fa-eye"></i>{{data.views}}</label>
                                <label ><i class="fa-solid fa-heart fz-18"></i>{{data.likes}}</label>
                            </div>
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
import { eventBus } from "../mybus";
import { useRouter } from "vue-router";
const router = useRouter();
// const videos=ref([])
// const Likesvideos=ref([])
// const likes=ref([])
const props = defineProps({
  data: Object,
});

let likes = ref([]);
const likevideoId = ref([]);
const getLikesVideos = async () => {
   await axios.get(`https://localhost:7243/api/Video/MyLike`, { withCredentials: true }).then((response) => {
      if (response.data.length > 0) {
         likes.value = response.data;
         likevideoId.value = likes.value.map((v) => {
            return v.videoId;
         });
      }
   });
};

const postVideoLike = async (data) => {
   console.log(props.data.id);
   await axios
      .post(`https://localhost:7243/api/Video/Like/${props.data.id}`, {}, { withCredentials: true })
      .then((response) => {
         data.isClicked= !data.isClicked;
         eventBus.emit("postVideoLike");
      })
      .catch((error) => {
         console.log(error);
         if (error.response.status === 401) {
            router.push("/login");
         }
      });
};

onMounted(() => {});

eventBus.on("postVideoLike", () => {
    getLikesVideos();
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
