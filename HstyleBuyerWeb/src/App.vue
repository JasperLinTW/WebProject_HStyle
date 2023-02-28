<script>
import webHeader from './components/WebHeader.vue'
export default {
  name: "App",
  components: {
    webHeader
  }
};


</script>

<template>
  
  <div id="app">
    <webHeader />
     
    
    <router-view />
  </div>
  
</template>

<style scoped>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
