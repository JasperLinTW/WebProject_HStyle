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
        <router-link :to="'/product/' + rec[0].product_Id">
          <img :src="recImg.length > 0 ? recImg[0] : ''" alt="Large Image">
        </router-link>

      </div>
      <div class="col-md-3 mt-5">
        <div class="row">
          <div class="col-md-6 img-container-sm1">
            <router-link :to="'/product/' + rec[1].product_Id">
              <img :src="recImg.length > 1 ? recImg[1] : ''" alt="Small Image 1">
            </router-link>
          </div>
        </div>
      </div>
      <div class="col-md-3 d-flex align-items-end">
        <div class="row">
          <div class="col-md-12 img-container-sm2">
            <router-link :to="'/product/' + rec[2].product_Id">
              <img :src="recImg.length > 2 ? recImg[2] : ''" alt="Small Image 2"></router-link>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="container">
    <div class="row">
      <div class="h500px">
        <div class="col-md-12">
          <span v-if="orec.length > 0" class="px-5">| 會員專屬推薦 |</span>
          <span v-else class="px-5">| 新品推薦 |</span>
        </div>
        <div class="col-md-12">
          <div class="row">
            <RecommendCard v-for="item in orec" :data="item" v-if="orec.length > 0"></RecommendCard>
            <RecommendCard v-for="item in newrec" :data="item" v-else></RecommendCard>
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
const recImg = ref([])
const isLoadEnd = ref(false);
//推薦商品
const getWeatherRecommend = async () => {
  await axios.get(`https://localhost:7243/api/Weather/weatherRec`)
    .then(response => {
      rec.value = response.data;
      console.log(rec.value);
      recImg.value = response.data.map((p) => {
        return p.imgs[0];
      })
      isLoadEnd.value = true;
      console.log(rec.value);
    })
    .catch(error => { console.log(error); });
}

const orec = ref([]);
//推薦商品
const getOrderRecommend = async () => {
  await axios.get(`https://localhost:7243/api/Products/MemberRec`, { withCredentials: true })
    .then(response => {
      orec.value = response.data;
    })
    .catch(error => { console.log(error); });
}

const newrec = ref([]);
const newProductsRecommend = async () => {
  await axios.get(`https://localhost:7243/api/Products/NewRec`)
    .then(response => {
      newrec.value = response.data;
    })
    .catch(error => { console.log(error); });
}



onMounted(() => {
  getWeatherRecommend();
  getOrderRecommend();
  newProductsRecommend();
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