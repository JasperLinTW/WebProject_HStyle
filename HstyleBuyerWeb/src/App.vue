<script>
import HStyleHeader from './components/HStyleHeader.vue'
export default {
  name: "App",
  components: {
    HStyleHeader,
  }
};


</script>

<template>
  
  <div id="app">
    <HStyleHeader />
    
    <router-view />
  </div>
  
</template>

<style scoped>
#app {
  /* font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale; */
  text-align: center;
  color: #2c3e50;
}
</style>
