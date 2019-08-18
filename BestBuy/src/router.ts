import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home.vue';
import ProductDetails from '@/components/ProductDetails.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/productdetails/:id',
      name: 'ProductDetails',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component:ProductDetails
    }
  ]
})
