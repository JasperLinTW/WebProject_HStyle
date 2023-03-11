<!-- Product.vue -->
<template>
  <div class="m-5 container">
    <div class="row">
      <div class="col-lg-5 border-bottom">
        <div class="d-flex justify-content-start">
          <div class="filter">
            <div class="dropdown-toggle" id="sortDropdown" data-bs-toggle="dropdown" aria-expanded="false">
              排序
            </div>
            <ul class="dropdown-menu menu border-0 mt-1" aria-labelledby="sortDropdown">
              <li><a class="dropdown-item" href="#" v-for="(option, index) in sortOptions" :key="index"
                  @click="setSortOption(option)">{{ option }}</a></li>
            </ul>
          </div>
          <div class="filter">
            <div class="dropdown-toggle" id="categoryDropdown" data-bs-toggle="dropdown" aria-expanded="false">
              類別
            </div>
            <ul class="dropdown-menu menu border-0 mt-1" aria-labelledby="categoryDropdown">
              <li><a class="dropdown-item" href="#" v-for="(option, index) in categoryOptions" :key="index"
                  @click="setCategoryOption(option)">{{ option }}</a></li>
            </ul>
          </div>
          <div class="filter">
            <div class="dropdown-toggle" id="colorDropdown" data-bs-toggle="dropdown" aria-expanded="false">
              顏色
            </div>
            <ul class="dropdown-menu menu border-0 mt-1 " aria-labelledby="colorDropdown">
              <div class="row">
                <li class="col-md-1">
                  <a class="dropdown-item item " href="#"
                    v-for="(option, index) in colorOptions.slice(0, Math.ceil(colorOptions.length / 2))" :key="index"
                    @click="setColorOption(option)">
                    {{ option }}
                  </a>
                </li>
                <li class="col-md-1">
                  <a class="dropdown-item item" href="#"
                    v-for="(option, index) in colorOptions.slice(Math.ceil(colorOptions.length / 2),)" :key="index"
                    @click="setColorOption(option)">
                    {{ option }}
                  </a>
                </li>
              </div>

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
import Back2Top from "../components/Back2Top.vue";
import ProductCard from "../components/ProductCard.vue";
import { useRoute } from "vue-router";
import axios from "axios";
import { ref, onMounted, watch } from "vue";
import { eventBus } from "../mybus";
//商品預覽
const products = ref([]);
const route = useRoute();
//console.log(route.params.tag);

//商品篩選排序
const categoryOptions = ref([]);
const colorOptions = ref([]);
const sortOptions = ref(['新到舊', '舊到新', '價格高到低', '價格低到高']);
//商品收藏
const likeProductsId = ref([]);
let likes = ref([]);
const likesProducts = async () => {
  await axios
    .get("https://localhost:7243/api/Products/products/likes", {
      withCredentials: true,
    })
    .then((response) => {
      if (response.data.length > 0) {
        //console.log(response.data);
        likes.value = response.data;
        likeProductsId.value = likes.value.map((p) => {
          return p.productId;
        });
      }
      loadProducts();
    })
    .catch((error) => {
      console.log(error);
      loadProducts();
    });
};
const loadProducts = async () => {
  await axios
    .get("https://localhost:7243/api/Products/products", {
      withCredentials: true,
    })
    .then((response) => {
      //console.log(response.data);
      response.data.map((p) => {
        p.isClicked = likeProductsId.value.includes(p.product_Id);
      });

      //把篩選的先列出
      categoryOptions.value = [...new Set(response.data.map((p) => p.pCategoryName))];
      colorOptions.value = Array.from(new Set(response.data.flatMap((p) => p.specs.map((s) => s.color))));
      console.log(colorOptions.value);
      if (route.params.tag == "new") {
        products.value = response.data.filter((p) => p.tags.includes("新品"));
      } else {
        products.value = response.data;
      }
    })
    .catch((error) => {
      console.log(error);
    });
};
watch(
  () => route.params.tag,
  (newTag, oldTag) => {
    loadProducts();
  }
);
eventBus.on("addProductLike", () => {
  likesProducts();
});
onMounted(() => {
  likesProducts();

});
</script>
<style scoped>
.filter {
  margin-right: 15%;
  padding-bottom: 0.5%;
  font-size: 12pt;

}

.menu {
  min-width: 100%;
  min-height: 21%;
  border: none;
  background-color: #ffffff;
  padding-left: 2%;
}

.dropdown-menu a:hover {
  background-color: transparent;
  color: #46a3ff;
}

.dropdown-toggle {
  cursor: pointer;
}
</style>