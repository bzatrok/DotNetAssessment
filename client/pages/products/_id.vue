<template>
    <div>
        <error :show="error" />
        <spinner :show="loading" />
        <transition name="fade">
            <div v-if="product !== null" class="container">
                <div class="productContainer">
                    <div class="productContainer__image">
                        <img 
                            :src="product.imageUrl"
                            class="image" />
                    </div>
                    <div class="productContainer__details">
                        <product-detail v-for="detail in presentationProduct" 
                            :key="detail.displayName" 
                            :name="detail.displayName"
                            :value="detail.value"
                            :show="detail.show"
                            :cross="detail.cross"
                            :showDollar="detail.showDollar" />
                        <div class="productContainer__footer">
                            <v-btn>Buy now!</v-btn>
                        </div>
                    </div>
                </div>
                <div class="alsoViewed">
                    <also-viewed-product 
                        v-for="recommended in product.alsoViewed" 
                        :key="recommended.id"
                        :id="recommended.id"
                        :name="recommended.name"
                        :price="recommended.price"
                        :imageUrl="recommended.thumbnailImage" />
                </div>
            </div>
        </transition>
    </div>
</template>

<script>
import Axios from 'axios'
import ProductDetail from '../../components/productDetail.vue'
import AlsoViewedProduct from '../../components/alsoViewedProduct.vue'
import Spinner from '../../components/spinner.vue'
import Error from '../../components/error.vue'


export default {
    components:{
        ProductDetail,
        AlsoViewedProduct,
        Spinner,
        Error,
    },
    data: () => ({
         product: null,
         loading: true,
         error: false
    }),
    computed:{
        onSale: function() {
            return  this.product.salePrice < this.product.regularPrice
            
        },
        presentationProduct: function() {
            return [
                this.productDetailFactory('Name', this.product.name, this.product.name),
                this.productDetailFactory('Regular price', this.product.regularPrice, this.product.regularPrice, this.onSale, true),
                this.productDetailFactory('Sale price', this.product.salePrice, this.onSale, false, true),
                this.productDetailFactory('Number of reviews', this.product.reviewCount, this.product.reviewCount),
                this.productDetailFactory('Review score', this.product.reviewAverage, this.product.reviewAverage),
                this.productDetailFactory('Description', this.product.description, this.product.description),
            ]
        }
    },
    async mounted(){
        this.loading = true;

        const productId = this.$route.params.id;

        try {
            const response = await Axios.get(`http://localhost:5000/api/products/${productId}`)
            this.product = response.data;
        } catch (error) {
            this.error = true
        } finally {
            this.loading = false;
        }

    },
    methods: {
        productDetailFactory: function(displayName, value, show, cross, showDollar){
            return {
                displayName,
                value,
                show,
                cross,
                showDollar
            }
        }
    }
}
</script>

<style scoped>
    .productContainer {
        display: flex;
        justify-content: space-between;
    }

    .productContainer__image {
        width: 48%;
        background: whitesmoke;
        display:flex;
        align-items:center;
        justify-content:center;
    }

    .productContainer__image .image {
        max-width: 90%;
        object-fit: contain;
    }

    .productContainer__details {
        width: 48%;
        background: whitesmoke;
    }

    .productContainer__footer {
        display: flex;
        justify-content: flex-end;
        padding: 15px;
    }

    .alsoViewed {
        margin-top: 30px;
        display: grid;
        grid-template-columns: 1fr 1fr 1fr;
        grid-gap: 10px;
    }

    .fade-enter-active, .fade-leave-active {
        transition: opacity 1s;
    }

    .fade-enter, .fade-leave-to {
        opacity: 0;
    }

</style>