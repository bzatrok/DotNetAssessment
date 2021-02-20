<template>
  <div>
    <error :show="error" />
    <form @submit.prevent="handleSearch"  class="formContainer">
      <v-text-field 
        v-model="searchInput" 
        required 
        label="Enter product name"></v-text-field>

      <v-btn type="submit">Search</v-btn>
    </form>

    <product v-for="p in products" :key="p.id" :product="p" />
    <spinner :show="loading" />

    <div v-if="products.length" v-observe-visibility="scrolledToBottom"></div>
  </div>
</template>

<script>
import Axios from 'axios'
import Product from '../components/product.vue';
import Spinner from '../components/spinner.vue'
import Error from '../components/error';

export default {
  components: {
    Product,
    Spinner,
    Error
  },
  data: () => ({
    loading: false,
    error: false,
    searchInput: '',
    products: [],
    page: 1
  }),
  methods:{
    handleSearch () {
      this.products = []

      this.loadProducts();
    },
    async loadProducts () {
      try {
        this.loading = true;
        this.error = false

        const response = await Axios.get(`http://localhost:5000/api/products?name=${this.searchInput}&page=${this.page}`)

        this.products.push(...response.data);
        this.searchInput = ''

      } catch (error) {
        this.error = true;
      } finally {
        this.loading = false;
      }
    },
    scrolledToBottom(isVisible) {
      if(!isVisible) return;
      
      this.page++;
      this.loadProducts();
    }
  }
}
</script>

<style scoped>

  .formContainer {
    padding-bottom: 50px;
  }
  
</style>