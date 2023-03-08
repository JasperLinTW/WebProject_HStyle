<!-- Product.vue -->
<template>
  <div class="m-5 container">
    <div class="row">
      <div class="col-lg-5 border-bottom">
        <div class="d-flex justify-content-start">
          <div class="filter">
            <div class="dropdown-toggle" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
              排序
            </div>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <li><a class="dropdow n-item" href="#">Menu item</a></li>
            </ul>
          </div>
          <div class="filter">
            <div class="dropdown-toggle" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
              尺寸
            </div>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <li><a class="dropdown-item" href="#">Menu item</a></li>
            </ul>
          </div>
          <div class="filter">
            <div class="dropdown-toggle" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
              類別
            </div>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <li><a class="dropdown-item" href="#">Menu item</a></li>
            </ul>
          </div>
          <div class="filter">
            <div class="dropdown-toggle" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
              顏色
            </div>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <li><a class="dropdown-item" href="#">Menu item</a></li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="container">
    <div class="row">
      <ProductCard v-for="item in products" :data="item" />
    </div>
  </div>

  <Back2Top />
</template>
  
<script setup>
import Back2Top from '../components/Back2Top.vue'
import ProductCard from '../components/ProductCard.vue'
import { useRoute } from 'vue-router';
import axios from 'axios';

//收藏
let likes = ref([]);

const likeProductsId = ref([])

const likesProducts = async () => {
  await axios.get("https://localhost:7243/api/Products/products/likes")
    .then(response => {
      if (response.data.length > 0) {
        likes.value = response.data;
        likeProductsId.value = likes.value.map(p => {
          return p.productId
        });
      }

    })
    .catch(error => { console.log(error); });
}

//商品預覽
const products = ref([]);

const loadProducts = async () => {
  await axios.get("https://localhost:7243/api/Products/products")
    .then(response => {
      response.data.map(p => {
        p.isClicked = likeProductsId.value.includes(p.product_Id);
      })
      products.value = response.data;
    })
    .catch(error => { console.log(error); });
}

//新品
const newProduct = ref("新品");

onMounted(() => {
  likesProducts();
  loadProducts();

});

const route = useRoute();
console.log(route.params.tag);

</script>
<style scoped>
.filter {
  margin-right: 15%;
  padding-bottom: 0.5%;
  font-size: 12pt;
}
</style>