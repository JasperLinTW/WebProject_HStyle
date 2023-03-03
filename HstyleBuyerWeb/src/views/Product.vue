<!-- Product.vue -->
<template>
  <div class="m-5">
    <div class="d-flex justify-content-start">
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
</template>
  
<script>
export default {
  components: {
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
  margin-right: 5%;
}
</style>