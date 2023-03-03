<template>
    <!-- Button trigger modal
    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
    Launch demo modal
    </button> -->
        <!-- Modal -->
        <div class="modal fade" id="checkInModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">每日簽到</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div>
                        <img id="HCoin" v-for="i in 7" :key="i" :src="`../src/assets/image/Hcoin.png`" alt="Image">
                    </div>
                </div>
                <div class="modal-footer">
                    <!-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button> -->
                    <button type="button" v-if="isToday" class="btn btn-primary">明日再來</button>
                    <button type="button" v-else class="btn btn-primary">今日簽到</button>
                </div>
                </div>
            </div>
        </div>
</template>

<script setup>
import{ref} from "vue";
const lastTime=new Date("2023/03/03").toLocaleDateString();
function buttomChoose(){
  isToday.value = lastTime===new Date().toLocaleDateString();   
    }


// export default{  
//   setup(){
//     const isToday=ref(true);
//     var lastTime=new Date("2023/03/02").toLocaleDateString();
//     isToday=lastTime===new Date().toLocaleDateString();

    // return{
    //   isToday
    // }
  // }
// }
</script>

<style scoped>
  /* 組件的 CSS 样式 */
  #HCoin{
    width:14%;
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
