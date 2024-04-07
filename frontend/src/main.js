import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import router from './routes/route'
import './assets/index.css'

const app = createApp(App)

app.use(router)

app.mount('#app')
