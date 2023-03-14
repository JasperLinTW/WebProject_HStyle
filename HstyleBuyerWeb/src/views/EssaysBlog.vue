<!-- Blog.EssaysBlog -->
<template>
  <div class="container">
    <div class="row border-bottom mb-5 mt-4 pb-2 d-flex justify-content-evenly">
      <div class="col-md-1">
        <router-link to="/Blog/EssaysBlog" class="nav-link targetAll btn-underline">文章</router-link>
      </div>
      <div class="col-md-1">
        <router-link to="/Blog/VideoBlog" class="nav-link targetAll btn-underline">影音</router-link>
      </div>
    </div>
  </div>

  <div class="container">
    <div class="row">
      <EssayCard v-for="item in essays" :data="item"></EssayCard>
    </div>
  </div>
</template>

<script setup>
import EssayCard from "../components/EssayCard.vue";
import { ref, onMounted } from "vue";
import axios from "axios";

//收藏
let likes = ref([]);

const likeEssays = ref([]);

const likesEssay = async () => {
  await axios
    .get("https://localhost:7243/api/Essay/Elike", { withCredentials: true })
    .then((response) => {
      if (response.data.length > 0) {
        likes.value = response.data;
        likeEssays.value = likes.value.map((e) => {
          return e.essayId;
        });
        //console.log(likeEssays.value);
      }
    })
    .catch((error) => {
      console.log(error);
    });
};

const essays = ref([]);

const getEssayInfo = async () => {
  await axios
    .get("https://localhost:7243/api/Essay")
    .then((response) => {
      response.data.map((e) => {
        e.isClicked = likeEssays.value.includes(e.essayId);
      });
      essays.value = response.data;
      //console.log(essays.value);
    })

    .catch((error) => {
      console.log(error);
    });
};
onMounted(() => {
  getEssayInfo();
});

onMounted(() => {
  likesEssay();
});
</script>

<style>
/* 寫css */
</style>
