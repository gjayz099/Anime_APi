import { createWebHistory, createRouter } from 'vue-router'

import Home from '../components/Home.vue'
import About from '../components/About.vue'
import NotFound from '../components/NotFound.vue'

const routes = [
    { path: '/', 
        name: 'Home',
    component: Home},
    { path: '/about',
    name: 'About',
     component: About},
    // { path: '/:catchAll(.*)',
    //  name: 'Not Found',
    //   component: NotFound},
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router