<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import ProductCard from "@/components/ProductCard.vue";
import { Product, ProductResponse } from "../models/Products";

@Component({
  components: { ProductCard }
})
export default class AddonProducts extends Vue {
  @Prop() private addOns?: Array<any>;
  productList: Array<Product>;

  product = {} as Product;
  constructor() {
    super();
    this.productList = new Array<Product>();
    
    if (this.addOns && this.addOns.length>0) {
      for (let i = 0; i < 3; i++) {
        this.addProduct(this.addOns[i].sku);
      }
      console.log('Addons',this.productList);
    }
  }
  addProduct(id: number) {
    fetch(
      `https://api.bestbuy.com/v1/products((sku=${id}))?apiKey=ExFNlAkCTKUdHusuItIv7oA4&format=json`
    )
      .then(response => {
        return response.json();
      })
      .then((myJson: ProductResponse) => {
        this.productList = [];
        if (myJson.total > 0 && myJson.products) {
          myJson.products.forEach(element => {
            this.productList.push(element);
          });
        }
      })
      .catch(re => {
        console.log("Catch", re);
        return null;
      });
  }
}
</script>
<template>
  <div class="container">
    <h1 v-if="productList.length>0" class="addon-header">Addon Products</h1>
    <div v-for="item in productList" v-bind:key="item.id">
      <ProductCard v-bind:product="item" />
    </div>
    <div class="clr"></div>
  </div>
</template>
