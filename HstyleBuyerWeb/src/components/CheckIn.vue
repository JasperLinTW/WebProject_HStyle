<template>
   <div class="modal fade" id="checkInModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
         <div class="modal-content">
            <div class="modal-header">
               <h1 class="modal-title fs-5" id="exampleModalLabel">每日簽到</h1>
               <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
               <div>
                  <img id="Check" v-for="i in checkIns.checkInTimes" :key="i" :src="`../src/assets/image/Checked.jpg`" alt="Image" />
                  <img id="unCheck" v-for="i in leftTimes" :key="i" :src="`../src/assets/image/Hcoin.png`" alt="Image" />
               </div>
            </div>
            <div class="modal-footer">
               <button type="button" class="btn btn-primary" @click="checkIn()">簽到</button>
            </div>
         </div>
      </div>
   </div>
</template>

<script setup>
// 點擊之後再做判斷
import { ref, onMounted } from "vue";
import axios from "axios";
const checkIns = ref([]);
let leftTimes = 0;

const getCheckInfo = async () => {
   await axios
      .get(`https://localhost:7243/api/HCoin/CheckIn`)
      .then((response) => {
         checkIns.value = response.data;
         leftTimes = 7 - checkIns.value.checkInTimes;
         //  console.log(checkIns.value);
      })
      .catch((error) => {
         console.log(error);
      });
};

var lastTime = new Date();
const checkIn = async () => {
   lastTime = new Date(checkIns.value.lastTime).toLocaleDateString();
   let today = new Date().toLocaleDateString();
   if (lastTime === today) {
      alert("今天打卡過囉!!");
   } else {
      await axios
         .put(`https://localhost:7243/api/HCoin/CheckIn`)
         .then((response) => {
            getCheckInfo();
            alert("打卡成功!!!");
         })
         .catch((error) => {
            console.log(error);
         });
   }
};

onMounted(() => {
   getCheckInfo();
});
</script>

<style scoped>
/* 組件的 CSS 样式 */
#Check,
#unCheck {
   width: 14%;
}
#Check {
   width: 11%;
   margin: 5px;
}
/* 按鈕 */
.btn:not(.nav-btns button) {
   background-color: #fff;
   color: rgb(12, 13, 12);
   padding: 10px 28px;
   border-radius: 25px;
   border: 1px solid rgb(12, 13, 12);
}
.btn:not(.nav-btns button):hover {
   background-color: #46a3ff;
   color: #fff;
   border-color: #46a3ff;
}
</style>
