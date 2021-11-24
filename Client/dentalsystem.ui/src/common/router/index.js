import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import identityRoutes from '../../identity/router/identityRoutes.js'
import schedulingRoutes from '../../scheduling/router/schedulingRoutes.js'

Vue.use(VueRouter)

const routes = [
  {
    showOn: 'NonAuthorized',
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    showOn: 'NonAuthorized',
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  ...identityRoutes,
  ...schedulingRoutes
]

const router = new VueRouter({
  routes
})

export default router
