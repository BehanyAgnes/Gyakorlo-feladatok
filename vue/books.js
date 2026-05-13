import { defineStore } from 'pinia'
import axios from 'axios'

export const useBooksStore = defineStore('books', {
  state: () => ({ books: [] }),
  actions: {
    async fetchBooks() {
      const response = await axios.get('http://localhost:3000/books')
      this.books = response.data
    }
  }
})
