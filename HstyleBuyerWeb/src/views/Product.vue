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
              <li><a class="dropdown-item" href="#">Menu item</a></li>
              <li><a class="dropdown-item" href="#">Menu item</a></li>
              <li><a class="dropdown-item" href="#">Menu item</a></li>
            </ul>
          </div>
          <div class="filter">
            <div class="dropdown-toggle" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
              尺寸
            </div>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <li><a class="dropdown-item" href="#">Menu item</a></li>
              <li><a class="dropdown-item" href="#">Menu item</a></li>
              <li><a class="dropdown-item" href="#">Menu item</a></li>
            </ul>
          </div>
          <div class="filter">
            <div class="dropdown-toggle" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
              類別
            </div>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <li><a class="dropdown-item" href="#">Menu item</a></li>
              <li><a class="dropdown-item" href="#">Menu item</a></li>
              <li><a class="dropdown-item" href="#">Menu item</a></li>
            </ul>
          </div>
          <div class="filter">
            <div class="dropdown-toggle" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
              顏色
            </div>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <li><a class="dropdown-item" href="#">Menu item</a></li>
              <li><a class="dropdown-item" href="#">Menu item</a></li>
              <li><a class="dropdown-item" href="#">Menu item</a></li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="container">
    <div class="row align-items-start">
      <ProductCard></ProductCard>
      <ProductCard></ProductCard>
      <ProductCard></ProductCard>
    </div>
  </div>

  <Back2Top></Back2Top>
</template>
  
<script>
import Back2Top from '../components/Back2Top.vue'
import ProductCard from '../components/ProductCard.vue'

export default {
  components: {
    Back2Top,
    ProductCard
  },
  data() {
    return {
      // 在這裡添加您的數據
    };
  },
  methods: {
    // 在這裡添加您的方法
  },
  mounted() {
    // 在這裡添加組件初始化邏輯
  }
};
</script>
<style scoped>
.filter {
  margin-right: 15%;
  padding-bottom: 0.5%;
  font-size: 12pt;
}
</style>