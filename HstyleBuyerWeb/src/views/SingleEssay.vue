<template>
  <div class="container mb-5">
    <div class="column">
      <img :src="essays.imgs === undefined ? '' : essays.imgs[0]" alt="Image" />
    </div>
  </div>

  <div class="column">
    <div class="fashion">{{ essays.categoryName }}</div>
    <div class="text">{{ essays.etitle }}</div>
    <div class="Who">By {{ essays.influencerName }}</div>
    <div class="Time">{{ formatDate(essays.uplodTime) }}</div>
    <hr />
    <div>
      <div class="container-text mx-auto h-100">
        {{
          decodeURI(essays.econtent)
            .replace(/<\/?[^>]+(>|$)/g, "")
            .slice(0, 170)
        }}
      </div>
    </div>
  </div>
</template>

<script setup>
import { useRoute } from "vue-router";
import { ref, onMounted } from "vue";
import axios from "axios";

const route = useRoute();
console.log(route.params.id);

const essays = ref({});

const getEssayInfo = async () => {
  await axios
    .get(`https://localhost:7243/api/Essay/${route.params.id}`)
    .then((response) => {
      essays.value = response.data;
      console.log(essays.value);
    })

    .catch((error) => {
      console.log(error);
    });
};
onMounted(() => {
  getEssayInfo();
});

//收藏
// let likes = ref([])

// const Essays = ref([])

// const likesEssay = async () => {
//     await axios.get("https://localhost:7243/api/Essay/Elike")
//         .then(response => {
//             if (response.data.length > 0) {
//                 likes.value = response.data;
//                 console.log(likes.value);
//                 Essays.value = likes.value.map(e => {
//                     return e.essayId
//                 });
//             }

//         })
//       .catch(error => { console.log(error); });
// };

const formatDate = (dateString) => {
  const date = new Date(dateString);
  const year = date.getFullYear();
  const month = date.getMonth() + 1;
  const day = date.getDate();
  return `${year}年${month}月${day}日`;
};
</script>

<style scoped>
.container {
  align-items: center;
  display: flex;
  position: relative;
}

.column {
  flex: 1;
  padding: 60px;
  position: relative;
}

.column:first-child {
  flex: none;
  width: 33.33%;
}

img {
  display: block;
  width: 150%;
  margin-bottom: 10px;
}
.text {
  font-size: 25px;
  font-family: 標楷體;
  font-weight: bold;
  text-align: center;
  position: absolute;
  top: -15em;
  left: 70%;
  transform: translate(-50%, -50%);
  z-index: 1;
}

.fashion {
  font-family: cursive;
  font-size: 14px;
  font-weight: bold;
  color: #333;
  text-transform: uppercase;
  padding: 4px 8px;
  border-radius: 4px;
  cursor: pointer;
  transition: font-size 2s, text-decoration 2s;
  position: absolute;
  top: -33em;
  left: 70%;
  transform: translateX(-50%);
}

.container-text {
  width: 905px;
  height: 1212px;
  text-align: justify; /* 上下文對齊 */
}

.fashion:hover {
  /* transition: font-size 0.2s ease, text-decoration 0.2s ease; */
  font-size: 15px;
  text-decoration: underline;
}

.Who,
.Time {
  font-size: 9px;
  font-weight: bold;
  color: #333;
  font-family: cursive;
}

.Who {
  position: absolute;
  top: -34em;
  left: 70%;
  transform: translateX(-50%);
}

.Time {
  position: absolute;
  top: -32em;
  left: 70%;
  transform: translateX(-50%);
}
.wrapper {
  padding: 0 20%;
}

.content {
  display: flex;
  text-align: justify; /* 上下文對齊 */
  text-justify: inter-word;
}
#topButton {
  display: none;
  position: fixed;
  bottom: 10px;
  right: 10px;
  z-index: 99;
  background-color: grey;
  padding: 5px;
  border-radius: 50%;
}
</style>