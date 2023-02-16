import { createApp } from 'vue'
import App from './App.vue'
axios.get("https://localhost:7243/api/Products").then(response => {
	alert(response);
})
createApp(App).mount('#app')
