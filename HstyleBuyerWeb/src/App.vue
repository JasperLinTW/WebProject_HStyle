<script>
import HStyleHeader from './components/HStyleHeader.vue'
import HStyleFooter from './components/HStyleFooter.vue'

export default {
  name: "App",
  components: {
    HStyleHeader,
    HStyleFooter,
  }
};


</script>

<template>
  
  <div id="app">
    <HStyleHeader />
    <router-view />
    <HStyleFooter/>
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
