<script setup>
import HStyleHeader from './components/HStyleHeader.vue'
import HStyleFooter from './components/HStyleFooter.vue'
import { ref } from 'vue'

const updateHandler = async (data) => {
  headerKey.value = data;
}
const headerKey = ref(0);

</script>

<template>
  <div id="app">
    <HStyleHeader :key="headerKey" />
    <router-view @update="updateHandler" class="viewContent" />
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
