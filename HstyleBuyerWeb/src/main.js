import { createApp } from 'vue'
import App from './App.vue'
import router from './router/index'
import mitt from 'mitt'

const app = createApp(App)
const emitter = mitt()

app.use(router)

app.mount('#app')



