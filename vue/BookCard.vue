<template>
  <div class="col-md-4 col-lg-3 mb-4">
    <div class="card h-100">
      <img :src="bookl.cover" class="card-img-top" :alt="bookl.title" style="height:280px;object-fit:cover;">
      <div class="card-body">
        <h5 class="card-title">{{ bookl.title }}</h5>
        <!-- <button class="btn btn-primary" @click="$emit('details', book.id)">Részletek</button> -->
        <!-- könyv adatok, pl. cím, borító -->
        <button @click="goToDetails">Részletek</button>
      </div>
    </div>
  </div>
</template>
<script setup>
//defineProps(['book'])
import { useRouter } from 'vue-router'
import { defineProps } from 'vue'

const props = defineProps({
  bookl: Object
})

const router = useRouter()

function goToDetails() {
  router.push(`/books/${props.bookl.id}`)
}
</script>
