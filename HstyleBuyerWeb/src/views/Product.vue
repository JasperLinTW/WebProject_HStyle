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
import { ref, onMounted, watch } from 'vue';


//商品預覽
const products = ref([]);
const route = useRoute();
console.log(route.params.tag);

//商品收藏
const likeProductsId = ref([]);
let likes = ref([]);
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

const loadProducts = async () => {
  await axios.get("https://localhost:7243/api/Products/products")
    .then(response => {
      response.data.map(p => {
        p.isClicked = likeProductsId.value.includes(p.product_Id);
      })
      if (route.params.tag == "new") {
        products.value = response.data.filter(p => p.tags.includes("新品"));
        console.log(products.value);
      }
      else { products.value = response.data }
    })
    .catch(error => { console.log(error); });
}
watch(() => route.params.tag, (newTag, oldTag) => {
  loadProducts();
})


onMounted(() => {
  likesProducts();
  loadProducts();


});




</script>
<style scoped>
.filter {
  margin-right: 15%;
  padding-bottom: 0.5%;
  font-size: 12pt;
}
</style>