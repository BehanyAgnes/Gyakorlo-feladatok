<template>
  <div class="container">
    <h2 class="my-4 text-center">Könyvek</h2>
    <div class="row">
      <BookCard v-for="book in booksStore.books"
                :key="book.id"
                :bookl="book"
                @details="showDetails" />
    </div>
  </div>
</template>
<script setup>
import { onMounted } from 'vue'
import { useBooksStore } from '../stores/books'
import BookCard from '../components/BookCard.vue'

const booksStore = useBooksStore()
onMounted(() => booksStore.fetchBooks())
const showDetails = (id) => { console.log('Könyv azonosító:', id) }
</script>
