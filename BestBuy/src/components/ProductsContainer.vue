<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import ProductCard  from '@/components/ProductCard.vue'
import { Product } from "../models/Products";


@Component({
  components: { ProductCard }
})
export default class ProductsContainer extends Vue {
  @Prop() private products?: Array<Product>;
  constructor() {
    super();
   
  }
}
</script>
<template>
  <div class="container">   
    <div v-for="item in products" v-bind:key="item.id">
      <ProductCard v-bind:product="item" />
    </div>
    <div class="clr"></div>
  </div>
</template>
<style>

</style>