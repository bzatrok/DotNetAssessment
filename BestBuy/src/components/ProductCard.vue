<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { Product } from "../models/Products";

@Component
export default class ProductCard extends Vue {
  @Prop() private product?: Product;
  constructor() {
    super();
  }
}
</script>
<template>
  <div class="card">
    <router-link v-bind:to="'/productdetails/' + product.sku">
      <img :src="product.image" />
      <div class="info">
        <h1>{{product.name}}</h1>
      </div>
      <div class="product-price">
          <span v-if="product.onSale" class="old-price">${{product.regularPrice}}</span>
          <span>${{product.salePrice}}</span>
          
        </div>
        <div class="clr"></div>
    </router-link>
  </div>
</template>