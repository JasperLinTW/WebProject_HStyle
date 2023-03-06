<template>
    <div class="container-fluid  m-5">
        <div class="row">
            <div class="col-lg-12 ps-5 mb-5">
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="http://localhost:5173/">首頁</a></li>
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
                            <img :src="image" class="pe-3">
                        </div>
                    </div>
                    <div class="col-lg-12 text-start">
                        <h5 class="py-5">{{ product.product_Name }}</h5>
                    </div>
                    <div class="col-lg-12 mb-5 text-start">
                        <div>
                            <!-- <div class="pb-4">
                                <label>尺寸:</label>
                                <button class="mx-2 btn-underline px-2" v-for="size in product.specs" :value="size.size">{{
                                    size.size
                                }}</button>
                            </div> -->
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
                    <div class="col-lg-12  mt-5 text-start">
                        <button @click="addItem()" class="add-to-cart"> NT$ {{ product.unitPrice }}<span
                                class="border-start border-dark ms-2"><span class="ps-2">加入購物車</span></span></button>
                        <span class="m-3" v-if="!isClicked" @click="isClicked = true"><i
                                class="fa-regular fa-heart icon-hover fz-18"></i></span>
                        <span class="m-3" v-else @click="isClicked = false"><i class="fa-solid fa-heart fz-18"></i></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Back2Top></Back2Top>
</template>

<script setup>
import { onMounted, ref, watch } from 'vue';
import { useRoute } from 'vue-router';
import axios from 'axios';
import { Swiper, SwiperSlide } from 'swiper/vue';
import Back2Top from "../components/Back2Top.vue"

// Import Swiper styles
import 'swiper/css';

import 'swiper/css/pagination';
// import required modules
import { Pagination } from 'swiper';


//路由
const route = useRoute();
const product = ref([]);

const isClicked = ref(false);

//商品呈現
const getProduct = async () => {
    await axios.get(`https://localhost:7243/api/Products/${route.params.id}`)
        .then(response => {
            product.value = response.data;
            SelectSpecId.value = product.value.specs[0].specId;
            // console.log(product.value.specs[0].specId);
        })
        .catch(error => { console.log(error); });
}

//照片輪播
const modules = ref([Pagination]);

//加入購物車
const emit =defineEmits(['update']);
const watchedNum =ref(0);
watch(watchedNum,(newValue) =>{
    emit('update',newValue)
})
const SelectSpecId = ref(0);
const addItem = async () => {
    await axios.post(`https://localhost:7243/api/Cart/${SelectSpecId.value}`)
        .then(response => {
            alert("新增成功");
            watchedNum.value += 1;
        })
        .catch(error => { console.log(error); });
}

onMounted(() => {
    getProduct();
})



</script>

<style scoped>
.btn-underline {
    position: relative;
    padding: 0;
    border: none;
    background: none;
    text-decoration: none;
    font-size: 15pt;
    color: #333;
    cursor: pointer;
}

.btn-underline:hover {
    color: #46A3FF;
}


.btn-underline::after {
    content: '';
    position: absolute;
    bottom: 0;
    left: 0;
    width: 100%;
    height: 2px;
    background-color: #46A3FF;
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
    width: 620px;
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
</style>
<style>
.swiper-pagination-bullet {
    background: var(--bs-gray-500) !important;
}
</style>