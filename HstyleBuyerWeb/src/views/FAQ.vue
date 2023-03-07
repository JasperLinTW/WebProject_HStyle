<template>
   <div style="text-align: center">
      <h1 style="font-weight: bold; text-transform: uppercase">常見問題</h1>
   </div>
   <div style="text-align: center">
      <form class="border">
         <label
            for="search-input"
            style="position: absolute; width: 1px; height: 1px; padding: 0; margin: -1px; overflow: hidden; clip: rect(0, 0, 0, 0); border: 0"
         >
            搜尋：
         </label>
         <input
            type="text"
            id="search-input"
            name="search"
            placeholder="搜尋"
            style="width: 200px; padding: 10px 25px; border-radius: 25px; border: none; outline: none"
         />
         <button
            type="submit"
            style="position: relative; left: -40px; padding: 10px; background-color: #f2f2f2; border: none; border-radius: 50%; outline: none"
         >
            <i class="fa-solid fa-magnifying-glass"></i>
            <!-- <img src="search-icon.png" alt="search icon" style="width: 20px; height: 20px" /> -->
         </button>
      </form>
   </div>

     <div>
    <!-- 分類選擇 -->
    <select v-model="selectedCategory" @change="handleCategoryChange">
      <option value="">全部分類</option>
      <option v-for="(category, index) in categories" :key="index" :value="category">
        {{ category }}
      </option>
    </select>

    <!-- 常見問題列表 -->
    <ul>
      <li v-for="(item, index) in filteredItems" :key="index" @click="toggleAnswer(index)">
        <h3>{{ item.title }}</h3>
        <p v-if="activeIndex === index">{{ item.content }}</p>
      </li>
    </ul>
  </div>

   <div style="text-align: center">
      <p class="clickable" onclick="toggleSubtitles('subtitles-1')">這是第一行文字</p>
      <div id="subtitles-1" style="display: none">
         <p>作品</p>
         <p>服務</p>
      </div>
   </div>

   <!-- Button trigger modal -->
   <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#CustomerQModal">顧客提問</button>
   <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#MemberQModal">會員提問</button>

   <CustmorQForm />
   <MemberQForm />
</template>

<script setup>
import { ref, onMounted } from "vue";
import axios from "axios";
import CustmorQForm from "../components/CustomerQForm.vue";
import MemberQForm from "../components/MemberQForm.vue";

const categoryQ = ref([]);
const getQCategoryInfo = async () => {
   await axios
      .get("https://localhost:7243/CommonQCategory")
      .then((response) => {
         categoryQ.value = response.data;
         console.log(response.data);
      })
      .catch((error) => {
         console.log(error);
      });
};

const commonQ = ref({});
const getCommonQInfo = async () => {
   await axios
      .get(`https://localhost:7243/CommonQ`)
      .then((response) => {
         commonQ.value = response.data;
         console.log(response.data);
      })
      .catch((error) => {
         console.log(error);
      });
};

onMounted(() => {
   getQCategoryInfo();
   getCommonQInfo();
});
</script>

<style scoped>
hr {
   border: none;
   border-top: 1px solid #ccc;
   width: 100%;
   max-width: 400px;
   margin: 0 auto;
}

.container {
   display: flex;
   flex-direction: row;
   align-items: center;
   text-align: center;
   margin: 0 auto;
   width: 80%;
   max-width: 800px;
   padding: 50px 0;
   font-size: 20px;
   line-height: 1.5;
}
.container.column {
   flex-direction: column;
}
.container hr {
   display: none;
   margin: 20px 0;
   border-top: 2px solid black;
}
.container.column hr {
   display: block;
   margin: 20px auto;
   width: 80%;
   max-width: 600px;
}
.container p {
   flex: 1;
}
.container .clickable {
   cursor: pointer;
}
.container .clickable:hover {
   font-weight: bold;
}
</style>
