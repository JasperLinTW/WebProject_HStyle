<template>
    <div class="container-fluid  m-5">
        <div class="row">
            <div class="col-lg-12 ps-5 mb-5">
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="http://localhost:5173/">Home</a></li>
                        <li class="breadcrumb-item"><a href="#">{{ product.pCategoryName }}</a></li>
                        <li class="breadcrumb-item active">{{ product.product_Name }}</li>
                    </ol>
                </nav>
            </div>
            <div class="col-lg-2"></div>
            <div class="col-lg-5">
                <swiper :direction="'vertical'" :pagination="{
                    clickable: true,
                }" :modules="modules" class="MySwiper">
                    <swiper-slide v-for="(image, index) in product.imgs" :key="index"><img :src="image"></swiper-slide>
                </swiper>
            </div>
            <div class="col-lg-5">
                <div class="row">
                    <div class="col-lg-8 d-flex justify-content-start">
                        <div v-for="(image, index) in product.imgs" :key="index" class="thumb">
                            <img :src="image" class="pe-3" @click="changeImage(index)">
                        </div>
                    </div>
                    <div class="col-lg-12 text-start">
                        <h5 class="py-5">{{ product.product_Name }}</h5>
                    </div>
                    <div class="col-lg-12 mb-5 text-start">
                        <div>
                            <div class="product-options">
                                <label>規格:</label>
                                <select v-model="SelectSpecId" class="mx-2">
                                    <option v-for="spec in product.specs" :value="spec.specId">
                                        {{ `${spec.color}, ${spec.size}` }}
                                    </option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12"></div>
                    <div class="col-lg-12  mt-5 text-start">
                        <button @click="addItem()" class="add-to-cart"> NT$ {{ product.unitPrice }}<span
                                class="border-start border-dark ms-2" data-bs-target="#exampleModal"><span
                                    class="ps-2">加入購物車</span></span></button>
                        <span class="m-3" v-if="!isClicked" @click="likesProduct()"><i
                                class="fa-regular fa-heart icon-hover fz-18"></i></span>
                        <span class="m-3" v-else @click="likesProduct()"><i class="fa-solid fa-heart fz-18"></i></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 pb-2">
                <button class="btn-underline" @click="showComment = false" :class="{ active: !showComment }">商品描述</button>
            </div>
            <div class="col-md-6">
                <button class="btn-underline" @click="showComment = true" :class="{ active: showComment }">商品評論</button>
            </div>
            <div v-if="showComment" class="col-md-12 border-top pt-3 mb-big">
                <PComment v-for="item in comment" :data="item"></PComment>
            </div>
            <div v-else class="col-md-12 border-top pt-5 px-6  mb-big">
                {{ product.description }}
            </div>
            <div class="h500px">
                <div class="col-md-12 line">
                    <span class="px-5">專屬推薦</span>
                </div>
                <div class="col-md-12">
                    <div class="row">
                        <RecommendCard v-for="item in rec" :data="item"></RecommendCard>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <Back2Top />
</template>

<script setup>
import { onMounted, ref, watch } from 'vue';
import { useRoute } from 'vue-router';
import axios from 'axios';
import { Swiper, SwiperSlide } from 'swiper/vue';
import Back2Top from "../components/Back2Top.vue";
import PComment from "../components/PComment.vue";
import RecommendCard from '../components/RecommendCard.vue';



// Import Swiper styles
import 'swiper/css';

import 'swiper/css/pagination';
// import required modules
import { Pagination } from 'swiper';

const objtest = {
    name: 'test',
    quantity: 1,
}


//路由
const route = useRoute();
const product = ref([]);

const isClicked = ref(false);
const showComment = ref(false);

//商品呈現
const getProduct = async () => {
    await axios.get(`https://localhost:7243/api/Products/${route.params.id}`)
        .then(response => {
            product.value = response.data;
            SelectSpecId.value = product.value.specs[0].specId;
            isClicked.value = likeProductsId.value.includes(parseInt(route.params.id));
        })
        .catch(error => { console.log(error); });
}

//照片輪播
const modules = ref([Pagination]);

//加入購物車
const emit = defineEmits(['update']);
const watchedNum = ref(0);
watch(watchedNum, (newValue) => {
    emit('update', newValue)
})
const SelectSpecId = ref(0);
const addItem = async () => {
    await axios.post(`https://localhost:7243/api/Cart/${SelectSpecId.value}`)
        .then(response => {
            watchedNum.value += 1;
        })
        .catch(error => { console.log(error); });
}

//收藏
let likes = ref([]);
const likeProductsId = ref([])

const likesProducts = async () => {
    await axios.get("https://localhost:7243/api/Products/products/likes")
        .then(response => {
            if (response.data.length > 0) {
                likes.value = response.data;
                likeProductsId.value = likes.value.map(p => {
                    return p.productId;
                });
            }
        })
        .catch(error => { console.log(error); });
}

const likesProduct = async () => {
    await axios.post(`https://localhost:7243/api/Products/product/like?product_id=${route.params.id}`)
        .then(response => {
            isClicked.value = !isClicked.value;
        })
        .catch(error => { console.log(error); });
}

const rec = ref([]);
//推薦商品
const getRecommend = async () => {
    await axios.get(`https://localhost:7243/api/Products/ProdRec/${route.params.id}`)
        .then(response => {
            rec.value = response.data;
            //console.log(rec.value);
        })
        .catch(error => { console.log(error); });
}

const comment = ref([]);
//評論
const getComment = async () => {
    await axios.get(`https://localhost:7243/api/Products/comments`)
        .then(response => {
            comment.value = response.data;
            console.log(comment.value);
        })
        .catch(error => { console.log(error); });
}


onMounted(() => {
    likesProducts();
    getProduct();
    getRecommend();
    getComment();
})



</script>

<style scoped>
.line {
    border-top: 1px solid #dee2e6;
    text-align: center;
    line-height: 0.1em;
}

.line span {
    background: #fff;
    padding: 0 10px;
}

.px-6 {
    padding-left: 15%;
    padding-right: 15%;
}

.mb-big {
    margin-bottom: 20%;
}

.h200px {
    height: 200px;
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
}


.btn-underline::after {
    content: '';
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

.thumb {
    width: 100px;
    height: 100px;
    margin-bottom: 10px;
}

.thumb img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}

.MySwiper {
    width: 617px;
    height: 550px;
}

.MySwiper .swiper-slide img {
    display: block;
    width: 100%;
    height: 100%;
    object-fit: cover;
}

.fz-18 {
    font-size: 20px;
    cursor: pointer;
}

.add-to-cart {
    background-color: #fff;
    color: rgb(12, 13, 12);
    padding: 10px 28px;
    border-radius: 25px;
    border: 1px solid rgb(12, 13, 12);
    transition: all 0.3s ease;
}

.add-to-cart:hover {
    background-color: #000;
    color: #fff;
}

.h500px {
    height: 500px;
}


.product-options label {
    font-weight: bold;
    margin-right: 10px;
}

.product-options select {
    outline: none;
    padding: 5px;
    border: 1px solid #ccc;
    border-radius: 5%;
    font-size: 15px;

}

a {
    text-decoration-line: none;
    color: #000;
}
</style>
<style>
.swiper-pagination-bullet {
    background: var(--bs-gray-500) !important;
}
</style>