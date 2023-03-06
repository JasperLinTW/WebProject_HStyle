<script setup>
import HStyleHeader from './components/HStyleHeader.vue'
import HStyleFooter from './components/HStyleFooter.vue'
</script>

<template>
  <div id="app">
    <HStyleHeader />
    <router-view class="viewContent" />
    <HStyleFooter />
  </div>
</template>

<style scoped>
#app {
  text-align: center;
  color: #2c3e50;

}

.viewContent {
  min-height: 600px;
}
</style>
