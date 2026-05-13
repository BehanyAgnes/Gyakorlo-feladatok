import { createRouter, createWebHistory } from 'vue-router'

import Home from '../pages/Home.vue'
import Books from '../pages/Books.vue'
import BookDetails from '../pages/BookDetails.vue'

const routes = [
  { path: '/', name: 'home', component: Home },
  { path: '/books', name: 'books', component: Books },
  { path: '/books/:id', name: 'book',component: BookDetails }
]

export default createRouter({
  history: createWebHistory(),
  routes
})