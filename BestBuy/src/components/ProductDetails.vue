<script lang="ts">
    import { Component, Vue, Prop } from "vue-property-decorator";
    import { ProductResponse, Product } from "../models/Products";
    import AddonProducts from "@/components/AddonProducts.vue";

    @Component({
        components: { AddonProducts }
    })
    export default class ProducDetails extends Vue {
        productList: Array<Product>;

        product = {} as Product;
        constructor() {
            super();
            this.productList = new Array<Product>();

            this.getProductDetails();
            //1494407
        }

        getProductDetails() {
            var id = this.$route.params.id;
            var search = `((sku=${id}))`;

            fetch(
                `https://localhost:44387/api/products?search=${search}&page=1`

            )
                .then(response => {
                    return response.json();
                })
                .then(res => {
                    return JSON.parse(res.Response);
                })
                .then((myJson: ProductResponse) => {
                    this.productList = [];
                    if (myJson && myJson.products) {
                        myJson.products.forEach(element => {
                            this.productList.push(element);
                        });
                    }
                })
                .catch(re => {
                    console.log("Catch", re);
                })
                .finally(() => { });
        }
    }
</script>
<template>
    <div class="container" v-if="productList[0]">
        <div class="product">
            <img :src="productList[0].image" />
            <div class="details">
                <div class="product-description">
                    <span>{{productList[0].class}}</span>
                </div>
                <h1>{{productList[0].name}}</h1>
                <p>{{productList[0].customerReviewAverage}} star average from {{productList[0].customerReviewCount}} ratings.</p>
                <p>Description:{{productList[0].longDescription}}</p>
                <div class="product-price">
                    <span class="old-price">{{productList[0].regularPrice}}</span>
                    <span>{{productList[0].salePrice}}</span>
                    <a href="#" class="cart-btn">Add to cart</a>
                </div>
            </div>
        </div>

        <div class="clr"></div>
        <AddonProducts v-bind:addOns="productList[0].relatedProducts" />
    </div>
</template>
<style>
</style>