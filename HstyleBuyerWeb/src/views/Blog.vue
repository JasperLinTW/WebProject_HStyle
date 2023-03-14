<!-- Blog.vue -->
<template>
  <div class="container">
    <div class="row border-bottom mb-5 mt-4 pb-2 d-flex justify-content-evenly">
      <div class="col-md-1"><router-link to="/Blog/EssaysBlog" class="nav-link targetAll btn-underline">文章</router-link>
      </div>
      <div class="col-md-1"> <router-link to="/Blog/VideoBlog" class="nav-link targetAll btn-underline">影音</router-link>
      </div>
    </div>
  </div>

  <div class="container">
    <!-- 圖片倫播 -->
    <div class="wrap">
      <a class="slide-arrow" id="slidePrev"><i class="fa-solid fa-chevron-left"></i></a>
      <a class="slide-arrow right" id="slideNext"><i class="fa-solid fa-chevron-right"></i></a>
      <ul class="slide-img" id="slideImg">
        <li><img src="../assets/image/carousel01.webp" alt="" /></li>
        <li><img src="../assets/image/carousel02.jpg" alt="" /></li>
        <li><img src="../assets/image/carousel03.jpg" alt="" /></li>
        <li><img src="../assets/image/carousel03.jpg" alt="" /></li>
        <li><img src="../assets/image/carousel03.jpg" alt="" /></li>
      </ul>
      <div class="card-img-overlay">
        <div class="card-title">
          <h5 class="">
            This is a wider card with supporting text below as a natural lead-in
            to additional content. This content is a little bit longer.
          </h5>
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
    <!-- 圖片倫播 end -->

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
      <!-- </div>
      <div class="row"> -->
        <VideoCard v-for="items in videos.slice(0, 2)" :data="items"></VideoCard>
      </div>
      <!-- <EssayCard v-for="item in newessays.slice(0, 2)" :data="item"></EssayCard> -->
    </div>

    <!-- 左右兩邊文章專區 -->

  <!-- <div v-if="loaded" class="container-essay">
      <div class="column">
        <router-link :to="'/EssaysBlog/' + essays[1].essayId">
          <img :src="essays[0].imgs[0]" class="" alt="" />
          <div class="details">
            <div class="category">{{ essays[0].categoryName }}</div>
            <div class="title">{{ essays[0].etitle }}</div>
            <div class="influencer">{{ essays[0].influencerName }}</div>
            <div class="formatDate">{{ formatDate(essays[0].uplodTime) }}</div>
          </div>
        </router-link>
      </div>
      <div class="column" style="z-index: 0">
        <img src="../assets/image/jisoo.jpg" alt="Image" />
        <img src="../assets/image/jisoo.jpg" alt="Image" />
        <img src="../assets/image/jisoo.jpg" alt="Image" />
      </div>
      <div class="column" style="z-index: 0">
        <img src="../assets/image/jisoo.jpg" alt="Image" />
        <img src="../assets/image/jisoo.jpg" alt="Image" />
        <img src="../assets/image/jisoo.jpg" alt="Image" />
      </div>
                                      </div> -->

    <div class="container-essay" ref="container">
      <div class="col-4 column" ref="firstColumn">
        <img src="../assets/image/jisoo.jpg" alt="Image" />
      </div>
      <div class="col-4 column" ref="secondColumn">
        <div class="container">
          <div class="row mb-3">
            <div class="col mb-3">
              <div class="custom-card">
                <img src="https://via.placeholder.com/150" class="card-img-top" alt="..." />
                <div class="card-body">
                  <h5 class="card-title1">Card title 1</h5>
                  <p class="card-text">
                    11111111This is a wider card with supporting text below as a
                    natural lead-in to additional content. This content is a
                    little bit longer.
                  </p>
                  <small class="text-muted">Last updated 3 mins ago</small>
                </div>
              </div>
            </div>
          </div>

          <div class="row mt-3">
            <div class="col mb-3">
              <div class="custom-card">
                <img src="https://via.placeholder.com/150" class="card-img-top" alt="..." />
                <div class="card-body">
                  <h5 class="card-title1">Card title 2</h5>
                  <p class="card-text">
                    2222222222This is a wider card with supporting text below as
                    a natural lead-in to additional content. This content is a
                    little bit longer.
                  </p>
                  <small class="text-muted">Last updated 3 mins ago</small>
                </div>
              </div>
            </div>
          </div>

          <div class="row mt-3">
            <div class="col mb-3">
              <div class="custom-card">
                <img src="https://via.placeholder.com/150" class="card-img-top" alt="..." />
                <div class="card-body">
                  <h5 class="card-title1">Card title 3</h5>
                  <p class="card-text">
                    333333333333This is a wider card with supporting text below
                    as a natural lead-in to additional content. This content is
                    a little bit longer.
                  </p>
                  <small class="text-muted">Last updated 3 mins ago</small>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-4 column" ref="thirdColumn">
        <img src="../assets/image/jisoo.jpg" alt="Image" />
        <img src="../assets/image/jisoo.jpg" alt="Image" />
        <img src="../assets/image/jisoo.jpg" alt="Image" />
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
import EssayCard from "../components/EssayCard.vue";
import VideoCard from "../components/VideoCard.vue";
import { ref, onMounted } from "vue";
import axios from "axios";
const loaded = ref(false);
const essays = ref([]);
const getEssayInfo = async () => {
  await axios
    .get("https://localhost:7243/api/Essay")
    .then((response) => {
      essays.value = response.data;
      // console.log(essays.value);
      loaded.value = true;
    })
    .catch((error) => {
      console.log(error);
    });
};
// 影片
const videos = ref([])
const getVideos = async () => {
  await axios.get(`https://localhost:7243/api/Video`)
    .then(response => {
      videos.value = response.data;
      // console.log(videos.value);
      loaded.value = true;
    })
    .catch(error => { console.log(error); });
}
onMounted(() => {
  getEssayInfo();
  getVideos();
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
    slideMove = 0 - index * 1300;
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
const setup = () => {
  const firstColumn = ref(null);
  const container = ref(null);
  const secondColumn = ref(null);
  const thirdColumn = ref(null);
  onMounted(() => {
    const containerEl = container.value;
    const firstColumnEl = firstColumn.value;
    const secondColumnEl = secondColumn.value;
    const thirdColumnEl = thirdColumn.value;
    containerEl.addEventListener("scroll", () => {
      const scrollTop = containerEl.scrollTop;
      const secondColumnTop =
        secondColumnEl.getBoundingClientRect().top + window.scrollY;
      const thirdColumnTop =
        thirdColumnEl.getBoundingClientRect().top + window.scrollY;
      if (scrollTop < secondColumnTop || scrollTop > thirdColumnTop) {
        firstColumnEl.classList.add("col-4");
        secondColumnEl.classList.add("col-4");
        thirdColumnEl.classList.add("col-4");
        firstColumnEl.style.position = "fixed";
        firstColumnEl.style.top = "0";
        firstColumnEl.style.bottom = "0";
      } else {
        firstColumnEl.style.position = "relative";
        firstColumnEl.style.top = "auto";
        firstColumnEl.style.bottom = "auto";
      }
    });
  });
  return {
    firstColumn,
    container,
    secondColumn,
    thirdColumn,
  };
};
</script>

<style scoped>
.wrap {
  width: 1300px;
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
  width: 6500px;
  /* left: -1600px; */
}
.slide-img li {
  width: 1300px;
  height: 500px;
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
/* card custom-card */
.custom-card {
  position: relative;
  top: 50px;
}
/* .custom-card:nth-child(2) {
  
} */
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
/* 
.card-body {
  height: auto;
}
.card-title1 {
  height: 100px;
}
.card-text {
  height: 80px;
  line-height: 1.5;
} 
.text-muted {
  height: -8px;
}*/
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
  right: 180px;
  left: 190px;
  font-family: cursive;
  font-weight: bold;
  padding: 0px;
  height: 320px;
}
.title {
  font-family: 標楷體;
  font-size: large;
  left: 50%;
  transform: translateX(-50%);
  /* padding:60px; */
  height: 300px;
}
.influencer {
  font-family: cursive;
  padding: 60px;
  height: 180px;
  left: 115px;
  right: 150px;
}
.formatDate {
  left: 80px;
  right: 90px;
  /* bottom: 20px; */
  font-family: cursive;
  font-weight: bold;
  padding: 60px;
  height: 150px;
}
/* 
.custom-card {
  width: 100%;
} */
.custom-card .card-img-top {
  max-width: 500px;
  max-height: 500px;
}
/* 文章專區 */
.container-essay {
  display: flex;
  position: relative;
  overflow-x: hidden;
  height: 100vh;
  /* overflow-x: scroll; */
}
.card-img-top {
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
/* 
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
  height: 100px;
  overflow-y: scroll;
}
img {
  display: block;
  width: 100%;
  margin-bottom: 10px;
} */
.column {
  flex: 1;
  padding: 10px;
  margin-right: 10px;
}
.column:first-child {
  flex: none;
  width: 33.33%;
  position: sticky;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  overflow: hidden;
}
.column:first-child img {
  height: 100%;
  object-fit: cover;
}
.column:not(:first-child) {
  position: relative;
  z-index: -1;
}
img {
  display: block;
  width: 100%;
  margin-bottom: 10px;
}
a {
  text-decoration: none;
}
.btn-underline::after {
  content: "";
  position: absolute;
  bottom: 0;
  left: 0;
  width: 100%;
  height: 2px;
  background-color: #000000;
  transform: scaleX(0);
  transition: transform 0.3s ease;
}
.btn-underline:hover::after {
  transform: scaleX(1);
}
.btn-underline {
  position: relative;
  padding: 0;
  border: none;
  background: none;
  text-decoration: none;
  font-size: 12pt;
  color: #333;
  cursor: pointer;
}
.btn-underline:hover {
  color: #000000;
}</style>