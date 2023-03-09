<!-- Recommend.vue -->
<template>
  <div class="container mt-5 mb-7">
    <div class="row">
      <div class="col-md-12 line">
        <span class="px-5 fs-5 fw-bold">今日推薦</span>
      </div>
    </div>
  </div>
  <div class="container d-flex justify-content-center mb-6">
    <div v-if="isLoadEnd" class="row  justify-content-center">
      <div class="col-md-6 img-container-lg">
        <img :src="rec[[0]].imgs[0]" alt="Large Image">
      </div>
      <div class="col-md-3 mt-5">
        <div class="row">
          <div class="col-md-6 img-container-sm1">
            <img :src="rec[[1]].imgs[0]" alt="Small Image 1">
          </div>
        </div>
      </div>
      <div class="col-md-3 d-flex align-items-end">
        <div class="row">
          <div class="col-md-12 img-container-sm2">
            <img :src="rec[[2]].imgs[0]" alt="Small Image 2">
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="container">
    <div class="row">
      <div class="h500px">
        <div class="col-md-12">
          <span class="px-5">| 會員專屬推薦 |</span>
        </div>
        <div class="col-md-12">
          <div class="row">
            <RecommendCard v-for="item in orec" :data="item"></RecommendCard>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
  
<script setup>
import { onMounted, ref } from 'vue';
import axios from "axios";
import RecommendCard from '../components/RecommendCard.vue';

const rec = ref([]);
const isLoadEnd = ref(false);
//推薦商品
const getWeatherRecommend = async () => {
  await axios.get(`https://localhost:7243/api/Weather/weatherRec`)
    .then(response => {
      rec.value = response.data;
      isLoadEnd.value = true;
      console.log(rec.value);
    })
    .catch(error => { console.log(error); });
}

const orec = ref([]);
//推薦商品
const getOrderRecommend = async () => {
  await axios.get(`https://localhost:7243/api/Products/MemberRec`)
    .then(response => {
      orec.value = response.data;
    })
    .catch(error => { console.log(error); });
}



onMounted(() => {
  getWeatherRecommend();
  getOrderRecommend();
})

</script>

<style scoped>
.h500px {
  height: 500px;
}

.line {
  border-top: 1px solid #dee2e6;
  text-align: center;
  line-height: 0.1em;
}

.line span {
  background: #fff;
  padding: 0 10px;
}

.fz15 {
  font-size: 15pt;
  text-align: left;
}

.mb-7 {
  margin-bottom: 5%;
}

.mb-6 {
  margin-bottom: 15%;
}

.px-10 {
  padding-left: 10%;
  padding-right: 10%;
}

.img-container-lg {
  width: 550px;
  height: 800px;
  overflow: hidden;
}

.img-container-lg img {
  display: block;
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.img-container-sm1 {
  width: 330px;
  height: 450px;
  overflow: hidden;
}

.img-container-sm1 img {
  display: block;
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.img-container-sm2 {
  width: 330px;
  height: 500px;
  overflow: hidden;
}

.img-container-sm2 img {
  display: block;
  width: 100%;
  height: 100%;
  object-fit: cover;
}
</style>