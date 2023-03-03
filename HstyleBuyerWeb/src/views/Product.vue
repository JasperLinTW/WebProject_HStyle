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
      <ProductCard />
    </div>
  </div>

  <Back2Top />
</template>
  
<script setup>
import Back2Top from '../components/Back2Top.vue'
import ProductCard from '../components/ProductCard.vue'

</script>
<style scoped>
.filter {
  margin-right: 15%;
  padding-bottom: 0.5%;
  font-size: 12pt;
}
</style>