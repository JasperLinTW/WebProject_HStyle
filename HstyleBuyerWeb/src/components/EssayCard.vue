<template>
    <!-- 内文解碼 -->
    <!-- <div v-html="decodeURI(item.econtent)"></div> -->
    <P>文章部落格頁面</P>
    <div class="container">
  <div class="row">
    <div class="col-md-4  mb-4" v-for="item in essays">
      <div class="card border-0 card1">
        <div class="card-img w-100 h200px rounded overflow-hidden">
          <img :src="item.imgs[0]" class="card-img-top" alt="Essays Image">

        </div>
        <div class="card-header d-flex bg-white border-bottom-0">
          <span class="badge bg-secondary opacity-50 me-1" v-for="tag in item.tags">{{ tag }}</span>
          <!-- <span>
            <i class="fa-solid fa-comment-dots"></i>
          </span> -->
        </div>
        <div class="card-body">
          <a class="text-dark text-decoration-none stretched-link" href="" target="_blank">{{ item.etitle }}</a>
        </div>
        <div class="card-footer bg-white border-top-0 d-flex">
            <span class="me-auto">{{ item.uplodTime.slice(0, 10) }}</span>
           
          <!-- <span><i class="fa-regular fa-bookmark"></i></span> -->
          <div class="card-text text-end">
          <span v-if="!item.isClicked" @click="item.isClicked = true"><i
                            class="fa-regular fa-bookmark icon-hover fz-18"></i></span>
          <span v-else @click="item.isClicked = false"><i class="fa-solid fa-bookmark SolidHeart fz-18"></i></span>
           </div>
        </div>
      </div>
    </div>
  </div>
</div> 

</template>
<script setup>
import { ref, onMounted} from "vue";
import axios from "axios";

const essays = ref([]);

const getEssayInfo = async () => {
    await axios.get("https://localhost:7243/api/Essay")
    .then(response => { essays.value = response.data;  console.log(essays.value)})
  
    .catch(error => {console.log(error);});
   
};
onMounted(() => {
    getEssayInfo(); 
});

//收藏
let likes = ref([])

const Essays = ref([])

const likesEssay = async () => {
    await axios.get("https://localhost:7243/api/Essay/Elike")
        .then(response => {
            if (response.data.length > 0) {
                likes.value = response.data;
                console.log(likes.value);
                Essays.value = likes.value.map(e => {
                    return e.essayId
                });
            }

        })
        .catch(error => { console.log(error); });
}


</script>
<style>
.h200px{
            height: 200px;
        }
        .object-fit-cover{
            object-fit: cover;
        }
        .card1 img{
            transition: all 0.2s;
        }
        .card1:hover img{
            transform: scale(1.1);
        }

.SolidHeart{
    color: #46a3ff;
}

.fz-18 {
    font-size: 20px;
    cursor: pointer;
}

</style>