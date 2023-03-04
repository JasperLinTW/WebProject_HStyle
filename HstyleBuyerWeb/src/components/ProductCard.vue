<template>
    <div class="col-lg-4 d-flex justify-content-around px-5 py-5" v-for="item in products">
        <div class="card d-flex justify-content-center align-items-center">
            <div class="img-sz">
                <img v-if="!item.isIn" @mouseover="item.isIn = true" :src="item.imgs[0]" class="card-img-top"
                    alt="Product Image">
                <img v-else @mouseout="item.isIn = false" :src="item.imgs[1]" class="card-img-top" alt="Product Image">
            </div>

            <div class="card-body position-relative">
                <div class="position-absolute top-0 end-0 me-2 mt-2" v-for="tag in item.tags"> <label class="fz-9"
                        v-if="tag === newProduct">{{ newProduct
                        }}</label> </div>
                <div class="card-title fw-bold">{{ item.product_Name }}</div>
                <span>$NT {{ item.unitPrice }}</span>
                <div class="card-text text-end">
                    <span v-if="!item.isClicked" @click="item.isClicked = true"><i
                            class="fa-regular fa-heart icon-hover fz-18"></i></span>
                    <span v-else @click="item.isClicked = false"><i class="fa-solid fa-heart fz-18"></i></span>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import axios from 'axios';
import { ref, onMounted } from 'vue';

//圖片動畫
const isIn = ref(false);


//收藏
let likes = ref([]);

const likesProducts = async () => {
    await axios.get("https://localhost:7243/api/Products/products/likes")
        .then(response => {
            if (response.data.length > 0) {
                likes.value = response.data;
            }
        })
        .catch(error => { console.log(error); });
}


//商品預覽
const products = ref([]);

const loadProducts = async () => {
    await axios.get("https://localhost:7243/api/Products/products")
        .then(response => {
            products.value = response.data;
        })
        .catch(error => { console.log(error); });
}

//新品
const newProduct = ref("新品");

onMounted(() => {
    loadProducts();
    likesProducts();
});
</script>

<style scoped>
.card-img-top {
    border: none;
    border-radius: 0%;
}

.fz-18 {
    font-size: 20px;
    cursor: pointer;
}

.fz-9 {
    font-size: 15px;
    color: rgb(116, 129, 143);
}

.card {
    border: none;
    border-radius: 0%;
    cursor: pointer;
}

.img-sz {
    width: 330px;
    height: 450px;
    overflow: hidden;
}

.img-sz img {
    width: 100%;
    height: 100%;
    object-fit: cover;
    transition: transform 1.0s ease-in-out;
}

img:hover {
    transform: scale(1.1);
    animation: rotate 1s linear infinite;

}

img:mouseout {
    opacity: 0;
    transition-delay: 1s;
    transition-timing-function: ease-out;
}

.card-body {
    width: 100%;
}
</style>
