<template>
    <div class="">
        <div class="">
            <swiper :direction="'vertical'" :pagination="{
                clickable: true,
            }" :modules="modules" class="MySwiper">
                <swiper-slide v-for="image in product.imgs"><img :src="image"></swiper-slide>
            </swiper>
        </div>
        <div class="">
            <h5>{{ product.product_Name }}</h5>
            <p>{{ product.description }}</p>
            <p> NT$ {{ product.unitPrice }}</p>
            <div class="product-options">
                <div>
                    <label>尺寸:</label>
                    <select>
                        <option v-for="size in product.specs" :value="size.size">{{ size.size }}</option>
                    </select>
                </div>
                <div>
                    <label>顏色:</label>
                    <select>
                        <option v-for="color in product.specs" :value="color.color">{{ color.color }}</option>
                    </select>
                </div>
            </div>
        </div>
    </div>
    <button class="add-to-cart">加入購物車</button>
</template>

<script setup>
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
import axios from 'axios';
import { Swiper, SwiperSlide } from 'swiper/vue';

// Import Swiper styles
import 'swiper/css';

import 'swiper/css/pagination';

// import required modules
import { Pagination } from 'swiper';


//路由
const route = useRoute();
const product = ref([]);


//商品呈現
const getProduct = async () => {
    await axios.get(`https://localhost:7243/api/Products/${route.params.id}`)
        .then(response => {
            product.value = response.data;
            console.log(product.value);
        })
        .catch(error => { console.log(error); });
}

//照片輪播
const modules = ref([Pagination]);


onMounted(() => {
    getProduct();
})



</script>

<style scoped>
.swiper {
    width: 360px;
    height: 450px;
}

.swiper-slide img {
    display: block;
    width: 100%;
    height: 100%;
    object-fit: cover;
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
}

button {
    border-radius: 8px;
    border: 1px solid transparent;
    padding: 0.6em 1.2em;
    font-size: 1em;
    font-weight: 500;
    font-family: inherit;
    background-color: #1a1a1a;
    cursor: pointer;
    transition: border-color 0.25s;
}

button:focus,
button:focus-visible {
    outline: 4px auto -webkit-focus-ring-color;
}
</style>
<style>
.swiper-pagination-bullet {
    background: var(--bs-gray-500) !important;
}
</style>