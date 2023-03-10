<template>
    <div class="card border-0 border-bottom pb-3 mb-3 container">
        <div class="row d-flex justify-content-between mt-2">
            <div class="col-md-4">
                <div class="row text-start">
                    <div class="col-md-2 mb-4">{{ data.account }}</div>
                    <div class="col-md-4 star-rating"><i v-for="(star, index) in data.score " class="fa-solid fa-star"></i>
                    </div>
                    <div class="fz-comment col-md-12">{{ data.commentContent }}</div>
                    <div class="col-md-12 my-2"></div>
                    <div class="col-md-7 mt-4"> <label class="pe-3">購買規格:</label>Size {{ data.size }} | Color {{ data.color
                    }}</div>
                    <div class="col-md-5 mt-4">{{ data.createdTime }} </div>
                </div>
            </div>
            <div class="col-md-2"></div>
            <div class="col-md-3 img-comment" v-if="data.pcommentImgs && data.pcommentImgs.length === 1">
                <img :src="data.pcommentImgs[0]" alt="...">
            </div>
            <div class="col-md-3 ps-6" v-else-if="data.pcommentImgs && data.pcommentImgs.length > 1">
                <div id="carouselExampleFade" class="carousel slide carousel-fade img-comment" data-bs-ride="carousel">
                    <div class="carousel-inner ">
                        <div class="carousel-item" v-for="(item, index) in data.pcommentImgs" :key="index"
                            :class="{ 'active': index === 0 }">
                            <img :src="item" alt="...">
                        </div>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade"
                        data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade"
                        data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
            </div>
            <div class="col-md-3 text-end" v-else>
                <!-- 如果沒有照片 -->
            </div>
            <div class="col-md-1 text-end">
                <i v-if="!isClicked" class="fa-regular fa-thumbs-up fz-icon" @click="helpfulComment(data.commentId)"></i>
                <i v-else="isClicked" class="fa-solid fa-thumbs-up fz-icon" @click="helpfulComment(data.commentId)"></i>
            </div>
        </div>
    </div>
</template>
<script setup>
import { onMounted, ref } from 'vue';
import axios from 'axios';

const isClicked = ref(false);

const helpfulComment = async (commentId) => {
    await axios.post(`https://localhost:7243/api/Products/helpfulComment?comment_id=${commentId}`)
        .then(response => {
            isClicked.value = !isClicked.value;
        })
        .catch(error => { console.log(error); });
}


//跳createCModal的 data-bs-toggle="modal" data-bs-target="#ProductCommentModal"
const props = defineProps({
    data: Object
})

onMounted(() => {
    helpfulComment();
});


</script>
<style scoped>
.ps-6 {
    padding-left: 8%;
}

.fz-comment {
    font-size: 18px;
    height: 100%;
}

.fz-icon {
    font-size: 20px;
    cursor: pointer;
}

.fz-6 {
    font-size: 15px;
}

.card-text {
    font-size: 15px;
}

.card {
    width: 100%;
}

.star-rating i {
    font-size: 12pt;
    color: rgb(255, 208, 0);
    padding-top: 5px;
}

.img-comment {
    width: 150px;
    height: 150px;
    overflow: hidden;
    padding: 0;
}

.img-comment img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}
</style>