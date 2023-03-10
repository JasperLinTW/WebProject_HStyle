<!-- Blog.vue -->
<template>
 
  <div class="container-car">
    <div class="wrap">
      <a class="slide-arrow" id="slidePrev"><i class="fa-solid fa-chevron-left"></i></a>
      <a class="slide-arrow right" id="slideNext"><i class="fa-solid fa-chevron-right"></i></a>
      <ul class="slide-img" id="slideImg">
        <li><img src="../assets/image/chanel1.jpg" alt="" /></li>
        <li><img src="../assets/image/chanel2.jpg" alt="" /></li>
        <li><img src="../assets/image/chanel3.jpg" alt="" /></li>
        <li><img src="../assets/image/chanel4.jpg" alt="" /></li>
        <li><img src="../assets/image/chanel5.jpg" alt="" /></li>
      </ul>
      <div class="card-img-overlay">
        <div class="card-title">
          <h5 class="">This is a wider card with supporting text below as a natural lead-in to additional content. This
            content is a little bit longer.</h5>
        </div>
      </div>
      <ul class="pages">
        <li></li>
        <li></li>
        <li></li>
        <li></li>
        <li></li>
      </ul>
    </div>



  <div class="">
    <div class="vegas-slide-container">
      <div id="example"></div>
    </div>

    <hr />
    <p class="lan">最新消息</p>
    <hr />
  </div>
  <div class="container">
    <div class="row">
      <EssayCard v-for="item in essays.slice(0, 2)" :data="item"></EssayCard>
    </div>
  <!-- <div class="row">
          <VideoCard v-for="item in videos.slice(0,3)" :data="item"></VideoCard>
        </div>
          <EssayCard v-for="item in newessays.slice(0, 2)" :data="item"></EssayCard> -->
  </div>

  <!-- 左右兩邊文章專區 -->

  <div v-if="loaded" class="container-essay">
    
      <div  class="column">
        <router-link :to="'/EssaysBlog/' + essays[1].essayId">
        
            <img :src="essays[0].imgs[0]" class="" alt="">
            <div class="details">
            <div class="category">{{ essays[0].categoryName}}</div>
             <div class="title">{{ essays[0].etitle }}</div> 
             <div class="influencer">{{ essays[0].influencerName }}</div>
             <div class="formatDate">{{ formatDate(essays[0].uplodTime)}}</div>
            </div>
        </router-link> 
      </div>
      <div class="column " style="z-index:0;">
        <img src="../assets/image/jisoo.jpg" alt="Image">
        <img src="../assets/image/jisoo.jpg" alt="Image">
        <img src="../assets/image/jisoo.jpg" alt="Image">
      </div>
      <div class="column" style="z-index:0;">
        <img src="../assets/image/jisoo.jpg" alt="Image">
        <img src="../assets/image/jisoo.jpg" alt="Image">
        <img src="../assets/image/jisoo.jpg" alt="Image">
      </div>
   
  </div>


  <div class="">
    <div class="vegas-slide-container">
      <div id="example"></div>
    </div>

    <hr />
    <p class="lan">最新消息</p>
    <hr />
  </div>
  <div class="container">
    <div class="row">
      <EssayCard v-for="item in essays.slice(0, 2)" :data="item"></EssayCard>
    </div>
  <!-- <div class="row">
          <VideoCard v-for="item in videos.slice(0,3)" :data="item"></VideoCard>
        </div>
          <EssayCard v-for="item in newessays.slice(0, 2)" :data="item"></EssayCard> -->
  </div>
</div>
</template>
  
<script setup>
import EssayCard from '../components/EssayCard.vue'
import VideoCard from '../components/VideoCard.vue';
import { ref, onMounted } from "vue";
import axios from "axios";

const loaded = ref(false)
const essays = ref([]);

const getEssayInfo = async () => {
  await axios.get("https://localhost:7243/api/Essay")
    .then(response => {
      essays.value = response.data; console.log(essays.value)
      loaded.value = true;
    })
    .catch(error => { console.log(error); });

};
onMounted(() => {
  getEssayInfo();
});



// const videos=ref([])
// const getVideos=async()=>{
//     await axios.get(`https://localhost:7243/api/Video`)
//     .then(response=>{
//         videos.value=response.data;
//         console.log(videos.value);
//     })
//     .catch(error=>{console.log(error);});
// }
// onMounted(() => {
//     getVideos();
//     //getLikesVideos();
//     //postLike();
// });

const formatDate = (dateString) => {
  const date = new Date(dateString);
  const year = date.getFullYear();
  const month = date.getMonth() + 1;
  const day = date.getDate();
  return `${year}年${month}月${day}日`;
};


$(function () {

  let index = 0;
  let slideMove = 0;
  $(".pages li").eq(0).css("background", "white");
  $(".pages li").on("mouseenter", function () {

    index = $(this).index();

  });
  let slideLiLength = $(".pages li").length;
  console.log(slideLiLength);
  $("#slideNext").on("click", function () {
    // console.log("123");
    index++;
    if (index >= slideLiLength) {
      index = 0;
    }
    ;
    moveImg();
  });
  $("#slidePrev").on("click", function () {
    index--;
    if (index < 0) {
      index = slideLiLength - 1;
    }
    moveImg();
  });
  // 圖片移動
  function moveImg() {
    slideMove = 0 - index * 800;
    $("#slideImg").css("left", slideMove);
    $(".pages li")
      .eq(index)
      .css("background", "white")
      .siblings()
      .css("background", "transparent");
  }
  setInterval(autoImg, 2000);
  function autoImg() {
    index++;
    if (index >= slideLiLength) {
      index = 0;
    }
    moveImg();
  }
});
</script>

<style scoped>
.container-car{
  /* max-width:4000px;  change this value to adjust the width as desired 
  margin: 50px auto; centers the container horizontally */
}
.change-width{
  max-width: 1900px; /* change this value to adjust the width as desired */
  margin: 0 auto; /* centers the container horizontally */
}
.wrap {
  width: 800px;
  height: 400px;
  background-color: black;
  margin: 0 auto;
  position: relative;
  overflow: hidden;
}

.slide-img {
  position: absolute;
  margin: 0;
  padding: 0;
  left: 0;
  list-style: none;
  display: flex;
  width: 4000px;
  left: -1600px;
}

.slide-img li {
  width: 800px;
  height: 400px;
}

.slide-img li img {
  width: 100%;
  height: 100%;
  /* 控制元素內容大小 調整比例 */
  object-fit: cover;

}

.pages {
  position: absolute;
  list-style: none;
  margin: 0;
  padding: 0;
  display: flex;
  bottom: 10px;
  width: 100%;
  justify-content: center;
}

.pages li {
  border: 1px solid #fff;
  width: 5px;
  height: 5px;
  border-radius: 50%;
  margin: 0 5px;
}

.slide-arrow {
  position: absolute;
  /* background-color: red; */
  width: 30px;
  height: 100%;
  z-index: 1;
  display: flex;
  color: white;
  font-size: 36px;
  align-items: center;
  cursor: pointer;
  opacity: 0.6;
}

.right {
  right: 0;
}

.slide-arrow:hover {
  opacity: 1;
}

.card-title {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  padding: 20px;
  margin-bottom: 15%;
  text-align: center;
  background-color: rgba(84, 88, 90, 0.5);
}

.card-img-overlay {
  height: 500px;
}

hr .lan {
  border: none;
  border: 5px;
  border-bottom: 1px solid lightgray;
  margin: 300px 0 0 0;
  top: -15em;
  background-color: transparent;

}

/* essay card 排版 */
.details {
  position: relative;
}

.details div {
  position: absolute;
  bottom: 0;
  font-weight: bold;
  color: white;
}

.category {
  right: 275px;
  font-family: cursive ;
  font-weight: bold;
  padding:60px;
  height: 400px;
}

.title {
  font-family: 標楷體;
  font-size: x-large;
  left: 50%;
  transform: translateX(-50%);
  /* padding:60px; */
  height: 300px;
 
}

.influencer {

  font-family: cursive  ;
  padding:60px;
  height: 210px;
  left: 130px;
  right: 150px;
}

.formatDate {
  left: 130px;
  right: 150px;
  /* bottom: 20px; */
  font-family: cursive  ;
  font-weight: bold;
  padding:60px;
  height: 180px;
}


 

/* 文章專區 */
.container-essay {
  display: flex;
  position: relative;
  overflow-x: hidden;
  height: 100vh;
  /* scroll-snap-type: y mandatory; */
  overflow-x: scroll;
 

}

.card-img-top{
  height: 100vh;
}

/* 隱藏 scroll bar */
.container-essay::-webkit-scrollbar {
  display: none;
}


.container::-webkit-scrollbar-thumb {
  background-color: transparent;
}

.column::-webkit-scrollbar {
  width: 0;
  height: 0;
}

.column::-webkit-scrollbar-thumb {
  background-color: transparent;
}

.column {
  flex: 1;
  padding: 10px;
}

.column:not(:first-child) {
  position: relative;
  z-index: 1;
}

.column:first-child {
  flex: none;
  width: 33.33%;
  position: sticky;
  top: 0;
  height: 100%;
  overflow: hidden;
}

img {
  display: block;
  width: 100%;
  margin-bottom: 10px;
}

a {
  text-decoration: none;
}


</style>