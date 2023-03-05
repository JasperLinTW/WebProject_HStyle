import { createApp }  from 'vue'
import App from './App.vue'
import router from './router/index'
import { createGoogleAuth } from 'vue-google-signin'

const app = createApp(App)

app.use(router)

const gAuthOptions = {
  clientId: 'YOUR_CLIENT_ID',
  scope: 'profile email',
  prompt: 'select_account'
}

const googleAuth = createGoogleAuth(gAuthOptions)

app.use(googleAuth)

app.mount('#app')